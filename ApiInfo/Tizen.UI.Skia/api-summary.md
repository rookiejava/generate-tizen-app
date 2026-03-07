# API Summary: Tizen.UI.Skia

Source: `c:\workspace\temp\Generate_TizenApp\Packages\Tizen.UI.Skia.1.0.0-rc.5\lib\net8.0-tizen10.0\Tizen.UI.Skia.dll`
Generated (UTC): 2026-03-07T11:20:28.6871491+00:00

## Namespace `Tizen.UI.Skia`

### class `CustomRenderingView`

- Base: `Tizen.UI.ImageView`
- Members:
  - `.ctor()`
  - `public event EventHandler<SKPaintSurfaceEventArgs> PaintSurface`
  - `private Void <Invalidate>b__7_0()`
  - `public Void add_PaintSurface(EventHandler<SKPaintSurfaceEventArgs> value)`
  - `public Void Invalidate()`
  - `protected Void OnDrawFrame()`
  - `private Void OnRelayout(Object sender, EventArgs e)`
  - `protected Void OnResized()`
  - `public Void remove_PaintSurface(EventHandler<SKPaintSurfaceEventArgs> value)`
  - `protected Void SendPaintSurface(SKPaintSurfaceEventArgs e)`

### class `SKCanvasView`

- Base: `Tizen.UI.Skia.CustomRenderingView`
- Members:
  - `.ctor()`
  - `protected Void Dispose(Boolean disposing)`
  - `public Boolean get_IgnorePixelScaling()`
  - `protected Void OnDrawFrame()`
  - `protected Void OnResized()`
  - `protected Void SendMeasureInvalidatedIfNeed()`
  - `public Void set_IgnorePixelScaling(Boolean value)`
  - `public Boolean IgnorePixelScaling { get; set; }`

### class `SKPaintSurfaceEventArgs`

- Base: `System.EventArgs`
- Members:
  - `.ctor(SKSurface surface, SKImageInfo info)`
  - `.ctor(SKSurface surface, SKImageInfo info, SKImageInfo rawInfo)`
  - `public SKImageInfo get_Info()`
  - `public SKImageInfo get_RawInfo()`
  - `public SKSurface get_Surface()`
  - `public SKImageInfo Info { get; }`
  - `public SKImageInfo RawInfo { get; }`
  - `public SKSurface Surface { get; }`

## Extension Methods

- _(none)_

