using System;
using System.Collections;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class ViewTemplateExample2 : Grid, ITestCase
    {
        class MyViewModel
        {
            public int No { get; set; }
            public string Title { get; set; }
            public string Detail { get; set; }
            public string SubTitle { get; set; }
            public Color BG { get; set; }
        }

        public ViewTemplateExample2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "ViewTemplate Example2",
                FontSize = 30,
            });

            var items = new List<MyViewModel>();
            for (int i = 0; i <50; i++)
            {
                var rnd = new Random();
                items.Add(new MyViewModel
                {
                    No = i+1,
                    Title = $"Title {i}",
                    Detail = $"Detail of {i}",
                    SubTitle = $"SubTitle",
                    BG = new Color(rnd.Next(30, 255) / 255f, rnd.Next(30, 255) / 255f, rnd.Next(30, 255) / 255f, 1),
                });
            }

            Add(new DataBindingList()
            {
                ItemSource = items,
                ItemTemplate = new ViewTemplate(typeof(ItemView)),
            }.Row(1));
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }

        class ItemView : Grid, IBindableView
        {
            public ItemView()
            {
                BindingSession<MyViewModel> bindingSession = new BindingSession<MyViewModel>();
                SetAttached(bindingSession);

                RowDefinitions.Add(50);
                RowDefinitions.Add(50);
                ColumnDefinitions.Add(50);
                ColumnDefinitions.Add(GridLength.Star);

                Add(new TextView
                {
                    VerticalAlignment = TextAlignment.Center,
                    HorizontalAlignment = TextAlignment.Center,
                    FontSize = 25,
                    Name = "Number"
                }.RowSpan(2));
                Add(new TextView
                {
                    VerticalAlignment = TextAlignment.Center,
                    FontSize = 25,
                    Name = "Title"
                }.Column(1));
                Add(new TextView
                {
                    VerticalAlignment = TextAlignment.Center,
                    FontSize = 20,
                    Name = "Detail"
                }.Row(1).Column(1));

                this.SetBinding(bindingSession, ViewBindings.BackgroundColorProperty, "BG");
                (this["Number"] as TextView).SetBinding(bindingSession, TextBindings<TextView>.TextProperty, "No");
                (this["Title"] as TextView).SetBinding(bindingSession, TextBindings<TextView>.TextProperty, "Title");
                (this["Detail"] as TextView).SetBinding(bindingSession, TextBindings<TextView>.TextProperty, "Detail");

            }

            public object BindingContext
            {
                get => GetAttached<BindingSession<MyViewModel>>().ViewModel;
                set => GetAttached<BindingSession<MyViewModel>>().ViewModel = (MyViewModel)value;
            }
        }

        class DataBindingList : ScrollLayout
        {
            IList _items;
            VStack _innerLayout;
            public DataBindingList()
            {
                ScrollDirection = ScrollDirection.Vertical;
                Content = _innerLayout = new VStack();
            }

            public IList ItemSource
            {
                get => _items;
                set
                {
                    _items = value;
                    UpdateItemsView();
                }
            }

            ViewTemplate _itemTemplate;
            public ViewTemplate ItemTemplate
            {

                get => _itemTemplate;
                set
                {
                    _itemTemplate = value;
                    UpdateItemsView();
                }
            }

            void UpdateItemsView()
            {
                _innerLayout.Clear();
                if (_itemTemplate == null || _items == null)
                {
                    return;
                }
                foreach (var item in _items)
                {
                    var view = ItemTemplate.CreateContent();
                    if (view is IBindableView bindingView)
                    {
                        bindingView.BindingContext = item;
                    }
                    _innerLayout.Children.Add(view);
                }
            }
        }

    }
}
