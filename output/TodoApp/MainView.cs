using System;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace TodoApp;

// Define a custom View for the list item to be used with ViewTemplate(Type type)
public class TodoItemView : HStack, IBindableView
{
    private Label _textLabel;
    private object _bindingContext;

    public TodoItemView()
    {
        WidthResizePolicy = ResizePolicy.FillToParent;
        HeightResizePolicy = ResizePolicy.UseNaturalSize; // Allow the item to size itself based on content
        Spacing = 10; // Spacing between elements within this item view

        _textLabel = new Label
        {
            Text = "Default Item", // Placeholder text, will be updated by BindingContext
            WidthResizePolicy = ResizePolicy.FillToParent,
            FontSize = 24,
            TextColor = Color.Black,
            VerticalAlignment = TextAlignment.Center,
            HorizontalAlignment = TextAlignment.Start,
        };
        Children.Add(_textLabel);
    }

    // IBindableView implementation to receive the data item
    public object BindingContext
    {
        get => _bindingContext;
        set
        {
            if (_bindingContext != value)
            {
                _bindingContext = value;
                UpdateUI();
            }
        }
    }

    private void UpdateUI()
    {
        // Update the Label's text with the bound data item
        if (_textLabel != null && _bindingContext is string todoText)
        {
            _textLabel.Text = todoText;
        }
    }
}

public class MainView : ContentView
{
    private List<string> _todoItems;
    private TextField _todoInput;
    private ListView _todoListView;

    public MainView()
    {
        WidthResizePolicy = ResizePolicy.FillToParent;
        HeightResizePolicy = ResizePolicy.FillToParent;
        BackgroundColor = Color.FromHex("#FAFAFA");

        _todoItems = new List<string>();

        Body = CreateContent();
    }

    private View CreateContent()
    {
        _todoInput = new TextField
        {
            PlaceholderText = "Enter a new to-do item",
            WidthResizePolicy = ResizePolicy.FillToParent,
        };

        var addButton = new Button
        {
            Text = "Add",
            // UseNaturalSize for the button so it doesn't expand and push the TextField
            WidthResizePolicy = ResizePolicy.UseNaturalSize,
        };
        addButton.Clicked += OnAddButtonClicked;

        _todoListView = new ListView
        {
            WidthResizePolicy = ResizePolicy.FillToParent,
            HeightResizePolicy = ResizePolicy.FillToParent,
            ItemsSource = _todoItems,
            // Fix: Use the ViewTemplate(Type type) constructor with a custom IBindableView class.
            // The compiler was unable to convert Func<object, View> to Type, suggesting
            // that the ViewTemplate(Func<object, View>) constructor might not be correctly
            // exposed or resolved in this specific Tizen.UI version/context.
            ItemTemplate = new ViewTemplate(typeof(TodoItemView))
        };

        return new Scaffold
        {
            AppBar = new AppBar
            {
                Title = "To-Do List"
            },
            Content = new VStack
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                Spacing = 10, // Spacing between the input/button area and the list
                Children =
                {
                    new HStack
                    {
                        WidthResizePolicy = ResizePolicy.FillToParent,
                        Spacing = 10, // Spacing between the TextField and the Button
                        Children =
                        {
                            _todoInput,
                            addButton
                        }
                    },
                    _todoListView
                }
            }
        };
    }

    private void OnAddButtonClicked(object sender, InputEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(_todoInput.Text))
        {
            _todoItems.Add(_todoInput.Text.Trim());
            _todoInput.Text = string.Empty; // Clear the input field

            // Re-assigning ItemsSource forces the ListView to refresh its display.
            // For better performance with frequent updates, consider using ObservableCollection
            // or specific update methods if available in a more advanced ListView implementation.
            _todoListView.ItemsSource = null;
            _todoListView.ItemsSource = _todoItems;
        }
    }
}