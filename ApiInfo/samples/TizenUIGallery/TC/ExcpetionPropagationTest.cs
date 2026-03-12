using TizenUIGallery.Util;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class ExcpetionPropagationTest : Grid, ITestCase
    {
        public ExcpetionPropagationTest()
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
                Text = "ExcpetionPropagationTest",
                FontSize = 30,
            });
            Add(new VStack
            {
                new TextView
                {
                    Text = "Log...",
                    DesiredHeight = 500,
                    FontSize = 15,
                    Name = "Log",
                    IsMultiline = true,
                },
                new Button("make native excpetion")
                {
                    Clicked = () =>
                    {
                        (this["Log"] as TextView).Text = $"try throw excpetion .... ";
                        Task.Run(() =>
                        {
                            try
                            {
                                new View();
                            }
                            catch (Exception ex)
                            {
                                UIApplication.Current.PostToUI(() =>
                                {
                                    (this["Log"] as TextView).Text = $"Excpetion occurred\n{ex}";
                                });
                            }
                        });
                    }
                }
            }.Row(1));
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
