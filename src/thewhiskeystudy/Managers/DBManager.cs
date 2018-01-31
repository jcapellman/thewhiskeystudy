﻿using System;
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

        public bool UpdateDatabase(string rawJson)
        {
            List<RawDatabaseItem> deserializedObject = null;

            try
            {
                deserializedObject = JsonConvert.DeserializeObject<List<RawDatabaseItem>>(rawJson);
            } catch (Exception)
            {
                return false; // TODO: Handle errors
            }

            AddCachedItem(CacheKeys.FULL_RAW_DB, deserializedObject);
            File.WriteAllText(Constants.FILE_JSON_DBFILENAME, rawJson);

            return true;
        }

        public List<RawDatabaseItem> GetDatabase() {
            var cachedItem = GetCachedItem<List<RawDatabaseItem>>(CacheKeys.FULL_RAW_DB);

            // Database exists and cache hasn't been initialized
            if (cachedItem == default(List<RawDatabaseItem>) && File.Exists(Constants.FILE_JSON_DBFILENAME))
            {
                var result = JsonConvert.DeserializeObject<List<RawDatabaseItem>>(File.ReadAllText(Constants.FILE_JSON_DBFILENAME));

                AddCachedItem(CacheKeys.FULL_RAW_DB, result);

                return result;
            }

            return cachedItem;
        }
          
        public IQueryable<RawDatabaseItem> GetSuggestions(SuggestionFormChoices wantsReadilyAvailable, SuggestionFormChoices likesCaramel, SuggestionFormChoices likesSpice, double? maxPrice, SuggestionFormChoices likesHighProof, SuggestionFormChoices likesSmooth, SuggestionFormChoices likesSweet)
        {
            var query = GetDatabase().AsQueryable();

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

            return query;
        }
    }
}