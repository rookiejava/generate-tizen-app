using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using TizenUIGallery.Util;

namespace TizenUIGallery.TC
{
    class WebViewTest1 : Grid, ITestCase
    {
        WebView WebView => (this["WebView"] as WebView);

        public WebViewTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(60);
            RowDefinitions.Add(60);
            RowDefinitions.Add(60);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "WebView Test1",
                FontSize = 30,
            });
            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new Button("www.naver.com")
                    {
                        Clicked = () =>
                        {
                            WebView.Source = "http://www.naver.com";
                        }
                    },
                    new Button("www.google.com")
                    {
                        Clicked = () =>
                        {
                            WebView.Source = "http://www.google.com";
                        }
                    },
                    new Button("HTML")
                    {
                        Clicked = () =>
                        {
                           WebView.Source = new HtmlWebViewSource
                           {
                               Html = @"<HTML><BODY><H1>Tizen.UI</H1><P>Welcome to WebView.</P></BODY></HTML>"
                           };
                        }
                    },
                }
            }.Row(1).Margin(10));

            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new Button("GoBack")
                    {
                        Clicked = () =>
                        {
                            Console.WriteLine($"CanGoBack? : {WebView.CanGoBack}");
                            if(WebView.CanGoBack)
                            {
                                 WebView.GoBack();
                            }

                        }
                    },
                    new Button("GoForward")
                    {
                        Clicked = () =>
                        {
                            Console.WriteLine($"CanGoForward? : {WebView.CanGoForward}");
                            if(WebView.CanGoForward)
                            {
                                WebView.GoForward();
                            }
                        }
                    },
                    new Button("Reload")
                    {
                        Clicked = () =>
                        {
                           WebView.Reload();
                        }
                    }
                }
            }.Row(2).Margin(10));

            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new TextView
                    {
                        Name = "TextView"
                    }
                }
            }.Row(3).Margin(10));

            var webView = new WebView
            {
                Name = "WebView",
                Source = "http://www.naver.com"
            };
            webView.NavigationStarted += OnNavigationStarted;
            webView.NavigationCompleted += OnNavigationCompleted;
            Add(webView.Row(4));
        }

        void OnNavigationStarted(object sender, WebNavigationEventArgs e)
        {
            (this["TextView"] as TextView).Text = "State : NavigationStarted";
            Console.WriteLine($"OnNavigationStarted - Url: {e.Url}");

        }
        void OnNavigationCompleted(object sender, WebNavigationEventArgs e)
        {
            (this["TextView"] as TextView).Text = "State : NavigationCompleted";
            Console.WriteLine($"OnNavigationCompleted - Url: {e.Url}");
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
