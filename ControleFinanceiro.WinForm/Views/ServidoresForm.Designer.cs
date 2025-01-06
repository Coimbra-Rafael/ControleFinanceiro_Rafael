using System;

namespace ControleFinanceiro.WinForm.Views
{
    partial class ServidoresForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            this.servidorGridView = new System.Windows.Forms.DataGridView();
            this.incluir = new System.Windows.Forms.Button();
            this.alterar = new System.Windows.Forms.Button();
            this.excluir = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.servidorGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // servidorGridView
            // 
            this.servidorGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.servidorGridView.Location = new System.Drawing.Point(13, 205);
            this.servidorGridView.Name = "servidorGridView";
            this.servidorGridView.Size = new System.Drawing.Size(775, 233);
            this.servidorGridView.TabIndex = 0;
            // 
            // incluir
            // 
            this.incluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.incluir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.incluir.Location = new System.Drawing.Point(13, 163);
            this.incluir.Name = "incluir";
            this.incluir.Size = new System.Drawing.Size(97, 36);
            this.incluir.TabIndex = 1;
            this.incluir.Text = "Incluir";
            this.incluir.UseVisualStyleBackColor = false;
            this.incluir.Click += new System.EventHandler(this.incluir_Click);
            // 
            // alterar
            // 
            this.alterar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(171)))), ((int)(((byte)(78)))));
            this.alterar.Location = new System.Drawing.Point(116, 163);
            this.alterar.Name = "alterar";
            this.alterar.Size = new System.Drawing.Size(97, 36);
            this.alterar.TabIndex = 2;
            this.alterar.Text = "Alterar";
            this.alterar.UseVisualStyleBackColor = false;
            this.alterar.Click += new System.EventHandler(this.alterar_Click);
            // 
            // excluir
            // 
            this.excluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(120)))), ((int)(((byte)(86)))));
            this.excluir.Location = new System.Drawing.Point(219, 163);
            this.excluir.Name = "excluir";
            this.excluir.Size = new System.Drawing.Size(97, 36);
            this.excluir.TabIndex = 3;
            this.excluir.Text = "Excluir";
            this.excluir.UseVisualStyleBackColor = false;
            this.excluir.Click += new System.EventHandler(this.excluir_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.Location = new System.Drawing.Point(13, 21);
            this.txtPesquisa.Multiline = true;
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(192, 26);
            this.txtPesquisa.TabIndex = 4;
            this.txtPesquisa.Text = "Pesquisa";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(219, 22);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(48, 26);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // ServidoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.incluir);
            this.Controls.Add(this.alterar);
            this.Controls.Add(this.excluir);
            this.Controls.Add(this.servidorGridView);
            this.Name = "ServidoresForm";
            this.Text = "ServidoresForm";
            this.Load += new System.EventHandler(this.ServidoresForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.servidorGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView servidorGridView;
        private System.Windows.Forms.Button incluir;
        private System.Windows.Forms.Button alterar;
        private System.Windows.Forms.Button excluir;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnFiltrar;
    }
}