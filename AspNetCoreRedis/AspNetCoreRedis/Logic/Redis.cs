using Microsoft.Extensions.Caching.Distributed;

namespace AspNetCoreRedis.Logic
{
    public class Redis
    {
        public static async Task<byte[]> Get_cachedTimeUTC(IDistributedCache redis_service)
        {
            return await redis_service.GetAsync("cachedTimeUTC");
        }

        public static async Task Set_cachedTimeUTC(IDistributedCache redis_service,IConfiguration Configuration)
        {
            var tmp_Redis_cache_timeout = Configuration.GetValue(typeof(double), "Redis_cache_timeout");
            var currentTimeUTC = DateTime.UtcNow.ToString();
            byte[] encodedCurrentTimeUTC = System.Text.Encoding.UTF8.GetBytes(currentTimeUTC);
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds((double)tmp_Redis_cache_timeout));
            await redis_service
                .SetAsync("cachedTimeUTC", encodedCurrentTimeUTC, options);
        }
    }
}
