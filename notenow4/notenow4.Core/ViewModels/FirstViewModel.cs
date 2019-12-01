using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace notenow4.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        readonly IMvxNavigationService navigationService;

        public FirstViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }




        public async override void Prepare()
        {
            base.Prepare();
            await Task.Delay(1700);
           await navigationService.Navigate<HomeViewModel>();
        }


       // public ICommand ShowAboutPageCommand => new MvxAsyncCommand(() => navigationService.Navigate<HomeViewModel>());
    }
}
