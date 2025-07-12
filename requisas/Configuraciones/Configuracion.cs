using Microsoft.Extensions.Configuration;


namespace Configuraciones
{
    public static class Configuracion
    {
        public static IConfiguration? Configuration;


        static Configuracion()
        {
            CargarConfiguracion();
        }

        private static void CargarConfiguracion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(typeof(Configuracion).Assembly.Location)!)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
        public static string? Get(string key) => Configuration?[key];
    }
}
