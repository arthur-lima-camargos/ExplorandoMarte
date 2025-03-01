using ExplorandoMarte.src.Models;

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
