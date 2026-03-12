## Color & Theme

`MaterialColor`는 색상에 `Primary`, `Surface` 등 목적에 맞는 이름을 붙여 어떤 어플리케이션에서도 UX가 의도한 디자인 정체성이 유지될 수 있도록 도움을 주는 시스템이다.
```C#
new View
{
    BackgroundColor = MaterialColor.Primary // #387AFF
}
```

`MaterialColor`의 값은 시스템에 현재 설정되어 있는 Theme 에 맞춰 초기화 된다. 이후 시스템에 의해 Theme이 변경될 때마다 값이 업데이트 된다.

만약 Theme 패키지가 지정된 포멧의 `MaterialColor` 리소스를 포함하고 있지 않을 경우, 플랫폼 기본값(bright)으로 최초 세팅된 후 업데이트 되지 않는다.

각 패키지의 `shared/res` 위치에 `material_color.json` 이라는 이름의 파일이 있다면, `MaterialColor`는 해당 파일에 쓰여있는 값을 따르게 된다.

`material_color.json` 은 컬러 테이블을 표현한 데이터로 아래와 같은 형식을 따르면 된다: `#RRGGBB` 또는 `#RRGGBB/Alpha`

#### material_color.json sample
```json
{
  "Primary": "#6750A4",
  "PrimaryHigh": "#5142B0",
  "OnPrimary": "#FFFFFF",
  "PrimaryContainer": "#EADDFF",
  "OnPrimaryContainer": "#21005D",
  "Secondary": "#625B71",
  "OnSecondary": "#FFFFFF",
  "SecondaryContainer": "#E8DEF8",
  "OnSecondaryContainer": "#1D192B",
  "Tertiary": "#7D5260",
  "OnTertiary": "#FFFFFF",
  "TertiaryContainer": "#FFD8E4",
  "OnTertiaryContainer": "#31111D",
  "Error": "#BA1A1A",
  "OnError": "#FFFFFF",
  "ErrorContainer": "#FFDAD6",
  "OnErrorContainer": "#410002",
  "Background": "#FFFBFE",
  "OnBackground": "#1C1B1F",
  "Surface": "#FFFBFE",
  "OnSurface": "#1C1B1F",
  "SurfaceVariant": "#E7E0EC",
  "OnSurfaceVariant": "#49454F",
  "Outline": "#79747E",
  "OutlineVariant": "#CAC4D0",
  "Shadow": "#000000",
  "Scrim": "#000000",
  "InverseSurface": "#313033",
  "InverseOnSurface": "#F4EFF4",
  "InversePrimary": "#D0BCFF",
  "SurfaceDim": "#DED8E1",
  "SurfaceBright": "#FFFBFE",
  "SurfaceContainerLowest": "#FFFFFF",
  "SurfaceContainerLow": "#F7F2FA",
  "SurfaceContainer": "#F1EDF7",
  "SurfaceContainerHigh": "#ECE6F0",
  "SurfaceContainerHighest": "#E6E0E9",
  "Red": "#B3261E",
  "RedBright": "#EF9A9A",
  "Green": "#146C2E",
  "GreenBright": "#81C784",
  "OrangeBright": "#FFAB91",
  "Orange": "#E65100",
  "BackgroundVariant": "#F7F2FA",
  "SurfaceBrightest": "#FFFFFF",
  "SurfaceFixed": "#49454F",
  "SurfaceFixedVariant": "#1C1B1F",
  "SurfaceContainerHighestTranslucent": "#E6E0E9/90",
  "SurfaceContainerHigher": "#D0BCFF",
  "SurfaceContainerHigherTranslucent": "#D0BCFF/90",
  "SurfaceContainerSemi": "#E7E0EC",
  "SurfaceContainerFixed": "#FFFFFF",
  "SurfaceContainerFixedTranslucent": "#FFFFFF/50",
  "SurfaceContainerFixedVariant": "#1C1B1F",
  "InverseSurfaceContainer": "#313033",
  "SurfaceContainerTranslucent": "#FFFFFF/60",
  "SurfaceContainerTranslucentLow": "#FFFFFF/95",
  "SurfaceContainerTranslucentSemi": "#FFFFFF/35",
  "ToneOnTone": "#1C1B1F/5",
  "ToneOnToneHigh": "#1C1B1F/10",
  "OnSurfaceContainerHighest": "#1C1B1F",
  "OnSurfaceContainerHigher": "#49454F",
  "OnSurfaceContainerLow": "#79747E",
  "OnSurfaceContainerLowest": "#CAC4D0",
  "OnSurfaceContainerFixed": "#FFFFFF",
  "OnSurfaceContainerFixedInverse": "#1C1B1F",
  "OnSurfaceContainerFixedVariant": "#1C1B1F",
  "OnSurfaceContainerFixedVariantBright": "#FFFFFF",
  "OnSurfaceContainerSemi": "#1C1B1F",
  "InverseOnSurfaceContainer": "#F4EFF4",
  "OutlineHighest": "#49454F",
  "OutlineHigh": "#79747E",
  "OutlineLow": "#CAC4D0",
  "OutlineLowest": "#FFFFFF/35",
  "OutlineFixed": "#000000/10",
  "OutlineACCHigh": "#79747E/15",
  "OutlineACC": "#FFFFFF/0",
  "OutlineACCLow": "#FFFFFF/0",
  "OutlineACCTranslucent": "#F7F2FA/5",
  "BackgroundApp": "#FFFFFF",
  "SelectedOnBackground": "#000000/5",
  "SelectedOnSurface": "#000000/10",
  "SelectedOnSurfaceVariant": "#000000/5",
  "PressedOnSurfaceVariant": "#000000/16",
  "PressedOnColor": "#000000/10",
  "PressedOnSurface": "#000000/10",
  "ScrimOnBlurSmallScreen": "#000000/25",
  "ScrimHelpOverlay": "#49454F/75",
  "ScrimDefault": "#000000/40",
  "TextHighlight": "#6750A4/22",
  "ShadowDefault": "#000000/10",
  "ShadowVariant": "#000000/5",
  "BlurSurface": "#FFFFFF/80",
  "BlurLightUltraThin": "#262626/20"
}
```

## Non-system Colors

`MaterialColor`는 system color로 정의하고 있는 ID들의 static field를 가지고 있다: `Primary`, `Outline` 등

```C#
// System color
new View
{
    BackgroundColor = MaterialColor.Primary
}
```

여기에 정의되지 않은 아이디들은 사용자 정의 항목이라고 판단된 것들인데, 샤용자 정의 컬러를 정의하기 위해서 `material_color.json`에 추가하는 방식으로 정의할 수 있으며 아래와 같이 접근하면 된다.

```C#
// Non-system color
new View
{
    BackgroundColor = MaterialColor.Get("BackgroundApp")
}
```

<br/>
<br/>

## Theme Change
시스템 Theme이 변경되면 MaterialColor 테이블이 업데이트 되며, 해당 컬러를 사용한 `View`의 특정 속성도 함께 업데이트 된다.

```C#
new View()
{
    BackgroundColor = MaterialColor.Surface,
    // ...
}
```

위 `View`는 `MaterialColor.Surface` 와 연결이 되어있고 시스템 Theme 변경시 `View`의 background color도 함께 업데이트 되어 화면에 반영된다.


## App Custom Colors by Theme

기본 컬러 이외에 테마에 따라 변경되는 앱 전용 컬러를 정의하고 싶다면, `MaterialThemeLoader`를 상속받는 방식으로 가능하다.

### Sample

### Create a custom theme loader
```C#
public class AppThemeLoader : MaterialThemeLoader
{
    public override IDictionary<string, UIColor> LoadColorTable()
    {
        // NOTE This method is called when system theme change.
        // Tizen.UI.Components uses the color table returned by this method.
        // base.LoadColorTable() generate system theme color table.
        // You can add color to system theme color table here.
        // For example,
        return new Dictionary<string, UIColor>(base.LoadColorTable())
        {
            ["CustomColor1"] = UIColor.Red,
            ["CustomColor2"] = UIColor.Blue,
            // ...
        };
    }
}
```

### Set custom theme loader as default
Custom theme loader가 준비되면 해당 로더를 사용하도록 config 에서 설정해 준다.
```C#
public class AppConfig : MaterialConfig
{
    public override IThemeLoader CreateThemeLoader() => new AppThemeLoader();
}
```


### Set it to your application

```C#
public class YourApplication : MaterialApplication
{
    protected override MaterialConfig CreateConfig() => new AppConfig();
}
```