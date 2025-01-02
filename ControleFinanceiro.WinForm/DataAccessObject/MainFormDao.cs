using System;
using System.Configuration;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace ControleFinanceiro.WinForm.DataAccessObject
{
    public class MainFormDao : IDisposable
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLiteConnectionString"].ConnectionString;

        private string ConnectionString => _connectionString;

        public async Task CreateDatabaseAndTablesAsync()
        {
            try
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    // Abre a conexão
                    await connection.OpenAsync();

                    // Criar a tabela Clientes
                    using (var command = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Clientes
                            (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Nome TEXT NOT NULL,
                                Email TEXT NOT NULL,
                                Telefone TEXT NOT NULL,
                                Cidade TEXT NOT NULL,
                                Estado TEXT NOT NULL,
                                Endereco TEXT NOT NULL,
                                Bairro TEXT NOT NULL,
                                Numero TEXT NOT NULL,
                                Complemento TEXT
                            )", connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }

                    // Criar a tabela Servidor
                    using (var command = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Servidor
                        (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nome TEXT NOT NULL
                        )", connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }

                    // Criar a tabela ServidorClientes (relacionamento)
                    using (var command = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS ServidorClientes
                        (
                            ServidorId INTEGER NOT NULL,
                            ClienteId INTEGER NOT NULL,
                            FOREIGN KEY (ServidorId) REFERENCES Servidor(Id),
                            FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
                        )", connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }

                    using (var command = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS ContasReceber
                        (
                            
                        )", connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }

                    using (var command = new SQLiteCommand(
                       @"CREATE TABLE IF NOT EXISTS ContasPagar
                        (
                            
                        )", connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Exceção capturada e jogada novamente
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
