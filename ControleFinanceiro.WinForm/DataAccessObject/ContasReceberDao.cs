using ControleFinanceiro.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace ControleFinanceiro.WinForm.DataAccessObject
{
    public sealed class ContasReceberDao : IDisposable
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLite_connectionString"].ConnectionString;

        public async Task<bool> CreateReceber(ContasReceber contasReceber)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SQLiteCommand(@"INSERT INTO ContasReceber 
                        (ClienteId, ValorDesconto, ValorReceber, DataAReceber, DataRecebimento, Observacao, Situacao, QuantidadeParcelas, CreatedOn, UpdateOn) 
                        VALUES (@ClienteId, @ValorDesconto, @ValorReceber, @DataAReceber, @DataRecebimento, @Observacao, @Situacao, @QuantidadeParcelas, @CreatedOn, @UpdateOn)", connection))
                    {
                        command.Parameters.AddWithValue("@ClienteId", contasReceber.ClienteId);
                        command.Parameters.AddWithValue("@ValorDesconto", contasReceber.ValorDesconto);
                        command.Parameters.AddWithValue("@ValorReceber", contasReceber.ValorReceber);
                        command.Parameters.AddWithValue("@DataAReceber", contasReceber.DataAReceber);
                        command.Parameters.AddWithValue("@DataRecebimento", contasReceber.DataRecebimento);
                        command.Parameters.AddWithValue("@Observacao", contasReceber.Observacao);
                        command.Parameters.AddWithValue("@Situacao", contasReceber.Situacao);
                        command.Parameters.AddWithValue("@QuantidadeParcelas", contasReceber.QuantidadeParcelas);
                        command.Parameters.AddWithValue("@CreatedOn", contasReceber.CreatedOn);
                        command.Parameters.AddWithValue("@UpdateOn", contasReceber.UpdateOn);

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir conta a receber.", ex);
            }
        }

        public async Task<bool> UpdateContasReceber(ContasReceber contaReceber, string propriedadeAlterada)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = $"UPDATE ContasReceber SET {propriedadeAlterada} = @{propriedadeAlterada} WHERE Id = @Id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue($"@{propriedadeAlterada}",
                            typeof(ContasReceber).GetProperty(propriedadeAlterada)?.GetValue(contaReceber));
                        command.Parameters.AddWithValue("@Id", contaReceber.Id);

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar conta a receber.", ex);
            }
        }

        public async Task<bool> ExcluirContaReceber(long id)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM ContasReceber WHERE Id = @Id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir conta a receber.", ex);
            }
        }

        public async Task<IEnumerable<ContasReceber>> GetContasAReceberAsync()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new SQLiteCommand("SELECT * FROM ContasReceber", connection))
                    {
                        var contasReceber = new List<ContasReceber>();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                contasReceber.Add(new ContasReceber
                                {
                                    Id = Convert.ToInt64(reader["Id"]),
                                    ClienteId = Convert.ToInt64(reader["ClienteId"]),
                                    ValorDesconto = Convert.ToDecimal(reader["ValorDesconto"]),
                                    ValorReceber = Convert.ToDecimal(reader["ValorReceber"]),
                                    DataAReceber = Convert.ToDateTime(reader["DataAReceber"]),
                                    DataRecebimento = Convert.ToDateTime(reader["DataRecebimento"]),
                                    Observacao = reader["Observacao"].ToString(),
                                    Situacao = reader["Situacao"].ToString(),
                                    QuantidadeParcelas = Convert.ToInt64(reader["QuantidadeParcelas"])
                                });
                            }
                        }
                        return contasReceber;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter contas a receber.", ex);
            }
        }

        public async Task<ContasReceber> GetContasReceberById(long id)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new SQLiteCommand("SELECT * FROM ContasReceber WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new ContasReceber
                                {
                                    Id = Convert.ToInt64(reader["Id"]),
                                    ClienteId = Convert.ToInt64(reader["ClienteId"]),
                                    ValorDesconto = Convert.ToDecimal(reader["ValorDesconto"]),
                                    ValorReceber = Convert.ToDecimal(reader["ValorReceber"]),
                                    DataAReceber = Convert.ToDateTime(reader["DataAReceber"]),
                                    DataRecebimento = Convert.ToDateTime(reader["DataRecebimento"]),
                                    Observacao = reader["Observacao"].ToString(),
                                    Situacao = reader["Situacao"].ToString(),
                                    QuantidadeParcelas = Convert.ToInt64(reader["QuantidadeParcelas"])
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter conta a receber por ID.", ex);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
