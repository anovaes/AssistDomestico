using System;
using System.Collections.Generic;
using System.Text;

namespace AssistDomestico.Fin.DominioTest._Base
{
    public static class Resource
    {
        #region Geral
        #endregion

        #region Usuario
        public static readonly string Usuario_NomeObrigatorio = "Nome do usuário é obrigatório.";
        public static readonly string Usuario_NomeComCaracteresInvalidos = "Nome de usuário deve possuir apenas letras.";
        public static readonly string Usuario_EmailObrigatorio = "Email do usuário é obrigatório.";
        public static readonly string Usuario_EmailForaDoPadrao = "Email do usuário está fora do padrão [email@exemplo.com ou .br].";
        public static readonly string Usuario_LoginObrigatorio = "Login do usuário é obrigatório.";
        public static readonly string Usuario_SenhaObrigatoria = "Senha do usuário é obrigatória.";
        public static readonly string Usuario_CPFInvalido = "CPF do usuário inválido.";
        #endregion
    }
}
