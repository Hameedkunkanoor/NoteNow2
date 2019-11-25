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
  public  class NewNotesViewModel : MvxViewModel
    {
       
            readonly IMvxNavigationService navigationService;

            public NewNotesViewModel(IMvxNavigationService navigationService)
            {
                this.navigationService = navigationService;
            }

         string notesText = string.Empty;
        public string NotesText
        {
            get { return notesText; }
            set
            {
                if (SetProperty(ref notesText, value))
                    RaisePropertyChanged(() => NotesText);
            }
        }


        public ICommand SaveNotes => new Command(SaveNotesInDb);

        public async void SaveNotesInDb()
        {
           
            Notes notes = new Notes()
            {
            NotesText= NotesText,
                Date=DateTime.UtcNow,
        };

          
            await Application.Database.SaveNotes(notes);
            await navigationService.Navigate<HomeViewModel>();
        }
       
    }
    }
