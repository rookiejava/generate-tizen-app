using System;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class DropdownItemTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 16f;
        private const float s_spacing = 10f;
        private List<DropdownItem> _items;

        public DropdownItemTest() : base()
        {
            this.Fill();
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                Spacing = s_spacing,
                Padding = 50,
                Children =
                {
                    new VStack()
                    {
                        BackgroundColor = Color.White,
                        Spacing = s_spacing,
                        Padding = 10,
                        Children =
                        {
                            CreateCheck("Width Constraint", (v) => _items.ForEach(item => item.DesiredWidth = v ? 220 : -1)),
                            CreateCheck("Trailing Icon", (v) => _items.ForEach(item => item.IconPlacement = v ? IconPlacement.Trailing : IconPlacement.Leading)),
                        }
                    },
                    new VStack()
                    {
                        Spacing = s_spacing,
                    }.Self(out var itemStack)
                }
            }
            .FillHorizontal();

            _items = CreateDropdownItems();
            _items.ForEach(item => itemStack.Add(item));
        }

        private View CreateCheck(string text, Action<bool> onclick)
        {
            return new ClickableHStack()
            {
                Spacing = 10f,
                Children =
                {
                    new Checkbox()
                    {
                        SelectedChangedCommand = (s, e) => onclick((s as Checkbox).IsSelected)
                    }
                    .Self(out var check)
                    .CenterVertical(),
                    new Label()
                    {
                        Text = text,
                        FontSize = s_fontSize,
                        TextColor = s_fontColor,
                        VerticalAlignment = TextAlignment.Center
                    }
                    .Expand()
                    .Fill()
                },
                ClickedCommand = (s, e) => check.Toggle(e.InputDevice)
            }.FillHorizontal();
        }

        private List<DropdownItem> CreateDropdownItems()
        {
            return new List<DropdownItem>()
            {
                new DropdownItem()
                {
                    BorderlineWidth = 1,
                    IconResourceUrl = MaterialIcon.Camera,
                    IconPlacement = IconPlacement.Trailing
                }.StartHorizontal(),
                new DropdownItem()
                {
                    BorderlineWidth = 1,
                    Text = "Hello",
                }.StartHorizontal(),
                new DropdownItem()
                {
                    BorderlineWidth = 1,
                    Text = "Hello World! I'm fine thank you.",
                }.StartHorizontal(),
                new DropdownItem()
                {
                    BorderlineWidth = 1,
                    Text = "Hello",
                    IconResourceUrl = MaterialIcon.Camera
                }.StartHorizontal(),
                new DropdownItem()
                {
                    BorderlineWidth = 1,
                    Text = "Hello World! I'm fine thank you.",
                    IconResourceUrl = MaterialIcon.Camera
                }.StartHorizontal(),
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
