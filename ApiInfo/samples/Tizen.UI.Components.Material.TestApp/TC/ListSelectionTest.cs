using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tizen.UI.Components.Recycler;

namespace ComponentsTest
{
    internal class ListSelectionTest : VStack, INavigationTransition, ITestCase
    {
        private readonly Label _header;
        private static ListSelectionSource s_source;
        private readonly BindingSession<ListSelectionSource> _session = new BindingSession<ListSelectionSource>();
        public ListSelectionTest() : base()
        {
            s_source = GetListSource();
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;
            ItemAlignment = LayoutAlignment.Start;
            Spacing = 20f;

            Add(_header = new());
            _header.SetBinding(_session, TextBindings<Label>.TextProperty, "SelectedName");
            _session.ViewModel = s_source;

            Add(new ListView
            {
                IsHorizontal = false,
                HasDivider = true,
                ItemsSource = s_source,
                ItemTemplate = new ViewTemplate(typeof(ListSelectionTestItem)),
                ScrollBarVisibility = ScrollBarVisibility.Auto,
                InnerMargin = new Thickness(MaterialSpacing.Lg600, 0),
            });
        }

        private ListSelectionSource GetListSource()
        {
            var itemsSource = new ListSelectionSource();

            for (int i = 0; i < 50; i++)
            {
                itemsSource.Add(new ListSelectionData
                {
                    Index = i,
                    Title = $"{i}th",
                    IsSelected = false,
                });
            }

            return itemsSource;
        }

        private class ListSelectionTestItem : GroupSelectableBox, IBindableView
        {
            private HStack _stack;
            private readonly BindingSession<ListSelectionData> _session = new BindingSession<ListSelectionData>();
            public ListSelectionTestItem() : base()
            {
                IsSelectable = true;

                _stack = new HStack();
                Body = _stack;

                var radio = new RadioButton();
                radio.SetTwoWayBinding(_session, SelectableBindings<RadioButton>.IsSelectedProperty, "IsSelected");
                _stack.Add(radio);

                var label = new Label().Expand();
                label.SetBinding(_session, TextBindings<Label>.TextProperty, "Title");
                _stack.Add(label);
                this.SetTwoWayBinding(_session, SelectableBindings<ListSelectionTestItem>.IsSelectedProperty, "IsSelected");
            }

            protected override IList<View> InnerList => Body as ViewGroup;

            public override Thickness Padding
            {
                get => _stack.Padding;
                set => _stack.Padding = value;
            }

            // To disallow deselection by touch.
            protected override bool IsDeselectable => false;

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
                set => _session.ViewModel = (ListSelectionData)value;
            }
        }

        private class ListSelectionData : SelectableModel
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

        private class ListSelectionSource : ExclusiveSelectionModelGroup<ListSelectionData>
        {
            string _selectedName;
            public ListSelectionSource() : base()
            {
                PropertyChanged += (_, e) =>
                {
                    if (e.PropertyName == "Selected")
                    {
                        _selectedName = $"Selected : [{Selected?.Index}] : [{Selected?.Title}]";
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