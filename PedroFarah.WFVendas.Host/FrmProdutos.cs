using PedroFarah.WFVendas.Domain.Interfaces.Services;
using PedroFarah.WFVendas.Dto;

namespace PedroFarah.WFVendas.Host
{
    public partial class FrmProdutos: Form
    {
        private readonly IProdutoService _service;
        private int _produtoIdSelecionado = 0;

        public FrmProdutos(IProdutoService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
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
            dgvProdutos.DataSource = await _service.ListarGridAsync();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _produtoIdSelecionado = 0;
            txtNome.Clear();
            txtDescricao.Clear();
            numPreco.Value = 0;
            numEstoque.Value = 0;
            txtNome.Focus();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var produto = new Produto
            {
                Id = _produtoIdSelecionado,
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                Preco = numPreco.Value,
                Estoque = (int)numEstoque.Value
            };

            if(_produtoIdSelecionado == 0)
                await _service.InserirAsync(produto);
            else
                await _service.AtualizarAsync(produto);

            await CarregarGridAsync();
            btnNovo.PerformClick();
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if(_produtoIdSelecionado == 0)
                return;

            if(MessageBox.Show(
                "Deseja realmente excluir o registro selecionado?",
                "Exclusão de registro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            await _service.ExcluirAsync(new Produto { Id = _produtoIdSelecionado });

            await CarregarGridAsync();
            btnNovo.PerformClick();
        }

        private async void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
                return;

            if(dgvProdutos.Rows[e.RowIndex].Cells["Id"].Value == DBNull.Value)
                return;

            _produtoIdSelecionado = (int)(dgvProdutos.Rows[e.RowIndex].Cells["Id"].Value!);

            var prod = await _service.ObterPorIdAsync(new Produto { Id = _produtoIdSelecionado }) ?? throw new Exception("Produto não localizado.");

            txtNome.Text = prod.Nome;
            txtDescricao.Text = prod.Descricao;
            numPreco.Value = prod.Preco;
            numEstoque.Value = prod.Estoque;
        }
    }
}
