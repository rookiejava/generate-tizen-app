using System;
using Tizen.Applications;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Scene3D;

namespace Scene3DTest.TC
{
    class BikeShopping : Grid, ITestCase
    {
        static readonly string resourcePath = Application.Current.DirectoryInfo.Resource;
        readonly Color backgrounColor = new Color(0.85f, 0.85f, 0.85f, 1.0f);
        readonly string IBL_DIFFUSE_URL = resourcePath + "image/forest_diffuse_cubemap.png";
        readonly string IBL_SPECULAR_URL = resourcePath + "image/forest_specular_cubemap.png";

        Scene3DView _scene3DView;
        Model3D _bicycleModel;
        Animation3D _bicycleAnimation;
        Grid _panel;

        public BikeShopping()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.85f, 0.85f, 0.85f, 1.0f);
            ColumnDefinitions.Add(Window.Default.GetSize().Width * 0.6f);
            ColumnDefinitions.Add(GridLength.Star);

            SetupScene3DView();
            SetupPanel();
        }

        void SetupScene3DView()
        {
            _scene3DView = new Scene3DView()
            {
                Name = "Scene3DView",
                BackgroundColor = backgrounColor

            };
            _scene3DView.SetImageBasedLightingSource(IBL_DIFFUSE_URL, IBL_SPECULAR_URL);

            var defaultCamera = _scene3DView.DefaultCamera;
            defaultCamera.Position = new Point3D(0.0f, 0.0f, 4.0f);
            defaultCamera.NearPlaneDistance = 0.5f;
            defaultCamera.FarPlaneDistance= 500.0f;

            _bicycleModel = new Model3D(resourcePath + "models/bicycle/Old Bicycle.gltf")
            {
                Size = new Size3D(3.2f, 3.0f, 0.0f)
            };

            _bicycleAnimation = new Animation3D()
            {
                Duration = 8000,
                IsLoop = true
            };
            float intervalAnimation = 0.25f;
            int duration = _bicycleAnimation.Duration;
            int delay = 0;
            for (int i = 0; i < 5; i++)
            {
                var endTime = duration * (i * intervalAnimation);
                _bicycleAnimation.AnimateTo(_bicycleModel, Animatable3DPropertyValue<Model3D>.CreateRotation3DValue(new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), 90.0f * i)), delay, (int)endTime - delay);
                delay = (int)endTime;
            }

            _bicycleModel.ResourceReady += (s, e) =>
            {
                _bicycleModel.PivotPoint = new Point3D(0.5f, 0.5f, 0.5f);
                _bicycleAnimation.Play();
            };

            _scene3DView.Add(_bicycleModel);
            Add(_scene3DView.Column(0));
        }

        void SetupPanel()
        {
            _panel = new Grid()
            {
                Children =
                {
                    new VStack()
                    {
                        BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 1.0f),
                        Children =
                        {
                            new TextView
                            {
                                Text = "[HOT DEAL]",
                                FontSize = 30f.PointToPixel(),

                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                                WidthResizePolicy = ResizePolicy.FillToParent,
                            },
                            new TextView
                            {
                                Text = "Vintage Bicycle",
                                FontSize = 18f.PointToPixel(),
                                TextColor = Color.DarkGray,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                                WidthResizePolicy = ResizePolicy.FillToParent,
                            }.Margin(0, 5, 0, 0),
                            new VStack()
                            {
                                Name= "InfoBox",
                                BackgroundColor = Color.White,
                                BorderlineColor = Color.Gray,
                                BorderlineWidth = 3,
                                Children =
                                {
                                    new TextView
                                    {
                                        Text = "Price : $499.0",
                                        FontSize = 25f.PointToPixel(),
                                        WidthResizePolicy = ResizePolicy.FillToParent,
                                    }.Margin(40, 40, 0, 0),
                                    new TextView
                                    {
                                        Text = "Stock : 1",
                                        FontSize = 25f.PointToPixel(),
                                        PivotPointX = 40,
                                    }.Margin(40, 10, 0, 0),
                                    new TextView
                                    {
                                        Text = "Delivery : Dec. 1 - 5",
                                        FontSize = 25f.PointToPixel()
                                    }.Margin(40, 10, 0, 0),
                                    new TextView
                                    {
                                        Text = "Express $5.8 ~",
                                        FontSize = 20f.PointToPixel(),
                                    }.Margin(40, 5, 0, 0),
                                    new TextView()
                                    {
                                        Text = "Add to Cart",
                                        FontSize = 20f.PointToPixel(),
                                        BackgroundColor = Color.YellowGreen,
                                        HorizontalAlignment = TextAlignment.Center,
                                        DesiredHeight = 70
                                    },
                                    new TextView()
                                    {
                                        Text = "Buy Now",
                                        FontSize = 20f.PointToPixel(),
                                        BackgroundColor = Color.OrangeRed,
                                        HorizontalAlignment = TextAlignment.Center,
                                        DesiredHeight = 70
                                    }

                                }
                            }.Margin(0, 40, 0, 0),
                            new VStack()
                            {
                                Name= "DetailBox",
                                BackgroundColor = Color.White,
                                BorderlineColor = Color.Gray,
                                BorderlineWidth = 3,
                                DesiredHeight = 300,
                                Children =
                                {
                                    new TextView
                                    {
                                        Text = "Product Detail",
                                        FontSize = 20f.PointToPixel(),
                                        HorizontalAlignment = TextAlignment.Center,
                                        VerticalAlignment = TextAlignment.Center,
                                    }.Margin(0, 10, 0, 0)
                                }
                            }.Margin(0, 40, 0, 0)
                        }
                    }
                }
            }.Column(1);
            Add(_panel);
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