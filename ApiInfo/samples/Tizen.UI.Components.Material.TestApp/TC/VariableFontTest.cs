using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Internal;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class VariableFontTest : ScrollView, INavigationTransition, ITestCase
    {
        private readonly string _numericText = "1234567890";
        private readonly string _font = "OneUI_Clock_Default_Num Thin";

        // Font Spec
        // <!-- Weight -->
        // <Axis>
        //   <AxisTag>wght</AxisTag>
        //   <Flags>0x0</Flags>
        //   <MinValue>100.0</MinValue>
        //   <DefaultValue>100.0</DefaultValue>
        //   <MaxValue>900.0</MaxValue>
        //   <AxisNameID>256</AxisNameID>
        // </Axis>
        // <!-- Rounded Corners -->
        // <Axis>
        //   <AxisTag>RNDN</AxisTag>
        //   <Flags>0x0</Flags>
        //   <MinValue>0.0</MinValue>
        //   <DefaultValue>0.0</DefaultValue>
        //   <MaxValue>100.0</MaxValue>
        //   <AxisNameID>257</AxisNameID>
        // </Axis>
        public VariableFontTest() : base()
        {
            FontClient.Instance.AddCustomFontDirectory(ResourceManager.ResourceDirectory + "fonts");
            BackgroundColor = MaterialColor.Background;
            Content = new HStack()
            {
                Padding = new(24),
                Spacing = 1f,
                ItemAlignment = LayoutAlignment.Center,
                Children =
                {
                    CreateNormalFonts().Expand(),
                    CreateSemiRoundedFonts().Expand(),
                    CreateRoundedFonts().Expand()
                }
            };
        }

        // <!-- Thin -->
        // <!-- PostScript: OneUI_Clock_Default_Num-Thin -->
        // <NamedInstance flags="0x0" postscriptNameID="6" subfamilyNameID="17">
        //   <coord axis="wght" value="100.0"/>
        //   <coord axis="RNDN" value="0.0"/>
        // </NamedInstance>

        // <!-- Light -->
        // <!-- PostScript: OneUI_Clock_Default_Num-Light -->
        // <NamedInstance flags="0x0" postscriptNameID="259" subfamilyNameID="258">
        //   <coord axis="wght" value="305.0"/>
        //   <coord axis="RNDN" value="0.0"/>
        // </NamedInstance>

        // <!-- Regular -->
        // <!-- PostScript: OneUI_Clock_Default_Num-Regular -->
        // <NamedInstance flags="0x0" postscriptNameID="260" subfamilyNameID="2">
        //   <coord axis="wght" value="500.0"/>
        //   <coord axis="RNDN" value="0.0"/>
        // </NamedInstance>

        // <!-- Medium -->
        // <!-- PostScript: OneUI_Clock_Default_Num-Medium -->
        // <NamedInstance flags="0x0" postscriptNameID="262" subfamilyNameID="261">
        //   <coord axis="wght" value="690.0"/>
        //   <coord axis="RNDN" value="0.0"/>
        // </NamedInstance>

        // <!-- Bold -->
        // <!-- PostScript: OneUI_Clock_Default_Num-Bold -->
        // <NamedInstance flags="0x0" postscriptNameID="264" subfamilyNameID="263">
        //   <coord axis="wght" value="900.0"/>
        //   <coord axis="RNDN" value="0.0"/>
        // </NamedInstance>
        public VStack CreateNormalFonts()
        {
            return new VStack()
            {
                Spacing = 1f,
                Children =
                {
                    new Label("Normal"),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 100, roundAxis: "RNDN", round: 0),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 305, roundAxis: "RNDN", round: 0),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 500, roundAxis: "RNDN", round: 0),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 690, roundAxis: "RNDN", round: 0),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 900, roundAxis: "RNDN", round: 0)
                }
            };
        }

        // <!-- Thin SemiRounded -->
        // <!-- PostScript: OneUI_Clock_Default_Num-ThinSemiRounded -->
        // <NamedInstance flags="0x0" postscriptNameID="266" subfamilyNameID="265">
        //   <coord axis="wght" value="100.0"/>
        //   <coord axis="RNDN" value="50.0"/>
        // </NamedInstance>

        // <!-- Light SemiRounded -->
        // <!-- PostScript: OneUI_Clock_Default_Num-LightSemiRounded -->
        // <NamedInstance flags="0x0" postscriptNameID="268" subfamilyNameID="267">
        //   <coord axis="wght" value="305.0"/>
        //   <coord axis="RNDN" value="60.0"/>
        // </NamedInstance>

        // <!-- Regular SemiRounded -->
        // <!-- PostScript: OneUI_Clock_Default_Num-RegularSemiRounded -->
        // <NamedInstance flags="0x0" postscriptNameID="270" subfamilyNameID="269">
        //   <coord axis="wght" value="500.0"/>
        //   <coord axis="RNDN" value="60.0"/>
        // </NamedInstance>

        // <!-- Medium SemiRounded -->
        // <!-- PostScript: OneUI_Clock_Default_Num-MediumSemiRounded -->
        // <NamedInstance flags="0x0" postscriptNameID="272" subfamilyNameID="271">
        //   <coord axis="wght" value="690.0"/>
        //   <coord axis="RNDN" value="60.0"/>
        // </NamedInstance>

        // <!-- Bold SemiRounded -->
        // <!-- PostScript: OneUI_Clock_Default_Num-BoldSemiRounded -->
        // <NamedInstance flags="0x0" postscriptNameID="274" subfamilyNameID="273">
        //   <coord axis="wght" value="900.0"/>
        //   <coord axis="RNDN" value="60.0"/>
        // </NamedInstance>
        public VStack CreateSemiRoundedFonts()
        {
            return new VStack()
            {
                Spacing = 1f,
                Children =
                {
                    new Label("SemiRounded"),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 100, roundAxis: "RNDN", round: 50),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 305, roundAxis: "RNDN", round: 60),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 500, roundAxis: "RNDN", round: 60),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 690, roundAxis: "RNDN", round: 60),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 900, roundAxis: "RNDN", round: 60)
                }
            };
        }

        // <!-- Thin Rounded -->
        // <!-- PostScript: OneUI_Clock_Default_Num-ThinRounded -->
        // <NamedInstance flags="0x0" postscriptNameID="276" subfamilyNameID="275">
        //   <coord axis="wght" value="100.0"/>
        //   <coord axis="RNDN" value="100.0"/>
        // </NamedInstance>

        // <!-- Light Rounded -->
        // <!-- PostScript: OneUI_Clock_Default_Num-LightRounded -->
        // <NamedInstance flags="0x0" postscriptNameID="278" subfamilyNameID="277">
        //   <coord axis="wght" value="305.0"/>
        //   <coord axis="RNDN" value="100.0"/>
        // </NamedInstance>

        // <!-- Regular Rounded -->
        // <!-- PostScript: OneUI_Clock_Default_Num-RegularRounded -->
        // <NamedInstance flags="0x0" postscriptNameID="280" subfamilyNameID="279">
        //   <coord axis="wght" value="500.0"/>
        //   <coord axis="RNDN" value="100.0"/>
        // </NamedInstance>

        // <!-- Medium Rounded -->
        // <!-- PostScript: OneUI_Clock_Default_Num-MediumRounded -->
        // <NamedInstance flags="0x0" postscriptNameID="282" subfamilyNameID="281">
        //   <coord axis="wght" value="690.0"/>
        //   <coord axis="RNDN" value="100.0"/>
        // </NamedInstance>

        // <!-- Bold Rounded -->
        // <!-- PostScript: OneUI_Clock_Default_Num-BoldRounded -->
        // <NamedInstance flags="0x0" postscriptNameID="284" subfamilyNameID="283">
        //   <coord axis="wght" value="900.0"/>
        //   <coord axis="RNDN" value="100.0"/>
        // </NamedInstance>
        public VStack CreateRoundedFonts()
        {
            return new VStack()
            {
                Spacing = 1f,
                Children =
                {
                    new Label("Rounded"),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 100, roundAxis: "RNDN", round: 100),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 305, roundAxis: "RNDN", round: 100),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 500, roundAxis: "RNDN", round: 100),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 690, roundAxis: "RNDN", round: 100),
                    CreateLabel(text: _numericText, variableFont: _font, weightAxis: "wght", weight: 900, roundAxis: "RNDN", round: 100)
                }
            };
        }

        public View CreateLabel(string text, string variableFont, string weightAxis, float weight, string roundAxis, float round)
        {
            var label = new Label()
            {
                Text = text,
                FontFamily = variableFont,
                TextColor = Color.White,
                BackgroundColor = Color.Black,
                VerticalAlignment = TextAlignment.Center,
                AutoFontSize = new AutoFontSize()
                {
                    Enabled = true,
                    MinimumSize = 10,
                    MaximumSize = 140
                }
            };
            label.SetFontVariation(weightAxis, weight);
            label.SetFontVariation(roundAxis, round);
            return label;
        }

        public void WillAppear(bool byPopNavigation)
        {
        }

        public void WillDisappear(bool byPopNavigation)
        {
        }

        public void DidAppear(bool byPopNavigation)
        {
        }

        public void DidDisappear(bool byPopNavigation)
        {
            if (byPopNavigation)
            {
                Deactivate();
            }
        }

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }
    }
}
