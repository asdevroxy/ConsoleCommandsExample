namespace ExampleCommandConsole.Commands.Impl
{
    internal class CommandExit : Command
    {
        public override void Execute(string[] args)
        {
            Program.Quit = true;
        }
    }
}
