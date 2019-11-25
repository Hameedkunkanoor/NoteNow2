using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace notenow4.Core.ViewModels
{
    class HomeViewModel : MvxViewModel
    {

        readonly IMvxNavigationService navigationService;

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        // NewNotes
        public ICommand NewNotes => new MvxAsyncCommand(() => navigationService.Navigate<NewNotesViewModel>());
        public ICommand MyNotes => new MvxAsyncCommand(() => navigationService.Navigate<MyNotesViewModel>());

    }
}
