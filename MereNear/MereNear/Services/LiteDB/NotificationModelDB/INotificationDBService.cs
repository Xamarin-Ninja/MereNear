using LiteDB;
using MereNear.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace MereNear.Services.LiteDB.NotificationModelDB
{
    public interface INotificationDBService
    {
        bool IsNotificationDbPresentInDB();
        NotificationModel CreateNotificationModeInDB(NotificationModel item);
        NotificationModel DeleteItemFromDB(BsonValue id, NotificationModel item);
        IEnumerable<NotificationModel> ReadAllItems();
        NotificationModel UpdateNotificationModeInDb(BsonValue id, NotificationModel item);
    }
}
