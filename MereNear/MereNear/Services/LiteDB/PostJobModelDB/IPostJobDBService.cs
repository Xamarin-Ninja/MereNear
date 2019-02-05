using LiteDB;
using MereNear.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MereNear.Services.LiteDB.PostJobModelDB
{
    public interface IPostJobDBService
    {
        bool IsPostJobDbPresentInDB();
        PostJobModel CreatePostJobModelInDB(PostJobModel item);
        PostJobModel DeleteItemFromDB(BsonValue id, PostJobModel item);
        IEnumerable<PostJobModel> ReadAllItems();
        PostJobModel UpdatePostJobModelInDb(BsonValue id, PostJobModel item);
    }
}
