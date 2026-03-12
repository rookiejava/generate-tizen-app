//#define PERFTRACE
//#define INSPECTOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tizen.UI;
#if PERFTRACE || INSPECTOR
using Tizen.UI.Tools;
#endif

namespace Scene3DTest
{
    partial class App : UIApplication
    {
        TestList _mainList;
        protected override void OnCreate()
        {
#if PERFTRACE
            using var trace = TraceMarker.Create("OnCreate");
#endif
#if INSPECTOR
            Inspector.Start(5050);
#endif
            base.OnCreate();

            Console.WriteLine("OnCreate");
            _mainList = new TestList(GetTestCase());

            Window.Default.DefaultLayer.Add(_mainList);
            Window.Default.AddAvailableOrientation(WindowOrientation.Portrait);
            Window.Default.AddAvailableOrientation(WindowOrientation.Landscape);
            Window.Default.AddAvailableOrientation(WindowOrientation.PortraitInverse);
            Window.Default.AddAvailableOrientation(WindowOrientation.LandscapeInverse);

            Window.Default.KeyEvent += Default_KeyEvent;
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
            Tracer.AddAsyncEndEvent("MAIN", "0");
            Tracer.StartWebServer(5050);
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
            Tracer.Start();
            TraceMarker.Create("MAIN").Dispose();
            var trace = TraceMarker.Create("App");
#endif
            App app = new App();
#if PERFTRACE
            trace.Dispose();
            Tracer.AddAsyncStartEvent("MAIN", "0");
#endif
            app.Run(args);
        }
    }
}
