namespace PedroFarah.WFVendas.Host
{
    partial class FrmProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvProdutos;
        private Label lblDescricao;
        private Label lblNome;
        private Label lblPreco;
        private Label lblEstoque;
        private TextBox txtNome;
        private TextBox txtDescricao;
        private NumericUpDown numPreco;
        private NumericUpDown numEstoque;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnExcluir;

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
            dgvProdutos = new DataGridView();
            lblNome = new Label();
            lblDescricao = new Label();
            lblPreco = new Label();
            lblEstoque = new Label();
            txtNome = new TextBox();
            txtDescricao = new TextBox();
            numPreco = new NumericUpDown();
            numEstoque = new NumericUpDown();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnExcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEstoque).BeginInit();
            SuspendLayout();
            // 
            // dgvProdutos
            // 
            dgvProdutos.Location = new Point(12, 12);
            dgvProdutos.MultiSelect = false;
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.ReadOnly = true;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.Size = new Size(547, 200);
            dgvProdutos.TabIndex = 0;
            dgvProdutos.CellClick += dgvProdutos_CellClick;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(12, 233);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 8;
            lblNome.Text = "Nome:";
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(12, 263);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(61, 15);
            lblDescricao.TabIndex = 9;
            lblDescricao.Text = "Descrição:";
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Location = new Point(12, 293);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(40, 15);
            lblPreco.TabIndex = 10;
            lblPreco.Text = "Preço:";
            // 
            // lblEstoque
            // 
            lblEstoque.AutoSize = true;
            lblEstoque.Location = new Point(12, 323);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(52, 15);
            lblEstoque.TabIndex = 11;
            lblEstoque.Text = "Estoque:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(100, 230);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(458, 23);
            txtNome.TabIndex = 1;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(100, 260);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(458, 23);
            txtDescricao.TabIndex = 2;
            // 
            // numPreco
            // 
            numPreco.DecimalPlaces = 2;
            numPreco.Location = new Point(100, 291);
            numPreco.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPreco.Name = "numPreco";
            numPreco.Size = new Size(105, 23);
            numPreco.TabIndex = 3;
            // 
            // numEstoque
            // 
            numEstoque.Location = new Point(100, 321);
            numEstoque.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numEstoque.Name = "numEstoque";
            numEstoque.Size = new Size(105, 23);
            numEstoque.TabIndex = 4;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(100, 356);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(90, 23);
            btnNovo.TabIndex = 5;
            btnNovo.Text = "Novo";
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(200, 356);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(90, 23);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(300, 356);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(90, 23);
            btnExcluir.TabIndex = 7;
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // FrmProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 395);
            Controls.Add(dgvProdutos);
            Controls.Add(txtNome);
            Controls.Add(txtDescricao);
            Controls.Add(numPreco);
            Controls.Add(numEstoque);
            Controls.Add(btnNovo);
            Controls.Add(btnSalvar);
            Controls.Add(btnExcluir);
            Controls.Add(lblNome);
            Controls.Add(lblDescricao);
            Controls.Add(lblPreco);
            Controls.Add(lblEstoque);
            Name = "FrmProdutos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Produtos";
            Load += FrmProdutos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEstoque).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}