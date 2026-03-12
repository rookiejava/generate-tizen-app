using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class TabBarTest : VStack, INavigationTransition, ITestCase
    {
        private static readonly Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 20f;
        private const float s_buttonFontSize = 20f;
        private readonly TabBar _tabBar;

        public TabBarTest() : base()
        {
            BackgroundColor = MaterialColor.Background;
            Padding = new (12f, 0);
            Spacing = 5f;

            Add(new VStack()
            {
                Spacing = 20f,
                Padding = new (0f, 20f),
                BackgroundColor = MaterialColor.Background,
                Children =
                {
                    new Label("Ready")
                    {
                        FontSize = s_fontSize,
                        TextColor = MaterialColor.Primary
                    }
                    .Self(out var label),
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
                                    _tabBar.Add(new Item()
                                    {
                                        Text = $"Item{_tabBar.Count}"
                                    });
                                }
                            },
                            new Button("Remove")
                            {
                                FontSize = s_buttonFontSize,
                                ClickedCommand = (_, _) =>
                                {
                                    if (_tabBar.Count > 0)
                                    {
                                        _tabBar.RemoveAt(_tabBar.Count - 1);
                                    }
                                }
                            }
                        }
                    },

                    new Label("2. Test unselecting the selected Item.")
                    {
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    },

                    new Button("Unselect current item")
                    {
                        FontSize = s_buttonFontSize,
                        ClickedCommand = (_, _) =>
                        {
                            if (_tabBar.SelectedItem != null)
                            {
                                _tabBar.SelectedItem.IsSelected = false;
                            }
                        }
                    },
                }
            }
            .Self(out var contentView));

            Add(new TabBar()
            {
                Items =
                {
                    new Item()
                    {
                        Text = "Item0",
                    },
                },
                SelectionChangedCommand = (_, e) => label.Text = $"{(e.Previous as TabItem)?.Text} → {(e.Current as TabItem)?.Text}"
            }
            .Self(out _tabBar));
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
                IconResourceUrl = MaterialIcon.Photo;
            }

            protected override void OnSelectedChanged(KeyDeviceClass device)
            {
                base.OnSelectedChanged(device);
                IconResourceUrl = IsSelected ? MaterialIcon.PhotoFilled : MaterialIcon.Photo;
            }
        }
    }
}
