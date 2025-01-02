using ControleFinanceiro.WinForm.Models.Base;
using System;

namespace ControleFinanceiro.WinForm.Models
{
    public class Clientes : BaseEntity, IDisposable
    {
        public long Id { get; set; }
        //Propriedades do cliente
        public string Nome { get; set; }
        //Propriedades de Contado
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; }
        //Propriedades de Endereço
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public Clientes() : base() { }
        public Clientes(DateTime createdOn) : base(createdOn) { }

        public Clientes(string nome, string email, string telefone, string cidade, string estado, string endereco, string bairro, string numero, string complemento) : base()
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
        }

        public Clientes(string nome, string email, string telefone, string cidade, string estado, string endereco, string bairro, string numero, string complemento, DateTime createdOn) : base(createdOn)
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
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
