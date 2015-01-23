namespace SystemDot.Web.WebApi.Caching
{
    using System;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Filters;

    public class NoCacheFilterAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true,
                NoStore = true,
                MustRevalidate = true,
                MaxAge = new TimeSpan(0, 0, 0),
                Public = true
            };
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }
}