using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Recycler;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class ListMultipleSelectionTest : VStack, INavigationTransition, ITestCase
    {
        private readonly HStack _header;
        private static ListMultiSelectionSource s_source;
        private readonly BindingSession<ListMultiSelectionSource> _session = new BindingSession<ListMultiSelectionSource>();
        public ListMultipleSelectionTest() : base()
        {
            s_source = GetListSource();
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;
            ItemAlignment = LayoutAlignment.Start;
            Spacing = 20f;

            Add(_header = new HStack
            {
                Padding = new Thickness(30f, 10f),
                Spacing = 20f,
            });

            _header.Add(new Checkbox().Self(out var check));
            check.SetTwoWayBinding(_session, SelectableBindings<Checkbox>.IsSelectedProperty, "IsSelected");

            _header.Add(new Label().Self(out var label).Expand());
            label.SetBinding(_session, TextBindings<Label>.TextProperty, "SelectedName");
            _session.ViewModel = s_source;

            Add(new ListView
            {
                IsHorizontal = false,
                HasDivider = true,
                ItemsSource = s_source,
                ItemTemplate = new ViewTemplate(typeof(ListMultipleSelectionTestItem)),
                ScrollBarVisibility = ScrollBarVisibility.Auto,
                InnerMargin = new Thickness(MaterialSpacing.Lg600, 0),
            });
        }

        private ListMultiSelectionSource GetListSource()
        {
            var itemsSource = new ListMultiSelectionSource();

            for (int i = 0; i < 50; i++)
            {
                itemsSource.Add(new ListMultipleSelectionData
                {
                    Index = i,
                    Title = $"{i}th",
                    IsSelected = false,
                });
            }

            return itemsSource;
        }

        private class ListMultipleSelectionTestItem : SelectableBox, IBindableView
        {
            private HStack _stack;
            private readonly BindingSession<ListMultipleSelectionData> _session = new BindingSession<ListMultipleSelectionData>();
            public ListMultipleSelectionTestItem() : base()
            {
                IsSelectable = true;

                _stack = new HStack();
                Body = _stack;

                var check = new Checkbox();
                check.SetTwoWayBinding(_session, SelectableBindings<Checkbox>.IsSelectedProperty, "IsSelected");
                _stack.Add(check);

                var label = new Label().Expand();
                label.SetBinding(_session, TextBindings<Label>.TextProperty, "Title");
                _stack.Add(label);
                this.SetTwoWayBinding(_session, SelectableBindings<ListMultipleSelectionTestItem>.IsSelectedProperty, "IsSelected");
            }

            protected override IList<View> InnerList => Body as ViewGroup;
            protected override bool IsDeselectable => true;
            public override Thickness Padding
            {
                get => _stack.Padding;
                set => _stack.Padding = value;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _session.Dispose();
                }
                base.Dispose(disposing);
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (ListMultipleSelectionData)value;
            }
        }

        private class ListMultipleSelectionData : SelectableModel
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

        private class ListMultiSelectionSource : SelectionModelGroup<ListMultipleSelectionData>
        {
            string _selectedName;
            public ListMultiSelectionSource() : base()
            {
                PropertyChanged += (_, e) =>
                {
                    if (e.PropertyName == "SelectedCount")
                    {
                        _selectedName = $"Selected Count : [{SelectedCount}]]";
                        OnPropertyChanged(nameof(SelectedName));
                    }
                };
            }

            public string SelectedName
            {
                get => _selectedName;
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
            Dispose();
        }
    }
}