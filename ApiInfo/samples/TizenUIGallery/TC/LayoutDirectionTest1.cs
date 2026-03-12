using System;
using Tizen.UI;

namespace TizenUIGallery.TC
{
    public class LayoutDirectionTest1 : ViewGroup, ITestCase
    {
        public LayoutDirectionTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Add(new TextView
            {
                Text = "LayoutDirection Test1",
                BackgroundColor = Color.Yellow,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                PivotPointY = 0f,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 100,
                FontSize = 60,
            });

            Add(new TextView
            {
                Name = "Log",
                BackgroundColor = Color.Yellow,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                PivotPointY = 0f,
                Y = 110,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 50,
                FontSize = 20,
            });
            Add(new TextView
            {
                Name = "Log2",
                BackgroundColor = Color.Yellow,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                PivotPointY = 0f,
                Y = 162,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 50,
                FontSize = 20,
            });


            Add(new ViewGroup
            {
                Name = "View1",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 400,
                Width = 300,
                Y = 250,
                X = -150,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                Children =
                {
                    new ViewGroup
                    {
                        Name = "View1-1",
                        ParentOriginX = 0.5f,
                        ParentOriginY = 0.5f,
                        PivotPointX = 0.5f,
                        PivotPointY = 0.5f,
                        PositionUsesPivotPoint = true,
                        Height = 300,
                        Width = 200,
                        BackgroundColor = Color.Blue,
                        LayoutDirection = LayoutDirection.LeftToRight,
                        Children =
                        {
                            new View
                            {
                                Name = "View1-1-1",
                                ParentOriginX = 0.5f,
                                ParentOriginY = 0.5f,
                                PivotPointX = 0.5f,
                                PivotPointY = 0.5f,
                                PositionUsesPivotPoint = true,
                                Height = 200,
                                Width = 100,
                                BackgroundColor = Color.Khaki,
                            }
                        }
                    }
                }
            });

            Add(new ViewGroup
            {
                Name = "View2",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 400,
                Width = 300,
                Y = 250,
                X = 150,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Green,
                Children =
                {
                    new ViewGroup
                    {
                        Name = "View2-1",
                        ParentOriginX = 0.5f,
                        ParentOriginY = 0.5f,
                        PivotPointX = 0.5f,
                        PivotPointY = 0.5f,
                        PositionUsesPivotPoint = true,
                        Height = 300,
                        Width = 200,
                        BackgroundColor = Color.Blue,
                        Children =
                        {
                            new View
                            {
                                Name = "View2-1-1",
                                ParentOriginX = 0.5f,
                                ParentOriginY = 0.5f,
                                PivotPointX = 0.5f,
                                PivotPointY = 0.5f,
                                PositionUsesPivotPoint = true,
                                Height = 200,
                                Width = 100,
                                BackgroundColor = Color.Khaki,
                            }
                        }
                    }
                }
            });

            Add(new TextView
            {
                Name = "Btn1",
                Width = 200,
                Height = 80,
                BackgroundColor = Color.Green,
                X = 0,
                Y = 660,
                FontSize = 30,
                Text = "Check1",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center
            });

            Add(new TextView
            {
                Name = "Btn2",
                Width = 200,
                Height = 80,
                BackgroundColor = Color.Green,
                X = 220,
                Y = 660,
                Text = "Check2",
                FontSize = 30,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center
            });


            Add(new TextView
            {
                Name = "Btn3",
                Width = 200,
                Height = 80,
                BackgroundColor = Color.Green,
                X = 440,
                Y = 660,
                Text = "X",
                FontSize = 30,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center
            });

            Add(new TextView
            {
                Name = "Btn4",
                Width = 200,
                Height = 80,
                BackgroundColor = Color.Green,
                X = 0,
                Y = 760,
                FontSize = 30,
                Text = "Set LTR",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center
            });

            Add(new TextView
            {
                Name = "Btn5",
                Width = 200,
                Height = 80,
                BackgroundColor = Color.Green,
                X = 220,
                Y = 760,
                Text = "Set LTR",
                FontSize = 30,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center
            });


            Add(new TextView
            {
                Name = "Btn6",
                Width = 200,
                Height = 80,
                BackgroundColor = Color.Green,
                X = 440,
                Y = 760,
                Text = "X",
                FontSize = 30,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center
            });

            Add(new TextView
            {
                Name = "Btn7",
                Width = 200,
                Height = 80,
                BackgroundColor = Color.Green,
                X = 0,
                Y = 860,
                FontSize = 30,
                Text = "Set RTL",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center
            });

            Add(new TextView
            {
                Name = "Btn8",
                Width = 200,
                Height = 80,
                BackgroundColor = Color.Green,
                X = 220,
                Y = 860,
                Text = "Set RTL",
                FontSize = 30,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center
            });


            Add(new TextView
            {
                Name = "Btn9",
                Width = 200,
                Height = 80,
                BackgroundColor = Color.Green,
                X = 440,
                Y = 860,
                Text = "X",
                FontSize = 30,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center
            });

            (this["Btn1"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                    (this["Log"] as TextView).Text = $"View1 {this["View1"].LayoutDirection}, View1-1 {this["View1-1"].LayoutDirection}, View1-1-1 {this["View1-1-1"].LayoutDirection}";
                    (this["Log2"] as TextView).Text = $"Inherit Direction : View1 {this["View1"].InheritLayoutDirection}, View1-1 {this["View1-1"].InheritLayoutDirection}, View1-1-1 {this["View1-1-1"].InheritLayoutDirection}";
                }
            };

            (this["Btn2"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                    (this["Log"] as TextView).Text = $"View2 {this["View2"].LayoutDirection}, View2-1 {this["View2-1"].LayoutDirection}, View2-1-1 {this["View2-1-1"].LayoutDirection}";
                    (this["Log2"] as TextView).Text = $"Inherit Direction : View2 {this["View2"].InheritLayoutDirection}, View2-1 {this["View2-1"].InheritLayoutDirection}, View2-1-1 {this["View2-1-1"].InheritLayoutDirection}";
                }
            };

            (this["Btn3"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                }
            };

            (this["Btn4"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                    this["View1"].LayoutDirection = LayoutDirection.LeftToRight;
                }
            };

            (this["Btn5"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                    this["View2"].LayoutDirection = LayoutDirection.LeftToRight;
                }
            };

            (this["Btn6"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                }
            };

            (this["Btn7"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                    this["View1"].LayoutDirection = LayoutDirection.RightToLeft;
                }
            };

            (this["Btn8"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                    this["View2"].LayoutDirection = LayoutDirection.RightToLeft;
                }
            };

            (this["Btn9"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                }
            };

            this["View2-1"].LayoutDirectionChanged += (s, e) =>
            {
                (this["Log"] as TextView).Text = $"View2-1 LayoutDirection Changed {this["View2-1"].LayoutDirection}";
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
