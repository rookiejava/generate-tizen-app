using System;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Recycler;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;
using System.Runtime.CompilerServices;

namespace ComponentsTest
{
    internal class ListGoToTopTest : ListView, INavigationTransition, ITestCase
    {
        public ListGoToTopTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;

            IsHorizontal = false;
            ItemsSource = GetListSource();
            ItemTemplate = new ViewTemplate(typeof(MyItemView));
            ScrollBarVisibility = ScrollBarVisibility.Auto;
            InnerMargin = new Thickness(MaterialSpacing.Lg600, 0);
            SetScrollBar(new GoToTopScrollBar());
        }

        private ObservableCollection<ListGoToTopData> GetListSource()
        {
            var itemsSource = new ObservableCollection<ListGoToTopData>();
            for (int i = 0; i < 200; i++)
            {
                itemsSource.Add(new ListGoToTopData
                {
                    Index = i,
                    Title = $"{i}th item title",
                });
            }

            return itemsSource;
        }

        internal class MyItemView : Clickable, IBindableView
        {
            private readonly BindingSession<ListGoToTopData> _session = new BindingSession<ListGoToTopData>();
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
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (ListGoToTopData)value;
            }
        }

        private class ListGoToTopData : ViewModel
        {
            public int Index
            {
                get => Get<int>();
                set => Set(value);
            }

            public string Title
            {
                get => Get<string>();
                set => Set(value);
            }
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

