using System.Collections.Generic;
using System.Linq;
using LiteDB;
using LiteDB.LiteDBCommon;
using MereNear.Services.LiteDB.ChatModelDB;
using MereNear.Views.ViewCells;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChatModelDbService))]
namespace MereNear.Services.LiteDB.ChatModelDB
{
    public class ChatModelDbService : IChatModelDbService
    {
        private LiteDBService liteDBService;

        public ChatModelDbService()
        {
            liteDBService = LiteDBService.Instance;
        }

        public ChatItem CreateChatModelInDB(ChatItem item)
        {
            return liteDBService.CreateItem(item);
        }

        public ChatItem DeleteItemFromDB(BsonValue id, ChatItem item)
        {
            return liteDBService.DeleteItem(id, item);
        }

        public bool IsChatDbPresentInDB()
        {
            ChatItem model = liteDBService.ReadAllItems<ChatItem>().FirstOrDefault(t => t.ID != 0);
            if (model == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<ChatItem> ReadAllItems()
        {
            return liteDBService.ReadAllItems<ChatItem>();
        }

        public ChatItem UpdateChatModelInDb(BsonValue id, ChatItem item)
        {
            return liteDBService.UpdateItem(id, item);
        }
    }
}
