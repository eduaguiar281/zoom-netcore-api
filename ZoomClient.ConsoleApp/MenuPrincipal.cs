using System;
using System.Collections.Generic;
using System.Text;
using ZoomClient.ConsoleApp.Meetings;
using ZoomClient.ConsoleApp.Usuarios;

namespace ZoomClient.ConsoleApp
{
    public class MenuPrincipal : MenuBase
    {
        public MenuPrincipal()
            :base(null, "API ZOOM- Menu Principal")
        {
            ItensMenu.Add(1, new MenuUsuarios(this));
            ItensMenu.Add(2, new MenuMeetings(this));
        }

        public override void Execute()
        {
            base.Execute();


        }
    }
}
