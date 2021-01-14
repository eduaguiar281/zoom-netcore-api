using System;
using System.Collections.Generic;
using System.Text;

namespace ZoomClient.ConsoleApp
{
    public interface IItemMenu
    {
        string Titulo { get; set; }

        void Execute();

        IItemMenu MenuPai { get; }
    }
}
