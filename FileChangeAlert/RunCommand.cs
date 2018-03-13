using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChangeAlert
{
    class RunCommand
    {
        public static void runCmd(String command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
            }
            catch (Exception objException)
            {
                DateTime datetoday = DateTime.Today;
                DateTime timeOfDay = DateTime.Now;
                FileHandling.WriteToFile(@"..\..\logexecutionfailure.txt", "[" + datetoday + timeOfDay + "]" + "object exception");
            }
        }

        private static String result;
        public static String RunCmdAndGetOutput(String command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                result = proc.StandardOutput.ReadToEnd();
            }
            catch (Exception objException)
            {
                DateTime datetoday = DateTime.Today;
                DateTime timeOfDay = DateTime.Now;
                FileHandling.WriteToFile(@"..\..\logexecutionfailure.txt", "[" + datetoday + timeOfDay + "]" + "object exception");
            }
            return result;
        }

        public static String RunCmdGetOutputForLog(String command, String path)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);
                procStartInfo.WorkingDirectory = @path;
                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                result = proc.StandardOutput.ReadToEnd();
            }
            catch (Exception objException)
            {
                DateTime datetoday = DateTime.Today;
                DateTime timeOfDay = DateTime.Now;
                FileHandling.WriteToFile(@"..\..\logexecutionfailure.txt", "[" + datetoday + timeOfDay + "]" + "object exception");
            }
            return result;
        }
    }
}
