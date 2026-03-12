using System;
using System.Linq;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class LayoutAnimationTest : ContentView, INavigationTransition, ITestCase
    {
        const float IMEHeight = 500;
        public LayoutAnimationTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Layout hstack1 = null;
            Layout vstack1 = null;
            Body = new ScrollView
            {
                Content = new Grid()
                {
                    RowDefinitions =
                    {
                        GridLength.Auto,
                        GridLength.Auto,
                        GridLength.Star,
                    },
                    Children =
                    {
                        new HStack
                        {
                            new Button("Add")
                            {
                                ClickedCommand = (_, _) =>
                                {
                                    var selected = hstack1.Where(child => (child as Selectable).IsSelected).FirstOrDefault();
                                    if (selected != null)
                                    {
                                        hstack1.Insert(hstack1.IndexOf(selected), new SelectableBox());
                                    }
                                    else
                                    {
                                        hstack1.Add(new SelectableBox());
                                    }

                                    selected = vstack1.Where(child => (child as Selectable).IsSelected).FirstOrDefault();

                                    if (selected != null)
                                    {
                                        vstack1.Insert(vstack1.IndexOf(selected), new SelectableBox());
                                    }
                                    else
                                    {
                                        vstack1.Add(new SelectableBox());
                                    }
                                },
                            },
                            new Button("Remove")
                            {
                                ClickedCommand = (_, _) =>
                                {
                                    int removed = 0;
                                    foreach (var child in hstack1.Children.ToList())
                                    {
                                        if ((child as Selectable).IsSelected)
                                        {
                                            removed++;
                                            hstack1.Remove(child);
                                        }
                                    }
                                    if (removed == 0 && hstack1.Count > 0)
                                    {
                                        hstack1.Remove(hstack1[^1]);
                                    }
                                    removed = 0;
                                    foreach (var child in vstack1.Children.ToList())
                                    {
                                        if ((child as Selectable).IsSelected)
                                        {
                                            removed++;
                                            vstack1.Remove(child);
                                        }
                                    }
                                    if (removed == 0 && vstack1.Count > 0)
                                    {
                                        vstack1.Remove(vstack1[^1]);
                                    }
                                },
                            },
                        }.Spacing(10).Row(0),
                        new HStack
                        {
                            Spacing = 10,
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            DesiredHeight = 100,
                        }.Row(1).Self(out hstack1).ApplyAnimation(300, alphaFunction: new AlphaFunction(BuiltinAlphaFunctions.EaseOut)).HorizontalLayoutAlignment(LayoutAlignment.Center),
                        new VStack
                        {
                            Spacing = 10,
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                        }.Row(2).Self(out vstack1).ApplyAnimation(300).Center(),
                    }
                }.ApplyAnimation(300, alphaFunction: new AlphaFunction(BuiltinAlphaFunctions.EaseOut))
            };
        }

        class SelectableBox : Selectable
        {
            public SelectableBox()
            {
                BackgroundColor = RandomColor();
                IsSelectable = true;
                Body = new View
                {
                    DesiredHeight = 100,
                    DesiredWidth = 100,
                };
            }

            protected override void OnSelectedChanged(KeyDeviceClass device)
            {
                base.OnSelectedChanged(device);
                if (IsSelected)
                {
                    BorderlineColor = Color.Red;
                    BorderlineWidth = 1;
                }
                else
                {
                    BorderlineColor = Color.Transparent;
                }
            }
        }


        static Color RandomColor()
        {
            return new Color((Random.Shared.Next(100, 255) / 255f), (Random.Shared.Next(100, 255) / 255f), (Random.Shared.Next(100, 255) / 255f));
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
            Dispose();
        }
    }
}
