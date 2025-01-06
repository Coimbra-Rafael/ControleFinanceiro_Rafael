using ControleFinanceiro.WinForm.Models.Base;
using System;

namespace ControleFinanceiro.WinForm.Models
{
    public sealed class ContasPagar : BaseEntity, IDisposable
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorAPagar { get; set; }
        public long QuantidadeParcelas { get; set; }
        public DateTime DataAPagar { get; set; }
        public DateTime DataPagamento { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
