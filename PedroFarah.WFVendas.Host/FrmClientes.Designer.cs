namespace PedroFarah.WFVendas.Host
{
    partial class FrmClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvClientes;

        private Label lblNome;
        private Label lblEmail;
        private Label lblTelefone;

        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtTelefone;

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
            dgvClientes = new DataGridView();
            lblNome = new Label();
            lblEmail = new Label();
            lblTelefone = new Label();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtTelefone = new TextBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnExcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.Location = new Point(12, 12);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(547, 200);
            dgvClientes.TabIndex = 0;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(12, 233);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 1;
            lblNome.Text = "Nome:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 263);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "E-mail:";
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(12, 293);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(54, 15);
            lblTelefone.TabIndex = 5;
            lblTelefone.Text = "Telefone:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(100, 230);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(458, 23);
            txtNome.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(100, 260);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(458, 23);
            txtEmail.TabIndex = 4;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(100, 290);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(200, 23);
            txtTelefone.TabIndex = 6;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(100, 332);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(90, 23);
            btnNovo.TabIndex = 7;
            btnNovo.Text = "Novo";
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(200, 332);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(90, 23);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(300, 332);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(90, 23);
            btnExcluir.TabIndex = 9;
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // FrmClientes
            // 
            ClientSize = new Size(570, 369);
            Controls.Add(dgvClientes);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblTelefone);
            Controls.Add(txtTelefone);
            Controls.Add(btnNovo);
            Controls.Add(btnSalvar);
            Controls.Add(btnExcluir);
            Name = "FrmClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Clientes";
            Shown += FrmClientes_Shown;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion
    }
}