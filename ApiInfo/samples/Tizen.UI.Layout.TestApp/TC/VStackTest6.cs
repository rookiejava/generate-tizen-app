using LayoutTest.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class VStackTest6 : ViewGroup, ITestCase
    {
        public VStackTest6()
        {
            Add(new AbsoluteLayout
            {
                new VStack
                {
                    new ImageView()
                        .Name("ImageView")
                        .DesiredHeight(154)
                        .ResourceUrl("image_7869bd74985903b244c81a849a10a93dcbc244a4.png"),

                    new TextView()
                        .Text("Lorem plsum")
                        .TextColorFromHex("#565656")
                        .MultiLine(true)
                        .FontSize(30),

                    new HStack
                    {
                        new Button("2Summary")
                            .DesiredSize(150, 49),
                        new Button("Watch").DesiredSize(150, 49),
                    }
                    .Name("HStack")
                    .Spacing(20)
                    .HorizontalLayoutAlignment(LayoutAlignment.Fill)
                    .ItemAlignment(LayoutAlignment.Center),

                }
                .Name("VStack")
                .Spacing(20)
                .LayoutBounds(0, 0, 1, 1)
                .LayoutFlags(AbsoluteLayoutFlags.All)
                .Padding(100)
                .DesiredSize(420, 470)
                .CornerRadius(10)
                .BackgroundColorFromHex("#93bebebe")


            }.BackgroundColorFromHex("#69778B"));

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
