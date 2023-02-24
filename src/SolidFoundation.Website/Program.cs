using System.Diagnostics.CodeAnalysis;

namespace SolidFoundation.Website;

[ExcludeFromCodeCoverage]
public class Program
{
    protected static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureCmsDefaults()
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}
