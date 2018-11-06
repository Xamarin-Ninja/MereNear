using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MereNear.Model
{
    public class HomePageModel
    {
        public string category_id { get; set; }

        [JsonProperty("name")]
        public string CategoryName { get; set; }

        [JsonProperty("image")]
        public string CategoryImage { get; set; }
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
