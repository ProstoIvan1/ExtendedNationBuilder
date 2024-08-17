using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ExtendedNationBuilderAvalonia.Views.Dialog;

public partial class OkDialog : Window
{
    public OkDialog()
    {
        InitializeComponent();
    }
    public OkDialog(string title, string message) : this()
    {
        Title = title;
        messageTextBox.Text = message;
    }

    private void OkClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}