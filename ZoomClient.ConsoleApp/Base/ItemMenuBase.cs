using System;
using System.Collections.Generic;
using System.Text;

namespace ZoomClient.ConsoleApp
{
    public abstract class ItemMenuBase: IItemMenu
    {
        public ItemMenuBase(IItemMenu menuPai)
        {
            MenuPai = menuPai;
        }
        public ItemMenuBase(IItemMenu menuPai, string titulo)
        {
            Titulo = titulo;
            MenuPai = menuPai;
        }
        protected virtual void PressioneQualquerTecla()
        {
            Console.WriteLine("Pressione Qualquer Tecla Para Continuar...");
            Console.ReadKey();
        }

        protected void LimparTela()
        {
            Console.Clear();
        }
        protected virtual void Cabecalho()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine(Titulo);
            Console.WriteLine("=============================================================");
        }

        public string Titulo { get; set; }

        public IItemMenu MenuPai { get; }
        public virtual void Execute()
        {
            LimparTela();
            Cabecalho();
        }

        protected bool MensagemConfirmacao(string mensagem, string stringValidas)
        {
            Console.WriteLine(mensagem);
            string leitura = Console.ReadLine();

            return stringValidas.Contains(leitura);
        }

    }
}
