using ExampleCommandConsole.Commands;
using ExampleCommandConsole.Commands.Impl;
using ExampleCommandConsole.Managers;

namespace ExampleCommandConsole
{
    internal class Program
    {
        public static bool Quit = false;
        public static int ExitCode = 0;

        static void Main(string[] args)
        {
            Console.Title = "ExampleCommandConsole";
            Dictionary<string, Command> defaultCommands = new()
            {
                { "clear", new CommandClear() },
                { "echo", new CommandEcho() },
                { "exit", new CommandExit() },
                { "cat", new CommandCat() },
                { "start", new CommandStart() }, 
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
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("> ");
                string command = Console.ReadLine();
                Process(command);
            }

            if (ExitCode != 0)
            {
                Environment.Exit(ExitCode);
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
