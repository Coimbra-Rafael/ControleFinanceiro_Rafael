using ControleFinanceiro.WinForm.Models.Base;
using System;

namespace ControleFinanceiro.WinForm.Models
{
    public class Clientes : BaseEntity, IDisposable
    {
        public long Id { get; set; } 
        //Propriedades do cliente
        public string Nome { get; set; } = string.Empty;
        //Propriedades de Contado
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        //Propriedades de Endereço
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string ComplementoPagamento { get; set; } = string.Empty;

        public Clientes() : base() { }
        public Clientes(DateTime createdOn) : base(createdOn) { }

        public Clientes(string nome, string email, string telefone, string cidade, string estado, string endereco, string bairro, string numero, string complemento, string complementoPagamento) : base()
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cidade = cidade;
            Estado = estado;
            Endereco = endereco;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
            ComplementoPagamento = complementoPagamento;
        }

        public Clientes(string nome, string email, string telefone, string cidade, string estado, string endereco, string bairro, string numero, string complemento, string complementoPagamento, DateTime createdOn) : base(createdOn)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cidade = cidade;
            Estado = estado;
            Endereco = endereco;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
            ComplementoPagamento = complementoPagamento;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
