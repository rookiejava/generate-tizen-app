using LayoutTest.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Components.Animations;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class TranslateTest : Grid, ITestCase
    {
        public TranslateTest()
        {
            BackgroundColor = Color.White;
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Translate X/Y Test",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                ScrollDirection = ScrollDirection.Horizontal,
                Content = new HStack
                {
                    Padding = 10,
                    Spacing = 10,
                    Children =
                    {
                        new AbsoluteLayout
                        {
                            new TextView
                            {
                                IsMultiline = true,
                                Text = "Absolute > View [0, 0, -1, -1], translate(100, 50)",
                                FontSize = 15,
                            },
                            new View
                            {
                                Name = "Target1",
                                BackgroundColor = RandomColor(),
                                DesiredHeight = 100,
                                DesiredWidth = 100,
                            }.LayoutBounds(0, 0, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).TranslateX(100).TranslateY(50),
                            new Button("UIAnimation")
                            {
                                Clicked = () =>
                                {
                                    var animation = new UIAnimation(p =>
                                    {
                                        this["Target1"].TranslateX(100 + (200 - p * 200));
                                        this["Target1"].TranslateY(50 + (-200  + p * 200));
                                    });
                                    animation.Commit(this, "Move", easing: Easing.EaseIn);
                                }
                            }.LayoutBounds(0.5f, 1, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),

                        }.DesiredWidth(300).DesiredHeight(500).Margin(10).BackgroundColor(RandomColor()),

                        new VStack
                        {
                            new TextView
                            {
                                Text = "VStack > View (Expand(), TranslateX(-30))",
                                FontSize = 15,
                            },
                            new View
                            {
                                Name = "Target2",
                                BackgroundColor = RandomColor().WithAlpha(0.5f)
                            }.Expand().TranslateX(-30).Margin(20),
                            new Button("Animation")
                            {
                                Clicked = () =>
                                {
                                    var animation = new UIAnimation { 
                                        {0, 0.5f, new UIAnimation(p =>
                                        {
                                            this["Target2"].TranslateX(-30 + 30 * p);
                                        })},
                                        {0.5f, 1, new UIAnimation(p =>
                                        {
                                            this["Target2"].TranslateX(0 - 30 * p);
                                        })}
                                    };
                                    animation.Commit(this, "Move", length:300);
                                }
                            }.Center(),
                        }.DesiredWidth(300).DesiredHeight(500).Margin(10).BackgroundColor(RandomColor()),

                        new Grid
                        {
                            RowDefinitions = { GridLength.Auto , GridLength.Star, GridLength.Auto },
                            Children =
                            {
                                new TextView
                                {
                                    Text = "Grid > View (GridLength.Star)",
                                    FontSize = 15,
                                },
                                new View
                                {
                                    Name = "Target3",
                                    BackgroundColor = RandomColor().WithAlpha(0.5f)
                                }.Margin(20).Row(1),
                                new Button("Animation")
                                {
                                    Clicked = () =>
                                    {
                                        var animation = new UIAnimation(p =>
                                        {
                                            this["Target3"].TranslateY(-600 * p);
                                        }, easing: Easing.EaseIn);

                                        animation.Commit(this, "Move", length:500, finished: async (p,_) => {
                                            await Task.Delay(1000);
                                            this["Target3"].Opacity = 0;
                                            this["Target3"].TranslateY(0);
                                            var ani = new UIAnimation(p => this["Target3"].Opacity = p);
                                            ani.Commit(this, "opacity");
                                        });
                                    }
                                }.Center().Row(2),
                            }
                        }.DesiredWidth(300).DesiredHeight(500).Margin(10).BackgroundColor(RandomColor()),

                        new VStack
                        {
                            new TextView
                            {
                                Text = "HStack>(Box , View.Exapnd() , Box) - Animation with layout",
                                FontSize = 15,
                            },
                            new HStack
                            {
                                new View
                                {
                                    BackgroundColor = RandomColor(),
                                    DesiredWidth = 10,
                                },

                                new View
                                {
                                    Name = "Target4",
                                    BackgroundColor = RandomColor(),
                                }.Expand(),
                                
                                new View
                                {
                                    BackgroundColor = RandomColor(),
                                    DesiredWidth = 10,
                                },
                            }.DesiredWidth(300).DesiredHeight(500).Margin(10).BackgroundColor(RandomColor()).Name("HStack4"),
                            new Button("Animation")
                            {
                                Clicked = () =>
                                {
                                    var animation = new UIAnimation(p =>
                                    {
                                        this["Target4"].Translate(0, -300 * p);
                                        this["HStack4"].DesiredHeight(500 - 300 * p);
                                        this["HStack4"].DesiredWidth(300 + 300 * p);
                                        this["HStack4"].TranslateY(300 * p);
                                    }, easing: Easing.EaseIn);

                                    animation.Commit(this, "Move", length:500, finished: async (p,_) => {
                                        await Task.Delay(1000);
                                        this["Target4"].Translate(0, 0);
                                        this["HStack4"].DesiredHeight(500);
                                        this["HStack4"].DesiredWidth(300);
                                        this["HStack4"].TranslateY(0);
                                    });
                                }
                            }.Center(),
                        },

                    }
                }
            }.Row(1));
        }

        static Color RandomColor()
        {
            return new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f);
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