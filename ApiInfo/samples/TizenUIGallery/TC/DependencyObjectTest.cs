using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    
    public class DependencyObjectTest : Grid, ITestCase
    {
        public DependencyObjectTest()
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
                Text = "DependencyObject Test",
                FontSize = 30,
            });

            Add(new LayoutExample
            {
                Name = "Layout",
                BackgroundColor = Color.Gray,
                Children =
                {
                    new View
                    {
                        BackgroundColor = Color.Yellow,
                    }.Attach(new AbsoluteLayoutParam
                    {
                        Bounds = new Rect(0, 0, 1, 1),
                        LayoutFlags = AbsoluteLayoutFlags.All
                    }),

                    new View
                    {
                        BackgroundColor = Color.Red,
                    }.Attach(new AbsoluteLayoutParam
                    {
                        Bounds = new Rect(20, 20, 0.5f, 0.5f),
                        LayoutFlags = AbsoluteLayoutFlags.SizeProportional
                    }),

                    new View
                    {
                        BackgroundColor = Color.Green,
                    }.Attach(new AbsoluteLayoutParam
                    {
                        Bounds = new Rect(0.5f, 0.5f, 100, 100),
                        LayoutFlags = AbsoluteLayoutFlags.PositionProportional,
                    }),

                    new View
                    {
                        BackgroundColor = Color.Blue,
                    }.Attach(new AbsoluteLayoutParam
                    {
                        Bounds = new Rect(0.5f, 0.8f, 0.5f, 100),
                        LayoutFlags = AbsoluteLayoutFlags.PositionProportional| AbsoluteLayoutFlags.WidthProportional,
                    })
                }

            }.Row(1));

            var view = new View
            {
                BackgroundColor = Color.BurlyWood
            };

            view.Attach(new AbsoluteLayoutParam
            {
                Bounds = new Rect(0.5f, 30, 100, 100),
                LayoutFlags = AbsoluteLayoutFlags.XProportional
            });

            (this["Layout"] as LayoutExample).Add(view);

            (this["Layout"] as LayoutExample).Relayout += (s, e) =>
            {
                (this["Layout"] as LayoutExample).LayoutUpdate();
            };
        }

        class LayoutExample : ViewGroup 
        {
            public void LayoutUpdate()
            {
                foreach (var child in Children)
                {
                    var param = child.GetAttached<AbsoluteLayoutParam>();
                    if (param != null)
                    {
                        if (param.LayoutFlags.HasFlag(AbsoluteLayoutFlags.XProportional))
                        {
                            child.X = Width * param.Bounds.X;
                        }
                        else
                        {
                            child.X = param.Bounds.X;
                        }

                        if (param.LayoutFlags.HasFlag(AbsoluteLayoutFlags.YProportional))
                        {
                            child.Y = Height * param.Bounds.Y;
                        }
                        else
                        {
                            child.Y = param.Bounds.Y;
                        }

                        if (param.LayoutFlags.HasFlag(AbsoluteLayoutFlags.WidthProportional))
                        {
                            child.Width = Width * param.Bounds.Width;
                        }
                        else
                        {
                            child.Width = param.Bounds.Width;
                        }

                        if (param.LayoutFlags.HasFlag(AbsoluteLayoutFlags.HeightProportional))
                        {
                            child.Height = Height * param.Bounds.Height;
                        }
                        else
                        {
                            child.Height = param.Bounds.Height;
                        }
                    }
                }
            }
        }

        [Flags]
        enum AbsoluteLayoutFlags
        {
            None = 0,
            XProportional = 1 << 0,
            YProportional = 1 << 1,
            WidthProportional = 1 << 2,
            HeightProportional = 1 << 3,
            PositionProportional = 1 | 1 << 1,
            SizeProportional = 1 << 2 | 1 << 3,
            All = ~0
        }

        class AbsoluteLayoutParam
        {
            public Rect Bounds { get; set; }
            public AbsoluteLayoutFlags LayoutFlags { get; set; }
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
