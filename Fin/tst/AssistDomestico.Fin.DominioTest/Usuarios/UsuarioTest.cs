using AssistDomestico.Fin.DominioTest._Base;
using AssistDomestico.Fin.DominioTest._Util;
using Bogus;
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
        private string _login;
        private string _senha;
        private DateTime _nascimento;
        private Sexo _sexo;
        private string _cpf;

        public UsuarioTest()
        {
            Faker faker = new Faker();

            _nome = faker.Person.FullName;
            _email = faker.Person.Email;
            _login = faker.Internet.UserName();
            _senha = faker.Internet.Password(10);
            _nascimento = faker.Person.DateOfBirth;
            _sexo = Sexo.Masculino;
            _cpf = "12345678901";
        }

        #region Criar Objeto
        [Fact(DisplayName = "DeveCriarUsuario")]
        public void DeveCriarUsuario()
        {
            var usuarioEsperado = new
            {
                Nome = _nome,
                Email = _email,
                Login = _login,
                Senha = _senha,
                Nascimento = _nascimento,
                Sexo = _sexo,
                CPF = _cpf
            };

            var usuario = new Usuario(usuarioEsperado.Nome, usuarioEsperado.Email, usuarioEsperado.Login, usuarioEsperado.Senha, usuarioEsperado.Nascimento, usuarioEsperado.Sexo, usuarioEsperado.CPF);
            usuarioEsperado.ToExpectedObject().ShouldMatch(usuario);
        }

        [Theory(DisplayName = "NaoDeveUsuarioPossuirNomeNuloOuEmBranco")]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void NaoDeveUsuarioPossuirNomeNuloOuEmBranco(string nomeUsuarioNulo)
        {
            Assert.Throws<DominioException>(() =>
                UsuarioBuilder.Novo().ComNome(nomeUsuarioNulo).Criar()
            ).TestarMensagem(Resource.Usuario_NomeObrigatorio);
        }

        [Theory(DisplayName = "NaoDeveUsuarioPossuirNomeComCaracteresInvalidos")]
        [InlineData("12345")]
        [InlineData("@¨#&@¨¨#")]
        [InlineData("J04O )4 $1lva")]
        public void NaoDeveUsuarioPossuirNomeComCaracteresInvalidos(string nomeUsuarioInvalido)
        {
            Assert.Throws<DominioException>(() =>
                UsuarioBuilder.Novo().ComNome(nomeUsuarioInvalido).Criar()
            ).TestarMensagem(Resource.Usuario_NomeComCaracteresInvalidos);
        }

        [Theory(DisplayName = "NaoDeveUsuarioPossuirEmailNuloOuEmBranco")]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void NaoDeveUsuarioPossuirEmailObrigatorio(string emailUsuarioNulo)
        {
            Assert.Throws<DominioException>(() =>
                UsuarioBuilder.Novo().ComEmail(emailUsuarioNulo).Criar()
            ).TestarMensagem(Resource.Usuario_EmailObrigatorio);
        }

        [Theory(DisplayName = "NaoDeveUsuarioPossuirEmailForaDoPadrao")]
        [InlineData("aaaa")]
        [InlineData("email@test")]
        [InlineData("email.test.com")]
        public void NaoDeveUsuarioPossuirEmailForaDoPadrao(string emailForaDoPadrao)
        {
            Assert.Throws<DominioException>(() =>
                UsuarioBuilder.Novo().ComEmail(emailForaDoPadrao).Criar()
            ).TestarMensagem(Resource.Usuario_EmailForaDoPadrao);
        }

        [Theory(DisplayName = "NaoDeveUsuarioPossuirLoginNuloOuEmBranco")]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void NaoDeveUsuarioPossuirLoginNuloOuEmBranco(string loginUsuarioNulo)
        {
            Assert.Throws<DominioException>(() =>
                UsuarioBuilder.Novo().ComLogin(loginUsuarioNulo).Criar()
            ).TestarMensagem(Resource.Usuario_LoginObrigatorio);
        }

        [Theory(DisplayName = "NaoDeveUsuarioPossuirSenhaNulaOuEmBranco")]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void NaoDeveUsuarioPossuirSenhaNulaOuEmBranco(string senhaUsuarioNulo)
        {
            Assert.Throws<DominioException>(() =>
                UsuarioBuilder.Novo().ComSenha(senhaUsuarioNulo).Criar()
            ).TestarMensagem(Resource.Usuario_SenhaObrigatoria);
        }

        [Theory(DisplayName = "NaoDeveUsuarioPossuirCPFInvalido")]
        [InlineData("aaaa")]
        [InlineData("22.65")]
        [InlineData("22.65.11")]
        [InlineData("0000000000000")]
        [InlineData("12345")]
        [InlineData("123456789012")]
        [InlineData("  3456789012")]
        [InlineData("1234567890  ")]
        [InlineData("12345  89012")]
        public void NaoDeveUsuarioPossuirCPFInvalido(string cpfUsuarioInvalido)
        {
            Assert.Throws<DominioException>(() =>
                UsuarioBuilder.Novo().ComCPF(cpfUsuarioInvalido).Criar()
            ).TestarMensagem(Resource.Usuario_CPFInvalido);
        }
        #endregion

        #region Alterar Objeto

        [Theory(DisplayName = "NaoDeveAlterarNomeDoUsuarioComNomeNuloOuEmBranco")]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void NaoDeveAlterarNomeDoUsuarioComNomeNuloOuEmBranco(string nomeUsuarioNulo)
        {
            var usuarioJaCadastrado = UsuarioBuilder.Novo().Criar(out string msg);
            Assert.True(string.IsNullOrEmpty(msg), msg);

            Assert.Throws<DominioException>(() =>
                usuarioJaCadastrado.AlterarNome(nomeUsuarioNulo)
            ).TestarMensagem(Resource.Usuario_NomeObrigatorio);
        }

        [Theory(DisplayName = "NaoDeveAlterarNomeDoUsuarioComCaracteresInvalidos")]
        [InlineData("12345")]
        [InlineData("@¨#&@¨¨#")]
        [InlineData("J04O )4 $1lva")]
        public void NaoDeveAlterarNomeDoUsuarioComCaracteresInvalidos(string nomeUsuarioInvalido)
        {
            var usuarioJaCadastrado = UsuarioBuilder.Novo().Criar(out string msg);
            Assert.True(string.IsNullOrEmpty(msg), msg);

            Assert.Throws<DominioException>(() =>
                usuarioJaCadastrado.AlterarNome(nomeUsuarioInvalido)
            ).TestarMensagem(Resource.Usuario_NomeComCaracteresInvalidos);
        }

        [Theory(DisplayName = "NaoDeveAlterarSenhaDoUsuarioComSenhaNulaOuEmBranco")]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void NaoDeveAlterarSenhaDoUsuarioComSenhaNulaOuEmBranco(string senhaUsuarioNula)
        {
            var usuarioJaCadastrado = UsuarioBuilder.Novo().Criar(out string msg);
            Assert.True(string.IsNullOrEmpty(msg), msg);

            Assert.Throws<DominioException>(() =>
                usuarioJaCadastrado.AlterarSenha(senhaUsuarioNula)
            ).TestarMensagem(Resource.Usuario_SenhaObrigatoria);
        }

        #endregion
    }

    public class Usuario
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public DateTime Nascimento { get; private set; }
        public Sexo Sexo { get; private set; }
        public string CPF { get; private set; }

        public Usuario(string nome, string email, string login, string senha, DateTime nascimento, Sexo sexo, string cpf)
        {
            ValidarRegra.Novo()
                .Quando(string.IsNullOrWhiteSpace(nome), Resource.Usuario_NomeObrigatorio)
                .Quando(!nome.ContemApenasLetras(), Resource.Usuario_NomeComCaracteresInvalidos)
                .Quando(string.IsNullOrWhiteSpace(email), Resource.Usuario_EmailObrigatorio)
                .Quando(!email.EhEmail(), Resource.Usuario_EmailForaDoPadrao)
                .Quando(string.IsNullOrWhiteSpace(login), Resource.Usuario_LoginObrigatorio)
                .Quando(string.IsNullOrWhiteSpace(senha), Resource.Usuario_SenhaObrigatoria)
                .Quando(!ValidarCPF(cpf), Resource.Usuario_CPFInvalido)
                .DispararErro();

            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Nascimento = nascimento;
            Sexo = sexo;
            CPF = cpf;
        }

        internal void AlterarNome(string nome)
        {
            ValidarRegra.Novo()
                .Quando(string.IsNullOrWhiteSpace(nome), Resource.Usuario_NomeObrigatorio)
                .Quando(!nome.ContemApenasLetras(), Resource.Usuario_NomeComCaracteresInvalidos)
                .DispararErro();

            Nome = nome;
        }

        internal void AlterarSenha(string senha)
        {
            ValidarRegra.Novo()
                .Quando(string.IsNullOrWhiteSpace(senha), Resource.Usuario_SenhaObrigatoria)
                .DispararErro();

            Senha = senha;
        }

        #region Validação
        private bool ValidarCPF(string cpf)
        {
            if (cpf.Length == 11 &&
                !cpf.Contains(" ") &&
                cpf.EhNumerico() &&
                long.TryParse(cpf, out var num))
            {
                return num > 0;
            }

            return false;
        }
        #endregion
    }

    public enum Sexo
    {
        Masculino = 'M', Feminino = 'F'
    }
}
