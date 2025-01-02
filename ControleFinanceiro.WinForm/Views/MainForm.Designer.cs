namespace ControleFinanceiro.WinForm.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.clienteFormButton = new System.Windows.Forms.Button();
            this.servidorFormButton = new System.Windows.Forms.Button();
            this.ContasReceberTable = new System.Windows.Forms.DataGridView();
            this.contasReceberFormButton = new System.Windows.Forms.Button();
            this.contasPagarFormButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ContasReceberTable)).BeginInit();
            this.SuspendLayout();
            // 
            // clienteFormButton
            // 
            this.clienteFormButton.Location = new System.Drawing.Point(2, 2);
            this.clienteFormButton.Name = "clienteFormButton";
            this.clienteFormButton.Size = new System.Drawing.Size(121, 45);
            this.clienteFormButton.TabIndex = 0;
            this.clienteFormButton.Text = "Clientes";
            this.clienteFormButton.UseVisualStyleBackColor = true;
            this.clienteFormButton.Click += new System.EventHandler(this.ClienteFormButton_Click);
            // 
            // servidorFormButton
            // 
            this.servidorFormButton.Location = new System.Drawing.Point(129, 2);
            this.servidorFormButton.Name = "servidorFormButton";
            this.servidorFormButton.Size = new System.Drawing.Size(121, 45);
            this.servidorFormButton.TabIndex = 1;
            this.servidorFormButton.Text = "Servidores";
            this.servidorFormButton.UseVisualStyleBackColor = true;
            this.servidorFormButton.Click += new System.EventHandler(this.ServidorFormButton_Click);
            // 
            // ContasReceberTable
            // 
            this.ContasReceberTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContasReceberTable.Location = new System.Drawing.Point(12, 238);
            this.ContasReceberTable.Name = "ContasReceberTable";
            this.ContasReceberTable.Size = new System.Drawing.Size(776, 261);
            this.ContasReceberTable.TabIndex = 2;
            // 
            // contasReceberFormButton
            // 
            this.contasReceberFormButton.Location = new System.Drawing.Point(257, 2);
            this.contasReceberFormButton.Name = "contasReceberFormButton";
            this.contasReceberFormButton.Size = new System.Drawing.Size(121, 45);
            this.contasReceberFormButton.TabIndex = 3;
            this.contasReceberFormButton.Text = "Contas Receber";
            this.contasReceberFormButton.UseVisualStyleBackColor = true;
            this.contasReceberFormButton.Click += new System.EventHandler(this.ContasReceberFormButton_Click);
            // 
            // contasPagarFormButton
            // 
            this.contasPagarFormButton.Location = new System.Drawing.Point(384, 2);
            this.contasPagarFormButton.Name = "contasPagarFormButton";
            this.contasPagarFormButton.Size = new System.Drawing.Size(121, 45);
            this.contasPagarFormButton.TabIndex = 4;
            this.contasPagarFormButton.Text = "Contas Pagar";
            this.contasPagarFormButton.UseVisualStyleBackColor = true;
            this.contasPagarFormButton.Click += new System.EventHandler(this.ContasPagarFormButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.contasPagarFormButton);
            this.Controls.Add(this.contasReceberFormButton);
            this.Controls.Add(this.ContasReceberTable);
            this.Controls.Add(this.servidorFormButton);
            this.Controls.Add(this.clienteFormButton);
            this.Name = "MainForm";
            this.Text = "Controle Financeiro";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ContasReceberTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clienteFormButton;
        private System.Windows.Forms.Button servidorFormButton;
        private System.Windows.Forms.Button contasReceberFormButton;
        private System.Windows.Forms.Button contasPagarFormButton;
        private System.Windows.Forms.DataGridView ContasReceberTable;
    }
}

