using System;
using System.Collections.Generic;
using System.Text;
using ZoomClient.ConsoleApp.Usuarios;

namespace ZoomClient.ConsoleApp
{
    public class MenuPrincipal : MenuBase
    {
        public MenuPrincipal()
            :base(null, "API ZOOM- Menu Principal")
        {
            ItensMenu.Add(1, new MenuUsuarios(this));
        }
        
        public override void Execute()
        {
            base.Execute();


        }
    }
}
