using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;
using Tizen.Multimedia;

namespace VideoPlayer;

public class MainView : ContentView
{
    private Player _player;
    private VideoOverlayView _videoView;

    public MainView()
    {
        WidthResizePolicy = ResizePolicy.FillToParent;
        HeightResizePolicy = ResizePolicy.FillToParent;

        Body = CreateContent();

        InitializePlayer();
    }

    private void InitializePlayer()
    {
        try
        {
            _player = new Player();
            _videoView.SetPlayer(_player);
            // 인터넷 상의 샘플 비디오 URL
            _player.SetSource(new MediaUriSource("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            _player.PrepareAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine("Player Init Error: " + e.Message);
        }
    }

    private View CreateContent()
    {
        _videoView = new VideoOverlayView
        {
            WidthResizePolicy = ResizePolicy.FillToParent,
            HeightResizePolicy = ResizePolicy.FillToParent,
            BackgroundColor = Color.Black
        };

        var btnPlay = new Button 
        { 
            Text = "Play", 
            WidthResizePolicy = ResizePolicy.FillToParent,
            HeightResizePolicy = ResizePolicy.FillToParent
        };
        btnPlay.Clicked += (s, e) => { 
            if (_player?.State == PlayerState.Ready || _player?.State == PlayerState.Paused) 
                _player.Start(); 
        };

        var btnPause = new Button 
        { 
            Text = "Pause", 
            WidthResizePolicy = ResizePolicy.FillToParent,
            HeightResizePolicy = ResizePolicy.FillToParent
        };
        btnPause.Clicked += (s, e) => { 
            if (_player?.State == PlayerState.Playing) 
                _player.Pause(); 
        };

        var btnStop = new Button 
        { 
            Text = "Stop", 
            WidthResizePolicy = ResizePolicy.FillToParent,
            HeightResizePolicy = ResizePolicy.FillToParent
        };
        btnStop.Clicked += (s, e) => { 
            if (_player?.State == PlayerState.Playing || _player?.State == PlayerState.Paused) 
            {
                _player.Stop();
                _player.PrepareAsync(); // Stop 후에는 다시 Prepare가 필요함
            }
        };

        var controlPanel = new HStack
        {
            ItemAlignment = LayoutAlignment.Fill,
            WidthResizePolicy = ResizePolicy.FillToParent,
            Height = 80, // 고정 높이
            Children = { btnPlay, btnPause, btnStop }
        };

        return new Scaffold
        {
            AppBar = new AppBar
            {
                Title = "Tizen.UI Video Player",
            },
            Content = new VStack
            {
                ItemAlignment = LayoutAlignment.Fill,
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                Children =
                {
                    _videoView,
                    controlPanel
                }
            }
        };
    }
}
