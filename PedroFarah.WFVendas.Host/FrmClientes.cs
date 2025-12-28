using PedroFarah.WFVendas.Domain.Interfaces.Services;
using PedroFarah.WFVendas.Dto;

namespace PedroFarah.WFVendas.Host
{
    public partial class FrmClientes: Form
    {
        private readonly IClienteService _service;
        private int _clienteIdSelecionado;

        public FrmClientes(IClienteService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void FrmClientes_Shown(object? sender, EventArgs e)
        {
            BeginInvoke(async () =>
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                    await CarregarGridAsync();
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            });
        }


        private async Task CarregarGridAsync()
        {
            dgvClientes.DataSource = await _service.ListarGridAsync();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _clienteIdSelecionado = 0;
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtNome.Focus();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente
            {
                Id = _clienteIdSelecionado,
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text
            };

            if(_clienteIdSelecionado == 0)
                await _service.InserirAsync(cliente);
            else
                await _service.AtualizarAsync(cliente);

            await CarregarGridAsync();
            btnNovo.PerformClick();
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if(_clienteIdSelecionado == 0)
                return;

            if(MessageBox.Show(
                "Deseja realmente excluir o registro selecionado?",
                "Exclusão de registro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            await _service.ExcluirAsync(new Cliente { Id = _clienteIdSelecionado });

            await CarregarGridAsync();
            btnNovo.PerformClick();
        }

        private async void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
                return;

            _clienteIdSelecionado = (int)dgvClientes.Rows[e.RowIndex].Cells["Id"].Value;

            var cliente = await _service.ObterPorIdAsync(
                new Cliente { Id = _clienteIdSelecionado });

            if(cliente == null)
                return;

            txtNome.Text = cliente.Nome;
            txtEmail.Text = cliente.Email;
            txtTelefone.Text = cliente.Telefone;
        }
    }
}
