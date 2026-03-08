using System;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace WeatherApp;

public class MainView : ContentView
{
    public MainView()
    {
        WidthResizePolicy = ResizePolicy.FillToParent;
        HeightResizePolicy = ResizePolicy.FillToParent;
        BackgroundColor = Color.FromHex("#FAFAFA");

        Body = CreateContent();
    }

    private View CreateContent()
    {
        return new Scaffold
        {
            AppBar = new AppBar
            {
                Title = "날씨"
            },
            Content = new VStack
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                Spacing = 20, // Spacing between sections
                Children =
                {
                    // Current Weather Section
                    new VStack
                    {
                        WidthResizePolicy = ResizePolicy.FillToParent,
                        ItemAlignment = LayoutAlignment.Center, // Center children horizontally
                        Spacing = 10,
                        Children =
                        {
                            new Label
                            {
                                Text = "25°C",
                                FontSize = 80.0f,
                                FontWeight = FontWeight.Bold,
                                TextColor = Color.Black,
                                HorizontalAlignment = TextAlignment.Center
                            },
                            new Label
                            {
                                Text = "맑음",
                                FontSize = 30.0f,
                                TextColor = Color.Black,
                                HorizontalAlignment = TextAlignment.Center
                            }
                        }
                    },

                    // Divider
                    new Divider
                    {
                        DividerColor = Color.LightGray,
                        Thickness = 1.0f
                    },

                    // Weekly Forecast Section
                    new ListView
                    {
                        WidthResizePolicy = ResizePolicy.FillToParent,
                        HeightResizePolicy = ResizePolicy.FillToParent,
                        ItemsSource = GetWeeklyForecast(),
                        ItemTemplate = new ViewTemplate(() =>
                        {
                            return new HStack
                            {
                                WidthResizePolicy = ResizePolicy.FillToParent,
                                ItemAlignment = LayoutAlignment.Center,
                                Spacing = 15,
                                Children =
                                {
                                    new Label
                                    {
                                        Text = "{Binding Day}",
                                        FontSize = 20.0f,
                                        TextColor = Color.Black,
                                        WidthResizePolicy = ResizePolicy.Fixed,
                                        Width = 100.0f // Fixed width for day
                                    },
                                    new Image
                                    {
                                        ResourceUrl = "{Binding IconUrl}",
                                        Width = 40.0f,
                                        Height = 40.0f,
                                        ImageMultipliedColor = Color.Black // Adjust icon color if needed
                                    },
                                    new Label
                                    {
                                        Text = "{Binding MinMaxTemp}",
                                        FontSize = 20.0f,
                                        TextColor = Color.Black,
                                        HorizontalAlignment = TextAlignment.End, // Push to the right
                                        WidthResizePolicy = ResizePolicy.FillToParent
                                    }
                                }
                            };
                        })
                    }
                }
            }
        };
    }

    // Dummy data structure for weekly forecast
    public class WeatherForecast
    {
        public string Day { get; set; }
        public string IconUrl { get; set; } // e.g., "res/weather_sunny.png"
        public string MinMaxTemp { get; set; }
    }

    // Generate dummy weekly forecast data
    private List<WeatherForecast> GetWeeklyForecast()
    {
        return new List<WeatherForecast>
        {
            new WeatherForecast { Day = "월요일", IconUrl = "res/weather_sunny.png", MinMaxTemp = "18°C / 28°C" },
            new WeatherForecast { Day = "화요일", IconUrl = "res/weather_cloudy.png", MinMaxTemp = "19°C / 27°C" },
            new WeatherForecast { Day = "수요일", IconUrl = "res/weather_rainy.png", MinMaxTemp = "15°C / 22°C" },
            new WeatherForecast { Day = "목요일", IconUrl = "res/weather_sunny.png", MinMaxTemp = "17°C / 26°C" },
            new WeatherForecast { Day = "금요일", IconUrl = "res/weather_cloudy.png", MinMaxTemp = "19°C / 25°C" },
            new WeatherForecast { Day = "토요일", IconUrl = "res/weather_sunny.png", MinMaxTemp = "20°C / 29°C" },
            new WeatherForecast { Day = "일요일", IconUrl = "res/weather_sunny.png", MinMaxTemp = "21°C / 30°C" }
        };
    }
}