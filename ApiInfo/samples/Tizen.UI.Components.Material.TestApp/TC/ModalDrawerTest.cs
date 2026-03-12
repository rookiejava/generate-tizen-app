using System.Collections.Generic;
using System.Globalization;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class ModalDrawerTest : ScaffoldBase, INavigationTransition, ITestCase
    {
        private readonly ModalDrawer _drawer;
        private bool isRTL;

        public ModalDrawerTest() : base()
        {
            Body = new ModalDrawer()
            {
                Content = CreatePage("Page 0"),
                Items =
                {
                    new DrawerItem("Page 0"),
                    new DrawerItem("Page 1"),
                    new DrawerItem("Page 2"),
                    new DrawerItem("Page 3"),
                },
                SelectionChangedCommand = (o, _) =>
                {
                    _drawer.Content = CreatePage($"Page {_drawer.SelectedIndex}");
                }
            }
            .Self(out _drawer);

            FloatingActionButton = new IconButton("ic_plus.svg", IconButtonVariables.FAB)
            {
                ClickedCommand = (_, _) =>
                {
                    isRTL = !isRTL;
                    if (isRTL)
                    {
                        var culture = new CultureInfo("ar-SA");
                        Tizen.Applications.LocaleManager.SetApplicationLocale(culture);
                    }
                    else
                    {
                        var culture = new CultureInfo("ko-KR");
                        Tizen.Applications.LocaleManager.SetApplicationLocale(culture);
                    }
                }
            };
        }

        private View CreatePage(string text)
        {
            return new Scaffold()
            {
                BackgroundColor = Color.Transparent,
                AppBar = new AppBar()
                {
                    Leading = new ActionButton(MaterialIcon.Menu)
                    {
                        ClickedCommand = (_, _) => _drawer.Open()
                    },
                    Title = text
                }
                .Self(appBar => IndicatorAreaColorProvider = appBar),
                Content = new VStack()
                {
                    Padding = new (20f),
                    Spacing = 10f,
                    Children =
                    {
                        new ListItem($"{text} item0"),
                        new ListItem($"{text} item1"),
                        new ListItem($"{text} item2"),
                        new ListItem($"{text} item3"),
                        new ListItem($"{text} item4"),
                    }
                }
            };
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

        private class ListItem : ClickableBox
        {
            /// <inheritdoc/>
            new AbsoluteLayout Body => base.Body as AbsoluteLayout;

            /// <inheritdoc/>
            protected override IList<View> InnerList => Body.Children;

            public ListItem(string text)
            {
                base.Body = new AbsoluteLayout();
                Padding = new(12f);
                BackgroundColor = MaterialColor.SurfaceVariant;
                CornerRadius = new(0.25f);
                Body.Add(new Label(text)
                {
                    TextColor = MaterialColor.OnSurface
                });
                ClickedCommand = (_, _) => new Toast(text).Post();
            }

            /// <inheritdoc/>
            public override Thickness Padding
            {
                get => Body.Padding;
                set => Body.Padding = value;
            }
        }
    }
}
