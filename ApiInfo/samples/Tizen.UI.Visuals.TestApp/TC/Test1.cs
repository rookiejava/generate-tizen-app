using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Visuals;

namespace VisualObjectTest.TC
{
    class Test1 : Grid, ITestCase
    {
        public Test1()
        {
            Name = "Outter";
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
                Text = "Test1",
                FontSize = 30,
            });

            Add(new VStack
            {
                Name = "VStack",
                Children =
                {
                    new View
                    {
                        DesiredHeight = 200,
                        DesiredWidth = 300,
                        BackgroundColor = Color.White,
                        CornerRadius = 10,
                    }
                    .Add(new NPatchVisual
                    {
                        ResourceUrl = "keyboard_focus.9.png"
                    })
                    .Add(new ImageVisual
                    {
                        ResourceUrl = "dotnet_bot.png",
                        FittingMode = FittingMode.ScaleToFit,
                    })
                    .Add(new ColorVisual
                    {
                        TransformFlags = TransformFlags.PositionProportional,
                        Origin = VisualAlign.TopEnd,
                        PivotPoint = VisualAlign.TopEnd,
                        X = 0,
                        Y = 0,
                        Width = 50,
                        Height = 50,
                        CornerRadius = 25,
                        Color = Color.Red,
                    })
                    .Add(new ColorVisual
                    {
                        TransformFlags = TransformFlags.PositionProportional,
                        Origin = VisualAlign.TopBegin,
                        PivotPoint = VisualAlign.TopBegin,
                        X = 0,
                        Y = 0,
                        Width = 50,
                        Height = 50,
                        CornerRadius = 1,
                        Color = Color.Red,
                    })
                    .Add(new TextVisual
                    {
                        Text = "Hello world",
                        FontSize = 30,
                        Width = 300,
                        Height = 100,
                        TransformFlags = TransformFlags.PositionProportional,
                        TextColor = Color.Green,
                    }),
                    new View
                    {
                        DesiredHeight = 200,
                        DesiredWidth = 200,
                    }.Add(new ColorVisual
                    {
                        Width = 0.5f,
                        Height = 1,
                        Color = Color.Red,
                    })
                    .Add(new ColorVisual
                    {
                        X = 0.5f,
                        Width = 0.5f,
                        Height = 1,
                        Color = Color.Blue,
                    }),
                    new View
                    {
                        DesiredHeight = 200,
                        DesiredWidth = 200,
                    }.Add(new ColorVisual
                    {
                        Width = 0.5f,
                        Height = 0.5f,
                        Color = Color.Red,
                    })
                    .Add(new ColorVisual
                    {
                        X = 0.5f,
                        Y = 0.5f,
                        Width = 0.5f,
                        Height = 0.5f,
                        Color = Color.Red,
                    })
                    .Add(new ColorVisual
                    {
                        X = 0.5f,
                        Width = 0.5f,
                        Height = 0.5f,
                        Color = Color.Blue,
                    })
                    .Add(new ColorVisual
                    {
                        X = 0,
                        Y = 0.5f,
                        Width = 0.5f,
                        Height = 0.5f,
                        Color = Color.Blue,
                    }),
                    new View
                    {
                        DesiredHeight = 300,
                        DesiredWidth = 300
                    }.Add(new ColorVisual
                    {
                        Origin = VisualAlign.Center,
                        PivotPoint = VisualAlign.Center,
                        ModifyHeight = 0,
                        ModifyWidth = 0,
                        BorderlineColor = Color.Red,
                        BorderlineWidth = 20,
                    })
                    .Add(new ColorVisual
                    {
                        Origin = VisualAlign.Center,
                        PivotPoint = VisualAlign.Center,
                        ModifyHeight = -10,
                        ModifyWidth = -10,
                        BorderlineColor = Color.Green,
                        BorderlineWidth = 20,
                    })
                    .Add(new ColorVisual
                    {
                        Origin = VisualAlign.Center,
                        PivotPoint = VisualAlign.Center,
                        ModifyHeight = -20,
                        ModifyWidth = -20,
                        BorderlineColor = Color.Blue,
                        BorderlineWidth = 20,
                    })
                    .Add(new ColorVisual
                    {
                        Origin = VisualAlign.Center,
                        PivotPoint = VisualAlign.Center,
                        ModifyHeight = -30,
                        ModifyWidth = -30,
                        BorderlineColor = Color.Brown,
                        BorderlineWidth = 20,
                    })
                    .Add(new ColorVisual
                    {
                        Origin = VisualAlign.Center,
                        PivotPoint = VisualAlign.Center,
                        ModifyHeight = -40,
                        ModifyWidth = -40,
                        BorderlineColor = Color.Yellow,
                        BorderlineWidth = 20,
                    })
                }
            }.Row(1).Spacing(10));

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
