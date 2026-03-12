using System;
using Tizen.Applications;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.NativeHandle;
using Tizen.UI.Scene3D;

namespace Scene3DTest.TC
{
    class CameraTransition : Grid, ITestCase
    {
        static readonly string resourcePath = Application.Current.DirectoryInfo.Resource;
        readonly Color backgrounColor = new Color(0.85f, 0.85f, 0.85f, 1.0f);
        readonly string IBL_DIFFUSE_URL = resourcePath + "image/Irradiance.ktx";
        readonly string IBL_SPECULAR_URL = resourcePath + "image/Radiance.ktx";
        const int cameraAnimationDurationMilliSeconds = 2000;
        const float fake3DGapForFridge = 0.03f;
        const float fake3DGapForCleaner = 0.01f;
        const int fake3Dcount = 5;

        bool cameraAnimating = false;
        int currentCameraIndex = 0;
        float IBLScaleFactor = 0.7f;
        readonly Vector3D focusTextAxis = new Vector3D(0.0f, 0.0f, 1.0f);
        readonly float focusTextAngle = 0.0f;

        Scene3DView _scene3DView;
        LottieAnimationView _lottieView;
        bool _isLottiePlaying = false;

        Model3D bicycle;
        Model3D bicycle2;
        Model3D airPurifier;
        ViewGroup cleanerGroup;
        ViewGroup fridgeGroup;

        TextView focusText;
        ImageView focusImage;
        NObject focusedItem;
        uint focusTextState = 0u;

        enum FocusedViewType
        {
            NONE = 0,
            VIEW_3D = 1,
            VIEW_2D = 2,
        }
        FocusedViewType focusedViewType = FocusedViewType.NONE;

        public CameraTransition()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = backgrounColor;

            Window.Default.TouchEvent += OnWindowTouchEvent;
            Window.Default.KeyEvent += OnWindowKeyEvent;

            FocusManager.Instance.EnableDefaultFocusAlgorithm(true);

            SetupScene3DView();
        }

        void OnWindowTouchEvent(object sender, TouchEventArgs e)
        {
            if (e.Touch[0].State == TouchState.Down)
            {
                float fov = _scene3DView.Cameras[0].FieldOfView;
                Point3D cameraPosition = _scene3DView.Cameras[0].Position;
                float nearPlain = _scene3DView.Cameras[0].NearPlaneDistance;
                float farPlain = _scene3DView.Cameras[0].FarPlaneDistance;

                Console.WriteLine($"cpos : {cameraPosition.Z}");
                Console.WriteLine($"fov :  {fov}");
                Console.WriteLine($"near : {nearPlain}");
                Console.WriteLine($"far  : {farPlain}");
            }
        }

        void OnWindowKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyEvent.State != KeyState.Down)
            {
                return;
            }

            if (e.KeyEvent.KeyPressedName == "Escape" || e.KeyEvent.KeyPressedName == "XF86Back" || e.KeyEvent.KeyPressedName == "BackSpace")
            {
                if (IsFocused())
                {
                    ClearFocus();
                }
            }

            if (cameraAnimating)
            {
                return;
            }

            if (e.KeyEvent.KeyPressedName == "5")
            {
                SwitchCamera();
            }
            else if (e.KeyEvent.KeyPressedName == "6")
            {
                SwitchCameraProjectionType();
            }
            else if (e.KeyEvent.KeyPressedName == "7")
            {
                if (IsFocused())
                {
                    if (focusTextState == 0u)
                    {
                        // FocusText facing camera
                        focusTextState = 1u;
                        focusText.SetRotation3D(_scene3DView.GetCurrentCamera().Rotation * new Quaternion(new Vector3D(0f, 1.0f, 0f), 180.0f));
                    }
                    else
                    {
                        // FocusText has static orientation
                        focusTextState = 0u;
                        focusText.SetRotation3D(new Quaternion(focusTextAxis, focusTextAngle));
                    }
                }
            }
            else if (e.KeyEvent.KeyPressedName == "8")
            {
                IBLScaleFactor = 1.0f - IBLScaleFactor;
                _scene3DView.ImageBasedLightScaleFactor = IBLScaleFactor;
            }
            else if (e.KeyEvent.KeyPressedName == "9")
            {
                if (_lottieView != null)
                {
                    if (_isLottiePlaying)
                    {
                        _isLottiePlaying = false;
                        _lottieView.Pause();
                    }
                    else
                    {
                        _isLottiePlaying = true;
                        _lottieView.Play();
                    }
                }
            }
            else
            {
                MoveCameraByKey(e.KeyEvent.KeyPressedName);
            }
            Console.WriteLine($"camera Position : {_scene3DView.GetCurrentCamera().Position.X}, {_scene3DView.GetCurrentCamera().Position.Y}, {_scene3DView.GetCurrentCamera().Position.Z}\n");
            Vector3D axis = _scene3DView.GetCurrentCamera().Rotation.Axis;
            float angle = _scene3DView.GetCurrentCamera().Rotation.Angle;
            Console.WriteLine($"axis : {axis.X}, {axis.Y}, {axis.Z}, {angle}");
        }

        void MoveCameraByKey(string keyPressedName)
        {
            Vector3D direction = new Vector3D(0.0f, 0.0f, 1.0f);
            float moveDisplacement = 0.2f;
            Quaternion leftDisplacement = new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), 2.0f);
            Quaternion rightDisplacement = new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), -2.0f);
            if (keyPressedName == "1")
            {
                // Turn left
                _scene3DView.GetCurrentCamera().Rotation = leftDisplacement * _scene3DView.GetCurrentCamera().Rotation;
            }
            if (keyPressedName == "2")
            {
                // Turn right
                _scene3DView.GetCurrentCamera().Rotation = rightDisplacement * _scene3DView.GetCurrentCamera().Rotation;
            }
            if (keyPressedName == "3")
            {
                if (currentCameraIndex == 1)
                {
                    // Top view mode. move upside
                    Vector3D rotUpDirection = _scene3DView.GetCurrentCamera().Rotation.Rotate(new Vector3D(0.0f, -1.0f, 0.0f));
                    rotUpDirection.Normalize();
                    Point3D cameraPosition = _scene3DView.GetCurrentCamera().Position;
                    cameraPosition.X += rotUpDirection.X * moveDisplacement;
                    cameraPosition.Z += rotUpDirection.Z * moveDisplacement;
                    _scene3DView.GetCurrentCamera().Position = cameraPosition;
                }
                else
                {
                    // Go forward
                    Vector3D rotDirection = _scene3DView.GetCurrentCamera().Rotation.Rotate(direction);
                    rotDirection.Normalize();
                    Point3D cameraPosition = _scene3DView.GetCurrentCamera().Position;
                    cameraPosition.X += rotDirection.X * moveDisplacement;
                    cameraPosition.Z += rotDirection.Z * moveDisplacement;
                    _scene3DView.GetCurrentCamera().Position = cameraPosition;
                }
            }
            if (keyPressedName == "4")
            {
                if (currentCameraIndex == 1)
                {
                    // Top view mode. move downside
                    Vector3D rotUpDirection = _scene3DView.GetCurrentCamera().Rotation.Rotate(new Vector3D(0.0f, -1.0f, 0.0f));
                    rotUpDirection.Normalize();
                    Point3D cameraPosition = _scene3DView.GetCurrentCamera().Position;
                    cameraPosition.X -= rotUpDirection.X * moveDisplacement;
                    cameraPosition.Z -= rotUpDirection.Z * moveDisplacement;
                    _scene3DView.GetCurrentCamera().Position = cameraPosition;
                }
                else
                {
                    // Go backward
                    Vector3D rotDirection = _scene3DView.GetCurrentCamera().Rotation.Rotate(direction);
                    rotDirection.Normalize();
                    Point3D cameraPosition = _scene3DView.GetCurrentCamera().Position;
                    cameraPosition.X -= rotDirection.X * moveDisplacement;
                    cameraPosition.Z -= rotDirection.Z * moveDisplacement;
                    _scene3DView.GetCurrentCamera().Position = cameraPosition;
                }
            }

            // Camera position changed. Rotate camera follower.
            RotateViewsFollowCamera();
        }

        void RotateViewsFollowCamera()
        {
            if (IsFocused())
            {
                if (focusTextState == 1u)
                {
                    // Update FocusText orientation to face Camera
                    focusText.SetRotation3D(_scene3DView.GetCurrentCamera().Rotation * new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), 180.0f));
                }
            }
        }

        bool IsFocused()
        {
            return focusedViewType != FocusedViewType.NONE;
        }

        void ClearFocus()
        {
            FocusManager.Instance.ClearFocus();
            focusedItem = null;
            _scene3DView.SetKeyEventRouteTarget(null);
            focusedViewType = FocusedViewType.NONE;
            (focusText.Parent as ViewGroup)?.Remove(focusText);
            (focusImage.Parent as ViewGroup)?.Remove(focusImage);
        }

        void SwitchCameraProjectionType()
        {
            var currentCamera = _scene3DView.GetCurrentCamera();
            if (currentCamera.UseOrthographicProjection)
            {
                currentCamera.UseOrthographicProjection = false;
            }
            else
            {
                currentCamera.OrthographicSize = 5.0f;
                currentCamera.UseOrthographicProjection = true;
            }
        }

        void SwitchCamera()
        {
            currentCameraIndex++;
            if (currentCameraIndex >= _scene3DView.Cameras.Count)
            {
                currentCameraIndex = 0;
            }
            _scene3DView.AnimateCameraTransition(_scene3DView.Cameras[currentCameraIndex], cameraAnimationDurationMilliSeconds);
        }

        void SetupScene3DView()
        {
            _scene3DView = new Scene3DView()
            {
                Name = "Scene3DView",
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                Focusable = true,
            };
            _scene3DView.SetImageBasedLightingSource(IBL_DIFFUSE_URL, IBL_SPECULAR_URL, IBLScaleFactor);

            SetupSceneViewCamera();
            MakeSceneViewComponents();
            MakeFocusIndicator();
            Add(_scene3DView);
        }

        void SetupSceneViewCamera()
        {
            // Default camera setting.
            _scene3DView.DefaultCamera.Position = new Point3D(-2.39f, -1.5f, 1.35f);
            _scene3DView.DefaultCamera.NearPlaneDistance = 0.5f;
            _scene3DView.DefaultCamera.FarPlaneDistance = 500.0f;
            _scene3DView.DefaultCamera.Rotation = new Quaternion(new Vector3D(-0.015874173f, 0.9989224f, 0.0436139f), 2.4441528f.RadianToDegree());
            _scene3DView.DefaultCamera.FieldOfView = 70.0f;

            // Additional camera setting (top view camera).
            Camera camera = new Camera()
            {
                Position = new Point3D(0.0f, -3.95f, 0.0f),
                NearPlaneDistance = 0.5f,
                FarPlaneDistance = 500.0f,
                // Rotate by XAxis first, and then rotate by YAxis
                Rotation = new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), 90.0f) * new Quaternion(new Vector3D(1.0f, 0.0f, 0.0f), -90.0f),
                FieldOfView = 70.0f,
            };
            _scene3DView.Add(camera);
        }

        void MakeFocusIndicator()
        {
            // focusImage to denote focused object's name.
            focusImage = new ImageView()
            {
                ResourceUrl = resourcePath + "image/floor.png",
                // focus image will be set under the focused object.
                ParentOrigin = OriginPoint.BottomCenter,
                PivotPoint = OriginPoint.Center,
                PositionUsesPivotPoint = true,
            };
            focusImage.SetRotation3D(new Quaternion(new Vector3D(1.0f, 0.0f, 0.0f), 90.0f));

            focusText = new TextView()
            {
                Y = -0.2f,
                Width = 300,
                Height = 200,
                FontSize = 20f.PointToPixel(),

                // focus text will be set on the focused object.
                ParentOrigin = OriginPoint.TopCenter,
                PivotPoint = OriginPoint.BottomCenter,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.End,
            };
            focusText.SetScale3D(0.01f, 0.01f, 1.0f);
        }

        void MakeSceneViewComponents()
        {
            // Home Model.
            Model3D home = new Model3D(resourcePath + "models/staircase/staircase.gltf");
            home.ResourceReady += (e, s) =>
            {
                Console.WriteLine($"Staircase size : {home.Size}");
            };
            _scene3DView.Add(home);

            // 2D TextLabel in 3D space
            // Current TextLabel is developed for 2D UI
            // So, even this textlabel can be drawn in 3D space but there is something to fix.
            // Text texture size is set as same as TextLabel.
            // So, if TextLabel size is very small to be used in 3D space, the text result become bad.
            // This problem will be fixed soon.
            // In this sample, we used large TextLabel size (400, 200) and scaled it amount of 1/100 to show it in the 3D space
            TextView livingRoomText = new TextView()
            {
                Text = "Living Room",
                Width = 400,
                Height = 200,
                FontSize = 35f.PointToPixel(),
                ParentOrigin = OriginPoint.Center,
                PivotPoint = OriginPoint.Center,
                PositionUsesPivotPoint = true,
            };
            livingRoomText.SetPosition3D(-0.8f, -0.1f, 1.0f);
            livingRoomText.SetScale3D(0.01f, 0.01f, 1);
            livingRoomText.SetRotation3D(new Quaternion(new Vector3D(0.0f, 1.0f, 0.0f), -90.0f) * new Quaternion(new Vector3D(1.0f, 0.0f, 0.0f), 90.0f));
            _scene3DView.Add(livingRoomText);

            // 2D ImageView in 3D space
            ImageView rightFrame = new ImageView()
            {
                ResourceUrl = resourcePath + "image/lake_front.jpg",
                FittingMode = FittingMode.ScaleToFill,
                Width = 1.13f,
                Height = 1.53f,
                ParentOrigin = OriginPoint.Center,
                PivotPoint = OriginPoint.Center,
                PositionUsesPivotPoint = true,
            };
            rightFrame.SetPosition3D(-0.1f, -1.6f, -3.55f);
            _scene3DView.Add(rightFrame);

            // 2D LottieAnimationView in 3D space with lottie.
            // Similar reason with TextLabel, lottie rasterize depend on LottieAnimationView's size as pixel scale.
            // In this sample, we use large LottieAnimationView size (340, 460) and scaled it amout of 1/300 to show it in the 3D space
            LottieAnimationView leftFrame = new LottieAnimationView()
            {
                ResourceUrl = resourcePath + "image/insta_camera.json",
                FittingMode = FittingMode.ScaleToFill,
                Width = 340f,
                Height = 460f,
                ParentOrigin = OriginPoint.Center,
                PivotPoint = OriginPoint.Center,
                PositionUsesPivotPoint = true,
            };
            leftFrame.SetPosition3D(-2.78f, -1.6f, -3.55f);
            leftFrame.SetScale3D(1.0f / 300.0f, 1.0f / 300.0f, 1);
            _scene3DView.Add(leftFrame);

            // As default, lottie animation stoped.
            // We should call Play API if we want.
            leftFrame.Play();

            // Store lottie view so that we can control it.
            _lottieView = leftFrame;
            _isLottiePlaying = true;

            bicycle = new Model3D(resourcePath + "models/bicycle/Old Bicycle.gltf")
            {
                Position = new Point3D(4, -0.1f, -2.5f),
            };
            bicycle.ResourceReady += (e, s) =>
            {
                // Some features of Model (PivotPoint, GetAnimation, and etc) should be called after resources are loaded.
                // This ResourcesLoaded callback can be used for it.
                Console.WriteLine($"Bicycle size : {bicycle.Size}\n");
            };
            bicycle.KeyEvent += (s, e) =>
            {
                focusImage.Width = bicycle.Size.Y;
                focusImage.Height = bicycle.Size.Z;
                focusImage.SetScale3D(1.2f, 1.2f, 1.0f);
                focusImage.SetPosition3D(bicycle.Position);
                _scene3DView.Add(focusImage);
                focusText.Text = "Bicycle1";
                focusText.SetPosition3D(bicycle.Position.X, bicycle.Position.Y - bicycle.Size.Y, bicycle.Position.Z);
                _scene3DView.Add(focusText);
                focusedViewType = FocusedViewType.VIEW_3D;
            };
            _scene3DView.Add(bicycle);

            bicycle2 = new Model3D(resourcePath + "models/bicycle/Old Bicycle.gltf")
            {
                Position = new Point3D(4, -0.1f, -1.5f),
            };
            bicycle2.ResourceReady += (s, e) =>
            {
                Console.WriteLine($"Bicycle2 size : {bicycle2.Size}\n");
            };
            bicycle2.KeyEvent += (s, e) =>
            {
                focusImage.Width = bicycle2.Size.Y;
                focusImage.Height = bicycle2.Size.Z;
                focusImage.SetScale3D(1.2f, 1.2f, 1.0f);
                focusImage.SetPosition3D(bicycle2.Position);
                _scene3DView.Add(focusImage);
                focusText.Text = "Bicycle2";
                focusText.SetPosition3D(bicycle2.Position.X, bicycle2.Position.Y - bicycle2.Size.Y, bicycle2.Position.Z);
                _scene3DView.Add(focusText);
                focusedViewType = FocusedViewType.VIEW_3D;
            };
            _scene3DView.Add(bicycle2);

            // samsung cube airPurifier
            // Maybe this model should be in Samsung.
            airPurifier = new Model3D(resourcePath + "models/air/air.gltf")
            {
                Position = new Point3D(-1.5f, -0.1f, -2.7f),
            };
            airPurifier.ResourceReady += (s, e) =>
            {
                Console.WriteLine($"airPurifier size : {airPurifier.Size}");
            };
            airPurifier.KeyEvent += (s, e) =>
            {
                focusImage.Width = airPurifier.Size.Y;
                focusImage.Height = airPurifier.Size.Z;
                focusImage.SetScale3D(2.0f, 2.0f, 1.0f);
                focusImage.SetPosition3D(airPurifier.Position);
                _scene3DView.Add(focusImage);
                focusText.Text = "Air Purifier";
                focusText.SetPosition3D(airPurifier.Position.X, airPurifier.Position.Y - airPurifier.Size.Y, airPurifier.Position.Z);
                _scene3DView.Add(focusText);
                focusedViewType = FocusedViewType.VIEW_3D;
            };
            _scene3DView.Add(airPurifier);

            // 2D ImageView group, focusable.
            fridgeGroup = new ViewGroup()
            {
                Width = 1.56f,
                Height = 1.56f,
                // To resolve z-fight, Position sightly above the bottom
                ParentOrigin = OriginPoint.Center,
                PivotPoint = OriginPoint.BottomCenter,
                PositionUsesPivotPoint = true,
                Focusable = false,

                // Option. We can notify to FocusManager that it's childrens are not focusable.
                // So, Don't need to check it's children. It will optimize focusable object search time.
                FocusableChildren = false,
            };
            fridgeGroup.SetPosition3D(new Point3D(1.5f, -0.05f, -2.7f));
            // Build fake 3d image view.
            for (int i = 0; i < fake3Dcount; ++i)
            {
                ImageView fridge = new ImageView()
                {
                    ResourceUrl = resourcePath + "image/fridge2.png",
                    FittingMode = FittingMode.FitHeight,
                    WidthResizePolicy = ResizePolicy.FillToParent,
                    HeightResizePolicy = ResizePolicy.FillToParent,
                    ParentOrigin = OriginPoint.Center,
                    PivotPoint = OriginPoint.Center,
                    PositionUsesPivotPoint = true,
                };
                fridge.SetPosition3D(0.0f, 0.0f, fake3DGapForFridge * i);
                fridgeGroup.Add(fridge);
            }
            _scene3DView.Add(fridgeGroup);

            // 2D ImageView group, focusable
            cleanerGroup = new ViewGroup()
            {
                Width = 1.36f,
                Height = 0.0f,
                ParentOrigin = OriginPoint.Center,
                PivotPoint = OriginPoint.BottomCenter,
                PositionUsesPivotPoint = true,
                Focusable = false,

                FocusableChildren = false,
            };
            // To resolve z-fight, Position sightly above the bottom
            cleanerGroup.SetPosition3D(1.0f, -0.05f, -0.5f);
            // Build fake 3d image view.s
            for (int i = 0; i < fake3Dcount; ++i)
            {
                ImageView cleaner = new ImageView()
                {
                    ResourceUrl = resourcePath + "image/cleaner.png",
                    FittingMode = FittingMode.ScaleToFit,
                    WidthResizePolicy = ResizePolicy.FillToParent,
                    HeightResizePolicy = ResizePolicy.DimensionDependency, // Same size as width
                    ParentOrigin = OriginPoint.BottomCenter,
                    PivotPoint = OriginPoint.Center,
                    PositionUsesPivotPoint = true,
                };
                cleaner.SetPosition3D(0.0f, -fake3DGapForCleaner * i, 0.0f);
                cleaner.SetRotation3D(new Quaternion(new Vector3D(1.0f, 0.0f, 0.0f), 90.0f));
                cleanerGroup.Add(cleaner);
            }
            _scene3DView.Add(cleanerGroup);

            _scene3DView.KeyEvent += (s, e) =>
            {
                if (e.KeyEvent.State == KeyState.Up)
                {
                    return;
                }

                if (e.KeyEvent.KeyPressedName == "Escape" || e.KeyEvent.KeyPressedName == "XF86Back" || e.KeyEvent.KeyPressedName == "BackSpace")
                {
                    if (IsFocused())
                    {
                        ClearFocus();
                    }
                }

                if (focusedItem == null)
                {
                    focusedItem = airPurifier;
                    _scene3DView.SetKeyEventRouteTarget(airPurifier);
                }

                if (focusedItem == bicycle)
                {
                    switch (e.KeyEvent.KeyPressedName)
                    {
                        case "Left":
                            focusedItem = fridgeGroup;
                            _scene3DView.SetKeyEventRouteTarget(null);
                            break;
                        case "Right":
                        case "Down":
                            focusedItem = bicycle2;
                            _scene3DView.SetKeyEventRouteTarget(bicycle2);
                            break;
                        default:
                            break;
                    }
                }
                else if (focusedItem == bicycle2)
                {
                    switch (e.KeyEvent.KeyPressedName)
                    {
                        case "Left":
                        case "Up":
                            focusedItem = bicycle;
                            _scene3DView.SetKeyEventRouteTarget(bicycle);
                            break;
                        case "Down":
                            focusedItem = cleanerGroup;
                            _scene3DView.SetKeyEventRouteTarget(null);
                            break;
                        default:
                            break;
                    }
                }
                else if (focusedItem == airPurifier)
                {
                    switch (e.KeyEvent.KeyPressedName)
                    {
                        case "Right":
                        case "Up":
                            focusedItem = fridgeGroup;
                            _scene3DView.SetKeyEventRouteTarget(null);
                            break;
                        case "Down":
                            focusedItem = cleanerGroup;
                            _scene3DView.SetKeyEventRouteTarget(null);
                            break;
                        default:
                            break;
                    }
                }
                else if (focusedItem == fridgeGroup)
                {
                    switch (e.KeyEvent.KeyPressedName)
                    {
                        case "Right":
                        case "Up":
                            focusedItem = bicycle;
                            _scene3DView.SetKeyEventRouteTarget(bicycle);
                            break;
                        case "Down":
                            focusedItem = cleanerGroup;
                            _scene3DView.SetKeyEventRouteTarget(null);
                            break;
                        case "Left":
                            focusedItem = airPurifier;
                            _scene3DView.SetKeyEventRouteTarget(airPurifier);
                            break;
                        default:
                            break;
                    }
                }
                else if (focusedItem == cleanerGroup)
                {
                    switch (e.KeyEvent.KeyPressedName)
                    {
                        case "Right":
                        case "Up":
                            focusedItem = bicycle2;
                            _scene3DView.SetKeyEventRouteTarget(bicycle2);
                            break;
                        case "Left":
                            focusedItem = airPurifier;
                            _scene3DView.SetKeyEventRouteTarget(airPurifier);
                            break;
                        default:
                            break;
                    }
                }

                SetViewGroupFocused();
            };
        }

        void SetViewGroupFocused()
        {
            if (focusedItem == fridgeGroup)
            {
                focusImage.Width = fridgeGroup.Width;
                focusImage.Height = fridgeGroup.Height;
                focusImage.SetScale3D(1.0f, 1.0f, 1.0f);
                focusImage.SetPosition3D(0.0f, 0.0f, 0.0f);
                fridgeGroup.Add(focusImage);
                focusText.Text = "Fridge";
                focusText.X = fridgeGroup.X;
                focusText.Y = fridgeGroup.Y - 0.5f;
                focusText.SetPosition3D(0.0f, 0.0f - 0.3f, fake3DGapForFridge * 4);
                fridgeGroup.Add(focusText);
                focusedViewType = FocusedViewType.VIEW_2D;
            }
            else if (focusedItem == cleanerGroup)
            {
                focusImage.Width = cleanerGroup.Width;
                focusImage.Height = cleanerGroup.Height;
                focusImage.SetScale3D(1.2f, 1.2f, 1.2f);
                focusImage.SetPosition3D(0.0f, 0.0f, 0.0f);
                cleanerGroup.Add(focusImage);
                focusText.Text = "Robot vacuum cleaner";
                focusText.SetPosition3D(0.0f, -fake3DGapForCleaner * 4, 0.0f);
                focusText.X = 0;
                focusText.Y = -0.5f;
                cleanerGroup.Add(focusText);
                focusedViewType = FocusedViewType.VIEW_2D;
            }
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Window.Default.TouchEvent -= OnWindowTouchEvent;
            Window.Default.KeyEvent -= OnWindowKeyEvent;
            Dispose();
        }
    }
}