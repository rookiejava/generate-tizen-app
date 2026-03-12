using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class ViewTemplateExample : AbsoluteLayout, ITestCase
    {
        class MyViewModel
        {
            public string Title { get; set; }
            public string Detail { get; set; }
            public string SubTitle { get; set; }
            public Color BG { get; set; }
        }

        class TemplateView : ViewGroup, IBindableView
        {
            public TemplateView()
            {
                BindingSession<MyViewModel> session = new BindingSession<MyViewModel>();
                SetAttached(session);

                BackgroundColor = Color.Green;
                Width = 200;
                Height = 300;

                this.SetBinding(session, ViewBindings.BackgroundColorProperty, "BG");

                var label = new TextView
                {
                    Width = 200,
                    Height = 60,
                    FontSize = 45,
                    X = 0,
                    Y = 0,
                };

                label.SetBinding(session, TextBindings<TextView>.TextProperty, "Title");
                Add(label);

                var subTitle = new TextView
                {
                    Width = 100,
                    Height = 20,
                    FontSize = 15,
                    X = 10,
                    Y = 60,
                };
                subTitle.SetBinding(session, TextBindings<TextView>.TextProperty, "SubTitle");
                Add(subTitle);

                var details = new TextView
                {
                    Y = 100,
                    Width = 200,
                    Height = 100,
                    FontSize = 20,
                    TextColor = Color.Black,
                    IsMultiline = true,
                };
                details.SetBinding(session, TextBindings<TextView>.TextProperty, "Detail");
                Add(details);
            }

            public object BindingContext
            {
                get => GetAttached<BindingSession<MyViewModel>>().ViewModel;
                set => GetAttached<BindingSession<MyViewModel>>().ViewModel = (MyViewModel)value;
            }
        }

        public ViewTemplateExample()
        {
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            var template = new ViewTemplate(() =>
            {
                return new TemplateView();
            });

            var generated = template.CreateContent();
            Add(generated.LayoutBounds(0, 0, generated.Width, generated.Height));

            (generated as IBindableView).BindingContext = new MyViewModel
            {
                Title = "Title1",
                SubTitle = "subTitle1",
                Detail = "This view is created by template, and apply some view model and all text are binding with view model",
                BG = Color.Green,
            };

            var generated2 = template.CreateContent();
            Add(generated2.LayoutBounds(210, 0, generated2.Width, generated2.Height));

            (generated2 as IBindableView).BindingContext = new MyViewModel
            {
                Title = "Title2",
                SubTitle = "subTitle2222",
                Detail = "This view also created same template that used to create Title1 view",
                BG = Color.Lime,
            };

            var generated3 = template.CreateContent();
            Add(generated3.LayoutBounds(420, 0, generated3.Width, generated3.Height));

            // it is same with .ViewModel property setter, but it is method so it can use null condition operator
            (generated3 as IBindableView).BindingContext = (new MyViewModel
            {
                Title = "Title3",
                SubTitle = "subTitle3333",
                Detail = "It also created by template",
                BG = Color.LightSkyBlue,
            });

            var template2 = new ViewTemplate(() =>
            {
                var view = new View
                {
                    Width = 10,
                    Height = 10,
                };
                BindingSession<MyViewModel> session = new BindingSession<MyViewModel>();
                view.BindingSession(session);
                view.SetBinding(session, ViewBindings.BackgroundColorProperty, "BG");
                return view;
            });

            Add(template2.CreateContent().LayoutBounds(0, 350, -1, -1).Name("Template2"));

            this["Template2"].BindingSession<MyViewModel>().ViewModel = new MyViewModel
            {
                BG = Color.BlueViolet
            };

            var templateSelector = new SelectorExample();

            var items = new string[] { "TextField", "TextEditor", "others" };
            int i = 0;
            foreach (var item in items)
            {
                var view = templateSelector.SelectTemplate(item, this).CreateContent();
                if (item == "TextField")
                {
                    (view as BindingTextField).Session.ViewModel = new MyViewModel
                    {
                        Title = "It is use case of TemplateSelector"
                    };
                }
                view.BackgroundColor = Color.Red;
                Add(view.LayoutBounds(0, 410 + i++ * 120, 400, 100));
            }
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }

        class SelectorExample : ViewTemplateSelector
        {
            ViewTemplate _textField = new ViewTemplate(typeof(BindingTextField));
            ViewTemplate _textEdtior = new ViewTemplate(typeof(TextEditor));
            ViewTemplate _label = new ViewTemplate(() => new TextView
            {
                Text = "A label for others",
                FontSize = 30,
            });

            protected override ViewTemplate OnSelectTemplate(object item, View container)
            {
                if ((string)item == "TextField")
                {
                    return _textField;
                }
                else if ((string)item == "TextEditor")
                {
                    return _textEdtior;
                }
                else
                {
                    return _label;
                }
            }
        }

        class BindingTextField : TextField
        {
            public BindingSession<MyViewModel> Session { get; } = new BindingSession<MyViewModel>();
            public BindingTextField()
            {
                this.SetBinding(Session, EditableTextBindings<TextField>.TextProperty, "Title");
            }
        }
    }
}
