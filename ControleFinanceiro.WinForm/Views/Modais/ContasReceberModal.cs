using ControleFinanceiro.WinForm.DataAccessObject;
using ControleFinanceiro.WinForm.Models;
using ControleFinanceiro.WinForm.Utils;
using System;
using System.Windows.Forms;

namespace ControleFinanceiro.WinForm.Views.Modais
{
    public partial class ContasReceberModal : Form
    {
        private readonly long contasReceberId = 0;

        public ContasReceberModal()
        {
            InitializeComponent();
        }

        public ContasReceberModal(long id)
        {
            InitializeComponent();
            contasReceberId = id;
            LoadContasReceberData(contasReceberId);
        }

        private async void ContasReceberModal_Load(object sender, EventArgs e)
        {
            comboBoxSituacao.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClienteId.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClienteId.DataSource = await new ClientesDao().GetClientesAsync();
            comboBoxClienteId.DisplayMember = "Nome";  // O nome do cliente será exibido no ComboBox
            comboBoxClienteId.ValueMember = "Id";

            if (contasReceberId == 0)
            {
                ConfigTextBox.SetPlaceholder(txtValorReceber, "Valor a Receber");
                ConfigTextBox.SetPlaceholder(txtValorDesconto, "Valor de Desconto");
                ConfigTextBox.SetPlaceholder(txtObservacao, "Observação");
            }
            else
            {
                if (string.IsNullOrEmpty(txtValorReceber.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtValorReceber, "Valor a Receber");
                }
                if (string.IsNullOrEmpty(txtValorDesconto.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtValorDesconto, "Valor de Desconto");
                }
                if (string.IsNullOrEmpty(txtObservacao.Text))
                {
                    ConfigTextBox.SetPlaceholder(txtObservacao, "Observação");
                }
            }

        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValorReceber.Text) || comboBoxClienteId.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConfigTextBox.ClearingReservedSpace(txtValorReceber, "Valor a Receber");
            ConfigTextBox.ClearingReservedSpace(txtValorDesconto, "Valor de Desconto");
            ConfigTextBox.ClearingReservedSpace(txtObservacao, "Observação");

            var conta = new ContasReceber();

            using (var contasReceberDao = new ContasReceberDao())
            {
                bool result = false;
                ContasReceber contaAntiga = null;

                if (contasReceberId != 0)
                {
                    contaAntiga = await contasReceberDao.GetContasReceberById(contasReceberId);
                    conta.Id = contaAntiga.Id;
                }

                if (contaAntiga == null)
                {
                    for (int i = 0; i <= Convert.ToInt64(txtQuantidadeParcelas.Text); i++)
                    {
                        conta.ClienteId =
                            Convert.ToInt64(comboBoxClienteId.SelectedValue); // O índice no ComboBox é usado como ID do cliente
                        conta.ValorDesconto = decimal.TryParse(txtValorDesconto.Text, out var desconto) ? desconto : 0;
                        conta.ValorReceber = decimal.Parse(txtValorReceber.Text);
                        conta.DataAReceber = DateTime.Parse(dtpDataAReceber.Text);
                        conta.DataRecebimento = DateTime.TryParse(dtpDataRecebimento.Text, out var dataRecebimento)
                            ? dataRecebimento
                            : DateTime.MinValue;
                        conta.Observacao = txtObservacao.Text;
                        conta.Situacao = comboBoxSituacao.Text;
                        conta.QuantidadeParcelas = (i + 1);


                        result = await contasReceberDao.CreateReceber(conta);
                    }

                    if (result)
                    {
                        MessageBox.Show("Conta a receber cadastrada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar conta a receber, verifique os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    conta.ClienteId = comboBoxClienteId.SelectedIndex; // O índice no ComboBox é usado como ID do cliente
                    conta.ValorDesconto = decimal.TryParse(txtValorDesconto.Text, out var desconto) ? desconto : 0;
                    conta.ValorReceber = decimal.Parse(txtValorReceber.Text);
                    conta.DataAReceber = DateTime.Parse(dtpDataAReceber.Text);
                    conta.DataRecebimento = DateTime.TryParse(dtpDataRecebimento.Text, out var dataRecebimento)
                        ? dataRecebimento
                        : DateTime.MinValue;
                    conta.Observacao = txtObservacao.Text;
                    conta.Situacao = comboBoxSituacao.Text;

                    var propriedadesAlteradas = Generics.GetChangedProperties(contaAntiga, conta);
                    foreach (var propriedade in propriedadesAlteradas)
                    {
                        result = await contasReceberDao.UpdateContasReceber(conta, propriedade);
                        if (!result)
                        {
                            MessageBox.Show($"Erro ao atualizar a propriedade {propriedade}.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    MessageBox.Show("Conta a receber atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void LoadContasReceberData(long id)
        {
            using (var contasReceberDao = new ContasReceberDao())
            {

                var conta = contasReceberDao.GetContasReceberById(id).ConfigureAwait(true).GetAwaiter().GetResult();
                if (conta != null)
                {
                    comboBoxClienteId.SelectedIndex = Convert.ToInt32(conta.ClienteId - 1); // Ajuste do índice
                    txtValorReceber.Text = conta.ValorReceber.ToString("F2");
                    txtValorDesconto.Text = conta.ValorDesconto.ToString("F2");
                    txtObservacao.Text = conta.Observacao;
                    dtpDataAReceber.Text = conta.DataAReceber.ToString("yyyy-MM-dd");
                    dtpDataRecebimento.Text = conta.DataRecebimento == DateTime.MinValue ? string.Empty : conta.DataRecebimento.ToString("yyyy-MM-dd");
                    comboBoxSituacao.SelectedItem = conta.Situacao;
                }
            }
        }
    }
}
