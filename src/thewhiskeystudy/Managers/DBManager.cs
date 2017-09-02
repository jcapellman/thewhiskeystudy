using Microsoft.EntityFrameworkCore;

using thewhiskeystudy.Objects;

namespace thewhiskeystudy.Managers
{
    public class DBManager : BaseManager
    {
        public DbSet<Reviews> Reviews { get; set; }
    }
}