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
   public class MyNotesViewModel : MvxViewModel
    {
        readonly IMvxNavigationService navigationService;

        public MyNotesViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
       public List<Notes> notesList;
        public List<Notes> NotesList
        {
            get { return notesList; }
            set
            {
                if (SetProperty(ref notesList, value))
                    RaisePropertyChanged(() => NotesList);
            }
        }
        public MvxCommand<Notes> NoteListListview => new MvxCommand<Notes>(OpenSelectedNotes);

        public async void OpenSelectedNotes(Notes notes)
        {
        //  await  navigationService.Navigate<>
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();
            NotesList = new List<Notes>() { };
            NotesList = await Application.Database.GetNotes();

         }
    } 
}
