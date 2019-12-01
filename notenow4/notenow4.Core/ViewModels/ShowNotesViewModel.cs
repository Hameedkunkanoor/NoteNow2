using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using notenow4.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace notenow4.Core.ViewModels
{
   public class ShowNotesViewModel : MvxViewModel<Notes>
    {
        readonly IMvxNavigationService navigationService;

        public ShowNotesViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public Notes notes;
        public Notes Notes
        {
            get { return notes; }
            set
            {
                if (SetProperty(ref notes, value))
                    RaisePropertyChanged(() => Notes);
            }
        }
        public override void Prepare(Notes parameter)
        {
            Notes = parameter;
        }
    }
}
