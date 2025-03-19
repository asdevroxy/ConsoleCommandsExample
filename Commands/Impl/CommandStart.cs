using System.Diagnostics;

namespace ExampleCommandConsole.Commands.Impl
{
    internal class CommandStart : Command
    {
        public override void Execute(string[] args)
        {
            Process proc = null;
            if (args.Length < 1)
            {
                proc = Process.Start("ExampleCommandConsole.exe");
            }
            else
            {
                string aj = string.Join(" ", args);
                string cmd = args[0];
                string cmdArgs = aj.Substring(cmd.Length);
                proc = Process.Start(cmd, cmdArgs);
            }


            WaitForExit(proc);
        }

        private void WaitForExit(Process process)
        {
            int pid = process.Id;
            process.WaitForExit();
            Console.WriteLine($"Process id {pid} exited with code {process.ExitCode}");
        }
    }
}
