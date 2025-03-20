using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCommandConsole.Commands.Impl
{
    internal class CommandCD : Command
    {
        public override void Execute(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine(Environment.CurrentDirectory);
                return;
            }

            if (args[0].Equals(".."))
            {
                Environment.CurrentDirectory = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf(@"\"));
                return;
            }

            Environment.CurrentDirectory = string.Join(" ", args);
        }
    }
}
