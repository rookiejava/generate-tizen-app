using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    // TODO Use Scaffold instead of HStack
    internal class AppBarTest : Scaffold, INavigationTransition, ITestCase
    {
        private const float s_fontSize = 20f;

        public AppBarTest() : base()
        {
            BackgroundColor = Color.White;

            AppBar = new AppBar()
            {
                Leading = new BackButton(),
                Title = "Title",
                ActionButtons =
                {
                    new ActionButton(MaterialIcon.Search)
                    {
                        // TODO Enable code after implement toast
                        // ClickedCommand = (_, _) => new Toast("Search clicked!").Post()
                    },
                    new ActionButton(MaterialIcon.Add)
                    {
                        // TODO Enable code after implement toast
                        // ClickedCommand = (_, _) => new Toast("Add clicked!").Post()
                    }
                },
                Trailing = new MoreButton()
                {
                    ModalContent = new DropdownList()
                    {
                        Items =
                        {
                            new DropdownItem("Item1"),
                            new DropdownItem("Item2"),
                            new DropdownItem("Item3"),
                        },
                        DismissedCommand = (s, _) => new Toast((s as DropdownList).SelectedItem.Text).Post()
                    }
                },
            }
            .Self(out var appBar);

            Content = new VStack()
            {
                Spacing = 20f,
                Padding = new(16f),
                Children =
                {
                    // TODO Enable code after implement Scaffold
                    // new Button("Show/hide indicator area")
                    // {
                    //     FontSize = s_fontSize,
                    //     ClickedCommand = (_, _) => HasIndicatorArea = !HasIndicatorArea
                    // },
                    new Button("Show/hide back button")
                    {
                        FontSize = s_fontSize,
                        ClickedCommand = (_, _) => appBar.Leading = appBar.Leading == null ? new BackButton() : null
                    },
                    new Button("Single/double title")
                    {
                        FontSize = s_fontSize,
                        ClickedCommand = (_, _) =>
                        {
                            appBar.TitleContent = appBar.TitleContent is DoubleTitle ? new Title(appBar.Title) : new DoubleTitle(appBar.Title, "Subtitle");
                        }
                    },
                    new Button("Add/remove action button")
                    {
                        FontSize = s_fontSize,
                        ClickedCommand = (_, _) =>
                        {
                            if (appBar.ActionButtons.Count > 2)
                            {
                                appBar.ActionButtons.RemoveAt(appBar.ActionButtons.Count - 1);
                            }
                            else
                            {
                                appBar.ActionButtons.Add(new ActionButton(MaterialIcon.Search));
                            }
                        }
                    },
                    new Button("Change app bar color")
                    {
                        FontSize = s_fontSize,
                        ClickedCommand = (_, _) => appBar.BackgroundColor = appBar.BackgroundColor == Color.Yellow ? Color.Gray : Color.Yellow
                    },
                    new InputField()
                    {
                        Text = appBar.Title,
                        DesiredWidth = 200f,
                        BorderlineWidth = 1f,
                        BorderlineColor = Color.Black
                    }
                    .Self((field) => field.TextChanged += (_, _) =>
                    {
                        appBar.Title = field.Text;
                    })
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
    }
}
