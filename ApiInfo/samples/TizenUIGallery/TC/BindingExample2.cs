using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class BindingExample2 : Grid, ITestCase
    {
        public BindingExample2()
        {
            Initialize();
            viewModel = new BindingExampe1ViewModel
            {
                Title = "Binding Example3",
                Color = Color.Red,
            };
            this.ViewModel(viewModel);
            moving.ViewModel(viewModel);
        }

        View moving;
        IBindingExample1Model viewModel;
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
            }
            .BindText("Title")
            .BindTextColor("Color"));
            //.Bind(TextBindings<TextView>.TextProperty, "Title")
            //.Bind(TextBindings<TextView>.TextColorProperty, "Color"));

            Add(new TextView
            {
                VerticalAlignment = TextAlignment.Center,
                BackgroundColor = Color.Gray,
                FontSize = 50,
            }
            .BindText("UserText").Row(1));
            //.Bind(TextBindings<TextView>.TextProperty, "UserText").Row(1));

            Add(new TextField
            {
                FontSize = 50,
                PlaceholderText = "Type here",
                BackgroundColor = Color.Coral,
            }.BindText("UserText").Row(2));
            //.TwoWayBind(EditableTextBindings<TextField>.TextProperty, "UserText").Row(2));

            moving = new TextView
            {
                Text = "Moving box",
                IsMultiline = true,
                Height = 100,
                Width = 100,
                HeightResizePolicy = ResizePolicy.Fixed,
                WidthResizePolicy = ResizePolicy.Fixed,
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
            }
            .BindBackgroundColor("Color")
            .BindX("X")
            .BindY("Y");
            //.Bind(ViewBindings.BackgroundColorProperty, "Color")
            //.Bind(ViewBindings.XProperty, "X")
            //.Bind(ViewBindings.YProperty, "Y");

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
                    viewModel.X += (curX - lastX);
                    viewModel.Y += (curY - lastY);
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
                            viewModel.Title += "..Text";
                        }
                    }.Margin(10),
                    new Button("Change Color")
                    {
                        Clicked = () =>
                        {
                            Random rnd = new Random();
                            viewModel.Color = new Color((float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, 1f);
                        }
                    }.Margin(10),
                    new Button("Reset")
                    {
                        Clicked = () =>
                        {
                            viewModel.Title = "Binding Example";
                            viewModel.Color = Color.Red;
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

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }
    }
}
