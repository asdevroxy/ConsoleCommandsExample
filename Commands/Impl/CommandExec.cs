using System.Diagnostics;

namespace ExampleCommandConsole.Commands.Impl
{
    internal class CommandExec : Command
    {
        public override void Execute(string[] args)
        {
            Process.Start(@"C:\Windows\System32\cmd.exe", $"/c {string.Join(" ", args)}").WaitForExit();
        }
    }
}
