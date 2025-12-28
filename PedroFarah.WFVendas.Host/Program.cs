using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PedroFarah.WFVendas.Domain.Validator;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.DataModule;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;

namespace PedroFarah.WFVendas.Host
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<Form1>();
                    services.AddSingleton<IDataModule, DataModule>();
                    services.AddTransient<IValidator<Produto>, ProdutoValidator>();
                    services.AddTransient<IValidator<Cliente>, ClienteValidator>();
                })
                .Build();

            ApplicationConfiguration.Initialize();

            using var scope = host.Services.CreateScope();
            var mainForm = scope.ServiceProvider.GetRequiredService<Form1>();
            Application.Run(mainForm);
        }
    }
}