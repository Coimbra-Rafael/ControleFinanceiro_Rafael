using ControleFinanceiro.WinForm.DataAccessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("C:\\ControleFinanceiro\\Database\\"))
            {
                Directory.CreateDirectory("C:\\ControleFinanceiro\\Database\\");
            }
            await new MainFormDao().CreateDatabaseAndTablesAsync().ConfigureAwait(true);
        }

        private void ClienteFormButton_Click(object sender, EventArgs e)
        {
            ClientesForm clientesForm = new ClientesForm();
            clientesForm.Show();
        }

        private void servidorFormButton_Click(object sender, EventArgs e)
        {
            ServidoresForm servidoresForm = new ServidoresForm();
            servidoresForm.Show();
        }
    }
}
