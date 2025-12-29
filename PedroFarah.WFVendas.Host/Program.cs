using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PedroFarah.WFVendas.Domain.Interfaces.Services;
using PedroFarah.WFVendas.Domain.Services;
using PedroFarah.WFVendas.Domain.Validators;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Host.ExceptionHandlers;
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
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddDebug();
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<IDataModule, DataModule>();
                    services.AddScoped<IValidator<Produto>, ProdutoValidator>();
                    services.AddScoped<IValidator<Cliente>, ClienteValidator>();
                    services.AddScoped<IValidator<Venda>, VendaValidator>();
                    services.AddScoped<IClienteService, ClienteService>();
                    services.AddScoped<IProdutoService, ProdutoService>();
                    services.AddScoped<IVendaService, VendaService>();
                    services.AddTransient<FrmPrincipal>();
                    services.AddTransient<FrmProdutos>();
                    services.AddTransient<FrmClientes>();
                    services.AddTransient<FrmVendas>();
                    services.AddTransient<FrmRelatorioVendas>();
                })
                .Build();

            ApplicationConfiguration.Initialize();

            Application.ThreadException += (sender, args) =>
            {
                ExceptionHandler.Handle(args.Exception);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                if(args.ExceptionObject is Exception ex)
                    ExceptionHandler.Handle(ex);
            };

            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                ExceptionHandler.Handle(args.Exception);
                args.SetObserved();
            };

            using var scope = host.Services.CreateScope();
            var mainForm = scope.ServiceProvider.GetRequiredService<FrmPrincipal>();
            Application.Run(mainForm);
        }
    }
}