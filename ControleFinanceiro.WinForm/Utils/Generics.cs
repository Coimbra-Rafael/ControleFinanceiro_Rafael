using ControleFinanceiro.WinForm.Models;
using System.Collections.Generic;

namespace ControleFinanceiro.WinForm.Utils
{
    public static class Generics 
    {
        public static IEnumerable<string> GetChangedProperties<T>(T clienteAntigo, T clienteNovo)
        {
            var propriedadesAlteradas = new List<string>();

            var propriedades = typeof(T).GetProperties();

            foreach (var propriedade in propriedades)
            {
                var valorAntigo = propriedade.GetValue(clienteAntigo)?.ToString() ?? string.Empty;
                var valorNovo = propriedade.GetValue(clienteNovo)?.ToString() ?? string.Empty;

                if (!valorAntigo.Equals(valorNovo))
                {
                    propriedadesAlteradas.Add(propriedade.Name);
                }
            }

            return propriedadesAlteradas;
        }
    }
}
