using System;
using System.Collections.Generic;
using AndcultureCode.ZoomClient.Models;
using AndcultureCode.ZoomClient.Models.Users;

namespace ZoomClient.ConsoleApp
{
    public class Program
    {
        public static AndcultureCode.ZoomClient.ZoomClient ZoomClient;
        private static void Inicializar()
        {
            var options = new ZoomClientOptions
            {
                ZoomApiKey = "TyDrLX_3Q9OyK9fl-A1jbw",
                ZoomApiSecret = "7TiT3Vks7lOMG9ganb5itofyCbO1IphSezm0"
            };
            ZoomClient = new AndcultureCode.ZoomClient.ZoomClient(options);
        }


        public static void Main(string[] args)
        {
            Inicializar();
            Console.WriteLine("Testes da API do ZOOM foi Inicializado!");

            MenuPrincipal menu = new MenuPrincipal();
            menu.Execute();
        }
    }
}
