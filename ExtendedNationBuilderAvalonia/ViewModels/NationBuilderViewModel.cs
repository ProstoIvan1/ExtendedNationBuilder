using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Avalonia.Platform.Storage;
using Avalonia.Controls;
using ExtendedNationBuilderAvalonia.Views.Dialog;
using DynamicData.Binding;
using System.Reactive;
using System.Reactive.Linq;
using ExtendedNationBuilder.Managers;
using ExtendedNationBuilder.Entities;
using ExtendedNationBuilder.Managers.Readers;
using ExtendedNationBuilder.Managers.Savers;
using DynamicData;
using System.IO;

namespace ExtendedNationBuilderAvalonia.ViewModels
{
    public class NationBuilderViewModel : ViewModelBase
    {
        public ObservableCollection<Nation> Nations { get; }

        [Reactive]
        public int SelectedNationIndex { get; set; }

        [Reactive]
        public string? NationName { get; set; }

        [Reactive]
        public string? RevolutionaryNationName { get; set; }

        [Reactive]
        public StartingBonus? StartingBonus { get; set; }
        private readonly StartingBonus randomBonusOption = new StartingBonus("", "Random");

        public CityNameTableControl CityNameTable { get; }
        public CityNameTableControl TownNameTable { get; }

        public ImagePathField FlagImagePath { get; }
        public ImagePathField RevolutionaryFlagImagePath { get; }

        public StartingBonus[] StartingBonuses { get; }
        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteCommand { get; }

        public NationBuilderViewModel(Window owner) : base(owner) 
        {
            SaveCommand = ReactiveCommand.Create(Save);

            IObservable<bool> canDelete = this.WhenAnyValue(x => x.SelectedNationIndex, i => i >= 0);
            DeleteCommand = ReactiveCommand.Create(Delete, canDelete);
            
            Nations = new ObservableCollection<Nation>(NationReader.GetAll());

            CityNameTable = new("City names", owner);
            TownNameTable = new("Town names", owner);

            FlagImagePath = new(owner, "Flag image");
            RevolutionaryFlagImagePath = new(owner, "Revolutionary flag image");

            var bonusList = new List<StartingBonus>();
            bonusList.AddRange(AllStartingBonuses.Get);
            StartingBonuses = bonusList.ToArray();
        }

        private void UpdateList()
        {
            string? name = NationName;
            Nations.Clear();
            Nations.AddRange(NationReader.GetAll());
            SelectNation(name);
        }

        public void Save()
        {
            foreach (Nation nation in Nations)
            {
                if (nation.Name == NationName && nation.Id != Nations[SelectedNationIndex].Id)
                {
                    new OkDialog("Error", "Nation name is already in use. Please use another.").ShowDialog(Owner);
                    return;
                }

            }

            if (NationName != null && RevolutionaryFlagImagePath.Path != null && FlagImagePath.Path != null &&
                CityNameTable.Names.Count > 0 && TownNameTable.Names.Count > 0 &&
                RevolutionaryNationName != null && StartingBonus != null)
            {
                if (0 <= SelectedNationIndex && SelectedNationIndex < Nations.Count)
                    SaveCurrent();
                else 
                { 
                    SaveNew(); 
                    SelectedNationIndex = Nations.Count - 1;
                }
            }
            else new OkDialog("Warning", "Not all fields have been filled.").ShowDialog(Owner);
        }

        private void SaveCurrent()
        {
            Nation nation = Nations[SelectedNationIndex];
            
            SaveNew();

            if (nation.Name != NationName)
                nation.Remove();

            UpdateList();
        }

        private void SaveNew()
        {
            Flag flag = new(NationName!);
            CityAndTownNames cityAndTownNames = new(NationName!, CityNameTable.Names.ToStrEnum(), TownNameTable.Names.ToStrEnum());

            Nation nation = new(NationName!, RevolutionaryNationName!, cityAndTownNames, flag, StartingBonus!);
            NationSaver saver = new(FlagImagePath.Path!, RevolutionaryFlagImagePath.Path!);
            saver.Save(nation);

            Nations.Add(nation);
        }

        public async void Delete()
        {
            if (0 <= SelectedNationIndex && SelectedNationIndex < Nations.Count)
            {
                YesNoDialog yesNoDialog = new("Confirm action", "Do you want to delete this nation?");
                await yesNoDialog.ShowDialog(Owner);
                if (yesNoDialog.Result)
                {
                    Nations[SelectedNationIndex].Remove();
                    Nations.RemoveAt(SelectedNationIndex);
                    SelectedNationIndex--;
                }

            }
        }

        private string? GetFlagPath(string flagId)
        {
            DirectoryInfo flagsDirectory = new DirectoryInfo(Directories.Flags);

            FileInfo[] files = flagsDirectory.GetFiles(flagId + "*.png", SearchOption.TopDirectoryOnly);
            if (files.Count() == 0)
            {
                files = flagsDirectory.GetFiles(flagId + "*.jpg", SearchOption.TopDirectoryOnly);
                if(files.Count() == 0)
                {
                    files = flagsDirectory.GetFiles(flagId + "*.jpeg", SearchOption.TopDirectoryOnly);
                    if (files.Count() == 0) return null;
                }
            }

            return files[0].FullName;
        }

        private void SelectNation(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                SelectedNationIndex = -1;
                return;
            }

            for (int i = 0; i < Nations.Count; i++)
            {
                if (Nations[i].Name == name)
                {
                    SelectedNationIndex = i;
                    return;
                }
            }

            throw new Exception("Nation not found");
        }

        public void SelectNation()
        {
            if (0 <= SelectedNationIndex && SelectedNationIndex < Nations.Count)
            {
                Nation nation = Nations[SelectedNationIndex];
                NationName = nation.Name;
                RevolutionaryNationName = nation.SplinterName;
                StartingBonus = nation.StartingBonus;

                CityNameTable.Names.Clear();
                TownNameTable.Names.Clear();

                CityNameTable.Add(nation.CityAndTownNames.CityNames.GetNames());
                TownNameTable.Add(nation.CityAndTownNames.TownNames.GetNames());

                FlagImagePath.Path = GetFlagPath(nation.Flag.Id);
                RevolutionaryFlagImagePath.Path = GetFlagPath(nation.Flag.RevId);
            }
            else ClearFields();
        }

        public void AddNewNation()
        {
            SelectedNationIndex = -1;
            ClearFields();
        }

        private void ClearFields()
        {
            NationName = null; 
            RevolutionaryNationName = null;
            CityNameTable.Names.Clear();
            TownNameTable.Names.Clear();
            FlagImagePath.Path = null;
            RevolutionaryFlagImagePath.Path = null;
            StartingBonus = null;
        }
    }

    
}
