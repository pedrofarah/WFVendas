namespace PedroFarah.WFVendas.Host
{
    partial class FrmVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private ComboBox cbClientes;
        private ComboBox cbProdutos;
        private NumericUpDown numQuantidade;
        private Button btnAdicionarItem;
        private Button btnConfirmar;

        private DataGridView dgvItens;

        private Label lblCliente;
        private Label lblProduto;
        private Label lblQuantidade;
        private Label lblTotal;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbClientes = new ComboBox();
            cbProdutos = new ComboBox();
            numQuantidade = new NumericUpDown();
            btnAdicionarItem = new Button();
            btnConfirmar = new Button();
            dgvItens = new DataGridView();
            lblCliente = new Label();
            lblProduto = new Label();
            lblQuantidade = new Label();
            lblTotal = new Label();
            btnNovaVenda = new Button();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            SuspendLayout();
            // 
            // cbClientes
            // 
            cbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClientes.Location = new Point(119, 15);
            cbClientes.Name = "cbClientes";
            cbClientes.Size = new Size(300, 23);
            cbClientes.TabIndex = 1;
            // 
            // cbProdutos
            // 
            cbProdutos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProdutos.Location = new Point(119, 45);
            cbProdutos.Name = "cbProdutos";
            cbProdutos.Size = new Size(300, 23);
            cbProdutos.TabIndex = 3;
            // 
            // numQuantidade
            // 
            numQuantidade.Location = new Point(119, 75);
            numQuantidade.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantidade.Name = "numQuantidade";
            numQuantidade.Size = new Size(120, 23);
            numQuantidade.TabIndex = 5;
            numQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAdicionarItem
            // 
            btnAdicionarItem.Location = new Point(249, 75);
            btnAdicionarItem.Name = "btnAdicionarItem";
            btnAdicionarItem.Size = new Size(75, 23);
            btnAdicionarItem.TabIndex = 6;
            btnAdicionarItem.Text = "Adicionar Item";
            btnAdicionarItem.Click += btnAdicionarItem_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(13, 365);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(150, 23);
            btnConfirmar.TabIndex = 9;
            btnConfirmar.Text = "Confirmar Venda";
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // dgvItens
            // 
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItens.Location = new Point(13, 113);
            dgvItens.Name = "dgvItens";
            dgvItens.ReadOnly = true;
            dgvItens.Size = new Size(524, 200);
            dgvItens.TabIndex = 7;
            // 
            // lblCliente
            // 
            lblCliente.Location = new Point(13, 18);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(100, 23);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // lblProduto
            // 
            lblProduto.Location = new Point(13, 48);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(100, 23);
            lblProduto.TabIndex = 2;
            lblProduto.Text = "Produto:";
            // 
            // lblQuantidade
            // 
            lblQuantidade.Location = new Point(13, 78);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(100, 23);
            lblQuantidade.TabIndex = 4;
            lblQuantidade.Text = "Quantidade:";
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(13, 333);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(342, 23);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "Total: R$ 0,00";
            // 
            // btnNovaVenda
            // 
            btnNovaVenda.Location = new Point(387, 367);
            btnNovaVenda.Name = "btnNovaVenda";
            btnNovaVenda.Size = new Size(150, 23);
            btnNovaVenda.TabIndex = 10;
            btnNovaVenda.Text = "Nova Venda";
            btnNovaVenda.Click += btnNovaVenda_Click;
            // 
            // FrmVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 400);
            Controls.Add(btnNovaVenda);
            Controls.Add(lblCliente);
            Controls.Add(cbClientes);
            Controls.Add(lblProduto);
            Controls.Add(cbProdutos);
            Controls.Add(lblQuantidade);
            Controls.Add(numQuantidade);
            Controls.Add(btnAdicionarItem);
            Controls.Add(dgvItens);
            Controls.Add(lblTotal);
            Controls.Add(btnConfirmar);
            Name = "FrmVendas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Venda";
            Shown += FrmVenda_Shown;
            ((System.ComponentModel.ISupportInitialize)numQuantidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNovaVenda;
    }
}