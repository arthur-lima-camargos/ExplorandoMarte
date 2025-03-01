using ExplorandoMarte.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.src.Commands
{
    /// <summary>
    /// Comando que rotaciona o rover para a esquerda.
    /// </summary>
    public class RotateLeftCommand : ICommand
    {
        public void Execute(Rover rover, Plateau plateau)
        {
            rover.TurnLeft();
        }
    }
}
