using AssistDomestico.Fin.DominioTest._Base;
using AssistDomestico.Fin.DominioTest._Util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AssistDomestico.Fin.DominioTest.Usuarios
{
    public class UsuarioTest
    {
        private string _nome;
        private string _email;
        private string _senha;
        private DateTime _nascimento;
        private Sexo _sexo;
        private string _cpf;

        public UsuarioTest()
        {
            _nome = "Usuario Test";
            _email = "usu.tst@teste.com";
            _senha = "1234";
            _nascimento = new DateTime(1990, 4, 5);
            _sexo = Sexo.Masculino;
            _cpf = "12345678901";
        }

        [Fact(DisplayName = "DeveCriarUsuario")]
        public void DeveCriarusuario()
        {
            var usuarioEsperado = new
            {
                Nome = "Usuario Test",
                Email = "usu.tst@teste.com",
                Senha = "1234",
                Nascimento = new DateTime(1990, 4, 5),
                Sexo = Sexo.Masculino,
                CPF = "12345678901"
            };

            var usuario = new Usuario(usuarioEsperado.Nome, usuarioEsperado.Email, usuarioEsperado.Senha, usuarioEsperado.Nascimento, usuarioEsperado.Sexo, usuarioEsperado.CPF);

            usuarioEsperado.ToExpectedObject().ShouldMatch(usuario);
        }

        [Theory(DisplayName = "NaoDeveUsuarioPossuirNomeInvalido")]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        [InlineData("12345")]
        [InlineData("@¨#&@¨¨#")]
        public void NaoDeveUsuarioPossuirNomeInvalido(string nomeUsuarioInvalido)
        {
            Assert.Throws<DominioException>(() =>
                new Usuario(nomeUsuarioInvalido,_email,_senha,_nascimento,_sexo,_cpf)    
            ).TestarMensagem("Nome de usuário inválido");

            
        }
    }

    public class Usuario
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime Nascimento { get; private set; }
        public Sexo Sexo { get; private set; }
        public string CPF { get; private set; }

        public Usuario(string nome, string email, string senha, DateTime nascimento, Sexo sexo, string cpf)
        {
            ValidarRegra.Novo()
                .Quando(string.IsNullOrWhiteSpace(nome), "Nome de usuário inválido")
                .DispararErro();

            Nome = nome;
            Email = email;
            Senha = senha;
            Nascimento = nascimento;
            Sexo = sexo;
            CPF = cpf;
        }
    }

    public enum Sexo
    {
        Masculino = 'M', Feminino = 'F'
    }
}
