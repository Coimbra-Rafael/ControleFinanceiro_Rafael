using ControleFinanceiro.WinForm.Models.Base;
using System;

namespace ControleFinanceiro.WinForm.Models
{
    public class ContasReceber : BaseEntity, IDisposable
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorReceber { get; set; }
        public DateTime DataAReceber { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string Observacao{ get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
