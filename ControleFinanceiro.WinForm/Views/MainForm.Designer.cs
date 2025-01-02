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
            ((System.ComponentModel.ISupportInitialize)(this.ContasReceberTable)).BeginInit();
            this.SuspendLayout();
            // 
            // clienteFormButton
            // 
            this.clienteFormButton.Location = new System.Drawing.Point(42, 39);
            this.clienteFormButton.Name = "clienteFormButton";
            this.clienteFormButton.Size = new System.Drawing.Size(121, 45);
            this.clienteFormButton.TabIndex = 0;
            this.clienteFormButton.Text = "Clientes";
            this.clienteFormButton.UseVisualStyleBackColor = true;
            this.clienteFormButton.Click += new System.EventHandler(this.ClienteFormButton_Click);
            // 
            // servidorFormButton
            // 
            this.servidorFormButton.Location = new System.Drawing.Point(193, 39);
            this.servidorFormButton.Name = "servidorFormButton";
            this.servidorFormButton.Size = new System.Drawing.Size(121, 45);
            this.servidorFormButton.TabIndex = 1;
            this.servidorFormButton.Text = "Servidores";
            this.servidorFormButton.UseVisualStyleBackColor = true;
            this.servidorFormButton.Click += new System.EventHandler(this.servidorFormButton_Click);
            // 
            // ContasReceberTable
            // 
            this.ContasReceberTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContasReceberTable.Location = new System.Drawing.Point(12, 238);
            this.ContasReceberTable.Name = "ContasReceberTable";
            this.ContasReceberTable.Size = new System.Drawing.Size(776, 261);
            this.ContasReceberTable.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.ContasReceberTable);
            this.Controls.Add(this.servidorFormButton);
            this.Controls.Add(this.clienteFormButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ContasReceberTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clienteFormButton;
        private System.Windows.Forms.Button servidorFormButton;
        private System.Windows.Forms.DataGridView ContasReceberTable;
    }
}

