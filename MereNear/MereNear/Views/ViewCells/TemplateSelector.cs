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
        public TemplateSelector()
        {
            // Retain instances!
            this.incomingDataTemplate = new DataTemplate(typeof(ReceiverViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(SenderViewCell));
            this.recieverDealTemplate = new DataTemplate(typeof(RecieverDealViewCell));
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

            else if(messageVm.SenderType ==2 && messageVm.IsRecieverDealType == true)
            {
                return this.recieverDealTemplate;
            }
            else if(messageVm.SenderType == 1)
            {
                return this.outgoingDataTemplate;
            }
            else
            {
                return this.recieverDealTemplate;
            }
            
        }
    }
}
