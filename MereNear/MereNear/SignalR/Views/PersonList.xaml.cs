using Xamarin.Forms;

namespace SignalR.Views
{
    public partial class PersonList : ContentPage
    {
        public PersonList()
        {
            InitializeComponent();
        }

        private void PersonChatListItemSeleted(object sender, SelectedItemChangedEventArgs e)
        {
            personChatList.SelectedItem = null;
        }
    }
}
