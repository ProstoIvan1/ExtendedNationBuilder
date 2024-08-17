using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExtendedNationBuilderAvalonia.ViewModels;

namespace ExtendedNationBuilderAvalonia;

public partial class ImagePathField : UserControl
{
    public string? Path 
    { 
        get
        {
            if (DataContext is ImagePathFieldViewModel)
            {
                var viewModel = (ImagePathFieldViewModel) DataContext;
                return viewModel.Path;
            }
            else throw new System.Exception("DataContext is not ImagePathFieldViewModel");
        }

        set
        {
            if (DataContext is ImagePathFieldViewModel)
            {
                var viewModel = (ImagePathFieldViewModel)DataContext;
                viewModel.Path = value;
            }
            else throw new System.Exception("DataContext is not ImagePathFieldViewModel");
        }
    } 

    public ImagePathField()
    {
        InitializeComponent();
    }

    public ImagePathField(Window owner, string watermark) : this()
    {
        DataContext = new ImagePathFieldViewModel(owner, watermark);
    }
}