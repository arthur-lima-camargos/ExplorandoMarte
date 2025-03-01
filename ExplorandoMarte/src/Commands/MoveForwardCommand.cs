using ExplorandoMarte.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.src.Commands
{
    /// <summary>
    /// Comando que faz o rover mover um ponto para a frente, se possível.
    /// Ele valida se a nova posição está dentro dos limites e se não há colisão.
    /// </summary>
    public class MoveForwardCommand : ICommand
    {
        public void Execute(Rover rover, Plateau plateau)
        {
            Position newPos = rover.GetNextPosition();
            if (!plateau.IsWithinBounds(newPos))
            {
                // Se a nova posição estiver fora dos limites, ignoramos o movimento e exibimos aviso.
                Console.WriteLine($"[Rover {rover.Id}] Movimento ignorado: ({newPos.X},{newPos.Y}) está fora dos limites do planalto.");
                return;
            }
            else if (plateau.IsPositionOccupied(newPos))
            {
                // Se a posição já estiver ocupada por outro rover, ignoramos o movimento.
                Console.WriteLine($"[Rover {rover.Id}] Movimento ignorado: Posição ({newPos.X},{newPos.Y}) já está ocupada.");
                return;
            }
            // Executa a movimentação.
            rover.Move();
        }
    }
}
