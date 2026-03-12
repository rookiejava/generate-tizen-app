using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class StaticDrawerTest : Scaffold, INavigationTransition, ITestCase
    {
        private readonly StaticDrawer _drawer;

        public StaticDrawerTest() : base()
        {
            AppBar = new AppBar()
            {
                Leading = new BackButton(),
                Title = "Static Drawer Test",
            };

            Content = new StaticDrawer()
            {
                Content = CreatePage("Page 0"),
                Items =
                {
                    new DrawerItem("Page 0"),
                    new DrawerItem("Page 1"),
                    new DrawerItem("Page 2"),
                    new DrawerItem("Page 3"),
                },
                SelectionChangedCommand = (o, _) => _drawer.SwapContent(CreatePage($"Page {_drawer.SelectedIndex}"))
            }
            .Self(out _drawer);
        }

        private View CreatePage(string text)
        {
            return new VStack()
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
                BackgroundColor = MaterialColor.OnSurfaceContainerLowest;
                CornerRadius = new(0.25f);
                Body.Add(new Label(text)
                {
                    TextColor = MaterialColor.OnSurfaceVariant
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
