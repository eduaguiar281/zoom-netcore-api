using AndcultureCode.ZoomClient.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZoomClient.ConsoleApp.Usuarios
{
    public class ListarUsarios: ItemMenuBase
    {
        public ListarUsarios(IItemMenu menuPai)
            :base(menuPai, "Listar Usuários")
        {

        }

        public override void Execute()
        {
            base.Execute();

            Console.WriteLine();

            var allUsers = Program.ZoomClient.Users.GetUsers(UserStatuses.Active, 30, 1);
            foreach (var user in allUsers.Users)
            {
                Console.WriteLine(user.Email);
                Console.WriteLine();
            }

            PressioneQualquerTecla();
        }
    }
}
