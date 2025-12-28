using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PedroFarah.WFVendas.Domain.Interfaces.Services;
using PedroFarah.WFVendas.Domain.Services;
using PedroFarah.WFVendas.Domain.Validators;
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
                    services.AddTransient<FrmPrincipal>();
                    services.AddTransient<FrmProdutos>();
                    services.AddScoped<IDataModule, DataModule>();
                    services.AddScoped<IValidator<Produto>, ProdutoValidator>();
                    services.AddScoped<IValidator<Cliente>, ClienteValidator>();
                    services.AddScoped<IClienteService, ClienteService>();
                    services.AddScoped<IProdutoService, ProdutoService>();
                })
                .Build();

            ApplicationConfiguration.Initialize();

            using var scope = host.Services.CreateScope();
            var mainForm = scope.ServiceProvider.GetRequiredService<FrmPrincipal>();
            Application.Run(mainForm);
        }
    }
}