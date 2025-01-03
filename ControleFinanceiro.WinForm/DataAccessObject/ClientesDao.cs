using ControleFinanceiro.WinForm.Models;
using System;
using System.Configuration;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace ControleFinanceiro.WinForm.DataAccessObject
{
    public class ClientesDao : IDisposable
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLiteConnectionString"].ConnectionString;

        private string ConnectionString => _connectionString;

        public async Task<bool> CustomerRegistration(Clientes cliente)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                await connection.OpenAsync();

                using (SQLiteCommand command = new SQLiteCommand(@"
                        INSERT INTO Clientes (Nome, Email, Telefone, Cidade, Estado, Endereco, Bairro, Numero, Complemento, CreatedOn, UpdateOn)
                        VALUES (@Nome, @Email, @Telefone, @Cidade, @Estado, @Endereco, @Bairro, @Numero, @Complemento, @CreatedOn, @UpdateOn)", connection))
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
                    command.Parameters.AddWithValue("@CreatedOn", cliente.CreatedOn);
                    command.Parameters.AddWithValue("@UpdateOn", cliente.UpdateOn);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
