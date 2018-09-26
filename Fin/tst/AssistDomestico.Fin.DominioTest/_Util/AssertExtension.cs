using AssistDomestico.Fin.DominioTest._Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AssistDomestico.Fin.DominioTest._Util
{
    public static class AssertExtension
    {
        public static void TestarMensagem(this DominioException exception, string mensagem)
        {
            if (exception.MensagensDeErro.Contains(mensagem))
                Assert.True(true);
            else
                Assert.True(false, $"Era esperado a mensagem {mensagem}");
        }
    }
}
