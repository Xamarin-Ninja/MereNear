using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using MereNear.Interface;
using MereNear.iOS.DataBase;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataBaseService))]
namespace MereNear.iOS.DataBase
{
    public class DataBaseService : IDataBase
    {
        public string GetFilePath(string file)
        {
            string document = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string library = Path.Combine(document, " .. ", " Library ", " Databases ");

            if (!Directory.Exists(library))
            {
                Directory.CreateDirectory(library);
            }

            return Path.Combine(library, file);
        }
    }
}