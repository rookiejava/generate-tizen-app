using Tizen.UI;

namespace ComponentsTest
{
    internal static class SampleGradient
    {
        public static Background CreateLinearSample()
        {
            var gradient = new LinearGradientBackground();

            gradient.GradientStops.Add(new (Color.Red, 0.0f));
            gradient.GradientStops.Add(new (Color.Green, 0.25f));
            gradient.GradientStops.Add(new (Color.Blue, 0.5f));
            gradient.GradientStops.Add(new (Color.Magenta, 0.75f));
            gradient.GradientStops.Add(new (Color.Cyan, 1.0f));
            gradient.StartPoint = new(-0.5f, 0);
            gradient.EndPoint = new(0.5f, 0);

            return gradient;
        }
    }
}