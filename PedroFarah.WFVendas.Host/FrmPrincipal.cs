using Microsoft.Extensions.DependencyInjection;

namespace PedroFarah.WFVendas.Host
{
    public partial class FrmPrincipal: Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FrmPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void AbrirFormulario<TForm>() where TForm : Form
        {
            var scope = _serviceProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<TForm>();

            form.MdiParent = this;
            form.FormClosed += (_, __) => scope.Dispose();

            form.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmProdutos>();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmClientes>();
        }

        private void movimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmVendas>();
        }

        private void relatórioDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmRelatorioVendas>();
        }
    }
}
