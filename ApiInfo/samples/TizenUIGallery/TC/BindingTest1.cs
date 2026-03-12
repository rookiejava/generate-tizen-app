using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class BindingTest1 : Grid, ITestCase
    {
        public BindingTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Binding Test1",
                FontSize = 30,
            });

            var session = new BindingSession<string>();
            session.ViewModel = "Binding with . (binding on ViewModel itself)";

            var session2 = new BindingSession<MyModel>();
            session2.ViewModel = new MyModel();

            int count = 0;
            Add(new VStack
            {
                new TextView().FontSize(20).SetBinding(session, TextBindings<TextView>.TextProperty, "."),
                new TextView().FontSize(20).SetBinding(session2, (vm, v) => v.Text = $"Value : {vm.Value}, Value2 : {vm.Value2}", "*"),
                new Button("Update")
                {
                    Clicked = () =>
                    {
                        session.ViewModel = $"Binding with . (binding on ViewModel itself) ({++count})";
                        session2.ViewModel.Value = count;
                    }
                },
                new Button("Update2")
                {
                    Clicked = () =>
                    {
                        session.ViewModel = $"Binding with . (binding on ViewModel itself) ({++count})";
                        session2.ViewModel.Value2 = count * 2;
                    }
                }
            }.Row(1).Padding(10).Spacing(10));
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }

        class MyModel : ViewModel
        {
            public float Value { get => this.Get<float>(); set { this.Set(value); } }
            public float Value2 { get => this.Get<float>(); set { this.Set(value); } }

        }
    }
}
