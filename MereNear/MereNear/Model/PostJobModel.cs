using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.Model
{
    public class PostJobModel
    {
        public int ID { get; set; }

        public string Address { get; set; }

        public Position AddressPosition { get; set; }

        public string CategoryName { get; set; }

        public string CategoryWork { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public Color StatusColor { get; set; }

        public Color TimeColor { get; set; }

        public string Distance { get; set; }
    }

}
