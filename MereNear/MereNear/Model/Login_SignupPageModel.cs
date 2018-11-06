using System;
using System.Collections.Generic;
using System.Text;

namespace MereNear.Model
{
    public class LoginModel
    {
        public string MobileNumber { get; set; }
    }

    public class SignupModel
    {
        public string PersonName { get; set; }
        public string MobileNumber { get; set; }
        public bool IsChecked { get; set; }
    }

    public class OTPModel
    {
        public string OTPNumber { get; set; }
    }
}
