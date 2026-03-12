using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class TabBarScrollTest : VStack, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 16f;
        private const float s_buttonFontSize = 20f;

        public TabBarScrollTest() : base()
        {
            BackgroundColor = MaterialColor.Background;
            Spacing = 12f;

            Add(new ScrollView()
            {
                BackgroundColor = MaterialColor.Surface,
                ScrollDirection = ScrollDirection.Horizontal,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                Content = new TabBar()
                {
                    BackgroundColor = Color.Transparent,
                    Items =
                    {
                        new Item()
                        {
                            Text = "Item0",
                            DesiredWidth = 110f,
                        }.Margin(8f),
                        new Item()
                        {
                            Text = "Item1",
                            DesiredWidth = 110f,
                        }.Margin(8f),
                        new Item()
                        {
                            Text = "Item2",
                            DesiredWidth = 110f,
                        }.Margin(8f),
                        new Item()
                        {
                            Text = "Item3",
                            DesiredWidth = 110f,
                        }.Margin(8f),
                    }
                }.Margin(12f)
                .Self(out var tabBar)
            });

            Add(new Label()
            {
                Text = "Ready",
                TextColor = MaterialColor.Primary,
                FontSize = s_fontSize,
            }
            .Self(out var label));

            tabBar.SelectionChangedCommand = (_, e) => label.Text = $"{(e.Previous as TabItem)?.Text} → {(e.Current as TabItem)?.Text}";

            Add(new VStack()
            {
                Spacing = 20f,
                Padding = new (20f),
                BackgroundColor = MaterialColor.Background,
                Children =
                {
                    new Label("1. Test Add and Remove TabBar items.")
                    {
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    },
                    new HStack()
                    {
                        Spacing = 4f,
                        Children =
                        {
                            new Button("Add")
                            {
                                FontSize = s_buttonFontSize,
                                ClickedCommand = (_, _) =>
                                {
                                    tabBar.Add(new Item()
                                    {
                                        Text = $"Item{tabBar.Count}",
                                        DesiredWidth = 110f,
                                    }.Margin(8f));
                                }
                            },
                            new Button("Remove")
                            {
                                FontSize = s_buttonFontSize,
                                ClickedCommand = (_, _) =>
                                {
                                    if (tabBar.Count > 0)
                                    {
                                        tabBar.RemoveAt(tabBar.Count - 1);
                                    }
                                }
                            }
                        }
                    }
                }
            });
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
        }

        private class Item : TabItem
        {
            public Item()
            {
                TextColor = s_fontColor.WithAlpha(0.4f);
            }

            protected override void OnSelectedChanged(KeyDeviceClass device)
            {
                base.OnSelectedChanged(device);
                TextColor = IsSelected ? s_fontColor : s_fontColor.WithAlpha(0.4f);
            }
        }
    }
}
