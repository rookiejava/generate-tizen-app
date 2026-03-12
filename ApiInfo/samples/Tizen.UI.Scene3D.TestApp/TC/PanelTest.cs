using Tizen.Applications;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Scene3D;

namespace Scene3DTest.TC
{
    class PanelTest : Grid, ITestCase
    {
        static readonly string resourcePath = Application.Current.DirectoryInfo.Resource;
        readonly string IBL_DIFFUSE_URL = resourcePath + "image/forest_diffuse_cubemap.png";
        readonly string IBL_SPECULAR_URL = resourcePath + "image/forest_specular_cubemap.png";

        Scene3DView _scene3DView;
        Grid _contentsInView;
        Grid _contentsInPanel;

        public PanelTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            SetupScene3DView();
        }

        void SetupScene3DView()
        {
            _scene3DView = new Scene3DView()
            {
                Name = "Scene3DView",
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = Color.FromRgba(0.3f, 0.3f, 0.3f, 0.3f),
                DesiredWidth = Window.Default.GetSize().Width * 0.9f,
                DesiredHeight = Window.Default.GetSize().Height * 0.9f,
            };
            _scene3DView.SetImageBasedLightingSource(IBL_DIFFUSE_URL, IBL_SPECULAR_URL);

            var defaultCamera = _scene3DView.DefaultCamera;
            defaultCamera.Position = new Point3D(0.0f, 0.0f, 20f);
            defaultCamera.NearPlaneDistance = 0.5f;
            defaultCamera.FarPlaneDistance= 100.0f;

            SetupContents();

            var image1 = new ImageView
            {
                ResourceUrl = resourcePath + "image/cleaner.png",
                DesiredWidth = 100,
                DesiredHeight = 100
            };
            _contentsInView.SetPosition3D(new Point3D(500.0f, 0.0f, 0.0f));
            _contentsInView.SetSize3D(new Size3D(300, 400, 0));

            _scene3DView.Add(new AbsoluteLayout
            {
                X = -4.0f,
                Y = -8.0f,
                DesiredWidth = 800,
                DesiredHeight = 400,
                ScaleX = 0.01f,
                ScaleY = 0.01f,
                Children =
                {
                    image1.LayoutBounds(0, 0, 100, 100),
                    _contentsInView.LayoutBounds(500, 0, 300, 400)
                }
            });

            var image2 = new ImageView
            {
                ResourceUrl = resourcePath + "image/cleaner.png",
                DesiredHeight = 100,
                DesiredWidth = 100

            };
            _contentsInPanel.SetPosition3D(new Point3D(0.0f, 3.0f, 0.0f));
            var modelForPanel = new Model3D
            {
                Children = {
                    new Panel()
                    {
                        Size = new Size3D(800.0f, 400.0f, 0.0f),
                        Scale = new Size3D(0.01f, 0.01f, 1.0f),
                        Content = new AbsoluteLayout
                        {
                            image2.LayoutBounds(0, 0, 100, 100),
                            _contentsInPanel.LayoutBounds(500, 0, 300, 400)
                        }
                    }
                }
            };
            _scene3DView.Add(modelForPanel);

            Add(_scene3DView);
        }

        void SetupContents()
        {
            _contentsInView = CreateContents();
            _contentsInPanel = CreateContents();
        }

        Grid CreateContents()
        {
            return new Grid
            {
                DesiredWidth = 300,
                DesiredHeight = 400,
                RowDefinitions =
                {
                    new GridRowDefinition
                    {
                        Height = GridLength.Star
                    },
                    new GridRowDefinition
                    {
                        Height = GridLength.Star
                    },
                    new GridRowDefinition
                    {
                        Height = GridLength.Star
                    }
                },
                Children =
                {
                    new TextView
                    {
                        Name = "Label1",
                        Text = "Panel Text",
                        FontSize = 60f.PointToPixel(),
                        TextColor = Color.Red,
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center,
                        BackgroundColor = Color.Aqua,
                    }.Row(0),
                    new ImageView
                    {
                        Name = "Image",
                        ResourceUrl = resourcePath + "image/cleaner.png",
                        HeightResizePolicy= ResizePolicy.Fixed,
                        WidthResizePolicy= ResizePolicy.Fixed,
                        BackgroundColor = Color.Red,
                    }.Row(1),
                    new TextView
                    {
                        Name = "Label2",
                        Text = "Panel Text",
                        FontSize = 60f.PointToPixel(),
                        TextColor = Color.Red,
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center,
                        WidthResizePolicy = ResizePolicy.FillToParent,
                        HeightResizePolicy = ResizePolicy.FillToParent,
                        BackgroundColor = Color.Green,
                    }.Row(2),
                }
            };
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