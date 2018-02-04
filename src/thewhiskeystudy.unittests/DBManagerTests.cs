using System;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using thewhiskeystudy.Managers;

namespace thewhiskeystudy.unittests
{
    [TestClass]
    public class DBManagerTests
    {
        [TestMethod]
        public void DBManager_NullCache()
        {
            try
            {
                var manager = new DBManager(null);
            } catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
        
        [TestMethod]
        public void DBManager_NullFile()
        {
            try
            {
                var manager = new DBManager(new MemoryCache(null));
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
    }
}