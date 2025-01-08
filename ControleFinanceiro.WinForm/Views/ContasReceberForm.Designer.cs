namespace ControleFinanceiro.WinForm.Views
{
    partial class ContasReceberForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvContas;
        private System.Windows.Forms.TextBox txtFiltroCliente;
        private System.Windows.Forms.Label lblFiltroCliente;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvContas = new System.Windows.Forms.DataGridView();
            this.txtFiltroCliente = new System.Windows.Forms.TextBox();
            this.lblFiltroCliente = new System.Windows.Forms.Label();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContas
            // 
            this.dgvContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContas.Location = new System.Drawing.Point(10, 43);
            this.dgvContas.Name = "dgvContas";
            this.dgvContas.Size = new System.Drawing.Size(480, 217);
            this.dgvContas.TabIndex = 0;
            // 
            // txtFiltroCliente
            // 
            this.txtFiltroCliente.Location = new System.Drawing.Point(86, 13);
            this.txtFiltroCliente.Name = "txtFiltroCliente";
            this.txtFiltroCliente.Size = new System.Drawing.Size(155, 20);
            this.txtFiltroCliente.TabIndex = 1;
            this.txtFiltroCliente.TextChanged += new System.EventHandler(this.txtFiltroCliente_TextChanged);
            // 
            // lblFiltroCliente
            // 
            this.lblFiltroCliente.AutoSize = true;
            this.lblFiltroCliente.Location = new System.Drawing.Point(10, 16);
            this.lblFiltroCliente.Name = "lblFiltroCliente";
            this.lblFiltroCliente.Size = new System.Drawing.Size(70, 13);
            this.lblFiltroCliente.TabIndex = 2;
            this.lblFiltroCliente.Text = "Filtrar Cliente:";
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(10, 277);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(69, 26);
            this.btnIncluir.TabIndex = 3;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(86, 277);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(69, 26);
            this.btnAlterar.TabIndex = 4;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(163, 277);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(69, 26);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // ContasReceberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(501, 313);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.lblFiltroCliente);
            this.Controls.Add(this.txtFiltroCliente);
            this.Controls.Add(this.dgvContas);
            this.Name = "ContasReceberForm";
            this.Text = "Contas a Receber";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}