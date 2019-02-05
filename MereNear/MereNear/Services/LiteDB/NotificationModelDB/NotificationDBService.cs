using LiteDB;
using LiteDB.LiteDBCommon;
using MereNear.Model;
using MereNear.Services.LiteDB.NotificationModelDB;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotificationDBService))]
namespace MereNear.Services.LiteDB.NotificationModelDB
{
    public class NotificationDBService: INotificationDBService
    {
        private LiteDBService liteDBService;

        public NotificationDBService()
        {
            liteDBService = LiteDBService.Instance;
        }

        public NotificationModel CreateNotificationModeInDB(NotificationModel item)
        {
            return liteDBService.CreateItem(item);
        }

        public NotificationModel DeleteItemFromDB(BsonValue id, NotificationModel item)
        {
            return liteDBService.DeleteItem(id, item);
        }

        public bool IsNotificationDbPresentInDB()
        {
            NotificationModel model = liteDBService.ReadAllItems<NotificationModel>().FirstOrDefault(t => t.ID != 0);
            if (model == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<NotificationModel> ReadAllItems()
        {
            return liteDBService.ReadAllItems<NotificationModel>();
        }

        public NotificationModel UpdateNotificationModeInDb(BsonValue bsonid, NotificationModel item)
        {
            return liteDBService.UpdateItem(bsonid, item);
        }
    }
}
