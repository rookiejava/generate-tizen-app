using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class CustomProgressTimerTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const int c_totalTime = 8000;
        private const int c_timerUpdateInterval = 16;
        private readonly LottieImageTimeCounter _progress;
        private readonly Timer _timer;
        private readonly Button _startButton;
        private readonly Button _pauseButton;
        private readonly Button _stopButton;
        private readonly Label _label;

        public CustomProgressTimerTest() : base()
        {
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                ItemAlignment = LayoutAlignment.Center,
                Spacing = 20f,
                Padding = new (50f),
                Children =
                {
                    // NOTE You can use material timer progress image if want
                    // * ResourceManager.GetCommonPath("i_progress_circle.json")
                    new LottieImageTimeCounter(c_totalTime, "progress_circle_300f.json")
                    {
                        DesiredWidth = 200f,
                        DesiredHeight = 200f,
                        BackgroundColor = MaterialColor.Primary,
                        UseReverseFrameIndex = true
                    }
                    .Self(out _progress),
                    new HStack()
                    {
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
                    }.ItemAlignment(LayoutAlignment.Center),
                    new Label(FormatTime(c_totalTime))
                    {
                        TextColor = s_fontColor,
                    }
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
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

            _progress.WarningChanged += (_, _) =>
            {
                if (_progress.IsWarning)
                {
                    _label.TextColor = Color.Red;
                }
                else
                {
                    _label.TextColor = s_fontColor;
                }
            };
        }

        private void DoStart()
        {
            _timer.Start();
            _startButton.IsEnabled = false;
            _pauseButton.IsEnabled = true;
            _stopButton.IsEnabled = true;
        }

        private void DoPause()
        {
            _timer.Stop();
            _startButton.IsEnabled = true;
            _pauseButton.IsEnabled = false;
            _stopButton.IsEnabled = true;
        }

        private void DoStop()
        {
            _timer.Stop();
            _progress.RemainingTime = c_totalTime;
            _label.Text = FormatTime(c_totalTime);
            _startButton.IsEnabled = true;
            _pauseButton.IsEnabled = false;
            _stopButton.IsEnabled = false;
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
