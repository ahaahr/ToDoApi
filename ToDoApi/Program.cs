using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ToDoApi
{
    public static class Globals
    {
        //public static readonly string CONNECTIONSTRING = "Server=(localdb)\\mssqllocaldb;Database=ToDoDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        public static readonly string CONNECTIONSTRING = @"
            Server=127.0.0.1,1433;
            Database=Master;
            User Id=SA;
            Password=MangoMango123
        ";
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
            .UseKestrel()
            .UseUrls("http://*:5000")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build()
            .Run();       
        }
    }
}
