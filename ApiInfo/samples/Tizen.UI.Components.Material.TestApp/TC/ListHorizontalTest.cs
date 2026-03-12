using System;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Recycler;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class ListHorizontalTest : VStack, INavigationTransition, ITestCase
    {
        private readonly Label header;
        private readonly ListView listView;

        public ListHorizontalTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0xf1f1f3, 1);
            ItemAlignment = LayoutAlignment.Start;

            Add(header = new()
            {
                Text = "ListVTest : [0f]]"
            });

            var itemsSource = new List<MyData>();
            for (int i = 0; i < 100; i++)
            {
                itemsSource.Add(new MyData
                {
                    Title = $"{i}th",
                    Description = $"This is a content area for {i}",
                });
            }

            Add(listView = new ListView
            {
                BackgroundColor = Color.White,
                IsHorizontal = true,
                HasDivider = true,
                Name = "Recycler",
                ItemsSource = itemsSource,
                ItemTemplate = new ViewTemplate(typeof(MyItemView)),
                ScrollBarVisibility = ScrollBarVisibility.Auto,
                InnerMargin = new Thickness(0, 40f)
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

            public string TitImagele
            {
                get => Get<string>();
                set => Set(value);
            }
        }

        internal class MyItemView : Clickable, IBindableView
        {
            private readonly BindingSession<MyData> _session = new BindingSession<MyData>();
            private readonly Random rand = new Random();
            private readonly HStack recoilBox;
            private readonly Label label;
            //BindingSession<MyData> _session;

            public MyItemView()
            {
                DesiredWidth = 250f;
                BackgroundColor = Color.LightGray;

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
