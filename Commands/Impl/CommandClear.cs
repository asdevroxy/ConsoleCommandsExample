using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCommandConsole.Commands.Impl
{
    public class CommandClear : Command
    {
        public override void Execute(string[] args)
        {
            Console.Clear();
        }
    }
}
