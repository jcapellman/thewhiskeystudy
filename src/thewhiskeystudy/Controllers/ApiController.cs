using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.lib.Common;

namespace thewhiskeystudy.Controllers
{
    public class ApiController : Controller
    {
        // TODO: Replace with proper auth middleware
        private bool IsAuthorized(string token) => System.IO.File.ReadAllText(Constants.FILE_TOKEN_FILENAME) == token;
        
        [HttpPut]
        public bool PUT(string jsonDb)
        {
            if (!HttpContext.Request.Headers.ContainsKey(Constants.HTTP_HEADER_TOKEN) || !IsAuthorized(HttpContext.Request.Headers[Constants.HTTP_HEADER_TOKEN]))
            {
                return false;
            }
            
            System.IO.File.WriteAllText(Constants.FILE_JSON_DBFILENAME, jsonDb);

            return true;
        }
    }
}