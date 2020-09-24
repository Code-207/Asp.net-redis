using StackExchange.Redis;
namespace Asp.net_redis.Services
{
    public class CommodityRecord
    {
        public void CommodityRecore(){
            var redis = ConnectionMultiplexer.Connect("localhost:6379,password:11");
            var db1 = redis.GetDatabase();

        }
    }
}
