namespace ExampleCommandConsole.Commands.Impl
{
    internal class CommandExit : Command
    {
        public override void Execute(string[] args)
        {
            Program.Quit = true;

            if (args.Length > 0)
            {
                int.TryParse(args[0], out Program.ExitCode);
            }
        }
    }
}
