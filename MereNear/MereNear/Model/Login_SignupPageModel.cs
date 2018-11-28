using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MereNear.Model
{
    public class LoginModel
    {
        [JsonProperty ("mobile")]
        public string MobileNumber { get; set; }
    }

    public class LoginResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public bool verify_acc { get; set; }
        public string code { get; set; }
    }

    public class OTPModel
    {
        [JsonProperty("code")]
        public string OTPNumber { get; set; }

        [JsonProperty("mobile")]
        public string MobileNumber { get; set; }

        [JsonProperty("fcm_token")]
        public string FCM_Token { get; set; }
    }

    public class OTPResponse
    {
        public string user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string FCM_Token { get; set; }
        public string mobile { get; set; }
        public string token { get; set; }
        public string code { get; set; }
        public object imageloc { get; set; }
        public string user_uid { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public bool verify_acc { get; set; }
    }
}
