namespace PedroFarah.WFVendas.Host
{
    partial class FrmRelatorioVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Panel pnlFiltros;

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
            pnlFiltros = new Panel();
            lblDataInicial = new Label();
            dtpDataInicial = new DateTimePicker();
            lblDataFinal = new Label();
            dtpDataFinal = new DateTimePicker();
            btnGerar = new Button();
            pnlFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFiltros
            // 
            pnlFiltros.Controls.Add(lblDataInicial);
            pnlFiltros.Controls.Add(dtpDataInicial);
            pnlFiltros.Controls.Add(lblDataFinal);
            pnlFiltros.Controls.Add(dtpDataFinal);
            pnlFiltros.Controls.Add(btnGerar);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(10);
            pnlFiltros.Size = new Size(900, 48);
            pnlFiltros.TabIndex = 0;
            // 
            // lblDataInicial
            // 
            lblDataInicial.AutoSize = true;
            lblDataInicial.Location = new Point(10, 15);
            lblDataInicial.Name = "lblDataInicial";
            lblDataInicial.Size = new Size(68, 15);
            lblDataInicial.TabIndex = 0;
            lblDataInicial.Text = "Data inicial:";
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(90, 11);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(110, 23);
            dtpDataInicial.TabIndex = 1;
            // 
            // lblDataFinal
            // 
            lblDataFinal.AutoSize = true;
            lblDataFinal.Location = new Point(215, 15);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(60, 15);
            lblDataFinal.TabIndex = 2;
            lblDataFinal.Text = "Data final:";
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Format = DateTimePickerFormat.Short;
            dtpDataFinal.Location = new Point(285, 11);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.Size = new Size(110, 23);
            dtpDataFinal.TabIndex = 3;
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(415, 10);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(142, 26);
            btnGerar.TabIndex = 4;
            btnGerar.Text = "Gerar Relatório";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // FrmRelatorioVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(pnlFiltros);
            Name = "FrmRelatorioVendas";
            Text = "Relatório de Vendas";
            Load += FrmRelatorioVendas_Load;
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}