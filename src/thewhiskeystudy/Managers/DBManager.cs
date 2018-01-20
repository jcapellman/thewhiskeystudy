﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

using thewhiskeystudy.lib.Objects;

namespace thewhiskeystudy.Managers
{
    public class DBManager : BaseManager
    {
        public List<RawDatabaseItem> GetDatabase()
        {
            using (var sr = new StreamReader("Whiskey DB.csv")) { 
                var csv = new CsvReader(sr);

                var records = new List<RawDatabaseItem>();

                while (csv.Read())
                {
                    try
                    {
                        var record = csv.GetRecord<RawDatabaseItem>();

                        records.Add(record);
                    }
                    catch (Exception ex)
                    {
                        var error = ex;
                    }
                }

                return records;
            }
        }

        public IQueryable<RawDatabaseItem> GetSuggestions(bool wantsReadilyAvailable, bool likesCaramel, bool likesSpice, double? maxPrice, bool likesHighProof, bool likesSmooth, bool likesSweet)
        {
            var query = GetDatabase().AsQueryable();

            if (maxPrice.HasValue)
            {
                query = query.Where(a => a.Price <= maxPrice.Value);
            }

            query = likesHighProof ? query.Where(a => a.ABV > 50.0f) : query.Where(a => a.ABV <= 50.0f);

            return query.Where(a => a.EasyToFind == wantsReadilyAvailable && a.HasCaramelNose == likesCaramel && a.HasCaramelTaste == likesCaramel && a.HasSpiceTaste == likesSpice && a.HasSmoothTaste == likesSmooth && a.HasSweetTaste == likesSweet);
        }
    }
}