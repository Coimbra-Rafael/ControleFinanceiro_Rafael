using ControleFinanceiro.WinForm.DataAccessObject;
using ControleFinanceiro.WinForm.Models;
using ControleFinanceiro.WinForm.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro.WinForm.Views.Modais
{
    public partial class ServidoresModal : Form
    {
        private long serverId = 0;
        public ServidoresModal()
        {
            InitializeComponent();
        }

        public ServidoresModal(long serveId)
        {
            InitializeComponent();
            serverId = serveId;
            LoadClientData(serveId);
        }


        private void LoadClientData(long serverId)
        {
            using (var servidorDao = new ServidorDao())
            {
                var cliente = servidorDao.GetServerByIdAsync(serverId).ConfigureAwait(true).GetAwaiter().GetResult();
                ConfigTextBox.ClearingReservedSpace(txtNome, "Nome");
               
                if (cliente != null)
                {
                    txtNome.Text = cliente.Nome;
                   
                }
            }
        }

        private void ServidoresModal_Load(object sender, EventArgs e)
        {
           
            if (serverId.Equals(0))
            {
                ConfigTextBox.SetPlaceholder(txtNome, "Nome");
              
            }
            else
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtNome, "Nome");
                }
              
            }
            this.ActiveControl = lblCursor;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConfigTextBox.ClearingReservedSpace(txtNome, "Nome");

            var servidor = new Servidor(txtNome.Text);
            using (var servidorDao = new ServidorDao())
            {
                bool result = false;
                Servidor servidorAntigo = null;
                if (serverId != 0)
                {
                    servidorAntigo = servidorDao.GetServerByIdAsync(serverId).ConfigureAwait(true).GetAwaiter().GetResult();
                    servidor.Id = servidorAntigo.Id;
                }
                if (servidorAntigo == null)
                {
                    result = servidorDao.CreateServer(servidor).ConfigureAwait(true).GetAwaiter().GetResult();

                    if (result)
                    {
                        MessageBox.Show("Servidor cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar Servidor, verifique os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    var propriedadesAlteradas = Generics.GetChangedProperties(servidorAntigo, servidor);
                    foreach (var propriedade in propriedadesAlteradas)
                    {
                        result = servidorDao.UpdateServerAsync(servidor, propriedade).ConfigureAwait(true).GetAwaiter().GetResult();

                        if (!result)
                        {
                            MessageBox.Show($"Erro ao atualizar a propriedade {propriedade}.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    MessageBox.Show("Servidor atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
