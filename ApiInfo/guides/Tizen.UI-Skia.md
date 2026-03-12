## Overview
`Tizen.UI.Skia` allows you to use [SkiaSharp](https://learn.microsoft.com/en-us/dotnet/api/skiasharp) for 2D graphics in your Lite UI applications.

## Usage
This section introduces the concepts of drawing graphics in `Tizen.UI` using `SkiaSharp`, including creating an `SKCanvasView` object to host the graphics, handling the `PaintSurface` event, and using a `SKPaint` object to specify color and other drawing attributes.

#### Adding SkiaSharp and Tizen.UI.Skia
Add `SkiaSharp` and `Tizen.UI.Skia` packages (`*.nupkg`) to your application. Once added, you can use `SkiaSharp` APIs by declaring following namespaces.

```cs
using SkiaSharp;
using Tizen.UI.Skia;
```

#### Using SKCanvasView
Creates an `SKCanvasView` object, attaches a handler for the `PaintSurface` event, and sets the `SKCanvasView` object to parent.
```cs
var canvasView = new SKCanvasView();
canvasView.PaintSurface += OnCanvasViewPaintSurface;
Add(canvasView);
```

The `PaintSurface` event handler is where you do all your drawing. This method can be called multiple times while your program is running, so it should maintain all the information necessary to recreate the graphics display:
```cs
void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
{
    ...
}
```

The [SKPaintSurfaceEventArgs](https://learn.microsoft.com/en-us/dotnet/api/skiasharp.views.forms.skpaintsurfaceeventargs) object that accompanies the event has two properties:

- [Info](https://learn.microsoft.com/en-us/dotnet/api/skiasharp.views.forms.skpaintsurfaceeventargs.info#skiasharp-views-forms-skpaintsurfaceeventargs-info) of type [SKImageInfo](https://learn.microsoft.com/en-us/dotnet/api/skiasharp.skimageinfo)
- [Surface](https://learn.microsoft.com/en-us/dotnet/api/skiasharp.views.forms.skpaintsurfaceeventargs.surface#skiasharp-views-forms-skpaintsurfaceeventargs-surface) of type [SKSurface](https://learn.microsoft.com/en-us/dotnet/api/skiasharp.sksurface)

The `SKImageInfo` structure contains information about the drawing surface, most importantly, its width and height in pixels. The `SKSurface` object represents the drawing surface itself. In this program, the drawing surface is a video display, but in other programs an SKSurface object can also represent a bitmap that you use `SkiaSharp` to draw on.

The most important property of `SKSurface` is [Canvas](https://learn.microsoft.com/en-us/dotnet/api/skiasharp.sksurface.canvas#skiasharp-sksurface-canvas) of type [SKCanvas](https://learn.microsoft.com/en-us/dotnet/api/skiasharp.skcanvas). This class is a graphics drawing context that you use to perform the actual drawing. The `SKCanvas` object encapsulates a graphics state, which includes graphics transforms and clipping.

Here's a typical start of a `PaintSurface` event handler:
```cs
void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
{
    SKImageInfo info = args.Info;
    SKSurface surface = args.Surface;
    SKCanvas canvas = surface.Canvas;

    canvas.Clear();
    ...
}
```

The [Clear](https://learn.microsoft.com/en-us/dotnet/api/skiasharp.skcanvas.clear#skiasharp-skcanvas-clear) method clears the canvas with a transparent color. An overload lets you specify a background color for the canvas.

Please refer to [this](https://learn.microsoft.com/en-us/dotnet/api/skiasharp) for more details.