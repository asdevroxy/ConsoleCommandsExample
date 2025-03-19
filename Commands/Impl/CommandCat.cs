namespace ExampleCommandConsole.Commands.Impl
{
    internal class CommandCat : Command
    {
        public override void Execute(string[] args)
        {
            if (args.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: You must specify a file!");
                return;
            }

            foreach (string arg in args)
            {
                if (!File.Exists(arg))
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"File {arg} does not exist.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                string data = File.ReadAllText(arg);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"### {arg}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(data);

                Console.WriteLine("\n\n");
            }
        }
    }
}
