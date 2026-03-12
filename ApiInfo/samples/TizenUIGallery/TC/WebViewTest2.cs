using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using TizenUIGallery.Util;

namespace TizenUIGallery.TC
{
    class WebViewTest2 : Grid, ITestCase
    {
        WebView WebView => (this["WebView"] as WebView);

        public WebViewTest2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(60);
            RowDefinitions.Add(60);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "WebView Test2",
                FontSize = 30,
            });
            Add(new TextField
            {
                Name = "TextField",
                BackgroundColor = Color.FromHex("#D1FFBD"),
                PlaceholderText = "Input number",
                PlaceholderTextColor = Color.Gray,
            }.Row(1).Margin(10));

            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new Button("EvaluateJavaScriptAsync")
                    {
                        Clicked = async () =>
                        {
                            try
                            {
                                int number = int.Parse((this["TextField"] as TextField).Text);
                                string result = await WebView.EvaluateJavaScriptAsync($"factorial({number})");
                                (this["TextView"] as TextView).Text = $"Factorial of {number} is {result}.";
                            }
                            catch (Exception)
                            {
                                (this["TextView"] as TextView).Text = "Input number correctly";
                                (this["TextField"] as TextField).Text = "";
                            }
                            
                        }
                    },
                    new TextView
                    {
                        Name = "TextView",
                        TextColor = Color.Coral,
                    }
                }
            }.Row(2).Margin(10));

            string htmlSource = @"
                <html>
                    <body>
                        <script type=""text/javascript"">
                        function factorial(num) {
                                if (num === 0 || num === 1)
                                    return 1;
                                for (var i = num - 1; i >= 1; i--) {
                                    num *= i;
                                }
                                return num;
                        }
                        </script>
                        <div style='display: flex; flex-direction: column; justify-content: center; align-items: center; width: 100%'>
                            <h1 style='font-family: script'><i>Tizen.UI.WebView.EvaluateJavaScriptAsync() Test</i></h1>
                            <h2 style='font-family: script'>
                                <b>This test is designed to check if we can successfully invoke a JavaScript function using <i>WebView.EvaluateJavaScriptAsync()</i> and retrieve its result.</b><br/>
                                <b>Here are the steps for testing: </b>
                                <ol>
                                  <li>Enter a number into the text field for calculating factorial.</li>
                                  <li>Click the 'EvaluateJavaScriptAsync' button.</li>
                                  <li>The calculated result will be displayed in the entry. Check if the factorial calculation is correct.</li>
                                </ol> 
                            </h2>
                        </div>
                    </body>
                </html>
            ";

            var webView = new WebView
            {
                Name = "WebView",
                Source = new HtmlWebViewSource
                {
                    Html = htmlSource
                }
            };
            Add(webView.Row(3));
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
