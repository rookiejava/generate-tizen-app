using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class VStackTest5 : AbsoluteLayout, ITestCase
    {
        public VStackTest5()
        {
            Add(new VStack
            {
                Padding = new Thickness(20, 30, 40, 50),
                BackgroundColor = Color.AliceBlue,
                DesiredHeight = 400,
                DesiredWidth = 200,
                Spacing = 10,
                Children =
                {
                    new View
                    {
                        BackgroundColor = Color.Gray,
                        DesiredHeight = 25,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Fill),
                    new VStack
                    {
                        BackgroundColor = Color.Yellow,
                        Children =
                        {
                            new TextView
                            {
                                FontSize = 20,
                                Text = "Hello world"
                            },
                        }
                    }.HorizontalLayoutAlignment(LayoutAlignment.Start),
                    new View
                    {
                        DesiredWidth = 50,
                        BackgroundColor = Color.Green,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Start).VerticalLayoutAlignment(LayoutAlignment.Fill),
                    new View
                    {
                        BackgroundColor = Color.Blue,
                        DesiredWidth = 100,
                        DesiredHeight = 100,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Start).VerticalLayoutAlignment(LayoutAlignment.Start),
                }
            }.LayoutBounds(10, 10, -1, -1));


            Add(new FlexBox
            {
                Padding = new Thickness(20, 30, 40, 50),
                BackgroundColor = Color.AliceBlue,
                DesiredHeight = 400,
                DesiredWidth = 200,
                Direction = FlexDirection.Column,
                AlignItems = FlexAlignItems.Start,
                Children =
                {
                    new View
                    {
                        BackgroundColor = Color.Gray,
                        DesiredHeight = 25,
                    }.Shrink(0).AlignSelf(FlexAlignSelf.Stretch),
                    new FlexBox
                    {
                        Name= "InnerFlexBox",
                        BackgroundColor = Color.Yellow,
                        Direction = FlexDirection.Row,
                        AlignItems = FlexAlignItems.Start,
                        Children =
                        {
                            new TextView
                            {
                                FontSize = 20,
                                Text = "Hello world"
                            },
                        },
                    }.AlignSelf(FlexAlignSelf.Start),
                    new View
                    {
                        DesiredWidth = 50,
                        BackgroundColor = Color.Green,
                    }.Grow(1),
                    new View
                    {
                        BackgroundColor = Color.Blue,
                        DesiredWidth = 100,
                        DesiredHeight = 100,
                    }.Shrink(0),
                }
            }.LayoutBounds(300, 10, -1, -1));



            var measrued = this["InnerFlexBox"].Measure(float.PositiveInfinity, float.PositiveInfinity);
            Console.WriteLine($"!!!! measured size : {measrued}");
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
