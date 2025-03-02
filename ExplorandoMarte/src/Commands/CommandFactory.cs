namespace ExplorandoMarte.src.Commands
{
    /// <summary>
    /// Fábrica para criação de objetos ICommand a partir de um caractere.
    /// </summary>
    public static class CommandFactory
    {
        public static ICommand GetCommand(char commandChar)
        {
            return commandChar switch
            {
                'L' => new RotateLeftCommand(),
                'R' => new RotateRightCommand(),
                'M' => new MoveForwardCommand(),
                _ => throw new ArgumentException($"Comando inválido: {commandChar}"),
            };
        }
    }
}
