using ControleFinanceiro.WinForm.DataAccessObject;
using ControleFinanceiro.WinForm.Utils;
using ControleFinanceiro.WinForm.Views.Modais;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro.WinForm.Views
{
    public partial class ServidoresForm : Form
    {
        public ServidoresForm()
        {
            InitializeComponent();
        }
        private void ServidoresForm_Load(object sender, EventArgs e)
        {
            ConfigTextBox.SetPlaceholder(txtPesquisa, "Pesquisar");
            GridFilter().ConfigureAwait(true).GetAwaiter();
        }

        private void incluir_Click(object sender, EventArgs e)
        {
            using (var servidorModal = new ServidoresModal()) 
            {
                servidorModal.ShowDialog();
                GridFilter().ConfigureAwait(true).GetAwaiter();
            }
        }

        private void alterar_Click(object sender, EventArgs e)
        {
            if (servidorGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um servirdor para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var servidorModal = new ServidoresModal(Convert.ToInt32(servidorGridView.SelectedRows[0].Cells[0].Value)))
            {
                servidorModal.ShowDialog();
                GridFilter().ConfigureAwait(true).GetAwaiter();
            }
        }

        private void excluir_Click(object sender, EventArgs e)
        {
            if (servidorGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um servidor para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int serverId = Convert.ToInt32(servidorGridView.SelectedRows[0].Cells[0].Value);

            var confirmResult = MessageBox.Show($"Deseja realmente excluir o servidor com ID {serverId}?",
                                                 "Confirmação",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                using (var servidorDao = new ServidorDao())
                {
                    var resultDelete = servidorDao.DeleteServerAsync(serverId).ConfigureAwait(true).GetAwaiter().GetResult();
                    if (resultDelete)
                    {
                        MessageBox.Show("Servidor excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GridFilter().ConfigureAwait(true).GetAwaiter();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir servidor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            GridFilter().ConfigureAwait(true).GetAwaiter();
        }



        private async Task GridFilter()
        {
            using (var servidorDao = new ServidorDao()) 
            {
                servidorGridView.DataSource = await servidorDao.GetServersAsync();
            }
        }
    }
}
