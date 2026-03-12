using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class SpinnerTest : Grid, INavigationTransition, ITestCase
    {
        public SpinnerTest() : base()
        {
            Padding = new (20f);
            BackgroundColor = MaterialColor.Background;

            Add(new SpinnerButton()
            {
                ModalContent = new DropdownList()
                {
                    Items =
                    {
                        new DropdownCheckItem("Item1"),
                        new DropdownCheckItem("Item2"),
                        new DropdownCheckItem("Item3"),
                    },
                    SelectionChangedCommand = (s, _) => new Toast((s as DropdownList).SelectedItem.Text).Post()
                }
            }.StartHorizontal().StartVertical());
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
