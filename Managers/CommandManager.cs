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
            if (commands.TryGetValue(name.ToLower(),out var cmd))
            {
                commands.Remove(name.ToLower());
            }
        }

        public void RunCommand(string name, string[] args = null)
        {
            if (commands.TryGetValue(name.ToLower(), out var command)) {
                try
                {
                    command.Execute(args ?? []);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
