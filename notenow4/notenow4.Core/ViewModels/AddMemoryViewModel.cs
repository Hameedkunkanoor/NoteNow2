using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Xamarin.Forms;
using notenow4.Core.Models;
namespace notenow4.Core.ViewModels
{
    public class AddMemoryViewModel : MvxViewModel
    {
        readonly IMvxNavigationService navigationService;

        public AddMemoryViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        
            string selectedEvent = string.Empty;
        public string SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                if (SetProperty(ref selectedEvent, value))
                    if(selectedEvent== "Others")
                    {
                        IsOthers = true;
                    }
                else
                    {
                        IsOthers = false;
                    }
                    RaisePropertyChanged(() => SelectedEvent);
            }
        }
        string memoryText = string.Empty;
        public string MemoryText
        {
            get { return memoryText; }
            set
            {
                if (SetProperty(ref memoryText, value))
                    RaisePropertyChanged(() => MemoryText);
            }
        }
        string otherOccasionName = string.Empty;
        public string OtherOccasionName
        {
            get { return otherOccasionName; }
            set
            {
                if (SetProperty(ref otherOccasionName, value))
                    RaisePropertyChanged(() => OtherOccasionName);
            }
        }
        bool isOthers = false;
        public bool IsOthers
        {
            get { return isOthers; }
            set
            {
                if (SetProperty(ref isOthers, value))
                    RaisePropertyChanged(() => IsOthers);
            }
        }
        
        List<string> occasionList ;
        public List<string> OccasionList
        {
            get { return occasionList; }
            set
            {
                if (SetProperty(ref occasionList, value))
                    RaisePropertyChanged(() => OccasionList);
            }
        }


        public ICommand SaveNotes => new Command(SaveNotesInDb);

        public async void SaveNotesInDb()
        {

            Memories memories = new Memories()
            {
                MemoryText = MemoryText,
              //  Date = DateTime.UtcNow,
            };

           
            await Application.Database.SaveMemories(memories);
            await navigationService.Navigate<MyMemoriesViewModel>();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            OccasionList = new List<string>() { };
            OccasionList.Add("BirthDay");
            OccasionList.Add("Anniversary");
            OccasionList.Add("Wedding");
            OccasionList.Add("Party");
            OccasionList.Add("Interview");
            OccasionList.Add("MyDay");
            OccasionList.Add("Memory To Remember");
            OccasionList.Add("Others");

        }
    }
}
