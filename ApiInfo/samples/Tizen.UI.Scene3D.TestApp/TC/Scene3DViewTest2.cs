using System;
using Scene3DTest.Util;
using Tizen.Applications;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Scene3D;

namespace Scene3DTest.TC
{
    class Scene3DViewTest2 : Grid, ITestCase
    {
        static string IBL_DIFFUSE_URL = Application.Current.DirectoryInfo.Resource + "image/forest_diffuse_cubemap.png";
        static string IBL_SPECULAR_URL = Application.Current.DirectoryInfo.Resource + "image/forest_specular_cubemap.png";
        static string HOME_MODEL_URL = Application.Current.DirectoryInfo.Resource + "models/staircase/staircase.gltf";
        static string AVATAR_MODEL_URL = Application.Current.DirectoryInfo.Resource + "models/VDAvatar1/VDAvatar1.gltf";
        static string AVATAR_ANIMATION_URL = Application.Current.DirectoryInfo.Resource + "models/VDAvatar1/mv_011_body.bvh";

        Model3D _model3D;
        Model3D _avatar;
        Camera _camera;
        Camera _secondCamera;
        Animation3D _modelAnimation;
        Animation3D _avatarAnimation;
        Light _light;

        Point3D _cameraPosition = new Point3D(-2.79f, -1.5f, 1.55f);
        int _currentCameraIndex = 0;
        bool _isLookingAvatar;

        public Scene3DViewTest2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.85f, 0.85f, 0.85f, 1.0f);
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Scene3DViewTest2",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    Spacing = 10,
                    Children = {
                        new Scene3DView
                        {
                            Name = "Scene3DView",
                            DesiredHeight = Window.Default.GetSize().Height * 0.7f,
                            X = 0.0f,
                            Y = 0.0f
                        },
                        new FlexBox
                        {
                            Wrap = FlexWrap.Wrap,
                            Children =
                            {
                                new TextView()
                                {
                                    Text = "Camera Position",
                                    VerticalAlignment = TextAlignment.Center,
                                    HorizontalAlignment = TextAlignment.Center,
                                    DesiredHeight = 60,
                                    FontSize = 20
                                }.Margin(3),
                                new Button("X + 0.1")
                                {
                                    Clicked = () =>
                                    {
                                        _cameraPosition.X += .1f;
                                        _camera.Position = _cameraPosition;
                                    }
                                }.Margin(3),
                                new Button("X - 0.1")
                                {
                                    Clicked = () =>
                                    {
                                        _cameraPosition.X -= .1f;
                                        _camera.Position = _cameraPosition;
                                    }
                                }.Margin(3),
                                new Button("Y + 0.1")
                                {
                                    Clicked = () =>
                                    {
                                        _cameraPosition.Y += .1f;
                                        _camera.Position = _cameraPosition;
                                    }
                                }.Margin(3),
                                new Button("Y - 0.1")
                                {
                                    Clicked = () =>
                                    {
                                        _cameraPosition.Y -= .1f;
                                        _camera.Position = _cameraPosition;
                                    }
                                }.Margin(3),
                                 new Button("Z + 0.1")
                                {
                                    Clicked = () =>
                                    {
                                        _cameraPosition.Z += .1f;
                                        _camera.Position = _cameraPosition;
                                    }
                                }.Margin(3),
                                new Button("Z - 0.1")
                                {
                                    Clicked = () =>
                                    {
                                        _cameraPosition.Z -= .1f;
                                        _camera.Position = _cameraPosition;
                                    }
                                }.Margin(3),
                                new TextView()
                                {
                                    Text = "Camera Transition",
                                    VerticalAlignment = TextAlignment.Center,
                                    HorizontalAlignment = TextAlignment.Center,
                                    DesiredHeight = 60,
                                    FontSize = 20
                                }.Margin(3),
                                new Button("CameraTransition")
                                {
                                    Name = "Transit",
                                    Clicked = () =>
                                    {
                                        var scene3DView = this["Scene3DView"] as Scene3DView;
                                        _currentCameraIndex++;
                                        if (_currentCameraIndex >= scene3DView.Cameras.Count)
                                        {
                                            _currentCameraIndex = 0;
                                        }
                                        Console.WriteLine($"Scene3DView - Cameras.Count:{scene3DView.Cameras.Count}");
                                        Console.WriteLine($"Scene3DView - AnimateCameraTransition({_currentCameraIndex})");
                                        scene3DView.AnimateCameraTransition(_currentCameraIndex == 0 ? _camera : _secondCamera, 2000);
                                    }
                                }.Margin(3),
                                new TextView()
                                {
                                    Text = "Shadow",
                                    VerticalAlignment = TextAlignment.Center,
                                    HorizontalAlignment = TextAlignment.Center,
                                    DesiredHeight = 60,
                                    FontSize = 20
                                }.Margin(3),
                                new Button("On/Off")
                                {
                                    Name = "Shadow",
                                    Clicked = () =>
                                    {
                                        if (_light.IsShadowEnabled)
                                        {
                                            _light.IsShadowEnabled = false;
                                        }
                                        else
                                        {
                                            _light.IsShadowEnabled = true;
                                            _light.IsShadowSoftFilteringEnabled = true;
                                            _light.ShadowIntensity = 0.5f;
                                        }
                                    }
                                }.Margin(3),
                                new TextView()
                                {
                                    Text = "Camera LookAt",
                                    VerticalAlignment = TextAlignment.Center,
                                    HorizontalAlignment = TextAlignment.Center,
                                    DesiredHeight = 60,
                                    FontSize = 20
                                }.Margin(3),
                                new Button("Change")
                                {
                                    Name = "LookAt",
                                    Clicked = () =>
                                    {
                                        var scene3DView = this["Scene3DView"] as Scene3DView;
                                        var camera = scene3DView.GetCurrentCamera();

                                        if (_isLookingAvatar)
                                        {
                                            camera.LookAt(new Vector3D(1.5f, -1.02f, -2.7f));
                                            _isLookingAvatar = false;

                                        }
                                        else
                                        {
                                            camera.LookAt(new Vector3D(_avatar.Position));
                                            _isLookingAvatar = true;
                                        }
                                    }
                                }.Margin(3),
                                new Button("Orthographic")
                                {
                                    Name = "Orthographic",
                                    Clicked = () =>
                                    {
                                        var scene3DView = this["Scene3DView"] as Scene3DView;
                                        var camera = scene3DView.GetCurrentCamera();
                                        camera.UseOrthographicProjection = !camera.UseOrthographicProjection;
                                    }
                                }.Margin(3),
                                new TextView()
                                {
                                    Text = "Motion",
                                    VerticalAlignment = TextAlignment.Center,
                                    HorizontalAlignment = TextAlignment.Center,
                                    DesiredHeight = 60,
                                    FontSize = 20
                                }.Margin(3),
                                new Button("Play")
                                {
                                    Name = "Motion",
                                    Clicked = () =>
                                    {
                                        var motionData = new MotionDataSet( ) {
                                            Duration = 1000,
                                            DataSet =
                                            {
                                                new MotionData<Point3D>()
                                                {
                                                    MotionIndex = MotionIndex.CreateTransformIndex(TransformTypes.Position),
                                                    MotionValue =
                                                    {
                                                        (0.0f,  new Point3D(0.0f, 0.0f, 0.0f)),
                                                        (0.2f,  new Point3D(0.0f, -0.4f, 0.0f)),
                                                        (0.4f,  new Point3D(0.0f, -0.8f, 0.0f)),
                                                        (0.6f,  new Point3D(0.0f, -0.4f, 0.0f)),
                                                        (0.8f,  new Point3D(0.0f, -0.8f, 0.0f)),
                                                        (1.0f,  new Point3D(0.0f, 0.0f, 0.0f))
                                                    }
                                                },
                                                new MotionData<Quaternion>()
                                                {
                                                    MotionIndex = MotionIndex.CreateTransformIndex(TransformTypes.Rotation),
                                                    MotionValue =
                                                    {
                                                        (0.0f,  new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), 0)),
                                                        (0.3f,  new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), 180)),
                                                        (0.6f,  new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), -360)),
                                                        (0.9f,  new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), 180)),
                                                        (1.0f,  new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), 0))
                                                    }
                                                }
                                            }
                                        };
                                        var motionAnimation = _avatar.LoadMotionDataAnimation(motionData);
                                        motionAnimation?.Play();
                                    }
                                }.Margin(3)
                            }
                        }
                    }
                }
            }.Row(1));

            SetupScene3DView();
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }

        void SetupScene3DView()
        {
            var scene3DView = this["Scene3DView"] as Scene3DView;

            scene3DView.ResourceReady += (o, e) =>
            {
                Console.WriteLine($"Scene3DView - ResourceReady");
            };

            scene3DView.SetImageBasedLightingSource(IBL_DIFFUSE_URL, IBL_SPECULAR_URL, 0.3f);

            _camera = scene3DView.DefaultCamera;
            if (!_camera.UseOrthographicProjection)
            {
                _camera.Position = _cameraPosition;
                _camera.Rotation = new Quaternion(new Vector3D(-0.015874173f, 0.9989224f, 0.0436139f), (float)(2.4441528f*180/Math.PI));
                _camera.NearPlaneDistance = 0.5f;
                _camera.FarPlaneDistance = 50.0f;
                _camera.FieldOfView = 45.0f;
                _camera.OrthographicSize = 2.7f;
            }

            _secondCamera = new Camera
            {
                Position = new Point3D(0.0f, -3.95f, 0.0f),
                Rotation = new Quaternion(new Vector3D(0, 1, 0), 90.0f) * new Quaternion(new Vector3D(1, 0, 0), -90.0f),
                NearPlaneDistance = 0.5f,
                FarPlaneDistance = 50.0f,
                FieldOfView = 70.0f
            };
            scene3DView.Add(_secondCamera);

            _light = new Light
            {
               MultipliedColor = Color.Yellow,
            };
            _light.LookAt(new Vector3D(0.0f, 0.0f, 0.0f));
            scene3DView.Add(_light);

            _model3D = new Model3D(HOME_MODEL_URL);

            _model3D.ResourceReady += (s, e) =>
            {
                Model3D model = s as Model3D;
                if (model.GetAnimationCount() > 0)
                {
                    _modelAnimation = model.GetAnimation(0);
                    if (_modelAnimation != null)
                    {
                        _modelAnimation.IsLoop = true;
                        _modelAnimation.Play();
                    }
                }
            };

            scene3DView.Add(_model3D);

            AddSceneModel(scene3DView, "models/air/air.gltf", "airPurifier", "Air Purifier", new Point3D(-1.5f, -0.1f, -2.7f), new Size3D(0.36700073f, 0.4360007f, 0.38000005f));
            AddSceneModel(scene3DView, "models/washer/washer.gltf", "washer", "Washer", new Point3D(1.5f, -0.11f, -2.7f), new Size3D(300.0f * 0.005f, 204.39229f * 0.005f, 300.0f * 0.005f));
            AddSceneModel(scene3DView, "models/powerbot/powerbot.gltf", "powerbot", "Powerbot", new Point3D(1.0f, -0.11f, -0.5f), new Size3D(250.23553f * 0.005f, 42.981087f * 0.005f, 292.4035f * 0.005f));

            LoadAvatar(scene3DView);
        }

        void AddSceneModel(Scene3DView sceneView, string modelUrl, string modelName, string focusedText, Point3D position, Size3D size)
        {
            Model3D model = new Model3D(Application.Current.DirectoryInfo.Resource + modelUrl)
            {
                Position = position,
                Size = size,
                Name = modelName,
            };
            model.ResourceReady += (s, e) =>
            {
                Console.WriteLine($" Resource Ready: {(s as Model3D).Name} Size: {(s as Model3D).Size}");
                if (model.GetAnimationCount() > 0u)
                {
                    model.GetAnimation(0).IsLoop = true;
                    model.GetAnimation(0).Play();
                }
            };
            sceneView.Add(model);
        }

        void LoadAvatar(Scene3DView scene3DView)
        {
            _avatar = new Model3D(AVATAR_MODEL_URL)
            {
                Name = "AvatarModel",
            };
            _avatar.Position -= new Point3D(0.0f, 0.81f, 0.0f);
            _avatar.ResourceReady += (s, e) =>
            {
                Console.WriteLine($"Resource Ready: {(s as Model3D).Name} Size: {(s as Model3D).Size}");
                _avatarAnimation = _avatar.LoadBvhAnimation(AVATAR_ANIMATION_URL, new Vector3D(0.01f, 0.01f, 0.01f));
                _avatarAnimation.IsLoop = true;
                _avatarAnimation.Play();
            };
            scene3DView.Add(_avatar);
        }
    }
}
