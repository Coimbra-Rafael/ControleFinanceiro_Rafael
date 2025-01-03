using ControleFinanceiro.WinForm.Models;
using System;
using System.Windows.Forms;

namespace ControleFinanceiro.WinForm.Views.Modais
{
    public partial class ClientesModal : Form
    {
        public ClientesModal()
        {
            InitializeComponent();
        }

        private void ClientesModal_Load(object sender, EventArgs e)
        {
            comboBoxEstado.Items.Add("São Paulo");


            SetPlaceholder(txtNome, "Nome");
            SetPlaceholder(txtEmail, "E-mail");
            SetPlaceholder(txtTelefone, "Telefone");
            SetPlaceholder(txtCidade, "Cidade");
            SetPlaceholder(txtEndereco, "Endereço");
            SetPlaceholder(txtBairro, "Bairro");
            SetPlaceholder(txtNumero, "Número");
            SetPlaceholder(txtComplemento, "Complemento (opcional)");
        }

        private static void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.ForeColor = System.Drawing.Color.Gray;
            textBox.Text = placeholder;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = System.Drawing.Color.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) ||
               string.IsNullOrEmpty(txtEmail.Text) ||
               string.IsNullOrEmpty(txtTelefone.Text) ||
               string.IsNullOrEmpty(txtCidade.Text) ||
               string.IsNullOrEmpty(comboBoxEstado.Text) ||
               string.IsNullOrEmpty(txtEndereco.Text) ||
               string.IsNullOrEmpty(txtBairro.Text) ||
               string.IsNullOrEmpty(txtNumero.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Criar objeto Cliente com as informações do formulário
            var cliente = new Clientes()
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                Cidade = txtCidade.Text,
                Estado = comboBoxEstado.SelectedItem.ToString(),
                Endereco = txtEndereco.Text,
                Bairro = txtBairro.Text,
                Numero = txtNumero.Text,
                Complemento = txtComplemento.Text
            };

            this.Focus();
        }
    }
}
