using System;
using System.Collections.Generic;
using System.Text;

namespace AssistDomestico.Fin.DominioTest._Base
{
    public class DominioException : ArgumentException
    {
        public List<string> MensagensDeErro { get; private set; }

        public DominioException(List<string> listaMensagens)
        {
            MensagensDeErro = new List<string>();

            foreach (var msg in listaMensagens)
            {
                MensagensDeErro.Add(msg);
            }
        }
    }
}
