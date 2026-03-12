using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class AlreadyHasParentTest : Grid, ITestCase
    {
        public AlreadyHasParentTest()
        {
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
                Text = "AlreadyHasParentTest",
                FontSize = 30,
            });

            Add(new VStack
            {
                new TextView
                {
                    IsMultiline = true,
                    Name = "Log"
                },
                new Button("Test Duplicated Add")
                {
                    Clicked = () =>
                    {
                        using var vg = new ViewGroup();
                        using var view1 = new View();
                        vg.Add(view1);
                        vg.Add(view1);
                        (this["Log"] as TextView).Text = $"Test1 view1 found on {(vg.IndexOf(view1))}\nParent of view1 is vg : {(view1.Parent == vg)}";
                    }
                },
                new Button("Test Duplicated Add2")
                {
                    Clicked = () =>
                    {
                        using var vg1 = new ViewGroup();
                        using var vg2 = new ViewGroup();
                        using var view1 = new View();
                        vg1.Add(view1);
                        vg2.Add(view1);
                        (this["Log"] as TextView).Text = $"View1 found on vg1 : ({vg1.IndexOf(view1)})\nView1 found on vg2 : ({vg2.IndexOf(view1)})\nParent of view1 : {(view1.Parent == vg1 ? "vg1" : "vg2")}";
                    }
                },
                new Button("Test Add self")
                {
                    Clicked = () =>
                    {
                        using var vg1 = new ViewGroup();
                        try
                        {
                            vg1.Children.Add(vg1);
                        }
                        catch (Exception ex)
                        {
                            (this["Log"] as TextView).Text = ex.Message;
                        }
                    }
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
