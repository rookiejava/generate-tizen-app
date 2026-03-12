## Overview
`Tizen.UI.Tool` provides useful tools and utilites that can be utilized during Tizen.UI app development.

### Inspector
`Inspector` is a tool that allows you to analyze the UI structure of Tizen.UI apps. You can add `Inspector` to the app's code, through the browser, you can dynamically inspect the UI hierachy in real-time.

#### Usage

1. Start the `Inspector` in your app
```cs
protected override void OnCreate()
{
    Inspector.Start(5000); // use 5000 port for inspector
    base.OnCreate();
    LoadApplication(new App());
}
```

2. Set up SDB port fowarding for the specified port.
```powershell
> sdb forward tcp:5000 tcp:5000
```

3. Open the browser
```sh
http://localhost:5000/
```

### Tracer
`Tracer` is a tool that assists in app performance profiling using [Perfetto](https://perfetto.dev/docs/).

#### Usage

1. Start the `Tracer` in your app
```cs
Trace.Start();
```

2. Add the `TraceMarker` to the sections you want to inspect
```
protected override void OnCreate()
{
    using var trace = TraceMarker.Create("OnCreate");
    base.OnCreate();
    //...
}
```

3. Start the Web server
```cs
Trace.StartWebServer(5050); // use 5050 port for inspector
```

4. Set up SDB port fowarding for the specified port.
```powershell
> sdb forward tcp:5050 tcp:5050
```

5. Open the browser
```sh
http://localhost:5050/
```

6.  Start and Stop the Tracer