using Microsoft.Extensions.Configuration;

namespace ConfigDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var (provider, conn) = GetProviderFromConfiguration();

            Console.WriteLine($"Provider: {provider}");
            Console.WriteLine($"Connection String: {conn}");
        }

        static (string Provider, string ConnectionString) GetProviderFromConfiguration()
        {
            // Building the configuration object
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Reading values from the config file
            string provider = config["ProviderName"];
            string connStr = config["SqlServer:ConnectionString"];

            return (provider, connStr);
        }
    }
}
