using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedConsole;

namespace zkmtt
{
    class MainCode
    {
        public static void Run(string[] args)
        {
            void ShowInfo()
            {
                AdvConsole.WriteLine(ConsoleColor.Cyan,
                    "ZAC's KMT Tool\n" +
                    "by Zach Combs\n" +
                    "\n" +
                    "\n" +
                    "zkmtt dump <source> [<destination>]     Writes content from <source> onto the console and/or if specified\n" +
                    "                                            <destination>.\n" +
                    "zkmtt decode <source> [<destination>]   Decodes content from <source> and creates an XML out of the content.\n" +
                    "zkmtt encode <source> [<destination>]   Encodes content from <source> (an xml file> into a KMT file)."
                    );
            }
            void ShowError(string message)
            {
                AdvConsole.WriteLine(ConsoleColor.Red,
                    "ERROR: \n" +
                    "{0}"
                    , message);
            }
            if (args == null)
            {
                ShowInfo();
            }
            else if (args.Length == 0)
            {
                ShowInfo();
            }
            else
            {
                string command = args[0];
                string[] argss = new string[args.Length - 1];
                Array.Copy(args, 1, argss, 0, argss.Length);

                bool knowcommand = false;
                StringValue errormessage = null;
                if (command == "dump")
                {
                    errormessage = Dump.Run(argss);
                    knowcommand = true;
                }
                else if (command == "decode")
                {
                    errormessage = Decode.Run(argss);
                    knowcommand = true;
                }
                else if (command == "encode")
                {
                    errormessage = Encode.Run(argss);
                    knowcommand = true;
                }

                if (knowcommand)
                {
                    if (errormessage == null)
                    {
                        AdvConsole.WriteLine(ConsoleColor.Green, "Success!");
                    }
                    else
                    {
                        ShowError(errormessage.Value);
                    }
                }
                else
                {
                    ShowError(String.Format(
                        "Unknown command: {0}"
                        , command));
                }
            }
        }
    }
}
