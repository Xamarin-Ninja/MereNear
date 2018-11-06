using SignalR.ViewModels;
using System;
using Xamarin.Forms;

namespace MereNear.Views.ViewCells
{
    public class TemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate incomingDataTemplate;
        private readonly DataTemplate outgoingDataTemplate;
        public TemplateSelector()
        {
            // Retain instances!
            this.incomingDataTemplate = new DataTemplate(typeof(ReceiverViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(SenderViewCell));
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
            return messageVm.SenderType == 1 ? this.outgoingDataTemplate : this.incomingDataTemplate;
        }
    }
}
