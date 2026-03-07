# API Summary: Tizen.UI.Tools

Source: `c:\workspace\temp\Generate_TizenApp\Packages\Tizen.UI.Tools.1.0.0-rc.5\lib\net8.0-tizen10.0\Tizen.UI.Tools.dll`
Generated (UTC): 2026-03-07T11:20:28.6915624+00:00

## Namespace `Tizen.UI.Tools`

### class `DumpViewTree`

- Base: `System.Object`
- Members:
  - `static .cctor()`
  - `.ctor()`
  - `public static String Dump()`
  - `public static Void Dump(Window window)`
  - `public static Void Dump(Layer view, Window parent)`
  - `public static Void Dump(View view, NObject parent)`
  - `public static String DumpInstance()`
  - `private static View GetBody(ContentView view)`
  - `private static ConcurrentDictionary<UInt32, WeakReference<View>> GetInstanceTable()`
  - `public static String ToHex(Color color)`

### class `Inspector`

- Base: `System.Object`
- Members:
  - `public static Void Start(Int32 port)`
  - `public static Void Stop()`

### class `WebServer`

- Base: `System.Object`
- Members:
  - `.ctor(Int32 port)`
  - `private String GetMimeType(String filename)`
  - `private Void Process(HttpListenerContext context)`
  - `public Void Start()`
  - `public Void Stop()`

## Extension Methods

- _(none)_

