using ControleFinanceiro.WinForm.Views.Modais;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleFinanceiro.WinForm.DataAccessObject;
using System.Data.SQLite;
using System.Configuration;

namespace ControleFinanceiro.WinForm.Views
{
    public partial class ContasReceberForm : Form
    {
        public ContasReceberForm()
        {
            InitializeComponent();
        }

        private async void txtFiltroCliente_TextChanged(object sender, EventArgs e)
        {
            // Captura o texto digitado no filtro
            string filtro = txtFiltroCliente.Text.ToLower();

            // Verifica se o filtro está vazio (não faz nada se não tiver texto)
            if (string.IsNullOrEmpty(filtro))
            {
                await new ContasReceberDao().GetContasAReceberAsync(); // Carrega todas as contas, sem filtro
                return;
            }

            // Cria a query SQL com filtro pelo nome do cliente ou clienteId
            string query = @"
        SELECT c.Id, c.ClienteId, c.ValorDesconto, c.ValorReceber, c.DataAReceber, c.DataRecebimento, c.Observacao, c.Situacao, c.CreatedOn, c.UpdateOn
        FROM ContasReceber c
        INNER JOIN Clientes cl ON c.ClienteId = cl.Id
        WHERE LOWER(cl.Nome) LIKE @filtro";

            // Conectar ao banco e executar a consulta
            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["SQLite_connectionString"].ConnectionString))
            {
                await connection.OpenAsync();

                using (var command = new SQLiteCommand(query, connection))
                {
                    // Passa o filtro de pesquisa para o parâmetro SQL
                    command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    // Executa a consulta
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // Limpa qualquer dado anterior no DataGridView
                        dgvContas.Rows.Clear();

                        // Preenche o DataGridView com os dados filtrados
                        while (await reader.ReadAsync())
                        {
                            dgvContas.Rows.Add(
                                reader["Id"],
                                reader["ClienteId"],
                                reader["ValorDesconto"],
                                reader["ValorReceber"],
                                reader["DataAReceber"],
                                reader["DataRecebimento"],
                                reader["Observacao"],
                                reader["Situacao"]
                            );
                        }
                    }
                }
            }
        }


        private void incluir_Click(object sender, EventArgs e)
        {
            using (var contasReceberModal = new ContasReceberModal())
            {
                var result = contasReceberModal.ShowDialog();
                if (result == DialogResult.OK) // Verifica se salvou com sucesso
                {
                    GridFilter().ConfigureAwait(false); // Atualiza a tela principal
                }
            }
        }


        private void alterar_Click(object sender, EventArgs e)
        {
            if (dgvContas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var contasReceberModal = new ContasReceberModal(Convert.ToInt32(dgvContas.SelectedRows[0].Cells[0].Value)))
            {
                var result = contasReceberModal.ShowDialog();
                if (result == DialogResult.OK) // Verifica se salvou com sucesso
                {
                    GridFilter().ConfigureAwait(false); // Atualiza a tela principal
                }
            }
        }


        private async void excluir_Click(object sender, EventArgs e)
        {
            if (dgvContas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma conta para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show("Tem certeza que deseja excluir esta conta?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvContas.SelectedRows[0].Cells["Id"].Value);
                    await new ContasReceberDao().ExcluirContaReceber(id);
                    MessageBox.Show("Conta excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await GridFilter(); // Atualiza o DataGridView após a exclusão
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private async Task GridFilter()
        {
            dgvContas.DataSource = null;

            // Simulação de carregamento de dados
            var dados = await new ContasReceberDao().GetContasAReceberAsync(); // Método que retorna a lista de contas a receber
            dgvContas.DataSource = dados;
        }

        private void ContasReceberForm_Load(object sender, EventArgs e)
        {
            GridFilter().ConfigureAwait(true).GetAwaiter();
        }
    }
}