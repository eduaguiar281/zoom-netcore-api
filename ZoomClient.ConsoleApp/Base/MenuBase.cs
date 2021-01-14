using System;
using System.Collections.Generic;
using System.Text;

namespace ZoomClient.ConsoleApp
{
    public abstract class MenuBase : ItemMenuBase
    {
        private int _indexSair;
        public MenuBase(IItemMenu menuPai)
            :base(menuPai)
        {

        }
        public MenuBase(IItemMenu menuPai, string titulo)
            :base(menuPai, titulo)
        {  }

        protected Dictionary<int, IItemMenu> ItensMenu { get; set; } = new Dictionary<int, IItemMenu>();

        protected int MostrarMenu()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("");
            foreach (var item in ItensMenu)
            {
                Console.WriteLine($"{item.Key:00}- {item.Value.Titulo}");
                _indexSair = item.Key + 1;
            }
            Console.WriteLine($"{_indexSair:00}- Sair");
            return int.Parse(Console.ReadLine());
        }


        public override void Execute()
        {
            int opcao;
            bool continuar;
            do
            {
                LimparTela();
                Cabecalho();
                opcao = MostrarMenu();
                ExecutarOpcao(opcao);
                continuar = opcao != _indexSair;
            }
            while (continuar);

            if (MenuPai != null)
                MenuPai.Execute();
            else
                PressioneQualquerTecla();
        }

        protected virtual void ExecutarOpcao(int opcao)
        {
            if (!ItensMenu.ContainsKey(opcao))
                return;
            ItensMenu[opcao].Execute();
        }
    }
}
