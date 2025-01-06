using ControleFinanceiro.WinForm.DataAccessObject;
using ControleFinanceiro.WinForm.Models;
using ControleFinanceiro.WinForm.Utils;
using ControleFinanceiro.WinForm.Views.Modais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro.WinForm.Views
{
    public partial class ClientesForm : Form
    {
        public ClientesForm()
        {
            InitializeComponent();
        }

        #region Eventos
        private void ClientesForm_Load(object sender, EventArgs e)
        {
            ConfigTextBox.SetPlaceholder(txtPesquisa, "Pesquisar");
            GridFilter().ConfigureAwait(true).GetAwaiter();
        }

        private void Incluir_Click(object sender, EventArgs e)
        {
            using (var clientesModal = new ClientesModal()) 
            {
                clientesModal.ShowDialog();
                GridFilter().ConfigureAwait(true).GetAwaiter();
            }
                

        }

        private void Alterar_Click(object sender, EventArgs e)
        {
            if (clienteGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var clientesModal = new ClientesModal(Convert.ToInt32(clienteGridView.SelectedRows[0].Cells[0].Value)))
            {
                clientesModal.ShowDialog();
                GridFilter().ConfigureAwait(true).GetAwaiter();
            }

        }

        private async void excluir_Click(object sender, EventArgs e)
        {
            if (clienteGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteId = Convert.ToInt32(clienteGridView.SelectedRows[0].Cells[0].Value);

            var confirmResult = MessageBox.Show($"Deseja realmente excluir o cliente com ID {clienteId}?",
                                                 "Confirmação",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                using (var clienteDao = new ClientesDao())
                {
                    var resultDelete = await clienteDao.DeleteClientAsync(clienteId);
                    if (resultDelete)
                    {
                        MessageBox.Show("Cliente excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GridFilter().ConfigureAwait(true).GetAwaiter();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region configuracao grid
        private void CreateGridHeaderClient(IEnumerable<Clientes> lstClientes)
        {
            clienteGridView.DataSource = lstClientes.ToList();
            clienteGridView.Columns["Id"].Visible = false;

            clienteGridView.Columns["Nome"].HeaderText = "Nome";
            clienteGridView.Columns["Nome"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clienteGridView.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            clienteGridView.Columns["Email"].HeaderText = "E-mail";
            clienteGridView.Columns["Email"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clienteGridView.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            clienteGridView.Columns["Telefone"].HeaderText = "Telefone";
            clienteGridView.Columns["Telefone"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clienteGridView.Columns["Telefone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            clienteGridView.Columns["Cidade"].Visible = false;
            clienteGridView.Columns["Cidade"].HeaderText = "Cidade";
            clienteGridView.Columns["Cidade"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clienteGridView.Columns["Cidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            clienteGridView.Columns["Estado"].Visible = false;
            clienteGridView.Columns["Estado"].HeaderText = "Estado";
            clienteGridView.Columns["Estado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clienteGridView.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            clienteGridView.Columns["Endereco"].Visible = false;
            clienteGridView.Columns["Endereco"].HeaderText = "Endereço";
            clienteGridView.Columns["Endereco"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clienteGridView.Columns["Endereco"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            clienteGridView.Columns["Bairro"].Visible = false;
            clienteGridView.Columns["Bairro"].HeaderText = "Bairro";
            clienteGridView.Columns["Bairro"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clienteGridView.Columns["Bairro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            clienteGridView.Columns["Numero"].Visible = false;
            clienteGridView.Columns["Numero"].HeaderText = "Número";
            clienteGridView.Columns["Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clienteGridView.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            clienteGridView.Columns["Complemento"].Visible = false;
            clienteGridView.Columns["Complemento"].HeaderText = "Complemento";
            clienteGridView.Columns["Complemento"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clienteGridView.Columns["Complemento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            clienteGridView.Columns["ComplementoPagamento"].HeaderText = "Complemento de Pagamento";
            clienteGridView.Columns["ComplementoPagamento"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clienteGridView.Columns["ComplementoPagamento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private async Task GridFilter()
        {
            using (var clienteDao = new ClientesDao())
            {
                IEnumerable<Clientes> clientes;
                if (txtPesquisa.Text.Equals("Pesquisar") && !chkBuscaPorComplemento.Checked  || string.IsNullOrEmpty(txtPesquisa.Text) && !chkBuscaPorComplemento.Checked)
                {
                    clientes = await clienteDao.GetClientesAsync();
                }
                else
                {
                    clientes = await clienteDao.GetClientesByFilterAsync(txtPesquisa.Text, chkBuscaPorComplemento.Checked);
                }
                CreateGridHeaderClient(clientes);
            }
        }

        #endregion

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            GridFilter().ConfigureAwait(true).GetAwaiter();
        }
    }
}