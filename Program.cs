using ExampleCommandConsole.Commands;
using ExampleCommandConsole.Commands.Impl;
using ExampleCommandConsole.Managers;

namespace ExampleCommandConsole
{
    internal class Program
    {
        public static bool Quit = false;
        public static int ExitCode = 0;

        public static string ExecutionDirectory { get; private set; }

        internal static List<string> PATH = [];

        static void Main(string[] args)
        {
            string[] paths = Environment.GetEnvironmentVariable("path").Split(";");
            PATH.AddRange(paths);

            ExecutionDirectory = Environment.CurrentDirectory;
            var origColor = Console.ForegroundColor;

            Console.Title = "ExampleCommandConsole";
            Dictionary<string, Command> defaultCommands = new()
            {
                { "cd", new CommandCD() },
                { "cat", new CommandCat() },

                { "clear", new CommandClear() },
                
                { "echo", new CommandEcho() },
                { "exit", new CommandExit() },
                { "exec", new CommandExec() },
                
                { "start", new CommandStart() },
            };

            foreach (var command in defaultCommands)
            {
                CommandManager.Instance.RegisterCommand(command.Key, command.Value);
            }

            if (args.Length > 0)
            {
                Process(string.Join(" ", args));
                Quit = true;
            }

            while (!Quit)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"{Environment.CurrentDirectory}> ");
                string command = Console.ReadLine();
                Process(command);
            }

            Console.ForegroundColor = origColor;

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
