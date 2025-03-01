using ExplorandoMarte.src.Models;

namespace ExplorandoMarte.src.Commands
{
    /// <summary>
    /// Comando que rotaciona o rover para a direita.
    /// </summary>
    public class RotateRightCommand : ICommand
    {
        public void Execute(Rover rover, Plateau plateau)
        {
            rover.TurnRight();
        }
    }
}
