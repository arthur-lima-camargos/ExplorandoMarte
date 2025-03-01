using ExplorandoMarte.src.Models;

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
