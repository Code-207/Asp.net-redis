using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Asp.net_redis.ViewComponent
{
    public class MessageLogViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public readonly IConnectionMultiplexer Redis;
        public readonly IDatabase Db1;
        public MessageLogViewComponent(IConnectionMultiplexer redis)
        {
            Redis = redis;
            Db1 = Redis.GetDatabase();
        }
        public IViewComponentResult Invoke() {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            Db1.StringIncrement($"{controller}/{action}");
            var value = Db1.StringGet($"{controller}/{action}");
            return View(value);
        }
    }

}
