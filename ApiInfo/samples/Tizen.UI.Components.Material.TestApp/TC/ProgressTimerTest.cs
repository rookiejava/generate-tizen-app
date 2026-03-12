using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class ProgressTimerTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const int c_totalTime = 8000;
        private const int c_timerUpdateInterval = 16;
        private readonly ProgressTimer _progress;
        private readonly Timer _timer;
        private readonly Button _startButton;
        private readonly Button _pauseButton;
        private readonly Button _stopButton;
        private readonly Label _label;

        public ProgressTimerTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                ItemAlignment = LayoutAlignment.Center,
                Spacing = 20f,
                Padding = new(50f),
                Children =
                {
                    // NOTE TimerProgress provides GUI looks of material timer.
                    // The timer functionality should be implemented by app. This is just for demonstration.
                    new ProgressTimer(c_totalTime).Self(out _progress),
                    new HStack()
                    {
                        ItemAlignment = LayoutAlignment.Center,
                        Spacing = 10f,
                        Children =
                        {
                            new Button("Start")
                            {
                                ClickedCommand = (s, e) => DoStart()
                            }
                            .Self(out _startButton),
                            new Button("Pause")
                            {
                                IsEnabled = false,
                                ClickedCommand = (s, e) => DoPause()
                            }
                            .Self(out _pauseButton),
                            new Button("Stop")
                            {
                                IsEnabled = false,
                                ClickedCommand = (s, e) => DoStop()
                            }
                            .Self(out _stopButton),
                        }
                    },
                    new Label(FormatTime(c_totalTime))
                    {
                        HorizontalAlignment = TextAlignment.Center,
                        TextColor = s_fontColor
                    }
                    .Self(out _label)
                }
            };

            _timer = new Timer(c_timerUpdateInterval);
            _timer.TickHandler += () =>
            {
                _progress.RemainingTime = Math.Max(_progress.RemainingTime - c_timerUpdateInterval, 0);
                _label.Text = FormatTime(_progress.RemainingTime);
                bool finished = _progress.RemainingTime == 0;

                if (finished)
                {
                    DoStop();
                }
                return !finished;
            };
        }

        private void DoStart()
        {
            _timer.Start();
            _startButton.IsEnabled = false;
            _pauseButton.IsEnabled = true;
            _stopButton.IsEnabled = true;
            _progress.IsPaused = false;
        }

        private void DoPause()
        {
            _timer.Stop();
            _startButton.IsEnabled = true;
            _pauseButton.IsEnabled = false;
            _stopButton.IsEnabled = true;
            _progress.IsPaused = true;
        }

        private void DoStop()
        {
            _timer.Stop();
            _progress.RemainingTime = c_totalTime;
            _label.Text = FormatTime(c_totalTime);
            _startButton.IsEnabled = true;
            _pauseButton.IsEnabled = false;
            _stopButton.IsEnabled = false;
            _progress.IsPaused = false;
        }

        private string FormatTime(int milliseconds)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(milliseconds);
            return string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                time.Hours,
                time.Minutes,
                time.Seconds,
                time.Milliseconds);
        }

        public void WillAppear(bool byPopNavigation)
        {
        }

        public void WillDisappear(bool byPopNavigation)
        {
        }

        public void DidAppear(bool byPopNavigation)
        {
        }

        public void DidDisappear(bool byPopNavigation)
        {
            if (byPopNavigation)
            {
                Deactivate();
            }
        }

        public void Activate()
        {
        }
        public void Deactivate()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}
