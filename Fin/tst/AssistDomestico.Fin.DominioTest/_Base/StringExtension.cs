using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AssistDomestico.Fin.DominioTest._Base
{
    public static class StringExtension
    {
        /// <summary>
        /// Verifica se a string contém apenas letras.
        /// </summary>
        /// <returns>Retorna true caso a string conter apenas letras, caso contrário falso.</returns>
        public static bool ContemApenasLetras(this string texto)
        {
            if (texto == null)
                return false;

            return Regex.Match(texto, "^[a-z A-Z À-Ú à-ú]*$").Success;
        }

        /// <summary>
        /// Verifica se a string é numérica.
        /// </summary>
        /// <returns>Retorna true caso a string for numérica, caso contrário falso.</returns>
        public static bool EhNumerico(this string texto)
        {
            return long.TryParse(texto, out long f);
        }

        /// <summary>
        /// Verifica se o valor é um email válido
        /// </summary>
        /// <returns>Retorna true caso o valor for um email válido, caso contrário falso.</returns>
        public static bool EhEmail(this string texto)
        {
            if (texto == null)
                return false;

            var regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return regex.IsMatch(texto);
        }
    }
}
