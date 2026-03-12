using System;
using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.Multimedia;

namespace TizenUIGallery.TC
{
    public class VideoOverlayViewTest1 : Grid, ITestCase
    {
        Player player;
        VideoOverlayView[] overlayView;
        int currentVideoView = 0;
        const int MAX_OVERLAY_VIEW = 2;

        void InitializePlayer()
        {
            player = new Player()
            {
                IsLooping = true,
                Muted = false
            };
            player.BufferingProgressChanged += (s, e) =>
            {
                Console.WriteLine($"BufferingProgressChanged: {e}");
            };
            var sourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "BigBuckBunny_short.mp4";
            player.SetSource(new MediaUriSource(sourcePath));
        }

        public VideoOverlayViewTest1()
        {
            InitializePlayer();

            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            overlayView = new VideoOverlayView[MAX_OVERLAY_VIEW];
            for (int i = 0; i < MAX_OVERLAY_VIEW; i++)
            {
                overlayView[i] = new VideoOverlayView();
                overlayView[i].DesiredSize(new Tizen.UI.Size(400, 300));
                overlayView[i].MoveTo(300 + 500 * i, 300);
                overlayView[i].Focusable = true;
                overlayView[i].DesiredWidth = 400;
                overlayView[i].DesiredHeight = 300;
                if (i == 0)
                {
                    overlayView[i].CornerRadius = new CornerRadius(20, 20, 20, 20);
                }
                Add(overlayView[i]);
            }

            currentVideoView = 0;
            overlayView[currentVideoView].SetPlayer(player);

            {
                var gesture = new PanGestureDetector();
                gesture.Attach(overlayView[0]);

                gesture.Detected += (s, e) =>
                {
                    if (e.Gesture.State == GestureState.Finished)
                    {
                        return;
                    }
                    overlayView[0].X += e.Gesture.Displacement.X;
                    overlayView[0].Y += e.Gesture.Displacement.Y;
                };
            }

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "VideoImageView Test1",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Content = new VStack {
                    Spacing = 10,
                    Children = {
                        new FlexBox
                        {
                            Wrap = FlexWrap.Wrap,
                            Children =
                            {
                                new Button("Play/Pause")
                                {
                                    Clicked = () =>
                                    {
                                        if (player.State == PlayerState.Idle)
                                        {
                                            player.PrepareAsync().Wait();
                                            player.Start();
                                        }
                                        else if (player.State == PlayerState.Ready || player.State == PlayerState.Paused)
                                        {
                                            player.Start();
                                        }
                                        else if (player.State == PlayerState.Playing)
                                        {
                                            player.Pause();
                                        }

                                    }
                                }.Margin(3),
                                new Button("Stop")
                                {
                                    Clicked = () =>
                                    {
                                        if (player.State == PlayerState.Playing)
                                        {
                                            player.Stop();
                                        }
                                    }
                                }.Margin(3),
                                new Button("Change View")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].SetPlayer(null);
                                        currentVideoView = currentVideoView ^ 1;
                                        overlayView[currentVideoView].SetPlayer(player);
                                    }
                                }.Margin(3),
                                new Button("Mute")
                                {
                                    Clicked = () =>
                                    {
                                        player.Muted = !player.Muted;
                                    }
                                }.Margin(3),
                                new Button("Loop")
                                {
                                    Clicked = () =>
                                    {
                                        player.IsLooping= !player.IsLooping;
                                    }
                                }.Margin(3),
                                new Button("Parent Scale +0.1")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].Parent.ScaleX = overlayView[currentVideoView].Parent.ScaleX+0.1f;
                                        overlayView[currentVideoView].Parent.ScaleY = overlayView[currentVideoView].Parent.ScaleY+0.1f;
                                    }
                                }.Margin(3),
                                new Button("Parent Scale -0.1")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].Parent.ScaleX = overlayView[currentVideoView].Parent.ScaleX-0.1f;
                                        overlayView[currentVideoView].Parent.ScaleY = overlayView[currentVideoView].Parent.ScaleY-0.1f;
                                    }
                                }.Margin(3),
                                new Button("Scale +0.1")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].ScaleX = overlayView[currentVideoView].ScaleX + 0.1f;
                                        overlayView[currentVideoView].ScaleY = overlayView[currentVideoView].ScaleY + 0.1f;
                                    }
                                }.Margin(3),
                                new Button("Scale -0.1")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].ScaleX = overlayView[currentVideoView].ScaleX - 0.1f;
                                        overlayView[currentVideoView].ScaleY = overlayView[currentVideoView].ScaleY - 0.1f;
                                    }
                                }.Margin(3)
                            }
                        },
                        new FlexBox
                        {
                            Wrap = FlexWrap.Wrap,
                            Children =
                            {
                                new Button("Size + 10")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].Width += 10;
                                        overlayView[currentVideoView].Height += 10;
                                    }
                                }.Margin(3),
                                new Button("Size - 10")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].Width -= 10;
                                        overlayView[currentVideoView].Height -= 10;
                                    }
                                }.Margin(3),
                                new Button("Position + 10")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].X += 10;
                                        overlayView[currentVideoView].Y += 10;
                                    }
                                }.Margin(3),
                                new Button("Position - 10")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].X -= 10;
                                        overlayView[currentVideoView].Y -= 10;
                                    }
                                }.Margin(3),
                                new Button("Player null")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].SetPlayer(null);
                                    }
                                }.Margin(3),
                                new Button("Visibility")
                                {
                                    Clicked = () =>
                                    {
                                        overlayView[currentVideoView].IsVisible = !overlayView[currentVideoView].IsVisible;
                                    }
                                }.Margin(3)
                            }
                        }
                    }
                }
            }.Row(1));

        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }

    }
}
