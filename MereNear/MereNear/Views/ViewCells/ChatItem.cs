using Xamarin.Forms.Maps;

namespace MereNear.Views.ViewCells
{
    
    public class ChatItem
    {
        public int ID { get; set; }

        public int MessageType { get; set; }

        public string Icon { get; set; }

        public string CurrentUser { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public string Time { get; set; }

        public int SenderType { get; set; }

        public bool IsRecieverDealType { get; set; }

        public int PurchaseAmount { get; set; }

        public int ServiceAmount { get; set; }

        public int SubtotalAmount { get; set; }

        public int TotalAmout { get; set; }
        
        public string CurrencyType { get; set; }

        public Position Location { get; set; }

    }
}