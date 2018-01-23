using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.lib.Common;
using thewhiskeystudy.Middleware;

namespace thewhiskeystudy.Controllers
{
    public class ApiController : Controller
    {
        [TokenFilter]
        [HttpPut]
        public bool PUT(string jsonDb)
        {
            System.IO.File.WriteAllText(Constants.FILE_JSON_DBFILENAME, jsonDb);

            return true;
        }
    }
}