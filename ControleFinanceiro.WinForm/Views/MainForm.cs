using ControleFinanceiro.WinForm.DataAccessObject;
using ControleFinanceiro.WinForm.Models;
using ControleFinanceiro.WinForm.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro.WinForm.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Eventos
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Constantes.CaminhoDatabase))
            {
                Directory.CreateDirectory(Constantes.CaminhoDatabase);
            }

            new MainFormDao().CreateDatabaseAndTablesAsync().ConfigureAwait(true).GetAwaiter();
            FiltroGrid().GetAwaiter();
        }

        private void ClienteFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientesForm clientesForm = new ClientesForm();
            clientesForm.FormClosed += (s, args) =>
            {
                this.Show();
            };
            clientesForm.ShowDialog();
        }

        private void servidorFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            ServidoresForm servidoresForm = new ServidoresForm();
            servidoresForm.FormClosed += (s, args) =>
             {
                 this.Show();
             };

            servidoresForm.ShowDialog();
        }

        private void contasReceberFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContasReceberForm contasReceberForm = new ContasReceberForm();
            contasReceberForm.FormClosed += (s, args) =>
            {
                this.Show();
            };
            contasReceberForm.ShowDialog();
        }

        private void contasPagarFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContasPagarForm contasPagarForm = new ContasPagarForm();
            contasPagarForm.FormClosed += (s, args) =>
            {
                this.Show();
            };
            contasPagarForm.ShowDialog();
        }
        #endregion

        #region Configuração Grid
        private void CreateGridHeaderContasReceberTable(IEnumerable<ContasReceber> enumerableContasReceber)
        {
            ContasReceberTable.DataSource = enumerableContasReceber;
            ContasReceberTable.Columns["Id"].Visible = false;

            ContasReceberTable.Columns["ClienteId"].HeaderText = "Cliente";
            ContasReceberTable.Columns["ClienteId"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ContasReceberTable.Columns["ClienteId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ContasReceberTable.Columns["DataAReceber"].HeaderText = "Data a receber";
            ContasReceberTable.Columns["DataAReceber"].Width = 150;
            ContasReceberTable.Columns["DataAReceber"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ContasReceberTable.Columns["DataAReceber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ContasReceberTable.Columns["ValorDesconto"].HeaderText = "Valor desconto";
            ContasReceberTable.Columns["ValorDesconto"].Width = 80;
            ContasReceberTable.Columns["ValorDesconto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ContasReceberTable.Columns["ValorDesconto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ContasReceberTable.Columns["ValorReceber"].HeaderText = "Valor a receber";
            ContasReceberTable.Columns["ValorReceber"].Width = 80;
            ContasReceberTable.Columns["ValorReceber"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ContasReceberTable.Columns["ValorReceber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ContasReceberTable.Columns["DataRecebimento"].HeaderText = "Data recebimento";
            ContasReceberTable.Columns["DataRecebimento"].Width = 150;
            ContasReceberTable.Columns["DataRecebimento"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ContasReceberTable.Columns["DataRecebimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ContasReceberTable.Columns["Observacao"].HeaderText = "Observação";
            ContasReceberTable.Columns["Observacao"].Width = 100;
            ContasReceberTable.Columns["Observacao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ContasReceberTable.Columns["Observacao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        #endregion

        #region Métodos
        private async Task FiltroGrid()
        {
            CreateGridHeaderContasReceberTable(await new MainFormDao().GetContasAReceberAsync());
        }
        #endregion
    }
}
