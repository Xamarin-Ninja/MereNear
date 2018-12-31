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
        private readonly DataTemplate senderDealTemplate;
        private readonly DataTemplate senderlocationTemplate;
        private readonly DataTemplate recieverlocationTemplate;

        public TemplateSelector()
        {
            // Retain instances!
            this.incomingDataTemplate = new DataTemplate(typeof(ReceiverViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(SenderViewCell));
            this.recieverDealTemplate = new DataTemplate(typeof(RecieverDealViewCell));
            this.senderDealTemplate = new DataTemplate(typeof(SenderDealViewCell));
            this.recieverlocationTemplate = new DataTemplate(typeof(LocationViewCell));
            this.senderlocationTemplate = new DataTemplate(typeof(SenderLocationViewCell));
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
                if (messageVm.SenderType == 1)
                {
                    return this.outgoingDataTemplate;
                }
                else if (messageVm.SenderType == 2)
                {
                    return this.incomingDataTemplate;
                }
                else
                {
                    return null;
                }
            }
            else if(messageVm.MessageType == 2)
            {
                if (messageVm.SenderType == 1)
                {
                    return this.senderDealTemplate;
                }
                else if (messageVm.SenderType == 2)
                {
                    return this.recieverDealTemplate;
                }
                else
                {
                    return null;
                }
            }
            else if(messageVm.MessageType == 3)
            {
                if (messageVm.SenderType == 1)
                {
                    return this.senderlocationTemplate;
                }
                else if (messageVm.SenderType == 2)
                {
                    return this.recieverlocationTemplate;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            
        }
    }
}
