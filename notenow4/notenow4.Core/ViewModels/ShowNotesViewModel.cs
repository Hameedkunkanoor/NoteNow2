using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace notenow4.Core.ViewModels
{
    class ShowNotesViewModel : MvxViewModel
    {
        readonly IMvxNavigationService navigationService;

        public ShowNotesViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
