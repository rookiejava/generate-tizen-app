using Tizen.Applications;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class FlexBoxTest2 : Grid, ITestCase
    {
        public FlexBoxTest2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);
            BackgroundColor = Color.Beige;
            Add(new FlexBox
            {
                Name = "FlexBox",
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.SpaceAround,
            });

            FlexBox flex = this["FlexBox"] as FlexBox;
            for (int i = 0; i < 30; i++)
            {
                flex.Add(new ImageView
                {
                    DesiredHeight = 100,
                    DesiredWidth = 100,
                    ResourceUrl = Application.Current.DirectoryInfo.Resource + "dotnet_bot.png",
                }.Margin(10));
            }
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
