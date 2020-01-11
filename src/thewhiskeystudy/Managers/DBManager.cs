using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.Extensions.Caching.Memory;

using Newtonsoft.Json;

using thewhiskeystudy.lib.Common;
using thewhiskeystudy.lib.Enums;
using thewhiskeystudy.lib.Objects;

namespace thewhiskeystudy.Managers
{
    public class DBManager : BaseManager
    {
        public DBManager(IMemoryCache cache) : base(cache) { }

        public (bool success, Exception exception) UpdateDatabase(string rawJson)
        {
            List<RawDatabaseItem> deserializedObject = null;

            try
            {
                deserializedObject = JsonConvert.DeserializeObject<List<RawDatabaseItem>>(rawJson);
            } catch (Exception ex)
            {
                return (false, ex);
            }

            AddCachedItem(CacheKeys.FULL_RAW_DB, deserializedObject);
            File.WriteAllText(Constants.FILE_JSON_DBFILENAME, rawJson);

            return (true, null);
        }

        private (List<RawDatabaseItem> result, Exception exception) GetDatabase() {
            try
            {
                var cachedItem = GetCachedItem<List<RawDatabaseItem>>(CacheKeys.FULL_RAW_DB);

                // Database exists and cache hasn't been initialized
                if (cachedItem.result != default(List<RawDatabaseItem>) || !File.Exists(Constants.FILE_JSON_DBFILENAME))
                {
                    return (cachedItem.result, null);
                }

                var result = JsonConvert.DeserializeObject<List<RawDatabaseItem>>(File.ReadAllText(Constants.FILE_JSON_DBFILENAME));

                AddCachedItem(CacheKeys.FULL_RAW_DB, result);

                return (result, null);

            } catch (Exception ex)
            {
                return (null, ex);
            }
        }
          
        public (IQueryable<RawDatabaseItem> result, Exception exception) GetSuggestions(SuggestionFormChoices wantsReadilyAvailable, 
            SuggestionFormChoices likesCaramel, SuggestionFormChoices likesSpice, double? maxPrice, 
            SuggestionFormChoices likesHighProof, SuggestionFormChoices likesSmooth, 
            SuggestionFormChoices likesSweet, DrinkTypeChoices drinkType)
        {
            var result = GetDatabase();

            if (result.exception != null)
            {
                return (null, result.exception);
            }

            var query = result.result.AsQueryable();

            if (maxPrice.HasValue)
            {
                query = query.Where(a => a.Price <= maxPrice.Value);
            }

            switch (likesHighProof)
            {
                case SuggestionFormChoices.YES:
                    query = query.Where(a => a.ABV >= 50);
                    break;
                case SuggestionFormChoices.NO:
                    query = query.Where(a => a.ABV < 50);
                    break;                                    
            }

            if (wantsReadilyAvailable != SuggestionFormChoices.NO_OPINION)
            {
                query = wantsReadilyAvailable == SuggestionFormChoices.YES
                    ? query.Where(a => a.EasyToFind)
                    : query.Where(a => !a.EasyToFind);
            }

            if (likesCaramel != SuggestionFormChoices.NO_OPINION)
            {
                query = likesCaramel == SuggestionFormChoices.YES
                    ? query.Where(a => a.HasCaramelNose || a.HasCaramelTaste)
                    : query.Where(a => !a.HasCaramelNose && !a.HasCaramelTaste);
            }

            if (likesSpice != SuggestionFormChoices.NO_OPINION)
            {
                query = likesSpice == SuggestionFormChoices.YES
                    ? query.Where(a => a.HasSpiceTaste)
                    : query.Where(a => !a.HasSpiceTaste);
            }

            if (likesSmooth != SuggestionFormChoices.NO_OPINION)
            {
                query = likesSmooth == SuggestionFormChoices.YES
                    ? query.Where(a => a.HasSmoothTaste)
                    : query.Where(a => !a.HasSmoothTaste);
            }

            if (likesSweet != SuggestionFormChoices.NO_OPINION)
            {
                query = likesSweet == SuggestionFormChoices.YES
                    ? query.Where(a => a.HasSweetTaste)
                    : query.Where(a => !a.HasSweetTaste);
            }

            if (drinkType != DrinkTypeChoices.NO_OPINION)
            {
                switch (drinkType)
                {
                    case DrinkTypeChoices.BOURBON:
                        query = query.Where(a => a.Type == DrinkTypeChoices.BOURBON);
                        break;
                    case DrinkTypeChoices.SCOTCH:
                        query = query.Where(a => a.Type == DrinkTypeChoices.SCOTCH);
                        break;
                    case DrinkTypeChoices.WHISKEY:
                        query = query.Where(a => a.Type == DrinkTypeChoices.WHISKEY);
                        break;
                }
            }

            return (query, null);
        }
    }
}