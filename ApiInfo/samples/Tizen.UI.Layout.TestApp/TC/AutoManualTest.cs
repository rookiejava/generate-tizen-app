using LayoutTest.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class AutoManualTest : ScrollLayout, ITestCase
    {
        HashSet<string> _presetList = new();
        JsonObject _lastDump;
        public AutoManualTest()
        {
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            var mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(100);
            mainGrid.RowDefinitions.Add(GridLength.Star);

            ScrollDirection = ScrollDirection.Vertical;
            Content = mainGrid;

            mainGrid.Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Auto Manual Test",
                FontSize = 30,
            });

            mainGrid.Add(new VStack
            {
                new TextView
                {
                    BackgroundColor = Color.White,
                    CornerRadius = 0.3f,
                    FontSize = 25,
                    Name = "ScreenState"
                }.HorizontalLayoutAlignment(LayoutAlignment.Start),
                new TextView
                {
                    FontSize = 25,
                    Name = "LastDump"
                }.HorizontalLayoutAlignment(LayoutAlignment.Start),
                new TextView
                {
                    FontSize = 20,
                    Text = "<font weight=bold>Set Client Size</font>",
                    IsMarkupEnabled = true,
                }.Margin(0, 20, 0, 0),
                new HStack
                {
                    new Button("1600x800")
                    {
                        Clicked = () =>
                        {
                            SetClientSize(1600, 800);
                        }
                    },
                    new Button("1280x720")
                    {
                        Clicked = () =>
                        {
                            SetClientSize(1280, 720);
                        }
                    },
                    new Button("720x480")
                    {
                        Clicked = () =>
                        {
                            SetClientSize(720, 480);
                        }
                    },
                    new Button("640x480")
                    {
                        Clicked = () =>
                        {
                            SetClientSize(640, 480);
                        }
                    },
                }.Spacing(10),

                new TextView
                {
                    FontSize = 20,
                    Text = "<font weight=bold>Dump all test case</font>",
                    IsMarkupEnabled = true,
                }.Margin(0, 20, 0, 0),
                new Button("Dump")
                {
                    Clicked = () =>
                    {
                        _ = Dump();
                    }
                },

                new Button("AutoTest - match with preset")
                {
                    Clicked = () =>
                    {
                        AutoTest();
                    }
                }.Margin(0, 20, 0, 0),

                new TextView
                {
                    FontSize = 20,
                    Text = "<font weight=bold>Compare last dump with preset result</font>",
                    IsMarkupEnabled = true,
                }.Margin(0, 50, 0, 0),

                new ScrollLayout
                {
                    ScrollDirection = ScrollDirection.Horizontal,
                    Content = new HStack
                    {
                        Spacing = 10,
                        Padding = 10,
                    }.Self(out var hstack).Attach(() =>
                    {
                        var dumpPath = UIApplication.Current.DirectoryInfo.Resource + "dump/";
                        var dumpfiles = Directory.GetFiles(dumpPath);
                        foreach (var dumpfile in dumpfiles)
                        {
                            _presetList.Add(Path.GetFileNameWithoutExtension(dumpfile));
                            hstack.Add(new Button($"Compare - {Path.GetFileNameWithoutExtension(dumpfile)}")
                            {
                                Clicked = () =>
                                {
                                    if (_lastDump == null)
                                    {
                                        (this["LastDump"] as TextView).Text = $"Error : No dump";
                                        return;
                                    }
                                    ComparePreset(Path.GetFileNameWithoutExtension(dumpfile));
                                }
                            });
                        }
                    })
                },

                new TextView
                {
                    FontSize = 20,
                    Text = "<font weight=bold>List of TCs that fails to match</font>",
                    IsMarkupEnabled = true,
                }.Margin(0, 50, 0, 0),
                new TextView
                {
                    Name = "Result",
                    FontSize = 20,
                    IsMultiline = true,
                }

            }.Row(1).Padding(10));

            (this["ScreenState"] as TextView).SetTextPadding(10);
            Relayout += OnRelayout;
        }

        async Task Dump()
        {
            Assembly asm = typeof(App).GetTypeInfo().Assembly;
            Type testCaseType = typeof(ITestCase);
            var tests = from test in asm.GetTypes()
                        where testCaseType.IsAssignableFrom(test) && !test.GetTypeInfo().IsInterface && !test.GetTypeInfo().IsAbstract
                        select test;

            JsonObject allDump = new JsonObject();
            foreach (var test in tests)
            {
                if (test == GetType())
                {
                    continue;
                }

                var tc = (ITestCase)Activator.CreateInstance(test);
                tc.Activate();
                await Task.Delay(2000);
                if (tc is View view)
                {
                    var dump = DumpViewTree(view);
                    allDump[tc.ToString()] = dump;
                }
                tc.Deactivate();
            }

            var clientSize = Window.Default.GetClientSize();
            var dpi = Window.Default.DPI;
            var path = UIApplication.Current.DirectoryInfo.Data + $"Dump_{clientSize.Width}_{clientSize.Height}_{dpi}.txt";
            File.WriteAllText(path, allDump.ToJsonString());

            (this["LastDump"] as TextView).Text = $"Current Dump - {clientSize.Width}x{clientSize.Height} - {dpi}";

            _lastDump = allDump;
        }

        async void AutoTest()
        {
            Window.Default.Maximize(true);
            await Task.Delay(50);
            var maxSize = Window.Default.GetClientSize();
            Window.Default.Maximize(false);
            await Task.Delay(50);
            if (maxSize.Width >= 1600 && maxSize.Height >= 800)
            {
                if (_presetList.Contains($"Dump_1600_800_{Window.Default.DPI}"))
                {
                    SetClientSize(1600, 800);
                    await Task.Delay(50);
                    await Dump();
                    ComparePreset($"Dump_1600_800_{Window.Default.DPI}");
                }
            }
            else if (maxSize.Width >= 1280 && maxSize.Height >= 720)
            {
                if (_presetList.Contains($"Dump_1280_720_{Window.Default.DPI}"))
                {
                    SetClientSize(1280, 720);
                    await Task.Delay(50);
                    await Dump();
                    ComparePreset($"Dump_1600_800_{Window.Default.DPI}");
                }
            }
            else if (maxSize.Width >= 720 && maxSize.Height >= 480)
            {
                if (_presetList.Contains($"Dump_720_480_{Window.Default.DPI}"))
                {
                    SetClientSize(720, 480);
                    await Task.Delay(50);
                    await Dump();
                    ComparePreset($"Dump_720_480_{Window.Default.DPI}");
                }
            }
            else if (maxSize.Width >= 640 && maxSize.Height >= 480)
            {
                if (_presetList.Contains($"Dump_640_480_{Window.Default.DPI}"))
                {
                    SetClientSize(640, 480);
                    await Task.Delay(50);
                    await Dump();
                    ComparePreset($"Dump_640_480_{Window.Default.DPI}");
                }
            }
            else
            {
                (this["Result"] as TextView).Text = "No matched resolution and DPI";
            }
        }

        JsonObject DumpViewTree(View view)
        {
            var node = new JsonObject();
            node["Width"] = view.Width;
            node["Height"] = view.Height;
            node["X"] = view.X;
            node["Y"] = view.Y;
            if (view is ViewGroup viewgroup)
            {
                node["Children"] = new JsonArray();
                foreach (var child in viewgroup)
                {
                    node["Children"].AsArray().Add(DumpViewTree(child));
                }
            }
            return node;
        }

        void OnRelayout(object sender, EventArgs e)
        {
            (this["ScreenState"] as TextView).Text = $"Client Size : {Window.Default.GetClientSize()}, DPI : {Window.Default.DPI}";
        }

        void SetClientSize(int width, int height)
        {
            var clientSize = Window.Default.GetClientSize();
            var windowSize = Window.Default.GetSize();
            var border = windowSize - clientSize;
            Window.Default.SetSize((ushort)(width + border.Width), (ushort)(height + border.Height));
        }

        void ComparePreset(string preset)
        {
            var dumpfile = UIApplication.Current.DirectoryInfo.Resource + $"dump/{preset}.txt";
            var jsonFromFile = File.ReadAllText(dumpfile);
            var json = JsonSerializer.Deserialize<JsonObject>(jsonFromFile);
            StringBuilder sb = new();
            foreach (var tc in _lastDump)
            {
                if (json.ContainsKey(tc.Key))
                {
                    var a = json[tc.Key].ToJsonString();
                    var b = tc.Value.ToJsonString();
                    if (a != b)
                    {
                        sb.AppendLine($"[{tc.Key}]");
                    }
                }
            }

            string result = "Pass all TCs";
            if (sb.Length > 0)
            {
                result = sb.ToString();
            }
            (this["Result"] as TextView).Text = result;
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
