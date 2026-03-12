using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Recycler;
using Tizen.UI.Components.Material;


namespace ComponentsTest
{
    internal class ListSwapTest : ListView, INavigationTransition, ITestCase
    {
        private static ListSwapSource s_source;
        private static ItemTouchHelper s_touchHelper;
        public ListSwapTest() : base()
        {
            // static variables
            s_source = GetListSource();
            s_touchHelper = new ItemTouchHelper(new ListSwapCallback());

            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;

            IsHorizontal = false;
            HasDivider = true;
            ItemsSource = s_source;
            ItemTemplate = new ViewTemplate(typeof(ListSwapTestItem));
            ScrollBarVisibility = ScrollBarVisibility.Auto;
            InnerMargin = new Thickness(MaterialSpacing.Lg600, 0);

            // Item Animator for swap animations.
            ItemAnimator = new DefaultItemAnimator();
            // Item Touch Helper with implementing move actions.
            ItemTouchHelper = s_touchHelper;
        }

        private ListSwapSource GetListSource()
        {
            var itemsSource = new ListSwapSource();

            for (int i = 0; i < 50; i++)
            {
                itemsSource.Add(new ListSwapData
                {
                    Index = i,
                    Title = $"{i}th",
                });
            }

            return itemsSource;
        }

        // User has to implement this callback.
        private class ListSwapCallback : LinearSwapCallback
        {
            public ListSwapCallback() : base()
            {
                // turn off longpress dragging.
                // SwapVertical icon of item will handle drag by calling StartDrag().
                IsLongpressDragEnabled = false;
            }

            public override bool OnMove(RecyclerView recyclerView, ViewHolder viewHolder, ViewHolder target)
            {
                // The holder position is not match with actual data position so you have to get your real position of the data source.
                int viewHolderPosition = s_source.IndexOf(viewHolder.BindingContext as ListSwapData);
                int targetPosition = s_source.IndexOf(target.BindingContext as ListSwapData);
                int fromPosition = Math.Min(viewHolderPosition, targetPosition);
                int toPosition = Math.Max(viewHolderPosition, targetPosition);

                if (fromPosition == toPosition)
                {
                    // target destination is same position. fail to move.
                    return false;
                }

                // please change the holder position before you moves.
                // let's try this can be done on framework side...
                // viewHolder.Position = target.Position;
                s_source.Move(fromPosition, toPosition);

                // mostly gap must be 1, but if it is bigger,
                if (fromPosition - toPosition > 1)
                {
                    s_source.Move(toPosition - 1, fromPosition);
                }
                return true;
            }
        }

        private class ListSwapTestItem : Clickable, IBindableView
        {
            private readonly BindingSession<ListSwapData> _session = new BindingSession<ListSwapData>();

            private readonly Label _label;
            private readonly ImageView _icon;

            public ListSwapTestItem() : base()
            {
                BackgroundColor = MaterialColor.Surface;

                Body = new HStack
                {
                    Padding = new Thickness(MaterialSpacing.Md400, 0),
                    Spacing = MaterialSpacing.Md100,
                    ItemAlignment = LayoutAlignment.Center,

                    Children =
                    {
                        new Label
                        {
                            TextColor = Color.Black,
                            HorizontalAlignment = TextAlignment.Start,
                            VerticalAlignment = TextAlignment.Center,
                        }.Self(out _label)
                        .Margin(new Thickness(0, MaterialSpacing.Md100))
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .Expand(),
                        new ImageView
                        {
                            ResourceUrl = MaterialIcon.SwapVertical,
                            DesiredWidth = 50,
                            DesiredHeight = 50,
                            ImageMultipliedColor = Color.Black,
                        }.Self(out _icon)
                        .VerticalLayoutAlignment(LayoutAlignment.Center),
                    }
                }.VerticalLayoutAlignment(LayoutAlignment.Center);

                //Bindings
                _label.SetBinding(_session, TextBindings<Label>.TextProperty, "Title");

                this.TouchEffect(RecoilEffect.List);

                _icon.TouchEvent += (_, e) =>
                {
                    if (e.Touch[0].State == TouchState.Started)
                    {
                        // Let the start drag when icon is on touched.
                        // Basic action of swap is longpressed,
                        // so to enable drag by icon touch,
                        // you may have to turn off IsLongpressDragEnabled on your callback.
                        s_touchHelper.StartDrag(this.Holder());
                    }
                    // we do not consume the event for item handle touch itself.
                    return;
                };
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (ListSwapData)value;
            }

            public string Text
            {
                get => _label.Text;
                set => _label.Text = value;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _session.Dispose();
                }
                base.Dispose(disposing);
            }
        }

        private class ListSwapData : ViewModel
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

        private class ListSwapSource : ViewModelGroup<ListSwapData>
        {
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // call this for dettaching the touch helper from view.
                s_touchHelper.DetachToRecyclerView();
            }
            base.Dispose(disposing);
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