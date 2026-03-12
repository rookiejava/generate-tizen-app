using System;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Recycler;
using Tizen.UI.Components.Material;
using System.Runtime.CompilerServices;

namespace ComponentsTest
{
    internal class ListViewExpandTest : ListView, INavigationTransition, ITestCase
    {
        private ObservableCollection<ListViewExpandTestGroup> _source;
        public ListViewExpandTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.SurfaceContainerHighest;

            IsHorizontal = false;
            IsGrouped = true;
            ItemsSource = GetListSource();
            ItemTemplate = new ViewTemplate(typeof(ListViewDefaultItem));
            GroupHeaderTemplate = new ViewTemplate(typeof(ListViewExpandItem));
            ScrollBarVisibility = ScrollBarVisibility.Auto;
            InnerMargin = new Thickness(MaterialSpacing.Lg600, 0);
            ItemAnimator = new DefaultItemAnimator();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        private ObservableCollection<ListViewExpandTestGroup> GetListSource()
        {
            if (_source != null)
                return _source;

            var rnd = new Random();
            var itemsSource = new ObservableCollection<ListViewExpandTestGroup>();
            for (int i = 0; i < 11; i++)
            {
                var group = new ListViewExpandTestGroup
                {
                    Index = i,
                    Title = $"Expand Group {i}",
                };
                itemsSource.Add(group);
            }

            _source = itemsSource;

            return _source;
        }

        private string GetResourePath(int i)
        {
            var index = i % 19 + 1;
            if (index < 10)
            {
                return $"settings/0{index}.png";
            }
            else
            {
                return $"settings/{index}.png";
            }
        }

        private class ListViewDefaultItem : Clickable, IBindableView
        {
            private readonly BindingSession<ListViewExpandTestData> _session = new BindingSession<ListViewExpandTestData>();
            private readonly HStack recoilBox;
            public ListViewDefaultItem() : base()
            {
                DesiredHeight = 83f;
                BackgroundColor = MaterialColor.SurfaceBrightest.WithAlpha(0.8f);
                CornerRadius = new CornerRadius(15f);
                this.Margin(10);

                recoilBox = new HStack()
                {
                    WidthResizePolicy = ResizePolicy.FillToParent,
                    HeightResizePolicy = ResizePolicy.FillToParent,
                    Padding = new Thickness(32, 20, 32, 20),
                    Children =
                    {
                        new Label()
                        {
                            FontFamily = MaterialFont.Normal400,
                            FontSize = 32,
                            TextColor = new Color(0x010102, 1),
                            HorizontalAlignment = TextAlignment.Start,
                            VerticalAlignment = TextAlignment.Center,
                        }.Expand().SetBinding(_session, TextBindings<Label>.TextProperty, "Title"),
                    },
                };
                Body = recoilBox;
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (ListViewExpandTestData)value;
            }

            public override View GetTouchEffectSecondaryTarget() => recoilBox;
        }

        private class ListViewExpandItem :  Clickable, IBindableView
        {
            private readonly BindingSession<ListViewExpandTestGroup> _session = new BindingSession<ListViewExpandTestGroup>();
            private readonly HStack recoilBox;

            public ListViewExpandItem() : base()
            {
                DesiredHeight = 83f;

                BackgroundColor = MaterialColor.SurfaceBrightest;
                this.Margin(10);
                CornerRadius = new CornerRadius(15f);

                recoilBox = new HStack
                {
                    WidthResizePolicy = ResizePolicy.FillToParent,
                    HeightResizePolicy = ResizePolicy.FillToParent,
                    Padding = new Thickness(32, 20, 32, 20),
                    Spacing = 20f,
                    Children =
                    {
                        new Label
                        {
                            FontFamily = MaterialFont.Normal400,
                            FontSize = 32,
                            TextColor = new Color(0x010102, 1),
                            HorizontalAlignment = TextAlignment.Start,
                            VerticalAlignment = TextAlignment.Center,
                        }.Expand().SetBinding(_session, TextBindings<Label>.TextProperty, "Title"),
                        new IconButton
                        {
                            IconWidth = 24f,
                            IconHeight = 24f,
                            Padding = new Thickness(4f),
                            IconResourceUrl = MaterialIcon.ArrowDown,
                            IconMultipliedColor = Color.Black,
                            ClickedCommand = (o, e) =>
                            {
                                var group = (ListViewExpandTestGroup)BindingContext;

                                if (group.Expanded)
                                {
                                    for (int i = 4; i >= 0; i--)
                                    {
                                        // Clear just reset the list.
                                        // Call remove only makes collection changed with remove action.
                                        group.RemoveAt(i);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        group.Add(new ListViewExpandTestData
                                        {
                                            Index = i,
                                            Title = $"{i}th Child",
                                        });
                                    }
                                }
                                group.Expanded = !group.Expanded;

                                e.Handled = true;
                            }
                        },
                    }
                };

                Body = recoilBox;
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (ListViewExpandTestGroup)value;
            }
        }

        private class ListViewExpandTestData : ViewModel
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

        private class ListViewExpandTestGroup : ViewModelGroup<ListViewExpandTestData>
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

            public bool Expanded
            {
                get => Get<bool>();
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
