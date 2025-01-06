using ControleFinanceiro.WinForm.Models.Base;
using System;

namespace ControleFinanceiro.WinForm.Models
{
    public sealed class Servidor : BaseEntity, IDisposable
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public Servidor() : base() { }

        public Servidor(string nome) : base()
        {
            Nome = nome;
        }

        public Servidor(long id, string nome, DateTime createdOn) : base(createdOn)
        {
            Id = id;
            Nome = nome;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
