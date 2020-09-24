using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using StackExchange.Redis;

namespace Asp.net_redis.ViewComponent
{
    public class ReadViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public readonly IConnectionMultiplexer Redis;
        public readonly IDatabase Db1;
        public ReadViewComponent(IConnectionMultiplexer redis)
        {
            Redis = redis;
            Db1 = redis.GetDatabase();
        }
        

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            try
            {
                var x = await Db1.SortedSetAddAsync
                    ("redis-set", "admin", 10);
                return View(x);
            }
            catch (RedisException e)
            {
                Console.WriteLine("Stack:" + e.StackTrace + "Message\n" + e.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
}
