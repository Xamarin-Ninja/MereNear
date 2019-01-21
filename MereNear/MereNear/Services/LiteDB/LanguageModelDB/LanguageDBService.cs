using System;
using System.Collections.Generic;
using LiteDB.LanguageModelDB;
using LiteDB.LiteDBCommon;
using MereNear.Model;
using Xamarin.Forms;
using System.Linq;

[assembly: Dependency(typeof(LanguageDBService))]
namespace LiteDB.LanguageModelDB
{
    public class LanguageDBService : ILanguageDBService
    {
        private LiteDBService liteDBService;

        public LanguageDBService()
        {
            liteDBService = LiteDBService.Instance;
        }

        public LanguageModel CreateLanguageModelInDB(LanguageModel item)
        {
            return liteDBService.CreateItem(item);
        }

        public LanguageModel DeleteItemFromDB(BsonValue id, LanguageModel item)
        {
            return liteDBService.DeleteItem(id, item);
        }

        public bool IsLanguageDbPresentInDB()
        {
            LanguageModel model = liteDBService.ReadAllItems<LanguageModel>().FirstOrDefault(t => t.ID != 0);
            if (model == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<LanguageModel> ReadAllItems()
        {
            return liteDBService.ReadAllItems<LanguageModel>();
        }

        public LanguageModel UpdateLanguageModelInDb(BsonValue bsonid, LanguageModel item)
        {
            return liteDBService.UpdateItem(bsonid, item);
        }
    }
}
