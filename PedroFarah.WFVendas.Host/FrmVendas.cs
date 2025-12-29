using PedroFarah.WFVendas.Domain.Interfaces.Services;
using PedroFarah.WFVendas.Dto;
using System.Data;

namespace PedroFarah.WFVendas.Host
{
    public partial class FrmVendas: Form
    {
        private readonly IClienteService _clienteService;
        private readonly IProdutoService _produtoService;
        private readonly IVendaService _vendaService;

        private List<VendaItem> _itens = new();

        public FrmVendas(
            IClienteService clienteService,
            IProdutoService produtoService,
            IVendaService vendaService)
        {
            InitializeComponent();
            _clienteService = clienteService;
            _produtoService = produtoService;
            _vendaService = vendaService;
        }

        private async void FrmVenda_Shown(object? sender, EventArgs e)
        {
            await CarregarCombosAsync();
            await NovaVenda();
        }

        private async Task NovaVenda()
        {
            this._itens = new();
            await CarregarCombosAsync();
            AtualizarGrid();

            cbClientes.SelectedItem = null;
            cbProdutos.SelectedItem = null;
        }


        private async Task CarregarCombosAsync()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                cbClientes.DataSource = await _clienteService.ListarAsync();
                cbClientes.DisplayMember = "Nome";
                cbClientes.ValueMember = "Id";

                cbProdutos.DataSource = await _produtoService.ListarAsync();
                cbProdutos.DisplayMember = "Nome";
                cbProdutos.ValueMember = "Id";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            if(cbProdutos.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecione o produto.",
                    "Adicionar Item",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var quantidade = (int)numQuantidade.Value;

            if(quantidade <= 0)
            {
                MessageBox.Show(
                    "Informe a quantidade do item.",
                    "Adicionar Item",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if(cbProdutos.SelectedItem is not Produto produto)
                throw new InvalidOperationException("Não foi possível localizar o produto selecionado.");

            var existente = _itens.FirstOrDefault(x => x.ProdutoId == produto!.Id);
            if(existente != null)
            {
                existente.Quantidade += quantidade;
            }
            else
            {
                _itens.Add(new VendaItem
                {
                    ProdutoId = produto.Id,
                    Produto = produto,
                    Quantidade = quantidade,
                    PrecoUnitario = produto.Preco
                });
            }

            AtualizarGrid();
        }

        private void ExibirTotalVenda()
        {
            lblTotal.Text = $"Total: R$ {_itens.Sum(i => i.PrecoUnitario * i.Quantidade):N2}";
        }

        private void AtualizarGrid()
        {
            dgvItens.DataSource = null;
            dgvItens.DataSource = _itens.Select(i => new
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade,
                PrecoUnitario = i.PrecoUnitario,
                Subtotal = i.PrecoUnitario * i.Quantidade
            }).ToList();

            ExibirTotalVenda();
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(cbClientes.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecione o cliente.",
                    "Confirmar Venda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if(cbClientes.SelectedItem is not Cliente cliente)
                throw new InvalidOperationException("Não foi possível localizar o cliente selecionado.");

            var venda = new Venda
            {
                ClienteId = cliente.Id,
                Cliente = cliente,
                Total = _itens.Sum(i => i.PrecoUnitario * i.Quantidade),
                Itens = _itens
            };

            await _vendaService.RegistrarVendaAsync(venda);

            MessageBox.Show("Venda registrada com sucesso.", "Confirmar Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await NovaVenda();
        }

        private async void btnNovaVenda_Click(object sender, EventArgs e)
        {
            await NovaVenda();
        }
    }
}
