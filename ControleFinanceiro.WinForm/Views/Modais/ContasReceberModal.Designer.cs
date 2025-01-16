using System;
using System.Globalization;
using System.Windows.Forms;

namespace ControleFinanceiro.WinForm.Views.Modais
{
    partial class ContasReceberModal 
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtClienteId;
        private TextBox txtValorDesconto;
        private TextBox txtValorReceber;
        private DateTimePicker dtpDataAReceber;
        private DateTimePicker dtpDataRecebimento;
        private TextBox txtObservacao;
        private ComboBox comboBoxSituacao;
        private Button btnSalvar;
        private Label lblCursor;
        private ComboBox comboBoxClienteId;

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

           

            this.comboBoxClienteId = new System.Windows.Forms.ComboBox();
            this.txtClienteId = new System.Windows.Forms.TextBox();
            this.txtValorDesconto = new System.Windows.Forms.TextBox();
            this.txtValorReceber = new System.Windows.Forms.TextBox();
            this.dtpDataAReceber = new System.Windows.Forms.DateTimePicker();
            this.dtpDataRecebimento = new System.Windows.Forms.DateTimePicker();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.comboBoxSituacao = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblCursor = new System.Windows.Forms.Label();
            this.txtQuantidadeParcelas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();


            this.dtpDataAReceber.CustomFormat = "dd/MM/yyyy"; // Formato brasileiro
            this.dtpDataRecebimento.CustomFormat = "dd/MM/yyyy"; // Formato brasileiro
            // 
            // txtClienteId
            // 
            this.txtClienteId.Location = new System.Drawing.Point(100, 30);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.Size = new System.Drawing.Size(200, 20);
            this.txtClienteId.TabIndex = 0;
            // 
            // txtValorDesconto
            // 
            this.txtValorDesconto.Location = new System.Drawing.Point(100, 60);
            this.txtValorDesconto.Name = "txtValorDesconto";
            this.txtValorDesconto.Size = new System.Drawing.Size(200, 20);
            this.txtValorDesconto.TabIndex = 1;
            // 
            // txtValorReceber
            // 
            this.txtValorReceber.Location = new System.Drawing.Point(100, 90);
            this.txtValorReceber.Name = "txtValorReceber";
            this.txtValorReceber.Size = new System.Drawing.Size(200, 20);
            this.txtValorReceber.TabIndex = 2;
            // 
            // dtpDataAReceber
            // 
            this.dtpDataAReceber.Location = new System.Drawing.Point(100, 120);
            this.dtpDataAReceber.Name = "dtpDataAReceber";
            this.dtpDataAReceber.Size = new System.Drawing.Size(200, 20);
            this.dtpDataAReceber.TabIndex = 3;
            // 
            // dtpDataRecebimento
            // 
            this.dtpDataRecebimento.Location = new System.Drawing.Point(100, 150);
            this.dtpDataRecebimento.Name = "dtpDataRecebimento";
            this.dtpDataRecebimento.Size = new System.Drawing.Size(200, 20);
            this.dtpDataRecebimento.TabIndex = 4;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(100, 180);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(200, 60);
            this.txtObservacao.TabIndex = 5;
            // 
            // comboBoxSituacao
            // 
            this.comboBoxSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSituacao.Items.AddRange(new object[] {
            "Pendente",
            "Recebido",
            "Cancelado"});
            this.comboBoxSituacao.Location = new System.Drawing.Point(100, 250);
            this.comboBoxSituacao.Name = "comboBoxSituacao";
            this.comboBoxSituacao.Size = new System.Drawing.Size(200, 21);
            this.comboBoxSituacao.TabIndex = 6;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(100, 313);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 30);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblCursor
            // 
            this.lblCursor.AutoSize = true;
            this.lblCursor.Location = new System.Drawing.Point(13, 330);
            this.lblCursor.Name = "lblCursor";
            this.lblCursor.Size = new System.Drawing.Size(47, 13);
            this.lblCursor.TabIndex = 8;
            this.lblCursor.Text = "lblCursor";
            // 
            // txtQuantidadeParcelas
            // 
            this.txtQuantidadeParcelas.Location = new System.Drawing.Point(100, 278);
            this.txtQuantidadeParcelas.Name = "txtQuantidadeParcelas";
            this.txtQuantidadeParcelas.Size = new System.Drawing.Size(47, 20);
            this.txtQuantidadeParcelas.TabIndex = 9;
            // 
            // ContasReceberModal
            //
            // this.comboBoxClienteId.FormattingEnabled = true;
            this.comboBoxClienteId.Location = new System.Drawing.Point(100, 30);
            this.comboBoxClienteId.Name = "comboBoxClienteId";
            this.comboBoxClienteId.Size = new System.Drawing.Size(200, 21); // Ajuste de tamanho
            this.comboBoxClienteId.TabIndex = 0;
            this.Controls.Add(this.comboBoxClienteId);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.txtQuantidadeParcelas);
            this.Controls.Add(this.txtClienteId);
            this.Controls.Add(this.txtValorDesconto);
            this.Controls.Add(this.txtValorReceber);
            this.Controls.Add(this.dtpDataAReceber);
            this.Controls.Add(this.dtpDataRecebimento);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.comboBoxSituacao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblCursor);
            this.Name = "ContasReceberModal";
            this.Text = "Contas a Receber";
            this.Load += new System.EventHandler(this.ContasReceberModal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox txtQuantidadeParcelas;
    }
}
