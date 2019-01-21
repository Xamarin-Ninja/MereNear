using MereNear.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiteDB.LanguageModelDB
{
    public interface ILanguageDBService
    {
        bool IsLanguageDbPresentInDB();
        LanguageModel CreateLanguageModelInDB(LanguageModel item);
        LanguageModel DeleteItemFromDB(BsonValue id,LanguageModel item);
        IEnumerable<LanguageModel> ReadAllItems();
        LanguageModel UpdateLanguageModelInDb(BsonValue id, LanguageModel item);
    }
}