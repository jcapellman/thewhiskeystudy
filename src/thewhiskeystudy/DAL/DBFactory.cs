using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using thewhiskeystudy.DAL.Tables;

namespace thewhiskeystudy.DAL
{
    public class DBFactory : DbContext
    {
        public DbSet<Reviews> Reviews { get; set; }        

        public List<T> SelectMany<T>(Expression<Func<T, bool>> expression = null) where T : BaseTable => 
            (expression == null ? Set<T>().Where(a => a.Active).ToList() : Set<T>().Where(a => a.Active).Where(expression).ToList());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tws.db");
        }
    }
}