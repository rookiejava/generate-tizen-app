using System;
using System.Collections.Generic;
using Scene3DTest.Util;
using Tizen.Applications;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Scene3D;

namespace Scene3DTest.TC
{
    class Scene3DViewTest1 : Grid, ITestCase
    {
        static string IBL_DIFFUSE_URL = Application.Current.DirectoryInfo.Resource + "image/forest_diffuse_cubemap.png";
        static string IBL_SPECULAR_URL = Application.Current.DirectoryInfo.Resource + "image/forest_specular_cubemap.png";

        // Model reference : https://sketchfab.com/models/b81008d513954189a063ff901f7abfe4
        // Get from KhronosGroup https://github.com/KhronosGroup/glTF-Sample-Models/tree/master/2.0/DamagedHelmet
        static string MODEL_URL = Application.Current.DirectoryInfo.Resource + "models/DamagedHelmet/DamagedHelmet.gltf";

        Model3D _model3D;
        Camera _camera;
        Camera _secondCamera;
        Animation3D _rotate3DAnimation;
        Animation3D _modelAnimation;

        Vector3D _animationAxis;
        float _animationAngleInDegree;
        Quaternion _animationQuaternion;

        Point3D _cameraPosition = new Point3D(0.0f, 0.0f, 5.55f);
        int _currentCameraIndex = 0;
        List<Camera> _additionalCameraList;

        bool _mutex = false; // Lock key event during some transition / Change informations

        public Scene3DViewTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.DarkOrchid;
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Scene3DViewTest1",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    Spacing = 10,
                    Children = {
                        new TextView
                        {
                            Name = "Log",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            WidthResizePolicy = ResizePolicy.FillToParent,
                            FontSize = 20,
                            DesiredHeight = 50,
                        },
                        new TextView
                        {
                            Name = "Log2",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            FontSize = 20,
                            DesiredHeight = 50,
                        },
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
                                //Camera Position Setting
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
                                //Camera Transition Animation
                                new TextView()
                                {
                                    Text = "Camera Transition Animation",
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
                                        //if (_mutex)
                                        //{
                                        //    return;
                                        //}
                                        var scene3DView = this["Scene3DView"] as Scene3DView;
                                        _currentCameraIndex++;
                                        if (_currentCameraIndex >= scene3DView.Cameras.Count)
                                        {
                                            _currentCameraIndex = 0;
                                        }
                                        Console.WriteLine($"Scene3DView - Cameras.Count:{scene3DView.Cameras.Count}");
                                        Console.WriteLine($"Scene3DView - AnimateCameraTransition({_currentCameraIndex})");
                                        scene3DView.AnimateCameraTransition(_currentCameraIndex == 0 ? _camera : _secondCamera, 2000);
                                        _mutex = true;
                                    }
                                }.Margin(3),
                                //Rotate Animation Setting
                                new TextView()
                                {
                                    Text = "Rotate Animation 3D (Model)",
                                    VerticalAlignment = TextAlignment.Center,
                                    HorizontalAlignment = TextAlignment.Center,
                                    DesiredHeight = 60,
                                    FontSize = 20
                                }.Margin(3),
                                new Button("Start")
                                {
                                    Name = "Start",
                                    Clicked = () =>
                                    {
                                        _animationQuaternion = new Quaternion(_animationAxis, _animationAngleInDegree);
                                        _rotate3DAnimation.AnimateBy(_model3D, Animatable3DPropertyValue<Model3D>.CreateRotation3DValue(_animationQuaternion), 0, 10000);
                                        _rotate3DAnimation.Play();
                                    }
                                }.Margin(3),
                                new Button("Stop")
                                {
                                    Name = "Stop",
                                    Clicked = () =>
                                    {
                                        _rotate3DAnimation.Stop();
                                    }
                                }.Margin(3),
                                new Button("Pause")
                                {
                                    Name = "Pause",
                                    Clicked = () =>
                                    {
                                        _rotate3DAnimation.Pause();
                                    }
                                }.Margin(3),
                                new Button("X + 0.1")
                                {
                                    Name = "X+",
                                    Clicked = () =>
                                    {
                                        _animationAxis.X+=0.1f;
                                    }
                                }.Margin(3),
                                new Button("X - 0.1")
                                {
                                    Name = "X-",
                                    Clicked = () =>
                                    {
                                        _animationAxis.X-=0.1f;
                                    }
                                }.Margin(3),
                                new Button("Y + 0.1")
                                {
                                    Name = "Y+",
                                    Clicked = () =>
                                    {
                                        _animationAxis.Y+=0.1f;
                                    }
                                }.Margin(3),
                                new Button("Y - 0.1")
                                {
                                    Name = "Y-",
                                    Clicked = () =>
                                    {
                                        _animationAxis.Y-=0.1f;
                                    }
                                }.Margin(3),
                                new Button("Z + 0.1")
                                {
                                    Name = "Z+",
                                    Clicked = () =>
                                    {
                                        _animationAxis.Z+=0.1f;
                                    }
                                }.Margin(3),
                                new Button("Z - 0.1")
                                {
                                    Name = "Z-",
                                    Clicked = () =>
                                    {
                                        _animationAxis.Z-=0.1f;
                                    }
                                }.Margin(3),
                                new Button("Angle + 10")
                                {
                                    Name = "A+",
                                    Clicked = () =>
                                    {
                                        _animationAngleInDegree += 10;
                                    }
                                }.Margin(3),
                                new Button("Angle - 10")
                                {
                                    Name = "A-",
                                    Clicked = () =>
                                    {
                                        _animationAngleInDegree -= 10;
                                    }
                                }.Margin(3),
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
                if (_mutex)
                {
                    _mutex = false;
                }
            };

            // 1. Set the IBL(Image Based Lighting) source to Scene3DView.
            scene3DView.SetImageBasedLightingSource(IBL_DIFFUSE_URL, IBL_SPECULAR_URL, 0.7f);

            // 2. Set the camera to Scene3DView.
            _camera = scene3DView.DefaultCamera;
            _camera.Position = _cameraPosition;
            _camera.Rotation = new Quaternion(new Vector3D(0, 1, 0), 180.0f);
            _camera.NearPlaneDistance = 0.5f;
            _camera.FarPlaneDistance = 50.0f;
            _camera.FieldOfView = 45.0f;

            _secondCamera = new Camera
            {
                Position = new Point3D(0.0f, -3.95f, 0.0f),
                Rotation = new Quaternion(new Vector3D(0, 1, 0), 90.0f) * new Quaternion(new Vector3D(1, 0, 0), -90.0f),
                NearPlaneDistance = 0.5f,
                FarPlaneDistance = 50.0f,
                FieldOfView = 70.0f
            };
            scene3DView.Add(_secondCamera);

            // 3. Set the light to Scene3DView.
            var light = new Light
            {
               MultipliedColor = Color.Yellow,
            };
            light.LookAt(new Vector3D(1.0f, 1.0f, 1.0f));
            scene3DView.Add(light);

            // 4. Set the model to Scene3DView.
            _model3D = new Model3D(MODEL_URL);

            _rotate3DAnimation = new Animation3D
            {
                IsLoop = true
            };
            _model3D.ResourceReady += (s, e) =>
            {
                Model3D model = s as Model3D;
                Console.WriteLine($"{model.Name} size : {model.Size}\n");
                Console.WriteLine($"Animation count {model.GetAnimationCount()} , Camera count {model.GetCameraCount()}\n");

                // You can play animation if the animation exists.
                if (model.GetAnimationCount() > 0)
                {
                    _modelAnimation = model.GetAnimation(0);
                    if (_modelAnimation != null)
                    {
                        _modelAnimation.IsLoop = true;
                        _modelAnimation.Play();
                    }
                }

                // You can apply camera properties if the camera parameter exists.
                if (model.GetCameraCount() > 0)
                {
                    _additionalCameraList = new List<Camera>();
                    bool firstSucceededCamera = true;
                    for (int i = 0; i < model.GetCameraCount(); ++i)
                    {
                        Camera additionalCamera = new Camera();
                        // If we success to make additional camera from model, Add that camera into sceneview, and select that.
                        if (model.ApplyCamera(i, additionalCamera))
                        {
                            scene3DView.Add(additionalCamera);
                            if (firstSucceededCamera)
                            {
                                _currentCameraIndex = scene3DView.Cameras.Count - 1;

                                Console.WriteLine($"Use additional camera [{_currentCameraIndex}]\n");
                                scene3DView.SetCurrentCamera(additionalCamera);
                                firstSucceededCamera = false;
                            }
                            _additionalCameraList.Add(additionalCamera);
                        }
                        else
                        {
                            Console.WriteLine($"Error! camera at [{i}] have some problem\n");
                            additionalCamera.Dispose();
                        }
                    }
                }

                // Auto rotate model only if it don't have camera.
                if (_model3D.GetCameraCount() == 0)
                {
                    _rotate3DAnimation.Play();
                    Console.WriteLine($"mModelRotateAnimation.Play()");
                }

                if (_mutex)
                {
                    _mutex = false;
                }
            };

            scene3DView.Add(_model3D);

            // 5. Animate to Model3D.
            _animationAxis = new Vector3D(0f, 1f, 0f);
            _animationAngleInDegree = 360.0f;
            _animationQuaternion = new Quaternion(_animationAxis, _animationAngleInDegree);
            _rotate3DAnimation.AnimateBy(_model3D, Animatable3DPropertyValue<Model3D>.CreateRotation3DValue(_animationQuaternion), 0, 10000);

            _mutex = true;

            // ETC
            var timer = new Timer(100)
            {
                TickHandler = () =>
                {
                    if (_rotate3DAnimation.State == AnimationState.Playing)
                    {
                        (this["X+"] as Button).IsVisible = false;
                        (this["X-"] as Button).IsVisible = false;
                        (this["Y+"] as Button).IsVisible = false;
                        (this["Y-"] as Button).IsVisible = false;
                        (this["Z+"] as Button).IsVisible = false;
                        (this["Z-"] as Button).IsVisible = false;
                        (this["A+"] as Button).IsVisible = false;
                        (this["A-"] as Button).IsVisible = false;
                    }
                    else
                    {
                        (this["X+"] as Button).IsVisible = true;
                        (this["X-"] as Button).IsVisible = true;
                        (this["Y+"] as Button).IsVisible = true;
                        (this["Y-"] as Button).IsVisible = true;
                        (this["Z+"] as Button).IsVisible = true;
                        (this["Z-"] as Button).IsVisible = true;
                        (this["A+"] as Button).IsVisible = true;
                        (this["A-"] as Button).IsVisible = true;
                    }

                    (this["Log"] as TextView).Text = $"Camera Position - [ X = {String.Format("{0:0.00}", _camera.Position.X)}, Y = {String.Format("{0:0.00}", _camera.Position.Y)}, Z = {String.Format("{0:0.00}", _camera.Position.Z)}], Near Distance : [{String.Format("{0:0.00}", _camera.NearPlaneDistance)}], Far Distance : [{String.Format("{0:0.00}", _camera.FarPlaneDistance)}], Field of View : [{String.Format("{0:0.00}", _camera.FieldOfView)}]";
                    (this["Log2"] as TextView).Text = $"Rotate Animation 3D - Quaternion(Axis : [ X = {String.Format("{0:0.00}", _animationAxis.X)}, Y = {String.Format("{0:0.00}", _animationAxis.Y)}, Z = {String.Format("{0:0.00}", _animationAxis.Z)}], Angle : [{_animationAngleInDegree}]) => (Axis : [ X = {String.Format("{0:0.00}", _animationQuaternion.Axis.X)}, Y = {String.Format("{0:0.00}", _animationQuaternion.Axis.Y)}, Z = {String.Format("{0:0.00}", _animationQuaternion.Axis.Z)}], Angle : [{_animationQuaternion.Angle}])"
                                                    + $", Animation Status - CurrentProgress:[{String.Format("{0:0.00}", _rotate3DAnimation.CurrentProgress)}], State : [{_rotate3DAnimation.State}] ";
                    return true;
                }
            };
            timer.Start();

            DetachedFromWindow += (s, e) =>
            {
                timer.Dispose();
            };
        }
    }
}
