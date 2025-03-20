using System.Diagnostics;
using ExampleCommandConsole.Commands;

namespace ExampleCommandConsole.Managers
{
    public class CommandManager
    {
        public static CommandManager Instance { get; private set; } = new CommandManager();

        private Dictionary<string, Command> commands = [];

        public void RegisterCommand(string name, Command command)
        {
            if (!commands.TryGetValue(name.ToLower(), out var cmd))
            {
                commands.Add(name.ToLower(), command);
            }
        }

        public void UnregisterCommand(string name)
        {
            if (commands.TryGetValue(name.ToLower(), out var cmd))
            {
                commands.Remove(name.ToLower());
            }
        }

        public void RunCommand(string name, string[] args = null)
        {
            if (commands.TryGetValue(name.ToLower(), out var command))
            {
                try
                {
                    command.Execute(args ?? []);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex);
                }

                return;
            }

            if (name == null || name.Trim().Length < 1) return;

            var path = Program.PATH;
            bool found = false;
            foreach (var pathVar in path)
            {
                var p = @$"{pathVar}\{name}.exe";
                if (!File.Exists(p)) continue;

                found = true;
                Process.Start(p, (args == null  || args.Length < 1) ? "" : string.Join(" ", args)).WaitForExit();
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: Unknown Command '{name}'");
            }
        }
    }
}
