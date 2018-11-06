using MereNear.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MereNear.Views.Common
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<string>(this, "OpenMasterDetailPage", (sender) => {
                if (!IsPresented)
                    IsPresented = true;
            });
        }

    }
}