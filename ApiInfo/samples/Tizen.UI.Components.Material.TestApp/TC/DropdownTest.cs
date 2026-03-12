using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class DropdownTest : AbsoluteLayout, INavigationTransition, ITestCase
    {
        private readonly DropdownList _dropdownList;

        public DropdownTest() : base()
        {
            Padding = new(20f);
            SetBackground(new ImageBackground()
            {
                Url = "rainbow.jpg"
            });

            new DropdownList()
            {
                Items =
                {
                    new DropdownCheckItem("Item1"),
                    new DropdownCheckItem("Item2"),
                    new DropdownCheckItem("Item3"),
                },
                DismissedCommand = (s, _) => new Toast((s as DropdownList).SelectedItem.Text).Post()
            }
            .Self(out _dropdownList);

            Add(new Button("Test1")
            {
                ClickedCommand = (s, _) => _dropdownList.Post((s as Button).GetScreenBounds())
            });

            Add(new Button("Test2")
            {
                ClickedCommand = (s, _) => _dropdownList.Post((s as Button).GetScreenBounds())
            }
            .LayoutBounds(1f, 0f, -1, -1)
            .LayoutFlags(AbsoluteLayoutFlags.PositionProportional));

            Add(new Button("Test3")
            {
                ClickedCommand = (s, _) =>
                {
                    new DropdownList()
                    {
                        Items =
                        {
                            new DropdownActionItem()
                            {
                                IconResourceUrl = MaterialIcon.Camera,
                                Text = "Camera",
                                ClickedCommand = (_, _) => new Toast("Camera clicked").Post()
                            },
                            new DropdownActionItem()
                            {
                                IconResourceUrl = MaterialIcon.Copy,
                                Text = "Copy",
                                ClickedCommand = (_, _) => new Toast("Copy clicked").Post()
                            },
                            new DropdownActionItem()
                            {
                                IconResourceUrl = MaterialIcon.Edit,
                                Text = "Rename",
                                ClickedCommand = (_, _) => new Toast("Rename clicked").Post()
                            }
                        }
                    }
                    .Post((s as Button).GetScreenBounds());
                }
            }
            .LayoutBounds(0.5f, 0.5f, -1, -1)
            .LayoutFlags(AbsoluteLayoutFlags.PositionProportional));

            Add(new Button("Test4")
            {
                ClickedCommand = (s, _) =>
                {
                    new DropdownList<UserItem>()
                    {
                        ModalPivot = ModalPivot.BottomEnd,
                        Items =
                        {
                            new UserItemText("Title1", "Subtitle of title 1"),
                            new UserItemText("Title2", "Subtitle of title 2"),
                            new UserItemDivder(),
                            new UserItemText("Title3", "Subtitle of title 3")
                        },
                    }
                    .Post((s as Button).GetScreenBounds());
                }
            }
            .LayoutBounds(0.5f, 1f, -1, -1)
            .LayoutFlags(AbsoluteLayoutFlags.PositionProportional));
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

        public abstract class UserItem : GroupSelectable
        {
            public abstract string Text { get; }
        }

        public class UserItemDivder : UserItem
        {
            public UserItemDivder()
            {
                Body = new Grid()
                {
                    Padding = new(20f, 0f),
                    Children =
                    {
                        new Divider()
                        {
                            Style = DividerStyle.Dotted,
                        }
                    }
                };
                IsClickable = false;
                IsSelectable = false;
                DesiredHeight = 20f;
                this.FillHorizontal();
            }

            public override string Text => "Divider";
        }

        public class UserItemText : UserItem
        {
            private readonly View _inner;
            private readonly Label _label;

            public UserItemText(string mainText, string subText)
            {
                this.TouchEffect(RecoilEffect.List);

                Body = new Grid()
                {
                    Children =
                    {
                        new VStack()
                        {
                            Spacing = 5f,
                            Padding = DropdownItemVariables.Default.Padding,
                            Children =
                            {
                                new Label(mainText)
                                {
                                    TextColor = DropdownItemVariables.Default.TextColor,
                                    FontSize = DropdownItemVariables.Default.FontSize,
                                }
                                .Self(out _label),
                                new Label(subText)
                                {
                                    TextColor = DropdownItemVariables.Default.TextColor.WithAlpha(0.5f),
                                    FontSize = DropdownItemVariables.Default.FontSize * 0.8f,
                                }
                            }
                        }
                        .StartHorizontal()
                        .CenterVertical()
                        .Self(out _inner)
                    }
                };
            }

            // Recoil scale target
            public override View GetTouchEffectSecondaryTarget() => _inner;

            public override string Text => _label.Text;
        }
    }
}
