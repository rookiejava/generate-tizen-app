using Tizen.UI;

namespace DeclarativeSample
{
    partial class App : UIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            Window.Default.DefaultLayer.Add(new HomeView());

            Window.Default.AddAvailableOrientation(WindowOrientation.Portrait);
            Window.Default.AddAvailableOrientation(WindowOrientation.Landscape);
            Window.Default.AddAvailableOrientation(WindowOrientation.PortraitInverse);
            Window.Default.AddAvailableOrientation(WindowOrientation.LandscapeInverse);

            Window.Default.KeyEvent += Default_KeyEvent;
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnTerminate()
        {
            base.OnTerminate();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        void Default_KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyEvent.State == KeyState.Up && e.KeyEvent.KeyPressedName == "XF86Back")
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            App app = new App();
            app.Run(args);
        }
    }
}
