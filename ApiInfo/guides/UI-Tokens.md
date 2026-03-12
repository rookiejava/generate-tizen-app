## UI Tokens

Token is a predefined value with a string ID. Tizen.UI provides various kind of token tables defined in UX guide documentation.

<br/>

## MaterialCorner

If UX guide specifies an object should have a radius with string Id such as `Sys_Radius/*`, it is expected to use an `MaterialCorner` token instead of hard cording a value directly.

```C#
view.CornerRadius = MaterialCorner.Lg;
```

<br/>

## MaterialColor
### System color

If UX guide specifies an object should have a color with string Id such as `Sys/*`, it is expected to use an `MaterialColor` token instead of hard cording a value directly.

```C#
view.BackgroundColor = MaterialColor.Primary;
```

<br/>

### Effect Color

If UX guide specifies an object should have a color with string Id such as `Effect/*`, it is also expected to use an `MaterialColor` token with name without `Effect` word.

```C#
view.BackgroundColor = MaterialColor.BlurSurface;
```

<br/>

> [!IMPORTANT]
> The value of MaterialColor will change by system theme. All Views with MaterialColor applied will get updated for system theme change.
> See [here](Color-&-Theme) for more details.

<br/>

## MaterialFont & MaterialFontSize

`Font` and `Weight` for text are defined separately in UX guide, however the two are treated as a single property `Font` in Material UI. In the above case, it is expected to use `MaterialFont` token like this:

```C#
text.FontFamily = MaterialFont.Normal600; // Normal font and 600 weight
```

For the text size, `MaterialFontSize` is provided:

```C#
text.FontSize = MaterialFontSize.Md;
```

<br/>

## MaterialSpacing

If UX guide specifies an object should have a length with string Id such as `Sys_Spacing/*`, it is expected to use an `MaterialSpacing` token instead of hard cording a value directly.

```C#
view.Padding = new Thickness(MaterialSpacing.Md400, MaterialSpacing.Xs40); // (horizontal, vertical)
```

<br/>

## MaterialBorder
If UX guide specifies an object should have a length with string Id such as `Sys_Border/*`, it is expected to use an `MaterialBorder` token instead of hard cording a value directly.

<br/>

# Manage Tokens

Basically token values are initialized with `MaterialConfig`.

Once your configuration class set up, you can override proper methods related with tokens:
* `MaterialFont` -> `CreateFontTable()`
* `MaterialFontSize` -> `CreateFontSizeTable()`
* `MaterialSpacing` -> `CreateSpacingTable()`
* `MaterialCorner` -> `CreateCornerTable()`
* `MaterialBorder` -> `CreateBorderTable()`
* `MaterialColor` -> `CreateColorTable()`

<br/>

The `MaterialFontSize`, for example,
```C#
public class MyUIConfig : MaterialConfig
{
    // ...

    public override IDictionary<string, float> CreateFontSizeTable() => new Dictionary<string, float>()
    {
        [nameof(MaterialFontSize.Xs3)] = 18f.Spx(),
        [nameof(MaterialFontSize.Xs2)] = 20f.Spx(),
        [nameof(MaterialFontSize.Xs)] = 24f.Spx(),
        [nameof(MaterialFontSize.Sm2)] = 26f.Spx(),
        [nameof(MaterialFontSize.Sm)] = 28f.Spx(),
        [nameof(MaterialFontSize.Md)] = 32f.Spx(),
        [nameof(MaterialFontSize.Lg)] = 36f.Spx(),
        [nameof(MaterialFontSize.Lg2)] = 40f.Spx(),
        [nameof(MaterialFontSize.Lg3)] = 50f.Spx(),
        [nameof(MaterialFontSize.Xl)] = 52f.Spx(),
        [nameof(MaterialFontSize.Xl2)] = 76f.Spx(),
        [nameof(MaterialFontSize.Xl3)] = 88f.Spx(),
        ["MyFontSize1"] = 1f.Spx(),
        ["MyFontSize2"] = 2f.Spx(),
        ["MyFontSize3"] = 3f.Spx(),
    };

    // ...
}
```
```C#
class MyApplication : MaterialApplication
{
    protected override void OnCreate()
    {
        base.OnCreate();
        // ...
    }

    protected override MaterialConfig CreateConfig() => new MyUIConfig();

    // ...
}
```

The code above will initialze `MaterialFontSize` tokens with specified values and also generate 3 new tokens `MyFontSize1/2/3`!.

All token classes are providing static `Get` method to access a user defined token:

```C#
var fontSize = MaterialFontSize.Get("MyFontSize1"); // It will return 1f.Spx()
```

<br/>

> [!CAUTION]
> Overriding color table will prevent overrided tokens to get updated by themes.

<br/>