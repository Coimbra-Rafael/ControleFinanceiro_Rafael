using ControleFinanceiro.WinForm.DataAccessObject;
using ControleFinanceiro.WinForm.Models;
using ControleFinanceiro.WinForm.Utils;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ControleFinanceiro.WinForm.Views.Modais
{
    public partial class ClientesModal : Form
    {
        private readonly long clienteId = 0;
        public ClientesModal()
        {
            InitializeComponent();
        }

        public ClientesModal(long clientId)
        {
            InitializeComponent();
            clienteId = clientId;
            LoadClientData(clientId);
        }

        private void ClientesModal_Load(object sender, EventArgs e)
        {
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;

            if (clienteId.Equals(0))
            {
                ConfigTextBox.SetPlaceholder(txtNome, "Nome");
                ConfigTextBox.SetPlaceholder(txtEmail, "E-mail");
                ConfigTextBox.SetPlaceholder(txtTelefone, "Telefone");
                ConfigTextBox.SetPlaceholder(txtCidade, "Cidade");
                ConfigTextBox.SetPlaceholder(txtEndereco, "Endereço");
                ConfigTextBox.SetPlaceholder(txtBairro, "Bairro");
                ConfigTextBox.SetPlaceholder(txtNumero, "Número");
                ConfigTextBox.SetPlaceholder(txtComplemento, "Complemento (opcional)");
                ConfigTextBox.SetPlaceholder(txtComplementoPagamento, "Complemento de pagamento (opcional)");
            }
            else
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtNome, "Nome");
                }
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtEmail, "E-mail");
                }
                if (string.IsNullOrEmpty(txtTelefone.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtTelefone, "Telefone");
                }
                if (string.IsNullOrEmpty(txtCidade.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtCidade, "Cidade");
                }
                if (string.IsNullOrEmpty(txtEndereco.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtEndereco, "Endereço");
                }
                if (string.IsNullOrEmpty(txtBairro.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtBairro, "Bairro");
                }
                if (string.IsNullOrEmpty(txtNumero.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtNumero, "Número");
                }
                if (string.IsNullOrEmpty(txtComplemento.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtComplemento, "Complemento (opcional)");
                }
                if (string.IsNullOrEmpty(txtComplementoPagamento.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtComplementoPagamento, "Complemento de pagamento (opcional)");
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
            ConfigTextBox.ClearingReservedSpace(txtEmail, "E-mail");
            ConfigTextBox.ClearingReservedSpace(txtTelefone, "Telefone");
            ConfigTextBox.ClearingReservedSpace(txtCidade, "Cidade");
            ConfigTextBox.ClearingReservedSpace(txtEndereco, "Endereço");
            ConfigTextBox.ClearingReservedSpace(txtBairro, "Bairro");
            ConfigTextBox.ClearingReservedSpace(txtNumero, "Número");
            ConfigTextBox.ClearingReservedSpace(txtComplemento, "Complemento (opcional)");
            ConfigTextBox.ClearingReservedSpace(txtComplementoPagamento, "Complemento de pagamento (opcional)");

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
                Complemento = txtComplemento.Text,
                ComplementoPagamento = txtComplementoPagamento.Text
            };

            using (var clienteDao = new ClientesDao())
            {
                var result = clienteDao.CustomerRegistration(cliente).ConfigureAwait(true).GetAwaiter().GetResult();

                if (result)
                {
                    MessageBox.Show("Cliente cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar cliente, verifique os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void LoadClientData(long clientId)
        {
            using (var clienteDao = new ClientesDao())
            {
                var cliente = clienteDao.GetClienteById(clientId).ConfigureAwait(true).GetAwaiter().GetResult();
                ConfigTextBox.ClearingReservedSpace(txtNome, "Nome");
                ConfigTextBox.ClearingReservedSpace(txtEmail, "E-mail");
                ConfigTextBox.ClearingReservedSpace(txtTelefone, "Telefone");
                ConfigTextBox.ClearingReservedSpace(txtCidade, "Cidade");
                ConfigTextBox.ClearingReservedSpace(txtEndereco, "Endereço");
                ConfigTextBox.ClearingReservedSpace(txtBairro, "Bairro");
                ConfigTextBox.ClearingReservedSpace(txtNumero, "Número");
                ConfigTextBox.ClearingReservedSpace(txtComplemento, "Complemento (opcional)");
                ConfigTextBox.ClearingReservedSpace(txtComplementoPagamento, "Complemento de pagamento (opcional)");
                if (cliente != null)
                {
                    txtNome.Text = cliente.Nome;
                    txtEmail.Text = cliente.Email;
                    txtTelefone.Text = cliente.Telefone;
                    txtCidade.Text = cliente.Cidade;
                    comboBoxEstado.SelectedItem = cliente.Estado;
                    txtEndereco.Text = cliente.Endereco;
                    txtBairro.Text = cliente.Bairro;
                    txtNumero.Text = cliente.Numero;
                    txtComplemento.Text = cliente.Complemento;
                    txtComplementoPagamento.Text = cliente.ComplementoPagamento;
                }
            }
        }
    }
}
