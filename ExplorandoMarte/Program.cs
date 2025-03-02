using ExplorandoMarte.src.Commands;
using ExplorandoMarte.src.Factories;
using ExplorandoMarte.src.Models;

namespace ExplorandoMarte
{
    class Program
    {
        static void Main(string[] args)
        {
            // O caminho do arquivo de entrada pode ser passado pelos argumentos; caso contrário, usa "input.txt".  
            string inputFile = args.Length > 0 ? args[0] : "input.txt";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Arquivo de entrada '{inputFile}' não encontrado.");
                return;
            }

            var lines = File.ReadAllLines(inputFile);
            if (lines.Length < 3)
            {
                Console.WriteLine("Arquivo de entrada inválido. Verifique o formato.");
                return;
            }

            // Primeira linha: limites do planalto (exemplo: "5 5")
            var plateauBoundary = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (plateauBoundary.Length != 2)
            {
                Console.WriteLine("Definição do planalto inválida.");
                return;
            }

            int maxX = int.Parse(plateauBoundary[0]);
            int maxY = int.Parse(plateauBoundary[1]);

            Plateau plateau = new Plateau(maxX, maxY);

            // As demais linhas vêm em pares: primeira linha da sonda e segunda, os comandos.
            List<string> outputResults = new List<string>();
            int roverCount = 0;

            for (int i = 1; i < lines.Length; i += 2)
            {
                roverCount++;
                string roverPositionLine = lines[i];
                string roverCommandsLine = (i + 1 < lines.Length) ? lines[i + 1] : "";

                try
                {
                    Rover rover = RoverFactory.CreateRover(roverPositionLine, roverCount.ToString());

                    // Valida se a posição inicial está dentro dos limites.
                    if (!plateau.IsWithinBounds(rover.Position))
                    {
                        Console.WriteLine($"[Rover {rover.Id}] Posição inicial fora dos limites do planalto.");
                        continue;
                    }

                    // Evita conflito: se a posição de início já estiver ocupada por outra sonda finalizada.
                    if (plateau.IsPositionOccupied(rover.Position))
                    {
                        Console.WriteLine($"[Rover {rover.Id}] Posição inicial já ocupada.");
                        continue;
                    }

                    // Processa cada comando utilizando a CommandFactory.
                    foreach (char command in roverCommandsLine)
                    {
                        var commandObj = CommandFactory.GetCommand(command);
                        if (commandObj != null)
                        {
                            commandObj.Execute(rover, plateau);
                        }
                    }

                    // Ao final de todos os comandos, registra a posição final do rover.
                    plateau.OccupyPosition(rover.Position);
                    outputResults.Add(rover.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao processar o Rover {roverCount}: {ex.Message}");
                }
            }

            // Exibe as posições finais no console.
            Console.WriteLine("Posições finais dos rovers:");
            foreach (var line in outputResults)
            {
                Console.WriteLine(line);
            }
        }
    }
}