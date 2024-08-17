using Avalonia.Controls;
using ExtendedNationBuilderAvalonia.ViewModels;
using System.Collections.ObjectModel;

namespace ExtendedNationBuilderAvalonia;

public partial class CityNameTableControl : UserControl
{
    public ObservableCollection<CityNameTableRecord> Names
    {
        get
        {
            if (DataContext is CityNamesTableViewModel)
            {
                var viewModel = (CityNamesTableViewModel) DataContext;
                return viewModel.CityNames;
            }
            else throw new System.Exception ("DataContext is not CityNamesTableViewModel");
        }
    }

    public void Add(string[] cityNames)
    {
        if (DataContext is CityNamesTableViewModel)
        {
            var viewModel = (CityNamesTableViewModel)DataContext;

            foreach(string name in cityNames)
                viewModel.CityNames.Add(new CityNameTableRecord(name));
        }
    }

    public CityNameTableControl() 
    {
        InitializeComponent();
    }

    public CityNameTableControl(string header, Window owner) : this()
    {
        DataContext = new CityNamesTableViewModel(header, owner);
    }

    private void DataGrid_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        dataGrid.BeginEdit();
    }
}