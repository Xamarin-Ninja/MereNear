using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SignalR.ViewModels
{
	public class ChatMessageViewModel : BindableBase
	{
        public ChatMessageViewModel()
        {

        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _image;

        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        private bool _isMine;

        public bool IsMine
        {
            get { return _isMine; }
            set { SetProperty(ref _isMine, value); }
        }
    }
}
