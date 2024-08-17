using Avalonia.Controls;
using ReactiveUI;

namespace ExtendedNationBuilderAvalonia.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public Window Owner { get; set; }
        public ViewModelBase(Window owner) 
        { 
            Owner = owner;
        }
    }
}
