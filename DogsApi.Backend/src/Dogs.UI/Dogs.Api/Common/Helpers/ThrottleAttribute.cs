using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Net;

namespace Dogs.Api.Common.Helpers
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ThrottleFilterAttribute : ActionFilterAttribute
    {
        public ThrottleFilterAttribute()
        {

        }
        public string Name { get; set; }
        public int Seconds { get; set; }
        public string Message { get; set; }

        public override void OnActionExecuting(ActionExecutingContext c)
        {
            var memCache = (IMemoryCache)c.HttpContext.RequestServices.GetService(typeof(IMemoryCache));
            var testProxy = c.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For");
            var key = 0;
            if (testProxy)
            {
                var ipAddress = IPAddress.TryParse(c.HttpContext.Request.Headers["X-Forwarded-For"], out IPAddress realClient);
                if (ipAddress)
                {
                    key = realClient.GetHashCode();
                }
            }
            if (key != 0)
            {
                key = c.HttpContext.Connection.RemoteIpAddress.GetHashCode();
            }
            memCache.TryGetValue(key, out bool forbidExecute);

            memCache.Set(key, true, new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMilliseconds(Seconds) });

            if (forbidExecute)
            {
                if (String.IsNullOrEmpty(Message))
                    Message = $"You may only perform this action every {Seconds}ms.";

                c.Result = new ContentResult { Content = Message, ContentType = "text/plain" };
                c.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            }
        }
    }
}
