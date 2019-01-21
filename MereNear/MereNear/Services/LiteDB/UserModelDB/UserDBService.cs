using System;
using System.Collections.Generic;
using LiteDB.UserModelDB;
using LiteDB.LiteDBCommon;
using MereNear.Model;
using Xamarin.Forms;
using System.Linq;

[assembly: Dependency(typeof(UserDBService))]
namespace LiteDB.UserModelDB
{
    public class UserDBService : IUserDBService
    {
        private LiteDBService liteDBService;

        public UserDBService()
        {
            liteDBService = LiteDBService.Instance;
        }

        public UserModel CreateUserModelInDB(UserModel item)
        {
            return liteDBService.CreateItem(item);
        }

        public UserModel DeleteItemFromDB(BsonValue id, UserModel item)
        {
            return liteDBService.DeleteItem(id, item);
        }

        public bool IsUserDbPresentInDB()
        {
            UserModel model = liteDBService.ReadAllItems<UserModel>().FirstOrDefault(t => t.ID != 0);
            if (model == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<UserModel> ReadAllItems()
        {
            return liteDBService.ReadAllItems<UserModel>();
        }

        public UserModel UpdateUserModelInDb(BsonValue bsonid, UserModel item)
        {
            return liteDBService.UpdateItem(bsonid, item);
        }
    }
}
