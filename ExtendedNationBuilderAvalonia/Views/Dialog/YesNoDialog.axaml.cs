using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ExtendedNationBuilderAvalonia.Views.Dialog;

public partial class YesNoDialog : Window
{
    public bool Result { get; private set; }

    public YesNoDialog()
    {
        InitializeComponent();
    }
    public YesNoDialog(string title, string message) : this()
    {
        Title = title;
        messageTextBox.Text = message;
    }

    private void YesClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Result = true;
        Close();
    }

    private void NoClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Result = false;
        Close();
    }
}