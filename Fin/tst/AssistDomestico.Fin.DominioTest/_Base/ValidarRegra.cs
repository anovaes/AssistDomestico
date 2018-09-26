using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssistDomestico.Fin.DominioTest._Base
{
    public class ValidarRegra
    {
        private List<string> _mensagens;

        public ValidarRegra()
        {
            _mensagens = new List<string>();
        }

        public static ValidarRegra Novo()
        {
            return new ValidarRegra();
        }

        public ValidarRegra Quando(bool condicao, string mensagemDeErro)
        {
            if (condicao)
                _mensagens.Add(mensagemDeErro);

            return this;
        }

        public void DispararErro()
        {
            if (_mensagens.Any())
                throw new DominioException(_mensagens);
        }
    }
}
