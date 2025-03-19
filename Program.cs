using ExampleCommandConsole.Commands;
using ExampleCommandConsole.Commands.Impl;
using ExampleCommandConsole.Managers;

namespace ExampleCommandConsole
{
    internal class Program
    {
        public static bool Quit = false;

        static void Main(string[] args)
        {
            Dictionary<string, Command> defaultCommands = new()
            {
                { "clear", new CommandClear() },
                { "echo", new CommandEcho() },
                { "exit", new CommandExit() }
            };

            foreach (var command in defaultCommands)
            {
                CommandManager.Instance.RegisterCommand(command.Key, command.Value);
            }

            if (args.Length > 0)
            {
                Process(string.Join(" ", args));
                return;
            }

            while (!Quit)
            {
                Console.Write("> ");
                string command = Console.ReadLine();
                Process(command);
            }
        }


        static void Process(string command)
        {
            int spaceIndex = command.IndexOf(" ");
            string[] cmdArgs = [];
            if (spaceIndex != -1)
            {
                string[] parts = command.Split(' ');
                command = parts[0];
                cmdArgs = new string[parts.Length - 1];

                for (int i = 1; i < parts.Length; i++)
                {
                    cmdArgs[i - 1] = parts[i];
                }
            }

            CommandManager.Instance.RunCommand(command.ToLower(), cmdArgs);
        }
    }
}
