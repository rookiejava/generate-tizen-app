using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class GridTest5 : ViewGroup, ITestCase
    {
        public GridTest5()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Add(new Grid
            {
                Name = "Outter",
                BackgroundColor = Color.AliceBlue,

                Children =
                {
                    new Grid
                    {
                        RowDefinitions =
                        {
                            new GridRowDefinition(),
                            new GridRowDefinition(),
                            new GridRowDefinition(),
                        },

                        ColumnDefinitions =
                        {
                            new GridColumnDefinition(),
                            new GridColumnDefinition(),
                            new GridColumnDefinition(),
                        },
                        Children =
                        {
                            new View
                            {
                                BackgroundColor = Color.AliceBlue
                            },
                            new TextView
                            {
                                Text = "Upper left",
                                FontSize = 30,
                            }.HorizontalLayoutAlignment(LayoutAlignment.Start).VerticalLayoutAlignment(LayoutAlignment.Start),

                            new View
                            {
                                BackgroundColor = Color.LightSkyBlue,
                            }.Column(1),
                            new TextView
                            {
                                Text = "Upper center",
                                FontSize = 30,
                            }.Column(1).HorizontalLayoutAlignment(LayoutAlignment.Center).VerticalLayoutAlignment(LayoutAlignment.Start),

                            new View
                            {
                                BackgroundColor = Color.CadetBlue
                            }.Column(2),
                            new TextView
                            {
                                Text = "Upper right",
                                FontSize = 30,
                            }.Column(2).HorizontalLayoutAlignment(LayoutAlignment.End).VerticalLayoutAlignment(LayoutAlignment.Start),

                            new View
                            {
                                BackgroundColor = Color.CornflowerBlue
                            }.Row(1),
                            new TextView
                            {
                                Text = "Center left",
                                FontSize = 30,
                            }.Row(1).HorizontalLayoutAlignment(LayoutAlignment.Start).VerticalLayoutAlignment(LayoutAlignment.Center),

                            new View
                            {
                                BackgroundColor = Color.DodgerBlue
                            }.Row(1).Column(1),
                            new TextView
                            {
                                Text = "Center center",
                                FontSize = 30,
                            }.Row(1).Column(1).HorizontalLayoutAlignment(LayoutAlignment.Center).VerticalLayoutAlignment(LayoutAlignment.Center),

                            new View
                            {
                                BackgroundColor = Color.DarkSlateBlue
                            }.Row(1).Column(2),
                            new TextView
                            {
                                Text = "Center right",
                                FontSize = 30,
                            }.Row(1).Column(2).HorizontalLayoutAlignment(LayoutAlignment.End).VerticalLayoutAlignment(LayoutAlignment.Center),

                            new View
                            {
                                BackgroundColor = Color.SteelBlue
                            }.Row(2),
                            new TextView
                            {
                                Text = "Lower left",
                                FontSize = 30,
                            }.Row(2).HorizontalLayoutAlignment(LayoutAlignment.Start).VerticalLayoutAlignment(LayoutAlignment.End),
                            
                            new View
                            {
                                BackgroundColor = Color.LightBlue
                            }.Row(2).Column(1),
                            new TextView
                            {
                                Text = "Lower center",
                                FontSize = 30,
                            }.Row(2).Column(1).HorizontalLayoutAlignment(LayoutAlignment.Center).VerticalLayoutAlignment(LayoutAlignment.End),
                            
                            new View
                            {
                                BackgroundColor = Color.BlueViolet
                            }.Row(2).Column(2),
                            new TextView
                            {
                                Text = "Lower right",
                                FontSize = 30,
                            }.Row(2).Column(2).HorizontalLayoutAlignment(LayoutAlignment.End).VerticalLayoutAlignment(LayoutAlignment.End)
                        }
                    },
                }
            });
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
