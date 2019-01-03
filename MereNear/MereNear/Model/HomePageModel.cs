using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MereNear.Model
{
    public class HomePageModel: INotifyPropertyChanged
    {
        public string category_id { get; set; }

        [JsonProperty("name")]
        public string CategoryName { get; set; }

        [JsonProperty("image")]
        public string CategoryImage { get; set; }

        public string AvailableServiceProvider { get; set; }
        private Color _frameColor = Color.LightGray;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Color FrameColor
        {
            get { return _frameColor; }
            set { _frameColor = value; OnPropertyChanged("FrameColor"); }
        }
    }

    public class GetCatApiModel
    {
        public bool status { get; set; }
        public List<HomePageModel> data { get; set; }
        public string message { get; set; }
    }

    public class HomePageDataModel
    {
        public string WorkerImage { get; set; }

        public string WorkerName { get; set; }

        public string WorkerRating { get; set; }

        public string WorkerExp { get; set; }

        public string WorkerCategory { get; set; }

        public string WorkerInformation { get; set; }
    }
}
