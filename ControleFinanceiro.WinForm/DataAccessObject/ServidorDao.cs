using ControleFinanceiro.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace ControleFinanceiro.WinForm.DataAccessObject
{
    public sealed class ServidorDao : IDisposable
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLite_connectionString"].ConnectionString;

        public async Task<bool> CreateServer(Servidor servidor)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand("@INSERT INTO Servidor (Nome, CreatedOn, UpdateOn) VALUES (@Nome, @CreatedOn, @UpdateOn)", connection))
                {
                    command.Parameters.AddWithValue("@Nome", servidor.Nome);
                    command.Parameters.AddWithValue("@CreatedOn", servidor.CreatedOn);
                    command.Parameters.AddWithValue("@UpdateOn", servidor.UpdateOn);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }
        public async Task<bool> UpdateServerAsync(Servidor clientes, string propriedadeAlterada)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = $"UPDATE Servidor SET {propriedadeAlterada} = @{propriedadeAlterada} WHERE Id = @Id";

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

        public async Task<bool> DeleteClientAsync(long serverId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SQLiteCommand command = new SQLiteCommand(
                    @"DELETE FROM Servidor WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", serverId);
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }

        public async Task<IEnumerable<Servidor>> GetServersAsync()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SQLiteCommand command = new SQLiteCommand(@"SELECT * FROM Servidor", connection))
                {
                    var servidores = new List<Servidor>();
                    using (var reader = await command.ExecuteReaderAsync()) 
                    {
                        if (!reader.HasRows) 
                        {
                            throw new ArgumentException("Não foi encontrado nenhum servidor.");
                        }

                        while(await reader.ReadAsync()) 
                        {
                            var servidor = new Servidor
                            {
                                Nome = reader["Nome"].ToString(),
                                CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString()),
                                UpdateOn = Convert.ToDateTime(reader["UpdateOn"].ToString())
                            };

                            servidores.Add(servidor);
                        }
                        return servidores;
                    }
                }
            }
        }

        public async Task<Servidor> GetServerByIdAsync(long serverId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SQLiteCommand command = new SQLiteCommand(@"SELECT * FROM Servidor Where Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", serverId);


                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            throw new ArgumentException("Não foi encontrado nenhum servidor."); // Retorna lista vazia se não houver registros
                        }

                        if (await reader.ReadAsync())
                        {
                            return new Servidor
                            {
                                Nome = reader["Nome"].ToString(),
                                CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString()),
                                UpdateOn = Convert.ToDateTime(reader["UpdateOn"].ToString())
                            };
                        }
                        return default;
                    }
                }
            }
        }

        public async Task<Servidor> GetServerByNomeAsync(string filter)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SQLiteCommand command = new SQLiteCommand(@"SELECT * FROM Servidor WHERE Nome LIKE @Nome", connection))
                {
                    command.Parameters.AddWithValue("@Nome", $"%{filter}%");

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            throw new ArgumentException("Não foi encontrado nenhum servidor."); // Retorna lista vazia se não houver registros
                        }

                        if (await reader.ReadAsync())
                        {
                            return new Servidor
                            {
                                Nome = reader["Nome"].ToString(),
                                CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString()),
                                UpdateOn = Convert.ToDateTime(reader["UpdateOn"].ToString())
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
