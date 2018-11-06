using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MereNear.Localization
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        CultureInfo GetCurrentCultureInfo(string sLanguageCode);
        void SetLocale();
        void ChangeLocale(string sLanguageCode);
    }
}
