using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MereNear.Model
{
    public class CountryCodeModel
    {
        [JsonProperty ("countryname")]
        public string CountryName { get; set; }

        [JsonProperty("telpref")]
        public string CountryDialCode { get; set; }

        [JsonProperty("isocode")]
        public string CountryCode { get; set; }

        [JsonProperty("countryflag")]
        public string CountryFlag { get; set; }
    }

    public class CountryStatusModel
    {
        public bool status { get; set; }
        public List<CountryCodeModel> data { get; set; }
        public string message { get; set; }
    }
}
