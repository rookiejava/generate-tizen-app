## UIConfig
`UIConfig` enables user to modify application settings related with Tizen.UI.

#### Properties and Method
The table below shows some key properties and methods defined in [MaterialConfig].

Name                   | Description
--                     | --
`ScalingFactor`        | Define a scaling factor value. Default is 1.
`BaselineDpi`          | Define a baseline dpi value used to calculate `Dp`. See [Unit & Scale](Unit-&-Scale).
`LongPressKeyCount`    | Define a required key pressed count to recognize long press.
`IsExcutionKey`        | Check if the key is for execution.
`IsBackKey`            | Check if the key is for back.
`CreateThemeLoader()`  | Generate a theme loader instance used in this application.
`CreateVariables()`    | Generate an `UIVariables` used in this application.
`CreateSpacingTable()` | Generate an `MaterialSpacing` table used in this application.
`CreateCornerTable()`  | Generate an `MaterialCorner` table used in this application.
`CreateBorderTable()`  | Generate an `MaterialBorder`table used in this application.
`CreateFontTable()`  | Generate an `MaterialFont` table used in this application.
`CreateFontSizeTable()`  | Generate an `MaterialFontSize` table used in this application.


If you want to custom a application settings, you need to define `MaterialConfig` derived class and set it to your application.

#### Create a `MaterialConfig` derived class
```C#
public class MyUIConfig : MaterialConfig
{
    public MyUIConfig()
    {
        // Sets properties to override
        // e.g.
        ScalingFactor = 1.5f;
        BaselineDpi = 240;
    }
}
```

#### Set it to the application
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