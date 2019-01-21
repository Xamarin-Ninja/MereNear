

using MereNear.Droid.DataBase;
using MereNear.Interface;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataBaseService))]
namespace MereNear.Droid.DataBase
{
    public class DataBaseService: IDataBase
    {
        public string GetFilePath(string file)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, file);
        }
    }
}