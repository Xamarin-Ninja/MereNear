using SignalR.ViewModels;
using System;
using Xamarin.Forms;

namespace MereNear.Views.ViewCells
{
    public class TemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate incomingDataTemplate;
        private readonly DataTemplate outgoingDataTemplate;
        private readonly DataTemplate recieverDealTemplate;
        private readonly DataTemplate locationTemplate;

        public TemplateSelector()
        {
            // Retain instances!
            this.incomingDataTemplate = new DataTemplate(typeof(ReceiverViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(SenderViewCell));
            this.recieverDealTemplate = new DataTemplate(typeof(RecieverDealViewCell));
            this.locationTemplate = new DataTemplate(typeof(LocationViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {

            //var messageVm = item as ChatMessageViewModel;
            //if (messageVm == null)
            //    return null;
            //return messageVm.IsMine == true ? this.outgoingDataTemplate : this.incomingDataTemplate;

            var messageVm = item as ChatItem;
            if (messageVm == null)
                return null;


            if(messageVm.MessageType == 1)
            {
                return this.outgoingDataTemplate;
            }
            else if(messageVm.MessageType == 2)
            {
                return this.recieverDealTemplate;
            }
            else if(messageVm.MessageType == 3)
            {
                return this.locationTemplate;
            }
            else
            {
                return null;
            }

            
        }
    }
}
