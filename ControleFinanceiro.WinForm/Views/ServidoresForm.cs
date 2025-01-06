using ControleFinanceiro.WinForm.DataAccessObject;
using ControleFinanceiro.WinForm.Utils;
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

        }

        private void alterar_Click(object sender, EventArgs e)
        {

        }

        private void excluir_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

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
