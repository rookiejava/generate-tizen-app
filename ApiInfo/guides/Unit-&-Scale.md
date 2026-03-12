## Units
There are 3 major units that developers can take.
Unit | Example| Description | Formula to px
--|--|--|--
px | `view.DesiredWidth = 15f;` | Pixels | value 
spx | `view.DesiredWidth = 15f.Spx();` | Scaled pixels | value * scalingFactor 
dp | `view.DesiredWidth = 15f.Dp();` | Density-independent pixels | value * Dpi / BaselineDpi

<br/>
⚠️ To set float-type property, please do not forget to use proper float literal to prevent data loss.

For example, when a scaling factor is 1.2f,
 Bad | Good
--|--
`8.Spx()` | `8f.Spx()`
 9 pixels (X) | 9.2 pixels (O)

<br/>

## Customizing unit
### Custom ScalingFactor
Define `MaterialConfig` inherited class to set baseline dpi.
```C#
public class CustomMaterialConfig : MaterialConfig
{
    public CustomMaterialConfig()
    {
        ScalingFactor = 2.5f;
    }
}
```
Then apply it to the application,
```C#
public class YourApplication: MaterialApplication
{
    protected override MaterialConfig CreateConfig() => new CustomMaterialConfig();
}


public class YourApplication: MaterialApplication
{
    protected override MaterialConfig CreateConfig() => new CustomMaterialConfig();
}
```

<br/>
