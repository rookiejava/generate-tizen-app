using TizenUIGallery.Util;
using System;
using System.Text;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class VisibilityChangeTest : Grid, ITestCase
    {
        public VisibilityChangeTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Visibility Changed event test",
                FontSize = 30,
            });

            Add(new VStack
            {
                new Grid
                {
                    ColumnDefinitions =
                    {
                        200,
                        200,
                        200,
                        200,
                        200,
                        GridLength.Star,
                    },
                    Children =
                    {
                        new Button("Lv1-Visible")
                        {
                            Name = "Lv1-Btn",
                            Clicked = () =>
                            {
                                var btn = this["Lv1-Btn"] as Button;
                                var target = this["Lv1"];
                                AppendLog("-------------------------------------------------------------------------------------------------");
                                target.IsVisible = !target.IsVisible;
                                btn.Text = $"Lv1-{(target.IsVisible ? "Visible" : "Invisible")}";
                            },
                        }.Column(0).Margin(10),
                        new Button("Lv2-Visible")
                        {
                            Name = "Lv2-Btn",
                            Clicked = () =>
                            {
                                var btn = this["Lv2-Btn"] as Button;
                                var target = this["Lv2"];
                                AppendLog("-------------------------------------------------------------------------------------------------");
                                target.IsVisible = !target.IsVisible;
                                btn.Text = $"Lv2-{(target.IsVisible ? "Visible" : "Invisible")}";

                            },
                        }.Column(1).Margin(10),
                        new Button("Lv3-Visible")
                        {
                            Name = "Lv3-Btn",
                            Clicked = () =>
                            {
                                var btn = this["Lv3-Btn"] as Button;
                                var target = this["Lv3"];
                                AppendLog("-------------------------------------------------------------------------------------------------");
                                target.IsVisible = !target.IsVisible;
                                btn.Text = $"Lv3-{(target.IsVisible ? "Visible" : "Invisible")}";

                            },
                        }.Column(2).Margin(10),
                        new Button("Lv4-Visible")
                        {
                            Name = "Lv4-Btn",
                            Clicked = () =>
                            {
                                var btn = this["Lv4-Btn"] as Button;
                                var target = this["Lv4"];
                                AppendLog("-------------------------------------------------------------------------------------------------");
                                target.IsVisible = !target.IsVisible;
                                btn.Text = $"Lv4-{(target.IsVisible ? "Visible" : "Invisible")}";

                            },
                        }.Column(3).Margin(10),
                        new Button("Lv5-Visible")
                        {
                            Name = "Lv5-Btn",
                            Clicked = () =>
                            {
                                var btn = this["Lv5-Btn"] as Button;
                                var target = this["Lv5"];
                                AppendLog("-------------------------------------------------------------------------------------------------");
                                target.IsVisible = !target.IsVisible;
                                btn.Text = $"Lv5-{(target.IsVisible ? "Visible" : "Invisible")}";

                            },
                        }.Column(4).Margin(10),

                    }
                },
                new AbsoluteLayout
                {
                    Name = "Lv1",
                    DesiredHeight = 200,
                    BackgroundColor = Color.AliceBlue,
                    BorderlineWidth = 1,
                    BorderlineColor = Color.Black,
                    Children =
                    {
                        new AbsoluteLayout
                        {
                            Name = "Lv2",
                            BackgroundColor = Color.CadetBlue,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                            Children =
                            {
                                new AbsoluteLayout
                                {
                                    Name = "Lv3",
                                    BackgroundColor = Color.Blue,
                                    BorderlineWidth = 1,
                                    BorderlineColor = Color.Black,
                                    Children =
                                    {
                                        new AbsoluteLayout
                                        {
                                            Name = "Lv4",
                                            BackgroundColor = Color.BlueViolet,
                                            BorderlineWidth = 1,
                                            BorderlineColor = Color.Black,
                                            Children =
                                            {
                                                new AbsoluteLayout
                                                {
                                                    Name = "Lv5",
                                                    BackgroundColor = Color.Brown,
                                                    BorderlineWidth = 1,
                                                    BorderlineColor = Color.Black,
                                                    Children =
                                                    {

                                                    },
                                                }.Margin(200, 10, 10, 10).LayoutBounds(0, 0, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All),
                                            },
                                        }.Margin(200, 10, 10, 10).LayoutBounds(0, 0, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All),
                                    },
                                }.Margin(200, 10, 10, 10).LayoutBounds(0, 0, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All),
                            },
                        }.Margin(200, 10, 10, 10).LayoutBounds(0, 0, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All),
                    },
                },
                new ScrollLayout
                {
                    DesiredHeight = 500,
                    Padding = 20,
                    BackgroundColor = Color.AntiqueWhite,
                    Content = new VStack
                    {
                        Name = "Log",
                    },
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                }
            }.Row(1));
            SetupEvents();
        }

        void SetupEvents()
        {
            this["Lv1"].VisibilityChanged += OnVisibleChanged;
            this["Lv2"].VisibilityChanged += OnVisibleChanged;
            this["Lv3"].VisibilityChanged += OnVisibleChanged;
            this["Lv4"].VisibilityChanged += OnVisibleChanged;
            this["Lv5"].VisibilityChanged += OnVisibleChanged;
        }

        void OnVisibleChanged(object sender, VisibilityChangedEventArgs e)
        {
            var view = sender as View;
            var sb = new StringBuilder();
            sb.Append($"[{view.Name}] ");
            sb.Append($"Visibility : {e.Visibility}, ");
            sb.Append($"Changed By Parent: {e.ChangedByParent}, ");
#if API12_OR_GREATER
            sb.Append($"IsAggregatedChange: {e.IsAggregatedChange}");
#endif
            AppendLog(sb.ToString());
        }

        void AppendLog(string log)
        {
            if (IsDisposed)
                return;
            var vstack = (this["Log"] as VStack);
            if (vstack == null)
                return;
            vstack.Children.Insert(0, new TextView
            {
                FontSize = 20,
                Text = log
            });

            if (vstack.Children.Count > 80)
            {
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
            }
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
