using System.Collections.Generic;
using System.Globalization;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace HelloTizenUI
{
    public class MainView : Scaffold, INavigationTransition
    {
        public MainView() : base()
        {
            AppBar = new AppBar
            {
                BackgroundColor = MaterialColor.PrimaryContainer,
                //Leading = new BackButton(),
                Title = "Title",
                ActionButtons =
                {
                    new ActionButton(MaterialIcon.Search)
                    {
                        ClickedCommand = (_, _) => new Toast("Search clicked!").Post()
                    },
                    new ActionButton(MaterialIcon.Add)
                    {
                        ClickedCommand = (_, _) => new Toast("Add clicked!").Post()
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
                    new Label("Hello Tizen.UI!")
                    {
                        FontSize = 40f,
                    }
                    .Expand()
                    .Center(),
                }
            };

            FloatingActionButton = new IconButton("ic_plus.svg", IconButtonVariables.FAB)
            {
                ClickedCommand = (_, _) => new Toast($"FAB clicked").Post()
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
