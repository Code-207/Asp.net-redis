using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Asp.net_redis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
             CreateHostBuilder(args).Build().Run();
            //Console.WriteLine(GenerateMd5("zjj2073272004"));
        }
        public static string GenerateMd5(string txt)
        {
            using MD5 mi = MD5.Create();
            var buffer = Encoding.Default.GetBytes(txt);
            //¿ªÊ¼¼ÓÃÜ
            var newBuffer = mi.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach (var t in newBuffer)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
