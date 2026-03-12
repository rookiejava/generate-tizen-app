using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class FlexBoxTest10 : ContentView, ITestCase
    {
        public FlexBoxTest10()
        {
            this.BackgroundColorFromHex("#FFFFFF");
            Body = new FlexBox
            {
                new FlexBox
                {
                    new TextView()
                        .Text("ViewGroupA")
                        .TextColorFromHex("#FFFFFF")
                        .FontSize(20)
                        .TextStart()
                }
                .Direction(FlexDirection.Column)
                .DesiredWidth(300)
                .AlignSelf(FlexAlignSelf.Stretch)
                .CenterItems()
                .CenterJustify()
                .Padding(100, 308, 100, 308)
                .BackgroundColorFromHex("#939393")
                .CornerRadius(50),

                new FlexBox
                {
                    new TextView()
                        .Text("ViewGroupB")
                        .TextColorFromHex("#FFFFFF")
                        .FontSize(20)
                        .TextStart()
                }
                .Direction(FlexDirection.Row)
                .DesiredHeight(300)
                .MinimumWidth(500)
                .MaximumWidth(1000)
                .Grow(1)
                .CenterItems()
                .CenterJustify()
                .Padding(10)
                .BackgroundColorFromHex("#939393")
                .CornerRadius(50)
                .Margin(70, 0, 0, 0),

                new FlexBox
                {
                    new View()
                        .BackgroundColorFromHex("#FF9F9F")
                        .DesiredSize(300, 232)
                        .CornerRadius(30),

                    new FlexBox
                    {
                        new TextView()
                            .Text("ViewGroupB")
                            .TextColorFromHex("#ffffff")
                            .FontSize(20)
                            .TextStart()
                    }
                    .Direction(FlexDirection.Row)
                    .CenterItems()
                    .CenterJustify()
                    .Padding(92, 70, 92, 70)
                    .DesiredSize(300, 232)
                    .BackgroundColorFromHex("#FF9F9F")
                    .CornerRadius(30)
                    .Margin(0, 30, 0, 0),

                    new View()
                        .BackgroundColorFromHex("#FF9F9F")
                        .DesiredSize(300, 232)
                        .CornerRadius(30)
                       .Margin(0, 30, 0, 0),

                }
                .Direction(FlexDirection.Column)
                .CenterItems()
                .CenterJustify()
                .Padding(50)
                .BackgroundColorFromHex("#939393")
                .CornerRadius(50)
                .Shrink(0)
                .Margin(70, 0, 0, 0),
            }
            .Direction(FlexDirection.Row)
            .CenterItems()
            .CenterJustify()
            .Padding(50)
            .BackgroundColorFromHex("#D1ECC8")
            .CornerRadius(50);
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
