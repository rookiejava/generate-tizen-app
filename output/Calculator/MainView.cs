using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace Calculator;

/// <summary>
/// 메인 화면 View - AI가 생성하는 핵심 코드
/// </summary>
public class MainView : ContentView
{
    private TextView _display;
    private string _currentInput = "";
    private string _previousInput = "";
    private string _operator = "";

    public MainView()
    {
        WidthResizePolicy = ResizePolicy.FillToParent;
        HeightResizePolicy = ResizePolicy.FillToParent;

        Body = CreateContent();
    }

    private void OnButtonClicked(object sender, InputEventArgs e)
    {
        var btn = sender as Button;
        if (btn == null) return;
        
        string text = btn.Text;

        if (text == "C")
        {
            _currentInput = "";
            _previousInput = "";
            _operator = "";
            _display.Text = "0";
        }
        else if (text == "=")
        {
            if (!string.IsNullOrEmpty(_operator) && !string.IsNullOrEmpty(_previousInput) && !string.IsNullOrEmpty(_currentInput))
            {
                if (double.TryParse(_previousInput, out double prev) && double.TryParse(_currentInput, out double curr))
                {
                    double result = 0;
                    switch (_operator)
                    {
                        case "+": result = prev + curr; break;
                        case "-": result = prev - curr; break;
                        case "*": result = prev * curr; break;
                        case "/": result = curr != 0 ? prev / curr : 0; break;
                    }
                    _display.Text = result.ToString();
                    _currentInput = result.ToString();
                    _previousInput = "";
                    _operator = "";
                }
            }
        }
        else if (text == "+" || text == "-" || text == "*" || text == "/")
        {
            if (!string.IsNullOrEmpty(_currentInput))
            {
                _operator = text;
                _previousInput = _currentInput;
                _currentInput = "";
            }
        }
        else
        {
            _currentInput += text;
            _display.Text = _currentInput;
        }
    }

    private Button CreateButton(string text)
    {
        var btn = new Button
        {
            Text = text,
            WidthResizePolicy = ResizePolicy.FillToParent,
            HeightResizePolicy = ResizePolicy.FillToParent,
        };
        btn.Clicked += OnButtonClicked;
        return btn;
    }

    private View CreateContent()
    {
        _display = new TextView
        {
            Text = "0",
            FontSize = 36,
            HorizontalAlignment = TextAlignment.End,
            VerticalAlignment = TextAlignment.Center,
            HeightResizePolicy = ResizePolicy.FillToParent,
            WidthResizePolicy = ResizePolicy.FillToParent,
            BackgroundColor = Color.FromHex("#EEEEEE")
        };

        var row1 = new HStack { ItemAlignment = LayoutAlignment.Fill, HeightResizePolicy = ResizePolicy.FillToParent };
        row1.Children.Add(CreateButton("7")); row1.Children.Add(CreateButton("8")); row1.Children.Add(CreateButton("9")); row1.Children.Add(CreateButton("/"));

        var row2 = new HStack { ItemAlignment = LayoutAlignment.Fill, HeightResizePolicy = ResizePolicy.FillToParent };
        row2.Children.Add(CreateButton("4")); row2.Children.Add(CreateButton("5")); row2.Children.Add(CreateButton("6")); row2.Children.Add(CreateButton("*"));

        var row3 = new HStack { ItemAlignment = LayoutAlignment.Fill, HeightResizePolicy = ResizePolicy.FillToParent };
        row3.Children.Add(CreateButton("1")); row3.Children.Add(CreateButton("2")); row3.Children.Add(CreateButton("3")); row3.Children.Add(CreateButton("-"));

        var row4 = new HStack { ItemAlignment = LayoutAlignment.Fill, HeightResizePolicy = ResizePolicy.FillToParent };
        row4.Children.Add(CreateButton("C")); row4.Children.Add(CreateButton("0")); row4.Children.Add(CreateButton("=")); row4.Children.Add(CreateButton("+"));

        return new Scaffold
        {
            AppBar = new AppBar
            {
                Title = "Calculator App",
            },
            Content = new VStack
            {
                ItemAlignment = LayoutAlignment.Fill,
                Children =
                {
                    _display,
                    row1,
                    row2,
                    row3,
                    row4
                }
            }
        };
    }
}
