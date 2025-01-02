using ControleFinanceiro.WinForm.Models;
using System;
using System.Collections.Generic;
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

                    // Criar a tabela ContasReceber
                    using (var command = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS ContasReceber
                            (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                ClienteId INTEGER NOT NULL,
                                ValorDesconto REAL NOT NULL,
                                ValorReceber REAL NOT NULL,
                                DataAReceber TEXT NOT NULL,
                                DataRecebimento TEXT NOT NULL,
                                Observacao TEXT,
                                FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
                            )", connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }

                    // Criar a tabela ContasPagar
                    using (var command = new SQLiteCommand(
                       @"CREATE TABLE IF NOT EXISTS ContasPagar
                            (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Descricao TEXT NOT NULL,
                                ValorAPagar REAL NOT NULL,
                                QuantidadeParcelas INTEGER NOT NULL,
                                DataAPagar TEXT NOT NULL,
                                DataPagamento TEXT NOT NULL
                            )", connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Exceção capturada e jogada novamente
                throw new ApplicationException("Erro ao criar banco de dados e tabelas.", ex);
            }
        }

        public async Task<IEnumerable<ContasReceber>> GetContasAReceberAsync()
        {
            try
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new SQLiteCommand(
                        @"SELECT * FROM ContasReceber", connection))
                    {
                        var contasReceber = new List<ContasReceber>();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (!reader.HasRows)
                            {
                                return contasReceber; // Retorna lista vazia se não houver registros
                            }

                            while (await reader.ReadAsync())
                            {
                                var contaAReceber = new ContasReceber
                                {
                                    Id = Convert.ToInt64(reader["Id"]),
                                    ClienteId = Convert.ToInt64(reader["ClienteId"]),
                                    ValorDesconto = Convert.ToDecimal(reader["ValorDesconto"]),
                                    ValorReceber = Convert.ToDecimal(reader["ValorReceber"]),
                                    DataAReceber = Convert.ToDateTime(reader["DataAReceber"]),
                                    DataRecebimento = Convert.ToDateTime(reader["DataRecebimento"]),
                                    Observacao = reader["Observacao"].ToString()
                                };

                                contasReceber.Add(contaAReceber);
                            }
                            return contasReceber;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao obter contas a receber.", ex);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
