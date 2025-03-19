namespace ExampleCommandConsole.Commands.Impl
{
    internal class CommandEcho : Command
    {
        public override void Execute(string[] args)
        {
            Console.WriteLine(string.Join(" ", args));
        }
    }
}
