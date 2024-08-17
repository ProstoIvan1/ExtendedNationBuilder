using Avalonia.Controls;
using DynamicData;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilderAvalonia.ViewModels
{
    public class CityNamesTableViewModel : ViewModelBase
    {
        [Reactive]
        public string Header { get; set; }

        public ObservableCollection<CityNameTableRecord> CityNames { get; } = new();

        [Reactive]
        public int SelectedIndex { get; set; }

        public CityNamesTableViewModel(string header, Window owner) : base(owner)
        {
            Header = header;
        }

        public void Add()
        {
            var cityName = new CityNameTableRecord();
            CityNames.Add(cityName);
            SelectedIndex = CityNames.Count - 1;
        }

        public void Remove()
        {
            if (0 <= SelectedIndex && SelectedIndex < CityNames.Count)
                CityNames.RemoveAt(SelectedIndex);
        }
    }
}
