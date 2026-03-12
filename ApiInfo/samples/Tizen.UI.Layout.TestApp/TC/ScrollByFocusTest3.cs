using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollByFocusTest3 : Grid, ITestCase
    {
        public ScrollByFocusTest3()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(100);

            Add(new Button("Top")
            {
                FocusHighlightEnabled = true,
                Focusable = true,
                FocusableChildren = true,
            });
            Add(new ScrollLayout
            {
                Content = new Grid
                {
                    Padding = 100,
                    ColumnDefinitions = { 50, 50, 50, 50, 50 },
                    RowDefinitions = { 50, 50, 50, 50, 50 },
                    ColumnSpacing = 50,
                    RowSpacing = 30,
                    Children =
                    {
                        new Button("1") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(0).Column(0),
                        new Button("2") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(0).Column(1),
                        new Button("3") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(0).Column(2),
                        new Button("4") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(0).Column(3),
                        new Button("5") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(0).Column(4),
                        new Button("6") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(1).Column(0),
                        new Button("7") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(1).Column(1),
                        new Button("8") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(1).Column(2),
                        new Button("9") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(1).Column(3),
                        new Button("10") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(1).Column(4),
                        new Button("11") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(2).Column(0),
                        new Button("12") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(2).Column(1),
                        new Button("13") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(2).Column(2),
                        new Button("14") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(2).Column(3),
                        new Button("15") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(2).Column(4),
                        new Button("16") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(3).Column(0),
                        new Button("17") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(3).Column(1),
                        new Button("18") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(3).Column(2),
                        new Button("19") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(3).Column(3),
                        new Button("20") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(3).Column(4),
                        new Button("21") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(4).Column(0),
                        new Button("22") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(4).Column(1),
                        new Button("23") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(4).Column(2),
                        new Button("24") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(4).Column(3),
                        new Button("25") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(4).Column(4),
                    }
                },
            }.Row(1));
            Add(new Button("Middle")
            {
                FocusHighlightEnabled = true,
                Focusable = true,
                FocusableChildren = true,
            }.Row(2));
            Add(new ScrollLayout
            {
                Content = new Grid
                {
                    Padding = 150,
                    ColumnDefinitions = { 50, 50, 50, 50, 50 },
                    RowDefinitions = { 50, 50, 50, 50, 50 },
                    ColumnSpacing = 50,
                    RowSpacing = 30,
                    Children =
                    {
                        new Button("26") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(0).Column(0),
                        new Button("27") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(0).Column(1),
                        new Button("28") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(0).Column(2),
                        new Button("29") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(0).Column(3),
                        new Button("30") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(0).Column(4),
                        new Button("31") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(1).Column(0),
                        new Button("32") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(1).Column(1),
                        new Button("33") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(1).Column(2),
                        new Button("34") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(1).Column(3),
                        new Button("35") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(1).Column(4),
                        new Button("36") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(2).Column(0),
                        new Button("37") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(2).Column(1),
                        new Button("38") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(2).Column(2),
                        new Button("39") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(2).Column(3),
                        new Button("40") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(2).Column(4),
                        new Button("41") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(3).Column(0),
                        new Button("42") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(3).Column(1),
                        new Button("43") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(3).Column(2),
                        new Button("44") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(3).Column(3),
                        new Button("45") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(3).Column(4),
                        new Button("46") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(4).Column(0),
                        new Button("47") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(4).Column(1),
                        new Button("48") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(4).Column(2),
                        new Button("49") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(4).Column(3),
                        new Button("50") { FocusHighlightEnabled = true, Focusable = true, FocusableChildren = true, }.Row(4).Column(4),
                    }
                },
            }.Row(3));
            Add(new Button("Bottom")
            {
                FocusHighlightEnabled = true,
                Focusable = true,
                FocusableChildren = true,
            }.Row(4));

            FocusManager.Instance.FocusChanged += OnFocusChanged;
            DetachedFromWindow += (s, e) =>
            {
                FocusManager.Instance.FocusChanged -= OnFocusChanged;
            };
        }

        private void OnFocusChanged(object sender, FocusChangedEventArgs e)
        {
            if (e.FocusedView is Button btn)
            {
                Console.WriteLine($"Focused : {btn.Text}");
            }
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }
    }
}
