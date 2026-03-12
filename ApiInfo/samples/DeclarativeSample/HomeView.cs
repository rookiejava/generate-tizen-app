using Tizen.UI;

namespace DeclarativeSample
{
    public partial class HomeView : ContentView
    {
        public HomeView()
        {
            InitializeComponent();
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
