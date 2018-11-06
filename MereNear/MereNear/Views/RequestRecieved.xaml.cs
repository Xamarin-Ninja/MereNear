using MereNear.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class RequestRecieved : ContentPage
    {
        public ObservableCollection<RequestRecievedPageModel> RequestedDataList = new ObservableCollection<RequestRecievedPageModel>();
        public RequestRecieved()
        {
            InitializeComponent();

            GetRequestedList();
        }

        private void GetRequestedList()
        {
            RequestedDataList.Add(new RequestRecievedPageModel
            {
                WorkerType = "Plumber",
                WorkerName = "Amar Singh",
                WorkerRequestedDate = "01/05/2017"
            });
            RequestedDataList.Add(new RequestRecievedPageModel
            {
                WorkerType = "Electrician",
                WorkerName = "Amar Singh",
                WorkerRequestedDate = "01/05/2017"
            });
            RequestedDataList.Add(new RequestRecievedPageModel
            {
                WorkerType = "Ac Repair",
                WorkerName = "Amar Singh",
                WorkerRequestedDate = "01/05/2018"
            });
            RequestedDataList.Add(new RequestRecievedPageModel
            {
                WorkerType = "Mobile Repair",
                WorkerName = "Amar Singh",
                WorkerRequestedDate = "01/05/2018"
            });
            RequestedDataList.Add(new RequestRecievedPageModel
            {
                WorkerType = "Painter",
                WorkerName = "Amar Singh",
                WorkerRequestedDate = "01/11/2018"
            });
        }
    }
}
