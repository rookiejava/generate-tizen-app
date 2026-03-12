using System;
using Tizen.Applications;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Scene3D;

namespace Scene3DTest.TC
{
    class CharacterAnimation : Grid, ITestCase
    {
        static readonly string resourcePath = Application.Current.DirectoryInfo.Resource;
        readonly Color backgrounColor = new Color(0.85f, 0.85f, 0.85f, 1.0f);
        readonly string IBL_DIFFUSE_URL = resourcePath + "image/Irradiance.ktx";
        readonly string IBL_SPECULAR_URL = resourcePath + "image/Radiance.ktx";

        Scene3DView _scene3DView;
        Model3D _characterModel;
        Animation3D _characterAnimation;

        public CharacterAnimation()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = backgrounColor;

            SetupScene3DView();
        }

        void SetupScene3DView()
        {
            _scene3DView = new Scene3DView()
            {
                Name = "Scene3DView",
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent
            };
            _scene3DView.SetImageBasedLightingSource(IBL_DIFFUSE_URL, IBL_SPECULAR_URL, 0.5f);

            var defaultCamera = _scene3DView.DefaultCamera;
            defaultCamera.Position = new Point3D(0.0f, -0.7f, 4.0f);
            defaultCamera.NearPlaneDistance = 0.5f;
            defaultCamera.FarPlaneDistance= 500.0f;

            _characterModel = new Model3D(resourcePath + "models/CesiumMan/CesiumMan.gltf")
            {
                Name = "CesiumMan"
            };
            _characterModel.TouchEvent += (s, e) =>
            {
                _characterAnimation?.Play();
            };
            _characterAnimation = new Animation3D();
            _characterModel.ResourceReady += (s, e) =>
            {
                _characterAnimation = _characterModel.GetAnimation(0);
            };

            _scene3DView.Add(_characterModel);
            Add(_scene3DView);
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