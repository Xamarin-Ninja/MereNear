using LiteDB;
using LiteDB.LiteDBCommon;
using MereNear.Model;
using MereNear.Services.LiteDB.PostJobModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(PostJobDBService))]
namespace MereNear.Services.LiteDB.PostJobModelDB
{
    public class PostJobDBService : IPostJobDBService
    {
        private LiteDBService liteDBService;

        public PostJobDBService()
        {
            liteDBService = LiteDBService.Instance;
        }
        public PostJobModel CreatePostJobModelInDB(PostJobModel item)
        {
            return liteDBService.CreateItem(item);
        }

        public PostJobModel DeleteItemFromDB(BsonValue id, PostJobModel item)
        {
            return liteDBService.DeleteItem(id, item);
        }

        public bool IsPostJobDbPresentInDB()
        {
            PostJobModel model = liteDBService.ReadAllItems<PostJobModel>().FirstOrDefault(t => t.ID != 0);
            if (model == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<PostJobModel> ReadAllItems()
        {
            return liteDBService.ReadAllItems<PostJobModel>();
        }

        public PostJobModel UpdatePostJobModelInDb(BsonValue id, PostJobModel item)
        {
            return liteDBService.UpdateItem(id, item);
        }
    }
}
