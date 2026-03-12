using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class FontScaleTest : Grid, ITestCase
    {
        public FontScaleTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "System Font Scale test",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    Name = "Stack",
                    Spacing = 4,
                    Children =
                    {
                        new TextView
                        {
                            Name = "Label1",
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "[TextView] FontSize : 30",
                            TextColor = Color.Black,
                            FontSize = 30,
                        },
                        new TextView
                        {
                            Name = "Label2",
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "[TextView] FontSize(Fixed) : 30 ",
                            TextColor = Color.Black,
                            FontSize = 30,
                            SystemFontScaleEnabled = false,
                        },
                        new TextField
                        {
                            Name = "TextField1",
                            BackgroundColor = Color.FromRgb(100, 100, 100),
                            BorderlineColor = Color.Gray,
                            BorderlineWidth = 1,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            PlaceholderText = "[TextField] FontSize : 30",
                            FontSize = 30,
                        },
                        new TextField
                        {
                            Name = "TextField2",
                            BackgroundColor = Color.FromRgb(100, 100, 100),
                            BorderlineColor = Color.Gray,
                            BorderlineWidth = 1,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            PlaceholderText = "[TextField] FontSize : 30",
                            FontSize = 30,
                            SystemFontScaleEnabled = false,
                        },
                        new TextEditor
                        {
                            Name = "TextEditor1",
                            BackgroundColor = Color.FromRgb(100, 100, 100),
                            BorderlineColor = Color.Gray,
                            BorderlineWidth = 1,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            PlaceholderText = "[TextEditor] FontSize : 30",
                            FontSize = 30,
                        },
                        new TextEditor
                        {
                            Name = "TextEditor2",
                            BackgroundColor = Color.FromRgb(100, 100, 100),
                            BorderlineColor = Color.Gray,
                            BorderlineWidth = 1,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            PlaceholderText = "[TextEditor] FontSize : 30",
                            FontSize = 30,
                            SystemFontScaleEnabled = false,
                        },
                    }
                }
            }.Row(1));

            SystemFontSizeManager.FontScaleChanged += (s, e) =>
            {
                UIApplication.Current.PostToUI(() => UpdateText());
            };
            UIApplication.Current.PostToUI(() => UpdateText());
        }

        void UpdateText()
        {
            if (IsDisposed)
                return;

            if (this["Label1"] is TextView label1)
            {
                label1.Text = $"[Label1] FontSize : {label1.FontSize}, ScaledFontSize : {label1.ScaledFontSize} , real height {label1.Height}";
                label1.StartTextScroll();
            }
            if (this["Label2"] is TextView label2)
            {
                label2.Text = $"[Label2/Fixed] FontSize : {label2.FontSize}, ScaledFontSize : {label2.ScaledFontSize} , real height {label2.Height}";
                label2.StartTextScroll();
            }
            if (this["TextField1"] is TextField textfield1)
            {
                textfield1.Text = $"[TextField1] FontSize : {textfield1.FontSize}, ScaledFontSize : {textfield1.ScaledFontSize} , real height {textfield1.Height}";
            }
            if (this["TextField2"] is TextField textfield2)
            {
                textfield2.Text = $"[TextField2/Fixed] FontSize : {textfield2.FontSize}, ScaledFontSize : {textfield2.ScaledFontSize} , real height {textfield2.Height}";
            }
            if (this["TextEditor1"] is TextEditor textEditor1)
            {
                textEditor1.Text = $"[TextEditor1] FontSize : {textEditor1.FontSize}, ScaledFontSize : {textEditor1.ScaledFontSize} , real height {textEditor1.Height}";
            }
            if (this["TextEditor2"] is TextEditor textEditor2)
            {
                textEditor2.Text = $"[TextEditor2/Fixed] FontSize : {textEditor2.FontSize}, ScaledFontSize : {textEditor2.ScaledFontSize} , real height {textEditor2.Height}";
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
