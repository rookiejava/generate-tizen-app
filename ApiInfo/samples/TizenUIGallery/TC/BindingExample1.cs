using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public interface IBindingExample1Model
    {
        string Title { get; set; }
        string UserText { get; set; }
        Color Color { get; set; }

        float X { get; set; }
        float Y { get; set; }
    }

    public class BindingExample1 : Grid, ITestCase
    {
        BindingSession<IBindingExample1Model> bindingSession = new BindingSession<IBindingExample1Model>();

        public BindingExample1(IBindingExample1Model viewmodel)
        {
            Initialize();
            bindingSession.ViewModel = viewmodel;
        }

        public BindingExample1() : this(new BindingExampe1ViewModel
        {
            Title = "Binding Example",
            Color = Color.Red,
        }) { }


        void Initialize()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(80);
            RowDefinitions.Add(80);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                FontSize = 30,
            }.SetBinding(bindingSession, TextBindings<TextView>.TextProperty, "Title")
            .SetBinding(bindingSession, TextBindings<TextView>.TextColorProperty, "Color"));
            
            
            Add(new TextView
            {
                VerticalAlignment = TextAlignment.Center,
                BackgroundColor = Color.Gray,
                FontSize = 50,
            }.SetBinding(bindingSession, TextBindings<TextView>.TextProperty, "UserText").Row(1));

            Add(new TextField
            {
                FontSize = 50,
                PlaceholderText = "Type here",
                BackgroundColor = Color.Coral,
            }.SetTwoWayBinding(bindingSession, EditableTextBindings<TextField>.TextProperty, "UserText").Row(2));

            var moving = new TextView
            {
                Text = "Moving box",
                IsMultiline = true,
                Height = 100,
                Width = 100,
                HeightResizePolicy = ResizePolicy.Fixed,
                WidthResizePolicy = ResizePolicy.Fixed,
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
            }.SetBinding(bindingSession, ViewBindings.BackgroundColorProperty, "Color")
.SetBinding(bindingSession, ViewBindings.XProperty, "X")
.SetBinding(bindingSession, ViewBindings.YProperty, "Y");

            var layer = new Layer();
            Window.Default.Add(layer);
            layer.Add(moving);
            moving.RaiseToTop();


            var toucharea = new TextView
            {
                Text = "Drag area",
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                BackgroundColor = Color.FloralWhite,
                DesiredWidth = 400,
                DesiredHeight = 300,
            }.Row(3);
            float lastX = 0;
            float lastY = 0;
            toucharea.TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    lastX = e.Touch[0].Position.X;
                    lastY = e.Touch[0].Position.Y;
                }
                if (e.Touch[0].State == TouchState.Motion)
                {
                    float curX = e.Touch[0].Position.X;
                    float curY = e.Touch[0].Position.Y;
                    bindingSession.ViewModel.X += (curX - lastX);
                    bindingSession.ViewModel.Y += (curY - lastY);
                    lastX = curX;
                    lastY = curY;
                }
            };
            Add(toucharea);

            Add(new FlexBox
            {
                BackgroundColor = Color.FromHex("#f9fff2"),
                Wrap = FlexWrap.Wrap,
                AlignContent = FlexAlignContent.Start,
                Children =
                {
                    new Button("Add Text")
                    {
                        Clicked = () =>
                        {
                            bindingSession.ViewModel.Title += "..Text";
                        }
                    }.Margin(10),
                    new Button("Change Color")
                    {
                        Clicked = () =>
                        {
                            Random rnd = new Random();
                            bindingSession.ViewModel.Color = new Color((float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, 1f);
                        }
                    }.Margin(10),
                    new Button("Reset")
                    {
                        Clicked = () =>
                        {
                            bindingSession.ViewModel.Title = "Binding Example";
                            bindingSession.ViewModel.Color = Color.Red;
                        }
                    }.Margin(10),
                },
            }.Row(4));

            DetachedFromWindow += (s, e) =>
            {
                layer.Dispose();
                moving.Dispose();
            };

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bindingSession.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }
    }

    public class BindingExampe1ViewModel : ViewModel, IBindingExample1Model
    {
        public string Title
        {
            get => Get<string>();
            set => Set(value);
        }
        
        public string UserText
        {
            get => Get<string>();
            set => Set(value);
        }

        public Color Color
        {
            get => Get<Color>();
            set => Set(value);
        }

        public float X
        {
            get => Get<float>();
            set => Set(value);
        }

        public float Y
        {
            get => Get<float>();
            set => Set(value);
        }
    }
}
