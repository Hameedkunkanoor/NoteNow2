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
        List<Notes> notesList;
        public List<Notes> NotesList
        {
            get { return notesList; }
            set
            {
                if (SetProperty(ref notesList, value))
                    RaisePropertyChanged(() => NotesList);
            }
        }
        public override async void ViewAppeared()
        {
            base.ViewAppeared();

            NotesList = await Application.Database.GetNotes();
         }
    }
}
