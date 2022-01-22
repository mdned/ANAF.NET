using ANAF.NET;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Demo.ConsoleApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var anafService = AnafConfiguration.GetAnafService();
                var result = await anafService.SearchCompany("11588780");
                Console.WriteLine(JsonConvert.SerializeObject(result));
                Console.ReadLine();
            }
            catch (AnafException)
            {
                throw;
            }
        }
    }
}