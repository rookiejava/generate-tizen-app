using DeclarativeSample.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace DeclarativeSample
{
    public partial class HomeView : ContentView
    {
        void InitializeComponent()
        {
            Body = new AbsoluteLayout
            {
                // TitleScreenView
                new AbsoluteLayout
                {
                    new FlexBox
                    {
                        new Button("Read Information")
                                .Name("Button1")
                                .DesiredWidth(360)
                                .DesiredHeight(104)
                                .BackgroundColorFromHex("#9c9c9c8e"),
                        new View().Basis(20),
                        new Button("Watch Movie")
                            .Name("Button2")
                            .DesiredWidth(360)
                            .DesiredHeight(104)
                            .BackgroundColorFromHex("#9c9c9c8e"),
                    }
                    .LayoutBounds(1, 1, -1, -1)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .Margin(0, 0, 30, 30),

                }.Name("TitleScreenView")
                .LayoutBounds(0, 0, 1, 288)
                .LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.YProportional | AbsoluteLayoutFlags.WidthProportional)
                .Margin(132, 0, 0, 0)
                .Background(new ImageBackground().Url("HomeView/image_bdf20c83edb9cc3b1c96b1ba2a1bd630b0fb26bc.png")),

                // menu view
                new FlexBox
                {
                    new ImageView()
                        .ResourceUrl("HomeView/image_0501bb48512e3551323d2486d436d24018bc789a.png")
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_b4151edac073a3ef18e6149b2bd778576a72208c.png")
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_6a5438811e38db84b5cbf3951139d6b7fcee4f50.png")
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_61b42c24de586936a213c4a8095c2f200f85a211.png")
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_8c69435f6623fb63639ee11eb2ef8c12e59cd7e2.png")
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_9794436308e9b0a94233cc27310602e12d57925d.png")
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_f15e3e559bb542faf10eb7673db400ad6e96ce5e.png")
                        .Center(),
                }
                .Name("MenuView")
                .Direction(FlexDirection.Column)
                .CenterItems()
                .CenterJustify()
                .Padding(10)
                .BackgroundColorFromHex("#3f4358")
                .Fill()
                .LayoutBounds(0, 0, 132, 1)
                .LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.YProportional | AbsoluteLayoutFlags.HeightProportional),

                // AppsView / scrollview
                new FlexBox
                {
                    new ScrollLayout
                    {
                        Content = new HStack
                        {
                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_730f1fe85421951b45279847df3e2aa225331b22.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_a60912bd871a95dcd5282e1169cd83bda38893fc.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_7b05959d8404880dee9416b42dcf7b5101312159.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_7aed9bc7eecc996e9fd1b4a80417a262eafacc1a.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_63df5fae2b4130161d55a8266a6702e20980071c.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_e1770480d25ca6787d718cebf4b06a9eabf44f44.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_5d8435f15dbf7f8c83d077e48dfa18812b208c34.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_45ba345bbd40cc8cfe07eb859371f314c5ac3c1f.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_63df5fae2b4130161d55a8266a6702e20980071c.png")
                        }
                        .Spacing(50)
                    }
                    .ScrollHorizontal()
                    .Margin(50, 0, 50, 0)
                    .DesiredHeight(230)
                    .Shrink(0),

                    // on now
                    new TextView()
                        .Text("On Now")
                        .FontSize(30)
                        .TextColorFromHex("#ffffff")
                        .TextStartHorizontal()
                        .Margin(50, 0, 0, 0)
                        .Shrink(0),

                    new ScrollLayout
                    {
                        Content = new HStack
                        {
                            // cardview
                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_d17b52bb046b52b3be7f87254f943f45595d77f5.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),

                                // for new sticker
                                //new ImageView
                                //{
                                //    ResourceUrl = "HomeView/.....",
                                //}.LayoutBounds(new Rect(0, 0, -1, -1)).LayoutFlags(AbsoluteLayoutFlags.None),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),

                            // cardview
                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_354d454ca0c96093a60f0ee48a77e66a6f769844.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),

                                // for new sticker
                                //new ImageView
                                //{
                                //    ResourceUrl = "HomeView/.....",
                                //}.LayoutBounds(new Rect(0, 0, -1, -1)).LayoutFlags(AbsoluteLayoutFlags.None),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),

                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_bedcce857199c251bace03ea5704f6b5b3c3d30b.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),

                                // for new sticker
                                //new ImageView
                                //{
                                //    ResourceUrl = "HomeView/.....",
                                //}.LayoutBounds(new Rect(0, 0, -1, -1)).LayoutFlags(AbsoluteLayoutFlags.None),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),

                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_6782d2ef946031d0082350e5ab8ddff32840f2fb.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),

                                // for new sticker
                                //new ImageView
                                //{
                                //    ResourceUrl = "HomeView/.....",
                                //}.LayoutBounds(new Rect(0, 0, -1, -1)).LayoutFlags(AbsoluteLayoutFlags.None),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),

                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_7869bd74985903b244c81a849a10a93dcbc244a4.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),

                                // for new sticker
                                //new ImageView
                                //{
                                //    ResourceUrl = "HomeView/.....",
                                //}.LayoutBounds(new Rect(0, 0, -1, -1)).LayoutFlags(AbsoluteLayoutFlags.None),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),

                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_d17b52bb046b52b3be7f87254f943f45595d77f5.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),

                                // for new sticker
                                //new ImageView
                                //{
                                //    ResourceUrl = "HomeView/.....",
                                //}.LayoutBounds(new Rect(0, 0, -1, -1)).LayoutFlags(AbsoluteLayoutFlags.None),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),
                        }
                    }
                    .ScrollHorizontal()
                }
                .BackgroundColorFromHex("#68768b")
                .Direction(FlexDirection.Column)
                .LayoutBounds(0, 0, 1, 1)
                .LayoutFlags(AbsoluteLayoutFlags.All)
                .Margin(132, 288, 0, 0),
            }.Name("Frame")
             .BackgroundColorFromHex("#ffffff");
        }
    }
}
