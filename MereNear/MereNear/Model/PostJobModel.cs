using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.Model
{
    public class PostJobModel
    {
        public int ID { get; set; }

        public string Address { get; set; }

        public LocationAddress AddressPosition { get; set; }

        public string DropAddress { get; set; }

        public LocationAddress DropAddressPosition { get; set; }

        public string CategoryName { get; set; }

        public string CategoryWork { get; set; }

        public string Description { get; set; }

        public string PostedDate { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string CategoryImage { get; set; }

        public string ServiceImage1 { get; set; }

        public string ServiceImage2 { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public Color StatusColor { get; set; }

        public Color TimeColor { get; set; }

        public bool IsDateVisible { get; set; }

        public string Distance { get; set; }

        public string WhenLabel { get; set; }

        public string PostedOnLabel { get; set; }

        public bool IsApplied { get; set; }
    }
}
