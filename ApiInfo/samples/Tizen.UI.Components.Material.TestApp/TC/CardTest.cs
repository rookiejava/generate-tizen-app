using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    public class DefaultCard : Card
    {
        public Label TitleText;
        public Label MessageText;
        public Button ConfirmButton;
        public DefaultCard(string titleText, string messageText, string buttonText)
        {
            DesiredWidth = 458f;
            DesiredHeight = 456f;

            Content = new Grid()
            {
                RowDefinitions = { GridLength.Auto, GridLength.Star, GridLength.Auto },
                Children =
                {
                    new HStack()
                    {
                        ItemAlignment = LayoutAlignment.Center,
                        Spacing = 10f,
                        Padding = new (MaterialSpacing.Md200, MaterialSpacing.Md200, MaterialSpacing.Md100, MaterialSpacing.Sm60),
                        Children =
                        {
                            new Image()
                            {
                                DesiredWidth = 36f,
                                DesiredHeight = 36f,
                                ResourceUrl = MaterialIcon.Photo,
                                ImageMultipliedColor = MaterialColor.OnSurfaceContainerHighest
                            }.CenterVertical(),
                            new Label()
                            {
                                DesiredWidth = 322f,
                                Text = titleText,
                                FontSize = MaterialFontSize.Xs,
                                FontFamily = MaterialFont.Normal400,
                                TextColor = MaterialColor.OnSurfaceContainerHighest
                            }.CenterVertical().Self(out TitleText),
                            new Image()
                            {
                                DesiredWidth = 36f,
                                DesiredHeight = 36f,
                                ResourceUrl = MaterialIcon.ArrowRight,
                                ImageMultipliedColor = MaterialColor.OnSurfaceContainerHighest
                            }.CenterVertical(),
                        }
                    }
                    .Row(0),
                    new HStack()
                    {
                        Padding = new (MaterialSpacing.Md400, 0f),
                        Children =
                        {
                            new Label()
                            {
                                Text = messageText,
                                FontSize = MaterialFontSize.Sm,
                                FontFamily = MaterialFont.Normal400,
                                TextColor = MaterialColor.OnSurfaceContainerHighest,
                                IsMultiline = true,
                                LineBreakMode = LineBreakMode.Word,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }.Self(out MessageText)
                        }
                    }
                    .Row(1),
                    new HStack()
                    {
                        ItemAlignment = LayoutAlignment.End,
                        Padding = new (0f, MaterialSpacing.Sm80, MaterialSpacing.Md200, MaterialSpacing.Md200),
                        Children =
                        {
                            new Button(buttonText)
                            {
                                Padding = new (MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                FontSize = MaterialFontSize.Sm2,
                                FontFamily = MaterialFont.Normal600,
                                TextColor = MaterialColor.OnPrimary,
                                BackgroundColor = MaterialColor.Primary
                            }.Self(out ConfirmButton)
                            .MinimumWidth(144f)
                            .MinimumHeight(64f)
                        }
                    }
                    .Row(2)
                }
            };
        }
    }

    public class TranslucentCard : DefaultCard
    {
        public TranslucentCard(string titleText, string messageText, string buttonText) : base(titleText, messageText, buttonText)
        {
            BackgroundColor = MaterialColor.SurfaceContainerTranslucent;
        }
    }

    public class DefaultSmallCard : Card
    {
        public Label TitleText;
        public Label MessageText;
        public Button ConfirmButton;
        public DefaultSmallCard(string titleText, string messageText, string buttonText)
        {
            DesiredWidth = 400f;
            DesiredHeight = 364f;

            Content = new Grid()
            {
                RowDefinitions = { GridLength.Auto, GridLength.Star, GridLength.Auto },
                Children =
                {
                    new HStack()
                    {
                        ItemAlignment = LayoutAlignment.Center,
                        Spacing = 10f,
                        Padding = new (MaterialSpacing.Md200, MaterialSpacing.Sm80, MaterialSpacing.Md100, MaterialSpacing.Xs40),
                        Children =
                        {
                            new Image()
                            {
                                DesiredWidth = 40f,
                                DesiredHeight = 40f,
                                ResourceUrl = MaterialIcon.Photo,
                                ImageMultipliedColor = MaterialColor.OnSurfaceContainerHighest
                            }.CenterVertical(),
                            new Label()
                            {
                                DesiredWidth = 256f,
                                Text = titleText,
                                FontSize = 28f,
                                FontFamily = MaterialFont.Normal400,
                                TextColor = MaterialColor.OnSurfaceContainerHighest
                            }.CenterVertical().Self(out TitleText),
                            new Image()
                            {
                                DesiredWidth = 40f,
                                DesiredHeight = 40f,
                                ResourceUrl = MaterialIcon.ArrowRight,
                                ImageMultipliedColor = MaterialColor.OnSurfaceContainerHighest
                            }.CenterVertical()
                        }
                    }.Row(0),
                    new HStack()
                    {
                        Padding = new (MaterialSpacing.Md200, 0f),
                        Children =
                        {
                            new Label()
                            {
                                Text = messageText,
                                FontSize = 30f,
                                FontFamily = MaterialFont.Normal400,
                                TextColor = MaterialColor.OnSurfaceContainerHighest,
                                IsMultiline = true,
                                LineBreakMode = LineBreakMode.Word,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }.Self(out MessageText)
                        }
                    }.Row(1),
                    new HStack()
                    {
                        ItemAlignment = LayoutAlignment.End,
                        Padding = new (0f, MaterialSpacing.Xs40, MaterialSpacing.Sm80, MaterialSpacing.Sm80),
                        Children =
                        {
                            new Button(buttonText)
                            {
                                Padding = new (MaterialSpacing.Md100, MaterialSpacing.Xs20),
                                FontSize = 32f,
                                FontFamily = MaterialFont.Normal600,
                                TextColor = MaterialColor.OnPrimary,
                                BackgroundColor = MaterialColor.Primary
                            }.Self(out ConfirmButton)
                            .MinimumWidth(136f)
                            .MinimumHeight(68f)
                        }
                    }.Row(2)
                }
            };
        }
    }

    public class TranslucentSmallCard : DefaultSmallCard
    {
        public TranslucentSmallCard(string titleText, string messageText, string buttonText) : base(titleText, messageText, buttonText)
        {
            BackgroundColor = MaterialColor.SurfaceContainerTranslucent;
        }
    }

    internal class CardTest : ScrollView, ITestCase
    {
        public CardTest() : base()
        {
            BackgroundColor = Color.Black;

            const string contentText = "hac dictum mauris massa penatibus sapien iaculis ornare,"
            + "facilisi malesuada quam est ullamcorper fusce. Interdum etiam himenaeos sapien molestie"
            + "facilisi malesuada quam est sem tempus metus penatibusff sem tempus metus penatibusff.";

            Content = new Grid()
            {
                RowDefinitions = { GridLength.Auto, GridLength.Auto },
                ColumnDefinitions = { GridLength.Auto, GridLength.Auto },
                RowSpacing = 20f,
                ColumnSpacing = 20f,
                Children =
                {
                    new DefaultCard("Default Card", contentText, "Confirm").Row(0).Column(0),
                    new DefaultSmallCard("Default Small Card", contentText, "OK").Row(0).Column(1),
                    new TranslucentCard("Translucent Card", contentText, "Confirm").Row(1).Column(0),
                    new TranslucentSmallCard("Translucent Small Card", contentText, "OK").Row(1).Column(1),
                }
            };
        }

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }
    }
}
