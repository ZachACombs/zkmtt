using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KMT;

namespace zkmtt
{
    class Dump
    {
        //Returns error message, or null if there is none
        public static StringValue Run(string[] args)
        {
            try
            {
                Ex exx = new Ex();

                #region Argument Count
                if (args.Length < 1)
                {
                    return new StringValue("You must specify a source file");
                }
                #endregion

                string source = args[0];
                #region Source File
                if (!File.Exists(source))
                {
                    return new StringValue(
                        "\"{0}\" does not exist"
                        , source);
                }
                #endregion

                //The dump is only written to a file if the user specifies one
                StringValue destination;
                #region Destination File
                if (args.Length < 2)
                {
                    destination = null;
                }
                else
                {
                    destination = new StringValue(args[1]);
                    if (File.Exists(destination.Value))
                    {
                        return new StringValue(
                            "\"{0}\" already exists"
                            , destination.Value);
                    }
                }
                #endregion

                Kmt kmt = new Kmt();
                #region Open KMT
                try
                {
                    kmt.Load(source);
                }
                catch (Exception ex)
                {
                    return new StringValue(ex.Message);
                }
                #endregion

                string dump = "";
                #region Extract Contents
                string mrszs(ushort x)
                {
                    if (x < 100)
                    {
                        return x.ToString("00");
                    }
                    else
                    {
                        return x.ToString();
                    }
                }
                dump = dump + String.Format(
                    "{0} Entries \n" +
                    "\n",
                    kmt.Entries.Count);
                string addgap(string s)
                {
                    string mask = "                            ";
                    if (s.Length >= 28) return s.Substring(0, mask.Length);
                    return s + mask.Substring(s.Length);
                }
                for (int n = 0; n < kmt.Entries.Count; n += 1)
                {
                    KmtEntry entry = kmt.Entries[n];
                    dump = dump + String.Format(
                        "Entry:\n" +
                        addgap("Mission Run File") + "mr{0}.szs\n" +
                        addgap("Game Mode") + "{1}\n" +
                        addgap("Course") + "{2}\n" +
                        addgap("Character") + "{3}\n" +
                        addgap("Vehicle") + "{4}\n" +
                        addgap("Engine Class") + "{5}\n" +
                        addgap("Time Limit") + "{6}\n" +
                        addgap("Controller Restriction") + "{7}\n" +
                        addgap("Score Required") + "{8}\n" +
                        addgap("Camera Mode") + "{9}\n" +
                        addgap("Minimap Object") + "{10}\n" +
                        addgap("Cannon Flag") + "{11}\n",
                        mrszs(entry.MissionRunFile),
                        exx.GameMode(entry.GameMode),
                        exx.Course(entry.Course),
                        exx.Character(entry.Character),
                        exx.Vehicle(entry.Vehicle),
                        exx.EngineClass(entry.EngineClass),
                        entry.TimeLimit,
                        entry.ControllerRestriction,
                        entry.Score,
                        exx.CameraMode(entry.CameraMode),
                        entry.Minimap,
                        entry.CannonFlag
                        );

                    for (int m = 0; m < entry.CPUs.Count; m += 1)
                    {
                        KmtCPUEntry cpuentry = entry.CPUs[m];
                        dump = dump + String.Format(
                        addgap("CPU " + (m + 1).ToString() + " Character") + "{0}\n" +
                        addgap("CPU " + (m + 1).ToString() + " Vehicle") + "{1}\n",
                        exx.Character(cpuentry.Character),
                        exx.Vehicle(cpuentry.Vehicle)
                        );
                    }

                    dump = dump + "\n";
                }
                #endregion
                
                #region Dump
                Console.WriteLine(dump);
                if (destination != null)
                {
                    File.WriteAllText(destination.Value, dump);
                }
                #endregion
            }
            catch (Exception ex)
            {
                return Ex.ExceptionMessage(ex);
            }

            return null;
        }
    }
}
