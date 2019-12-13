
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Xamarin.Forms;
using notenow4.Core.Models;

namespace notenow4.Core.ViewModels
{
    public class MyMemoriesViewModel : MvxViewModel
    {
        readonly IMvxNavigationService navigationService;

        public MyMemoriesViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public List<Memories> memoriesList;
        public List<Memories> MemoriesList
        {
            get { return memoriesList; }
            set
            {
                if (SetProperty(ref memoriesList, value))
                    RaisePropertyChanged(() => MemoriesList);
            }
        }
       // public MvxCommand<Notes> NoteListListview => new MvxCommand<Notes>(OpenSelectedNotes);
        public ICommand AddNewMemory => new Command(OpenSelectedNotes);

        
        public async void OpenSelectedNotes()
        {
            navigationService.Navigate<AddMemoryViewModel>();
            //  await  navigationService.Navigate<>
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();
            // NotesList = new List<Notes>() { };
            // NotesList = await Application.Database.GetNotes();
            MemoriesList = new List<Memories>() { };
            MemoriesList = await Application.Database.GetMemories();
        }
    }
}
