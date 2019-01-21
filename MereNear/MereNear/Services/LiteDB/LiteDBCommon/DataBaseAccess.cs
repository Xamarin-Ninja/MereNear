using LiteDB.LiteDBCommon;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(DataBaseAccess))]
namespace LiteDB.LiteDBCommon
{
    public class DataBaseAccess : IDataBaseAccess
    {
        public DataBaseAccess()
        {
        }


        #region ISQLite implementation

        public string DatabasePath()
        {
            var fileName = "AdvantageDb.db3";
            if (Device.RuntimePlatform == Device.Android)
            {
                var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);

                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }

                return path;
            }
            else
            {
                string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }

                return Path.Combine(libFolder, fileName);
            }
        }

        #endregion
    }
}
