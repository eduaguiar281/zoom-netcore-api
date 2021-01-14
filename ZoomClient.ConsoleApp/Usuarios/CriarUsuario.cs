using AndcultureCode.ZoomClient.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZoomClient.ConsoleApp.Usuarios
{
    public class CriarUsuario: ItemMenuBase
    {
        public CriarUsuario(IItemMenu menuPai)
            :base(menuPai, "Criar Usuario")
        {

        }

        private void Criar(string email, string primeiroNome, string sobreNome, string senha)
        {
            Program.ZoomClient.Users.CreateUser(new CreateUser
            {
                Email = email,
                FirstName = primeiroNome,
                LastName = sobreNome,
                Password = senha,
                Type = UserTypes.Basic
            },
            CreateUserAction.Create);
        }

        public override void Execute()
        {
            base.Execute();

            Console.WriteLine();

            bool continuar;
            do
            {
                Console.WriteLine("Digite um E-mail:");
                string email = Console.ReadLine();
                Console.WriteLine("Digite um Primeiro Nome:");
                string primeiroNome = Console.ReadLine();
                Console.WriteLine("Digite um Sobrenome:");
                string sobreNome = Console.ReadLine();
                Console.WriteLine("Digite uma Senha:");
                string senha = Console.ReadLine();

                Console.WriteLine("Confirma? (S/N)");
                string leitura = Console.ReadLine();
                if (leitura == "S" || leitura == "s")
                    Criar(email, primeiroNome, sobreNome, senha);

                Console.WriteLine("Incluir Novo? (S/N)");
                leitura = Console.ReadLine();
                continuar = (leitura == "S" || leitura == "s");
            }
            while (continuar);
            PressioneQualquerTecla();
        }

    }

}
