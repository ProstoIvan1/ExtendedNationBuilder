using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExtendedNationBuilderAvalonia.ViewModels;
using ReactiveUI;

namespace ExtendedNationBuilderAvalonia.Views;

public partial class NationBuilderWindow : Window
{
    public NationBuilderWindow()
    {
        InitializeComponent();
        DataContext = new ViewModels.NationBuilderViewModel(this);
    }

    public void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        if (DataContext is NationBuilderViewModel)
        {
            var viewModel = (NationBuilderViewModel) DataContext;
            viewModel.SelectNation();
        }
    }
}