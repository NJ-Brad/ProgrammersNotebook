using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace ProgrammersNotebook
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    //  If you want configuration available for your services :
                    //  https://stackoverflow.com/questions/71480200/how-to-access-iconfiguration-provided-by-createdefaultbuilder-from-within-conf
                    var config = hostContext.Configuration;

                    services.AddLogging(configure => configure.AddDebug())
                    .AddScoped<NotebookForm>()     // this puts the form under DI
                    ;
                    // configure other services here
                }).Build();

            //var form1 = host.Services.GetRequiredService<Form1>();
            var form1 = host.Services.GetRequiredService<NotebookForm>();
            Application.Run(form1);
        }
    }
}
