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

        private async void FrmProdutos_Load(object sender, EventArgs e)
            => dgvProdutos.DataSource = await _service.ListarGridAsync();

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _produtoIdSelecionado = 0;
            txtNome.Clear();
            txtDescricao.Clear();
            numPreco.Value = 0;
            numEstoque.Value = 0;
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

            dgvProdutos.DataSource = await _service.ListarGridAsync();
            btnNovo.PerformClick();
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if(_produtoIdSelecionado == 0) return;

            await _service.ExcluirAsync(new Produto { Id = _produtoIdSelecionado });
            dgvProdutos.DataSource = await _service.ListarGridAsync();
            btnNovo.PerformClick();
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            var row = dgvProdutos.Rows[e.RowIndex];
            _produtoIdSelecionado = (int)row.Cells["Id"].Value;

            txtNome.Text = row.Cells["Nome"].Value.ToString();
            txtDescricao.Text = row.Cells["Descrição"].Value.ToString();
            numPreco.Value = (decimal)row.Cells["Preço"].Value;
            numEstoque.Value = (int)row.Cells["Estoque"].Value;
        }
    }
}
