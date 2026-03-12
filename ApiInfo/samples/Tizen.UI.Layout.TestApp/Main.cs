//#define PERFTRACE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tizen.UI;
using Tizen.UI.Tools;
using Tizen.UI.WindowBorder;

namespace LayoutTest
{
    partial class App : UIApplication
    {
        TestList _mainList;
        protected override void OnCreate()
        {
#if PERFTRACE
            using var trace = PerfTrace.TraceMarker.Create("OnCreate");
#endif
            base.OnCreate();

            Inspector.Start(5050);

            Console.WriteLine("OnCreate");
            _mainList = new TestList(GetTestCase());
            Window.Default.DefaultLayer.Add(_mainList);

            Window.Default.AddAvailableOrientation(WindowOrientation.Portrait);
            Window.Default.AddAvailableOrientation(WindowOrientation.Landscape);
            Window.Default.AddAvailableOrientation(WindowOrientation.PortraitInverse);
            Window.Default.AddAvailableOrientation(WindowOrientation.LandscapeInverse);

            Window.Default.KeyEvent += Default_KeyEvent;

            DisplayMetrics.SetDensityBasedScaleFactor();

            // Window manager bug, it not consider height of task bar
            Window.Default.SetSize((ushort)Window.Default.GetSize().Width, (ushort)(Window.Default.GetSize().Height - 200));
            Window.Default.SetBorderView(new BorderView());
            FocusManager.Instance.EnableDefaultFocusAlgorithm(true);
        }

        IEnumerable<Type> GetTestCase()
        {
            Assembly asm = typeof(App).GetTypeInfo().Assembly;
            Type testCaseType = typeof(ITestCase);
            var tests = from test in asm.GetTypes()
                        where testCaseType.IsAssignableFrom(test) && !test.GetTypeInfo().IsInterface && !test.GetTypeInfo().IsAbstract
                        select test;
            return tests;
        }

        protected override void OnResume()
        {
            base.OnResume();
#if PERFTRACE
            PerfTrace.Trace.AddAsyncEndEvent("MAIN", "0");
            PerfTrace.Trace.WebUIStart(5050);
#endif
            Console.WriteLine("OnResume");
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
            Console.WriteLine($"KeyEvent : {e.KeyEvent.State} - {e.KeyEvent.KeyPressedName}");
            if (e.KeyEvent.State == KeyState.Up && e.KeyEvent.KeyPressedName == "XF86Back")
            {
                if (!_mainList.BackButtonPressed())
                {
                    Console.WriteLine("before call window dispose");
                    Window.Default.Dispose();
                    Console.WriteLine("after call window dispose");
                    Exit();
                }
            }
        }

        static void Main(string[] args)
        {
#if PERFTRACE
            Console.WriteLine("Test..");
            PerfTrace.Trace.TraceStart();
            PerfTrace.TraceMarker.Create("MAIN").Dispose();
            var trace = PerfTrace.TraceMarker.Create("App");
#endif
            App app = new App();
#if PERFTRACE
            trace.Dispose();
            PerfTrace.Trace.AddAsyncStartEvent("MAIN", "0");
#endif
            app.Run(args);
        }
    }
}
