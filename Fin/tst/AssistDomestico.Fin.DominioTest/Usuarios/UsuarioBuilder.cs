using AssistDomestico.Fin.DominioTest._Base;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistDomestico.Fin.DominioTest.Usuarios
{
    public class UsuarioBuilder
    {
        private int _id;
        private string _nome;
        private string _email;
        private string _login;
        private string _senha;
        private DateTime _nascimento;
        private Sexo _sexo;
        private string _cpf;

        public UsuarioBuilder()
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

        public static UsuarioBuilder Novo()
        {
            return new UsuarioBuilder();
        }

        public UsuarioBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public UsuarioBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public UsuarioBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public UsuarioBuilder ComLogin(string login)
        {
            _login = login;
            return this;
        }

        public UsuarioBuilder ComSenha(string senha)
        {
            _senha = senha;
            return this;
        }

        public UsuarioBuilder ComNascimento(DateTime nascimento)
        {
            _nascimento = nascimento;
            return this;
        }

        public UsuarioBuilder ComSexo(Sexo sexo)
        {
            _sexo = sexo;
            return this;
        }

        public UsuarioBuilder ComCPF(string cpf)
        {
            _cpf = cpf;
            return this;
        }

        public Usuario Criar()
        {
            return new Usuario(_nome, _email, _login, _senha, _nascimento, _sexo, _cpf);
        }

        public Usuario Criar(out string msg)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Nome : {_nome}");
            sb.AppendLine($"Email: {_email}");
            sb.AppendLine($"Login: {_login}");
            sb.AppendLine($"Senha: {_senha}");
            sb.AppendLine($"Nasc.: {_nascimento.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"Sexo : {_sexo.ToString()}");
            sb.AppendLine($"CPF  : {_cpf}");
            sb.AppendLine();

            Usuario usuario = null;
            msg = "";

            try
            {
                usuario = new Usuario(_nome, _email, _login, _senha, _nascimento, _sexo, _cpf);
            }
            catch (Exception ex)
            {
                //ex.MensagensDeErro.ForEach(x => sb.AppendLine(x));
                msg = sb.ToString();

            }

            return usuario;
        }
    }
}
