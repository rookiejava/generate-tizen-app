using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class UnitSizeTest1 : AbsoluteLayout, ITestCase
    {
        public UnitSizeTest1()
        {
            BackgroundColor = Color.White;

            Add(new TextView
            {
                Text = "UnitSizeTest1",
                BackgroundColor = Color.Yellow,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                FontSize = 50,
            }.LayoutBounds(0.5f, 0, 1, 80)
             .LayoutFlags(AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional));

            Add(new TextView
            {
                Name = "Log",
                BackgroundColor = Color.Yellow,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                Text = $"ScreenSize : {DisplayMetrics.ScreenWidth}x{DisplayMetrics.ScreenHeight}",
                FontSize = 20,
            }.LayoutBounds(0.5f, 110, 1, 50)
             .LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional));
            Add(new TextView
            {
                Name = "Log2",
                BackgroundColor = Color.Yellow,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                Text = $"Scale : {DisplayMetrics.Scale}",
                FontSize = 20,
            }.LayoutBounds(0.5f, 162, 1, 50)
             .LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional));


            Add(new ViewGroup
            {
                Name = "View1",
                DesiredWidth = 100.Dp(),
                DesiredHeight = 100.Dp(),
                BackgroundColor = Color.Yellow,
            }.LayoutBounds(0, 250, -1, -1)
            .Margin(200, 0, 0, 0));

            Add(new ViewGroup
            {
                Name = "View2",
                DesiredWidth = 100,
                DesiredHeight = 100,
                BackgroundColor = Color.Green,
            }.LayoutBounds(1, 250, -1, -1)
            .Margin(0,0,200,0)
            .LayoutFlags(AbsoluteLayoutFlags.XProportional));

            Add(new HStack
            {
                Spacing = 20,
                Children =
                {
                    new TextView
                    {
                        Name = "Btn4",
                        DesiredWidth = 200,
                        DesiredHeight = 80,
                        BackgroundColor = Color.Yellow,
                        FontSize = 20,
                        Text = "Unit 100x100",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center
                    },
                    new TextView
                    {
                        Name = "Btn5",
                        DesiredWidth = 200,
                        DesiredHeight = 80,
                        BackgroundColor = Color.Yellow,
                        FontSize = 20,
                        Text = "Unit 200x200",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center
                    },
                    new TextView
                    {
                        Name = "Btn6",
                        DesiredWidth = 200,
                        DesiredHeight = 80,
                        BackgroundColor = Color.Green,
                        FontSize = 20,
                        Text = "X",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center
                    },
                }
            }.LayoutBounds(0, 760, -1, -1)
             .LayoutFlags(AbsoluteLayoutFlags.XProportional));

            Add(new HStack
            {
                Spacing = 20,
                Children =
                {
                    new TextView
                    {
                        Name = "Btn7",
                        DesiredWidth = 200,
                        DesiredHeight = 80,
                        BackgroundColor = Color.Green,
                        FontSize = 20,
                        Text = "Pixel 100x100",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center
                    },
                    new TextView
                    {
                        Name = "Btn8",
                        DesiredWidth = 200,
                        DesiredHeight = 80,
                        BackgroundColor = Color.Green,
                        FontSize = 20,
                        Text = "Pixel 200x200",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center
                    },
                    new TextView
                    {
                        Name = "Btn9",
                        DesiredWidth = 200,
                        DesiredHeight = 80,
                        BackgroundColor = Color.Green,
                        FontSize = 20,
                        Text = "X",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center
                    },
                }
            }.LayoutBounds(0, 860, -1, -1)
             .LayoutFlags(AbsoluteLayoutFlags.XProportional));

            (this["Btn4"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                    this["View1"].DesiredSize(100.Dp(), 100.Dp());
                }
            };

            (this["Btn5"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                    this["View1"].DesiredSize(200.Dp(), 200.Dp());
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
                    this["View2"].DesiredSize(100, 100);
                }
            };

            (this["Btn8"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                    this["View2"].DesiredSize(200, 200);
                }
            };

            (this["Btn9"] as TextView).TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                {
                }
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
