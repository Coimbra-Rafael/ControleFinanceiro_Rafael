using ControleFinanceiro.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace ControleFinanceiro.WinForm.DataAccessObject
{
    public sealed class ClientesDao : IDisposable
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLite_connectionString"].ConnectionString;


        public async Task<bool> CustomerRegistration(Clientes cliente)
        {

            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SQLiteCommand command = new SQLiteCommand(@"
                        INSERT INTO Clientes (Nome, Email, Telefone, Cidade, Estado, Endereco, Bairro, Numero, Complemento, ComplementoPagamento, CreatedOn, UpdateOn)
                        VALUES (@Nome, @Email, @Telefone, @Cidade, @Estado, @Endereco, @Bairro, @Numero, @Complemento, @ComplementoPagamento, @CreatedOn, @UpdateOn)", connection))
                {
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                    command.Parameters.AddWithValue("@Cidade", cliente.Cidade);
                    command.Parameters.AddWithValue("@Estado", cliente.Estado);
                    command.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                    command.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                    command.Parameters.AddWithValue("@Numero", cliente.Numero);
                    command.Parameters.AddWithValue("@Complemento",
                                                string.IsNullOrEmpty(cliente.Complemento)
                                                ? DBNull.Value
                                                : (object)cliente.Complemento);
                    command.Parameters.AddWithValue("@ComplementoPagamento",
                                                string.IsNullOrEmpty(cliente.ComplementoPagamento)
                                                ? DBNull.Value
                                                : (object)cliente.ComplementoPagamento);
                    command.Parameters.AddWithValue("@CreatedOn", cliente.CreatedOn);
                    command.Parameters.AddWithValue("@UpdateOn", cliente.UpdateOn);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }

        public async Task<bool> UpdateClientAsync(Clientes clientes, string propriedadeAlterada)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = $"UPDATE Clientes SET {propriedadeAlterada} = @{propriedadeAlterada} WHERE Id = @Id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue($"@{propriedadeAlterada}",
                        typeof(Clientes).GetProperty(propriedadeAlterada)?.GetValue(clientes));

                    command.Parameters.AddWithValue("@Id", clientes.Id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

        public async Task<bool> DeleteClientAsync(long clienteId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SQLiteCommand command = new SQLiteCommand(
                    @"DELETE FROM Clientes WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", clienteId);
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }

        public async Task<IEnumerable<Clientes>> GetClientesAsync(string nome = null, string complemento = null)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(
                    @"SELECT * FROM Clientes", connection))
                {
                    var clientes = new List<Clientes>();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            return clientes; // Retorna lista vazia se não houver registros
                        }

                        while (await reader.ReadAsync())
                        {
                            var cliente = new Clientes()
                            {
                                Id = Convert.ToInt64(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefone = reader["Telefone"].ToString(),
                                Cidade = reader["Cidade"].ToString(),
                                Estado = reader["Estado"].ToString(),
                                Endereco = reader["Endereco"].ToString(),
                                Bairro = reader["Bairro"].ToString(),
                                Numero = reader["Numero"].ToString(),
                                Complemento = reader["Complemento"].ToString(),
                                ComplementoPagamento = reader["ComplementoPagamento"].ToString(),
                                CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                                UpdateOn = Convert.ToDateTime(reader["UpdateOn"])
                            };


                            clientes.Add(cliente);
                        }
                        return clientes;
                    }
                }
            }
        }

        public async Task<IEnumerable<Clientes>> GetClientesByFilterAsync(string valorPesquisa, bool buscaPorComplementoPagamento)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Clientes";

                if (buscaPorComplementoPagamento)
                {
                    query += " WHERE ComplementoPagamento LIKE @ValorPesquisa";
                }
                else
                {
                    query += " WHERE Nome LIKE @ValorPesquisa";
                }

                using (var command = new SQLiteCommand(
                    query, connection))
                {
                    command.Parameters.AddWithValue("@ValorPesquisa", $"%{valorPesquisa}%");

                    var clientes = new List<Clientes>();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            return clientes; // Retorna lista vazia se não houver registros
                        }

                        while (await reader.ReadAsync())
                        {
                            var cliente = new Clientes()
                            {
                                Id = Convert.ToInt64(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefone = reader["Telefone"].ToString(),
                                Cidade = reader["Cidade"].ToString(),
                                Estado = reader["Estado"].ToString(),
                                Endereco = reader["Endereco"].ToString(),
                                Bairro = reader["Bairro"].ToString(),
                                Numero = reader["Numero"].ToString(),
                                Complemento = reader["Complemento"].ToString(),
                                ComplementoPagamento = reader["ComplementoPagamento"].ToString(),
                                CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                                UpdateOn = Convert.ToDateTime(reader["UpdateOn"])
                            };


                            clientes.Add(cliente);
                        }
                        return clientes;
                    }
                }
            }
        }

        public async Task<Clientes> GetClienteById(long clienteId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(
                    @"SELECT * FROM Clientes where Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", clienteId);


                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            throw new ArgumentException("Não foi encontrado nenhum cliente."); // Retorna lista vazia se não houver registros
                        }

                        if (await reader.ReadAsync())
                        {
                            return new Clientes()
                            {
                                Id = Convert.ToInt64(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefone = reader["Telefone"].ToString(),
                                Cidade = reader["Cidade"].ToString(),
                                Estado = reader["Estado"].ToString(),
                                Endereco = reader["Endereco"].ToString(),
                                Bairro = reader["Bairro"].ToString(),
                                Numero = reader["Numero"].ToString(),
                                Complemento = reader["Complemento"].ToString(),
                                ComplementoPagamento = reader["ComplementoPagamento"].ToString(),
                                CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                                UpdateOn = Convert.ToDateTime(reader["UpdateOn"])
                            };
                        }
                        return default;
                    }
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
