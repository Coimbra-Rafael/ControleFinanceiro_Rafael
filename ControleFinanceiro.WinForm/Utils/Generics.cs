using ControleFinanceiro.WinForm.Models;
using System.Collections.Generic;

namespace ControleFinanceiro.WinForm.Utils
{
    public static class Generics 
    {
        public static IEnumerable<string> GetChangedProperties<T>(T oldObject, T newObject)
        {
            var propriedadesAlteradas = new List<string>();

            var propriedades = typeof(T).GetProperties();

            foreach (var propriedade in propriedades)
            {
                var oldValue = propriedade.GetValue(oldObject)?.ToString() ?? string.Empty;
                var newValue = propriedade.GetValue(newObject)?.ToString() ?? string.Empty;

                if (!oldValue.Equals(newValue))
                {
                    propriedadesAlteradas.Add(propriedade.Name);
                }
            }

            return propriedadesAlteradas;
        }
    }
}
