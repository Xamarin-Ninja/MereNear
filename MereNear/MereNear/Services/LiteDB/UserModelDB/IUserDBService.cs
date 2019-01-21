using MereNear.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiteDB.UserModelDB
{
    public interface IUserDBService
    {
        bool IsUserDbPresentInDB();
        UserModel CreateUserModelInDB(UserModel item);
        UserModel DeleteItemFromDB(BsonValue id,UserModel item);
        IEnumerable<UserModel> ReadAllItems();
        UserModel UpdateUserModelInDb(BsonValue id, UserModel item);
    }
}