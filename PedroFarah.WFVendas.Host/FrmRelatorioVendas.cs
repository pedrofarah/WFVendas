using Microsoft.Reporting.WinForms;
using PedroFarah.WFVendas.Domain.Interfaces.Services;

namespace PedroFarah.WFVendas.Host
{
    public partial class FrmRelatorioVendas: Form
    {
        private readonly IVendaService _service;
        private ReportViewer? reportViewer1;

        public FrmRelatorioVendas(IVendaService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void FrmRelatorioVendas_Load(object sender, EventArgs e)
        {
            dtpDataInicial.Value = DateTime.Today.AddDays(-30);
            dtpDataFinal.Value = DateTime.Today;

            ConfigurarReportViewer();
        }

        private void ConfigurarReportViewer()
        {
            //reportViewer1 = new ReportViewer
            //{
            //    Dock = DockStyle.Fill,
            //    ProcessingMode = ProcessingMode.Local
            //};

            //reportViewer1.LocalReport.ReportEmbeddedResource =
            //    "PedroFarah.WFVendas.Host.Reports.RelatorioVendas.rdlc";

            //Controls.Add(reportViewer1);
            //reportViewer1.BringToFront();

            //reportViewer1.LocalReport.DataSources.Clear();
        }

        private async void btnGerar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ValidarPeriodo();

            //    btnGerar.Enabled = false;
            //    Cursor = Cursors.WaitCursor;

            //    await CarregarRelatorioAsync();
            //}
            //finally
            //{
            //    btnGerar.Enabled = true;
            //    Cursor = Cursors.Default;
            //}
        }


        private void ValidarPeriodo()
        {
            if(dtpDataInicial.Value.Date > dtpDataFinal.Value.Date)
            {
                throw new InvalidOperationException(
                    "A data inicial não pode ser maior que a data final.");
            }
        }

        private async Task CarregarRelatorioAsync()
        {
            var dataInicial = dtpDataInicial.Value.Date;
            var dataFinal = dtpDataFinal.Value.Date;

            var dados = await _service.ObterRelatorioAsync(dataInicial, dataFinal);

            reportViewer1!.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("DataSetVendas", dados));

            var parametros = new[]
            {
                new ReportParameter(
                    "DataInicial",
                    dataInicial.ToString("yyyy-MM-dd")),

                new ReportParameter(
                    "DataFinal",
                    dataFinal.ToString("yyyy-MM-dd"))
            };

            reportViewer1.LocalReport.SetParameters(parametros);

            reportViewer1.RefreshReport();
        }

    }
}
