using ControleFinanceiro.WinForm.Views.Modais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro.WinForm.Views
{
    public partial class ContasReceberForm : Form
    {
        public ContasReceberForm()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            using (var contasReceberModal = new ContasReceberModal()) 
            {
                contasReceberModal.ShowDialog();
                GridFilter().ConfigureAwait(true).GetAwaiter();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvContas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var clientesModal = new ClientesModal(Convert.ToInt32(dgvContas.SelectedRows[0].Cells[0].Value)))
            {
                clientesModal.ShowDialog();
                GridFilter().ConfigureAwait(true).GetAwaiter();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvContas.SelectedRows.Count > 0)
            {
                int index = dgvContas.SelectedRows[0].Index;
         
            }
        }

        private void txtFiltroCliente_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroCliente.Text.ToLower();
            
        }

        private async Task GridFilter()
        {
            dgvContas.DataSource = null;
            dgvContas.DataSource = _contas;
        }
    }
}
}
