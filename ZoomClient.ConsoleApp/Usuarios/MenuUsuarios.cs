using System;
using System.Collections.Generic;
using System.Text;

namespace ZoomClient.ConsoleApp.Usuarios
{
    public class MenuUsuarios: MenuBase
    {
        public MenuUsuarios(IItemMenu menuPai)
            :base(menuPai, "API ZOOM- Usuários")
            
        {
            ItensMenu.Add(1, new ListarUsarios(this));
            ItensMenu.Add(2, new CriarUsuario(this));
        }
    }
}
