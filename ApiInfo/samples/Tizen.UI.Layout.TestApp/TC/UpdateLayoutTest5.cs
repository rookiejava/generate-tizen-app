using LayoutTest.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class UpdateLayoutTest5 : Grid, ITestCase
    {
        IEnumerable<string> _words = @"Why does my row have a yellow and black warning stripe?
If the non-flexible contents of the row (those that are not wrapped in Expanded or Flexible widgets) are together wider than the row itself, then the row is said to have overflowed. When a row overflows, the row does not have any remaining space to share between its Expanded and Flexible children. The row reports this by drawing a yellow and black striped warning box on the edge that is overflowing. If there is room on the outside of the row, the amount of overflow is printed in red lettering.

Story time
Suppose, for instance, that you had this code:

const Row(
  children: <Widget>[
    FlutterLogo(),
    Text(""Flutter's hot reload helps you quickly and easily experiment, build UIs, add features, and fix bug faster. Experience sub-second reload times, without losing state, on emulators, simulators, and hardware for iOS and Android.""),
    Icon(Icons.sentiment_very_satisfied),
  ],
)
The row first asks its first child, the FlutterLogo, to lay out, at whatever size the logo would like. The logo is friendly and happily decides to be 24 pixels to a side. This leaves lots of room for the next child. The row then asks that next child, the text, to lay out, at whatever size it thinks is best.

At this point, the text, not knowing how wide is too wide, says ""Ok, I will be thiiiiiiiiiiiiiiiiiiiis wide."", and goes well beyond the space that the row has available, not wrapping. The row responds, ""That's not fair, now I have no more room available for my other children!"", and gets angry and sprouts a yellow and black strip.".Split();


        List<double> _history = new();

        public UpdateLayoutTest5()
        {
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "UpdateLayout Test5",
                FontSize = 30,
            });

            Add(new VStack
            {
                new HStack
                {
                    new Button("Update1")
                    {
                        Clicked = () =>
                        {
                            (this["Target"] as TextView).Text = "!!!!!!!!!!!!! Body!!!!!!!!!";
                        }
                    },
                    new Button("Update2")
                    {
                        Clicked = () =>
                        {
                            (this["Target"] as TextView).Text = "Body";
                        }
                    },
                    new Button("Test1")
                    {
                        Clicked = async () =>
                        {
                            var scroller = this["Scroll"] as ScrollLayout;
                            for (int i = 0; i < 10; i++)
                            {
                                Task waitable = null;
                                if (i % 2 == 0)
                                {
                                    waitable = scroller.ScrollTo(scroller.ScrollSize.Width, true);
                                }
                                else
                                {
                                    waitable = scroller.ScrollTo(0, true);
                                }
                                var label = (this["Target"] as TextView);
                                var old = label.Text;
                                for (int j = 0; j < 10; j++)
                                {
                                    label.Text += "!!!!";
                                    await Task.Delay(30);
                                    label.Text = old;
                                    await Task.Delay(30);
                                }

                                await waitable;
                            }
                        }
                    },
                    new Button("Test2")
                    {
                        Clicked = () =>
                        {
                            UIApplication.Current.PostToUI(() =>
                            {
                                var stopwatch = Stopwatch.StartNew();
                                (this["Target"] as TextView).Text += "!";
                                UIApplication.Current.PostToUI(() =>
                                {
                                    (this["Log"] as TextView).Text = $"Elapsed ms : {stopwatch.ElapsedMilliseconds}";
                                    _history.Add(stopwatch.ElapsedMilliseconds);
                                    if (_history.Count % 10 == 0)
                                    {
                                        var total = _history.TakeLast(10).Sum();
                                        (this["Log"] as TextView).Text += $" Avg(last 10) : {total/10d}";
                                        _history.Clear();
                                    }
                                });
                            });
                        }
                    },
                    new TextView
                    {
                        DesiredHeight = 100,
                        DesiredWidth = 400,
                        Name = "Log",
                        FontSize = 20,
                    }

                }.Spacing(10),
                new ScrollLayout
                {
                    Name = "Scroll",
                    ScrollDirection = ScrollDirection.Horizontal,
                    Content = new HStack
                    {
                        new HStack
                        {
                            new TextView { Text = "Heading..", FontSize = 30, BackgroundColor = Color.LightCoral },
                            new TextView { Text = "Body ...", Name = "Target", FontSize = 30 },
                            new TextView { Text = "Footer...", FontSize = 30, BackgroundColor = Color.LightCoral}
                        }
                    }.Self(out var stack).Attach(() =>
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            stack.Add(CreateFlexBox().Margin(10));
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            stack.Add(CreateNestedFlexBox().Margin(10));
                        }
                    })
                }.Expand()
            }.Row(1));
        }

        View CreateFlexBox()
        {
            return new ScrollLayout
            {
                Content = new FlexBox
                {
                    BackgroundColor = Color.White,
                    CornerRadius = 0.1f,
                    Direction = FlexDirection.Column,
                }.MaximumWidth(200).Self(out var layout).Attach(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        layout.Add(new TextView
                        {
                            IsMultiline = true,
                            FontSize = 20,
                            TextColor = Color.Black,
                            Text = $"{i} - {GenerateText()}"
                        }.Margin(5));
                    }
                })
            };
        }

        View CreateNestedFlexBox()
        {
            return new FlexBox
            {
                DesiredWidth = 300,
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                Children =
                {
                    CreateInnerFlexBox(),
                    CreateInnerFlexBox(),
                    CreateInnerFlexBox(),
                    CreateInnerFlexBox(),
                    CreateInnerFlexBox(),
                    CreateInnerFlexBox(),
                    CreateInnerFlexBox(),
                    CreateInnerFlexBox(),
                    CreateInnerFlexBox(),
                    CreateInnerFlexBox(),
                    CreateInnerFlexBox(),
                }
            };
        }

        View CreateInnerFlexBox()
        {
            return new FlexBox
            {
                BackgroundColor = Color.White,
                Direction = FlexDirection.Column,

            }.Self(out var self).Attach(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    self.Add(new TextView
                    {
                        FontSize = 20,
                        IsMultiline = true,
                        Text = GenerateText()
                    });
                }
            });
        }

        int current = 0;
        string GenerateText(int count = 30)
        {
            current += count;
            if (current >= _words.Count())
                current = 0;
            return string.Join(" ", _words.Skip(current).Take(count));
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

    static class AttachedCode
    {
        public static T Attach<T>(this T self, Action action) where T : class
        {
            action.Invoke();
            return self;
        }
    }
}
