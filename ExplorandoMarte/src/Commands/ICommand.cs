using ExplorandoMarte.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.src.Commands
{
    /// <summary>
    /// Interface que representa um comando a ser executado por um rover.
    /// </summary>
    public interface ICommand
    {
        void Execute(Rover rover, Plateau plateau);
    }
}
