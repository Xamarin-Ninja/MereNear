using MereNear.ViewModels.Common;
using Prism.Commands;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
    public class NotificationsPageViewModel : BaseViewModel
    {
        #region Constructor
        public NotificationsPageViewModel()
        {

        }
        #endregion

        #region Command
        public ICommand HeaderLeftIconCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MessagingCenter.Send("HamburgurClick", "OpenMasterDetailPage");
                });
            }
        }
        #endregion
    }
}
