using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace thewhiskeystudy.Middleware
{
    public class TokenFilterAttribute : TypeFilterAttribute
    {
        public TokenFilterAttribute() : base(typeof(TokenFilter))
        {
        }
    }

    public class TokenFilter : IAuthorizationFilter
    {
        private bool IsAuthorized(string token) => System.IO.File.ReadAllText(lib.Common.Constants.FILE_TOKEN_FILENAME) == token;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey(lib.Common.Constants.HTTP_HEADER_TOKEN) || 
                !IsAuthorized(context.HttpContext.Request.Headers[lib.Common.Constants.HTTP_HEADER_TOKEN]))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}