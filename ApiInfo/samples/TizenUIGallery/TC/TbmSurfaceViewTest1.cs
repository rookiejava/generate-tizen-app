using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Internal;
using Tizen.Multimedia;
using System.Runtime.InteropServices;
using TizenUIGallery.Util;

namespace TizenUIGallery.TC
{
    public class TbmSurfaceViewTest1 : Grid, ITestCase
    {
        Player player;
        TbmSurfaceView _tbmSurfaceView;
        void InitializePlayer()
        {
            player = new Player()
            {
                IsLooping = false,
                Muted = false
            };
            player.EnableExportingVideoFrame();
        }

        MediaPacket _packet;

        EventHandler<VideoFrameDecodedEventArgs> handler;


        public TbmSurfaceViewTest1()
        {
            InitializePlayer();

            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "TbmSurfaceView Test1",
                FontSize = 30,
            });

            _tbmSurfaceView = new TbmSurfaceView
            {
                DesiredHeight = 300,
                DesiredWidth = 600,
            };

            Add(new VStack
            {
                new HStack
                {
                    new Button("Start (Update on MM thread)")
                    {
                        Clicked = async () =>
                        {
                            Console.WriteLine($"Player State : {player.State}");
                            if (player.State != PlayerState.Idle)
                            {
                                if (player.State == PlayerState.Playing || player.State == PlayerState.Paused)
                                    player.Stop();
                                player.Unprepare();
                            }
                            Console.WriteLine($"Player State2 : {player.State}");

                            _tbmSurfaceView.SetSource(new NativeImageSource(0, 0));

                            player.SetSource(new MediaUriSource(UIApplication.Current.DirectoryInfo.Resource + "BigBuckBunny_short.mp4"));
                            if (handler != null)
                            {
                                player.VideoFrameDecoded -= handler;
                            }
                            handler = OnFrameDecodedUpdateOnMMThread;
                            player.VideoFrameDecoded += handler;
                            await player.PrepareAsync();
                            player.Start();
                        }
                    },

                    new Button("Start (Update on main thread)")
                    {
                        Clicked = async () =>
                        {
                            Console.WriteLine($"Player State : {player.State}");
                            if (player.State != PlayerState.Idle)
                            {
                                if (player.State == PlayerState.Playing || player.State == PlayerState.Paused)
                                    player.Stop();
                                player.Unprepare();
                            }
                            Console.WriteLine($"Player State2 : {player.State}");

                            player.SetSource(new MediaUriSource(UIApplication.Current.DirectoryInfo.Resource + "BigBuckBunny_short.mp4"));

                            if (handler != null)
                            {
                                player.VideoFrameDecoded -= handler;
                            }
                            handler = OnFrameDecodedUpdateOnMainThread;
                            player.VideoFrameDecoded += handler;
                            await player.PrepareAsync();
                            player.Start();
                        }
                    },

                    new Button("Start (Update with Texture)")
                    {
                        Clicked = async () =>
                        {
                            Console.WriteLine($"Player State : {player.State}");
                            if (player.State != PlayerState.Idle)
                            {
                                if (player.State == PlayerState.Playing || player.State == PlayerState.Paused)
                                    player.Stop();
                                player.Unprepare();
                            }
                            Console.WriteLine($"Player State2 : {player.State}");

                            player.SetSource(new MediaUriSource(UIApplication.Current.DirectoryInfo.Resource + "BigBuckBunny_short.mp4"));
                            if (handler != null)
                            {
                                player.VideoFrameDecoded -= handler;
                            }
                            handler = OnFrameDecodedUpdateWithTexture;
                            player.VideoFrameDecoded += handler;
                            await player.PrepareAsync();
                            player.Start();
                        }
                    },
                },
                _tbmSurfaceView,
            }.Row(1));
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            player.Stop();
            player.Dispose();
            Dispose();
        }

        void OnFrameDecodedUpdateWithTexture(object sender, VideoFrameDecodedEventArgs e)
        {
            UIApplication.Current.PostToUI(() =>
            {
                _packet?.Dispose();
                _packet = e.Packet;
                var handle = GetNativeHandle(e.Packet);
                int ret = media_packet_get_tbm_surface(handle, out var surface);
                var texture = new Texture(surface);
                _tbmSurfaceView.SetSource(texture);
                Window.Default.KeepRendering(0);
            });
        }

        void OnFrameDecodedUpdateOnMainThread(object sender, VideoFrameDecodedEventArgs e)
        {
            UIApplication.Current.PostToUI(() =>
            {
                _packet?.Dispose();
                _packet = e.Packet;
                var handle = GetNativeHandle(e.Packet);
                int ret = media_packet_get_tbm_surface(handle, out var surface);
                _tbmSurfaceView.SetSource(surface);
                Window.Default.KeepRendering(0);
            });
        }

        void OnFrameDecodedUpdateOnMMThread(object sender, VideoFrameDecodedEventArgs e)
        {
            _packet?.Dispose();
            _packet = e.Packet;
            var handle = GetNativeHandle(e.Packet);
            int ret = media_packet_get_tbm_surface(handle, out var surface);
            _tbmSurfaceView.SetSource(surface);

            UIApplication.Current.PostToUI(() =>
            {
                Window.Default.KeepRendering(0);
            });
        }

        static IntPtr GetNativeHandle(MediaPacket handle)
        {
            var typeinfo = typeof(MediaPacket);
            var fieldInfo = typeinfo.GetField("_handle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (IntPtr)fieldInfo.GetValue(handle);
        }

        //int media_packet_get_tbm_surface(media_packet_h packet, tbm_surface_h* surface);
        [DllImport("libcapi-media-tool.so.0", EntryPoint = "media_packet_get_tbm_surface")]
        static extern int media_packet_get_tbm_surface(IntPtr packet, out IntPtr surface);
    }
}
