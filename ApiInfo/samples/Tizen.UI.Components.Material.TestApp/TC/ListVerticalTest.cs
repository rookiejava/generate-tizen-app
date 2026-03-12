using System;
using System.Text;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Recycler;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class ListVerticalTest : VStack, INavigationTransition, ITestCase
    {
        private readonly Label header;
        private readonly ListView listView;

        public ListVerticalTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0xf1f1f3, 1);
            ItemAlignment = LayoutAlignment.Start;

            Add(header = new()
            {
                Text = "ListVTest : [0f]]"
            });

            var itemsSource = new List<MyDataGroup>();
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var group = new MyDataGroup
                {
                    Title = $"Group {i}"
                };
                for (int j = 0; j < 10; j++)
                {
                    group.Add(new MyData
                    {
                        Title = $"{j}th",
                        Description = MultipleText($"This is a content area for {i} long and multiline text"),
                        Image = $"poster/{rnd.Next(6, 10):00}.jpg",
                    });
                }
                itemsSource.Add(group);
            }

            Add(listView = new ListView
            {
                IsHorizontal = false,
                IsGrouped = true,
                //IsLooping = true,
                HasDivider = true,
                Name = "Recycler",
                ItemsSource = itemsSource,
                ItemTemplate = new ViewTemplate(typeof(MyItemView)),
                GroupHeaderTemplate = new ViewTemplate(typeof(MyItemGroup)),
                GroupBodyTemplate = new ViewTemplate(typeof(MyGroupBody)),
                DividerTemplate = new ViewTemplate(typeof(MyItemDivider)),
                ScrollBarVisibility = ScrollBarVisibility.Auto,
                InnerMargin = new Thickness(88f, 0)
            }.Expand());
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

        private string MultipleText(string text)
        {
            Random rnd = new ();
            var multiple = rnd.Next(1, 5);
            StringBuilder sb = new StringBuilder();
            while (multiple-- > 0)
            {
                sb.Append(text);
            }
            return sb.ToString();
        }

        internal class MyData : ViewModel
        {
            public string Title
            {
                get => Get<string>();
                set => Set(value);
            }

            public string Description
            {
                get => Get<string>();
                set => Set(value);
            }

            public string Image
            {
                get => Get<string>();
                set => Set(value);
            }
        }

        internal class MyDataGroup : ViewModelGroup<MyData>
        {
            public string Title
            {
                get => Get<string>();
                set => Set(value);
            }
        }

        internal class MyItemDivider : AbsoluteLayout, IBindableView
        {
            public MyItemDivider()
            {
                DesiredHeight = 1f;
                this.Margin(new Thickness(32, 0, 32, 0));
                BackgroundColor = new Color(0xD6D6D8, 1);
            }

            public object BindingContext
            {
                get;
                set;
            }
        }

        internal class MyGroupBody : View, IBindableView
        {
            public MyGroupBody()
            {
                BackgroundColor = Color.White;
                CornerRadius = new CornerRadius(44);
            }

            public object BindingContext
            {
                get;
                set;
            }
        }

        internal class MyItemGroup : HStack, IBindableView
        {
            private readonly BindingSession<MyDataGroup> _session = new BindingSession<MyDataGroup>();
            private readonly Random rand = new Random();
            private readonly Label label;
            //BindingSession<MyData> _session;
            public MyItemGroup()
            {
                DesiredHeight = 69f;
                this.Padding(new Thickness(32, 20, 32, 12));

                label = new Label()
                {
                    FontFamily = MaterialFont.Normal600,
                    FontSize = 28,
                    TextColor = new Color(0x848487, 1),
                    HorizontalAlignment = TextAlignment.Start,
                    VerticalAlignment = TextAlignment.Center,
                }.Expand();
                label.SetBinding(_session, TextBindings<Label>.TextProperty, "Title");
                Add(label);
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (MyDataGroup)value;
            }
        }

        internal class MyItemView : Clickable, IGroupedItem, IBindableView
        {
            private readonly BindingSession<MyData> _session = new BindingSession<MyData>();
            private readonly HStack recoilBox;
            private readonly Label label;
            //BindingSession<MyData> _session;

            public MyItemView()
            {
                DesiredHeight = 83f;

                recoilBox = new HStack()
                {
                    WidthResizePolicy = ResizePolicy.FillToParent,
                    HeightResizePolicy = ResizePolicy.FillToParent,
                    Padding = new Thickness(32, 20, 32, 20)
                };

                label = new Label()
                {
                    FontFamily = MaterialFont.Normal400,
                    FontSize = 32,
                    TextColor = new Color(0x010102, 1),
                    HorizontalAlignment = TextAlignment.Start,
                    VerticalAlignment = TextAlignment.Center,
                }.Expand();
                label.SetBinding(_session, TextBindings<Label>.TextProperty, "Title");
                recoilBox.Add(label);
                Body = recoilBox;
                Relayout += OnRelayout;
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (MyData)value;
            }

            public bool IsFirstOfGroup { get; set; }
            public bool IsLastOfGroup { get; set; }

            public void UpdateByPosition(int position)
            {
                if (IsFirstOfGroup)
                {
                    CornerRadius = new CornerRadius(44, 44, 0, 0);
                }
                else if (IsLastOfGroup)
                {
                    CornerRadius = new CornerRadius(0, 0, 44, 44);
                }
                else
                {
                    CornerRadius = new CornerRadius(0, 0, 0, 0);
                }
            }

            public override View GetTouchEffectSecondaryTarget() => recoilBox;

            protected override bool OnClicked(KeyDeviceClass device)
            {
                //Log.Info("MyItemView", $"OnClicked! {GetHashCode()}");
                //LayoutHeight = LayoutHeight * 2;
                return base.OnClicked(device);
            }

            private void OnRelayout(object o, EventArgs e)
            {
                //Log.Error("LSH-TEST", $"{label.Text}, {GetHashCode()} : Resized {PositionX}, {PositionY}, {SizeWidth}, {SizeHeight}");
            }
        }
    }
}
