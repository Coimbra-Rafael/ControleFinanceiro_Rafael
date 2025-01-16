namespace ControleFinanceiro.WinForm.Views
{
    partial class ContasReceberForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvContas;
        private System.Windows.Forms.TextBox txtFiltroCliente;
        private System.Windows.Forms.Label lblFiltroCliente;

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
            this.incluir = new System.Windows.Forms.Button();
            this.alterar = new System.Windows.Forms.Button();
            this.excluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContas
            // 
            this.dgvContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContas.Location = new System.Drawing.Point(9, 51);
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
            // incluir
            // 
            this.incluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.incluir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.incluir.Location = new System.Drawing.Point(9, 274);
            this.incluir.Name = "incluir";
            this.incluir.Size = new System.Drawing.Size(97, 36);
            this.incluir.TabIndex = 6;
            this.incluir.Text = "Incluir";
            this.incluir.UseVisualStyleBackColor = false;
            this.incluir.Click += new System.EventHandler(this.incluir_Click);
            // 
            // alterar
            // 
            this.alterar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(171)))), ((int)(((byte)(78)))));
            this.alterar.Location = new System.Drawing.Point(112, 274);
            this.alterar.Name = "alterar";
            this.alterar.Size = new System.Drawing.Size(97, 36);
            this.alterar.TabIndex = 7;
            this.alterar.Text = "Alterar";
            this.alterar.UseVisualStyleBackColor = false;
            this.alterar.Click += new System.EventHandler(this.alterar_Click);
            // 
            // excluir
            // 
            this.excluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(120)))), ((int)(((byte)(86)))));
            this.excluir.Location = new System.Drawing.Point(215, 274);
            this.excluir.Name = "excluir";
            this.excluir.Size = new System.Drawing.Size(97, 36);
            this.excluir.TabIndex = 8;
            this.excluir.Text = "Excluir";
            this.excluir.UseVisualStyleBackColor = false;
            this.excluir.Click += new System.EventHandler(this.excluir_Click);
            // 
            // ContasReceberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(501, 318);
            this.Controls.Add(this.incluir);
            this.Controls.Add(this.alterar);
            this.Controls.Add(this.excluir);
            this.Controls.Add(this.lblFiltroCliente);
            this.Controls.Add(this.txtFiltroCliente);
            this.Controls.Add(this.dgvContas);
            this.Name = "ContasReceberForm";
            this.Text = "Contas a Receber";
            this.Load += new System.EventHandler(this.ContasReceberForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button incluir;
        private System.Windows.Forms.Button alterar;
        private System.Windows.Forms.Button excluir;
    }
}