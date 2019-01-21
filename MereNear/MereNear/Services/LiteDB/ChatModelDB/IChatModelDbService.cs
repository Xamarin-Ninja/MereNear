using LiteDB;
using MereNear.Views.ViewCells;
using System.Collections.Generic;

namespace MereNear.Services.LiteDB.ChatModelDB
{
    public interface IChatModelDbService
    {
        bool IsChatDbPresentInDB();
        ChatItem CreateChatModelInDB(ChatItem item);
        ChatItem DeleteItemFromDB(BsonValue id, ChatItem item);
        IEnumerable<ChatItem> ReadAllItems();
        ChatItem UpdateChatModelInDb(BsonValue id, ChatItem item);
    }
}
