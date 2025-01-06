using System;

namespace ControleFinanceiro.WinForm.Models
{
    public sealed class ServidorClientes : IDisposable
    {
        public long ServidorId { get; set; }
        public long ClienteId { get; set; }
        public ServidorClientes() { }
        public ServidorClientes(long servidorId, long clienteId)
        {
            ServidorId = servidorId;
            ClienteId = clienteId;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
