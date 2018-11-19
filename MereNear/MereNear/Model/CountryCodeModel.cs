using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MereNear.Model
{
    public class CountryCodeModel
    {
        [JsonProperty ("name")]
        public string CountryName { get; set; }
        [JsonProperty("dial_code")]
        public string CountryDialCode { get; set; }
        [JsonProperty("code")]
        public string CountryCode { get; set; }
    }

    public class CountryStatusModel
    {
        public bool status { get; set; }
        public List<CountryCodeModel> data { get; set; }
        public string message { get; set; }
    }
}
