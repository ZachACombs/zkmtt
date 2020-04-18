using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using KMT;

namespace zkmtt
{
    class KmtXml
    {
        Ex exx;

        bool trytoparse(string s, out ulong result)
        {
            bool success;
            ulong value;
            if (s.IndexOf("0x") == 0 | s.IndexOf("0X") == 0)
            {
                bool kill = false;
                string ss = s.Substring(2).ToLower();
                int n = 0;
                ulong newvalue = 0;
                while (n < ss.Length & (!kill))
                {
                    int pos = ss.Length - 1 - n;
                    string cc = ss.Substring(pos, 1);
                    if (cc == "0") newvalue += 00 * (ulong)Math.Pow(16d, n);
                    else if (cc == "1") newvalue += 01 * (ulong)Math.Pow(16d, n);
                    else if (cc == "2") newvalue += 02 * (ulong)Math.Pow(16d, n);
                    else if (cc == "3") newvalue += 03 * (ulong)Math.Pow(16d, n);
                    else if (cc == "4") newvalue += 04 * (ulong)Math.Pow(16d, n);
                    else if (cc == "5") newvalue += 05 * (ulong)Math.Pow(16d, n);
                    else if (cc == "6") newvalue += 06 * (ulong)Math.Pow(16d, n);
                    else if (cc == "7") newvalue += 07 * (ulong)Math.Pow(16d, n);
                    else if (cc == "8") newvalue += 08 * (ulong)Math.Pow(16d, n);
                    else if (cc == "9") newvalue += 09 * (ulong)Math.Pow(16d, n);
                    else if (cc == "a") newvalue += 10 * (ulong)Math.Pow(16d, n);
                    else if (cc == "b") newvalue += 11 * (ulong)Math.Pow(16d, n);
                    else if (cc == "c") newvalue += 12 * (ulong)Math.Pow(16d, n);
                    else if (cc == "d") newvalue += 13 * (ulong)Math.Pow(16d, n);
                    else if (cc == "e") newvalue += 14 * (ulong)Math.Pow(16d, n);
                    else if (cc == "f") newvalue += 15 * (ulong)Math.Pow(16d, n);
                    else kill = true;
                    n += 1;
                }
                success = !kill;
                value = newvalue;
            }
            else
            {
                success = ulong.TryParse(s, out value);
            }
            result = value;
            return success;
        }
        bool TryParse_Byte(string s, out byte result)
        {
            ulong value;
            if (trytoparse(s, out value))
            {
                if (value <= (ulong)byte.MaxValue)
                {
                    result = (byte)value;
                    return true;
                }
            }
            result = 0;
            return false;
        }
        bool TryParse_UInt16(string s, out ushort result)
        {
            ulong value;
            if (trytoparse(s, out value))
            {
                if (value <= (ulong)ushort.MaxValue)
                {
                    result = (ushort)value;
                    return true;
                }
            }
            result = 0;
            return false;
        }
        bool TryParse_UInt32(string s, out uint result)
        {
            ulong value;
            if (trytoparse(s, out value))
            {
                if (value <= (ulong)uint.MaxValue)
                {
                    result = (uint)value;
                    return true;
                }
            }
            result = 0;
            return false;
        }

        string name_filenumber;
        string name_gamemode;
        string name_course;
        string name_character;
        string name_vehicle;
        string name_engineclass;
        string name_timelimit;
        string name_controllerrestriction;
        string name_score;
        string name_cameramode;
        string name_minimap;
        string name_cannonflag;
        string name_cpus;
        string name_cpu;
        string name_cpu_character;
        string name_cpu_vehicle;

        public KmtXml()
        {
            exx = new Ex();

            name_filenumber = "filenumber";
            name_gamemode = "gamemode";
            name_course = "course";
            name_character = "character";
            name_vehicle = "vehicle";
            name_engineclass = "engineclass";
            name_timelimit = "timelimit";
            name_controllerrestriction = "controllerrestriction";
            name_score = "score";
            name_cameramode = "cameramode";
            name_minimap = "minimap";
            name_cannonflag = "cannonflag";
            name_cpus = "cpus";
            name_cpu = "cpu";
            name_cpu_character = "character";
            name_cpu_vehicle = "vehicle";
        }

        public XmlElement MakeEntry(XmlDocument xmldocument, KmtEntry entry)
        {
            XmlElement newelement(string name, string innertext)
            {
                XmlElement element = xmldocument.CreateElement(name);
                element.InnerText = innertext;
                return element;
            }

            XmlElement newentry = xmldocument.CreateElement("entry");
            newentry.AppendChild(newelement(name_filenumber, 
                entry.MissionRunFile.ToString()));
            newentry.AppendChild(newelement(name_gamemode,
                exx.GameMode(entry.GameMode)));
            newentry.AppendChild(newelement(name_course,
                exx.Course(entry.Course)));
            newentry.AppendChild(newelement(name_character,
                exx.Character(entry.Character)));
            newentry.AppendChild(newelement(name_vehicle,
                exx.Vehicle(entry.Vehicle)));
            newentry.AppendChild(newelement(name_engineclass,
                exx.EngineClass(entry.EngineClass)));
            newentry.AppendChild(newelement(name_timelimit, 
                entry.TimeLimit.ToString()));
            newentry.AppendChild(newelement(name_controllerrestriction, 
                entry.ControllerRestriction.ToString()));
            newentry.AppendChild(newelement(name_score, 
                entry.Score.ToString()));
            newentry.AppendChild(newelement(name_cameramode,
                exx.CameraMode(entry.CameraMode)));
            newentry.AppendChild(newelement(name_minimap, 
                entry.Minimap.ToString()));
            newentry.AppendChild(newelement(name_cannonflag, 
                entry.CannonFlag.ToString()));

            XmlElement element_cpus = xmldocument.CreateElement(name_cpus);
            for (int n = 0; n < entry.CPUs.Count; n += 1)
            {
                KmtCPUEntry cpuentry = entry.CPUs[n];
                XmlElement element_cpu = xmldocument.CreateElement(name_cpu);
                element_cpu.AppendChild(newelement(name_cpu_character,
                    exx.Character(cpuentry.Character)));
                element_cpu.AppendChild(newelement(name_cpu_vehicle,
                    exx.Vehicle(cpuentry.Vehicle)));
                element_cpus.AppendChild(element_cpu);
            }
            newentry.AppendChild(element_cpus);

            return newentry;
        }

        //Returns error message or null if there is none
        public StringValue TryReadEntry(XmlNode entry, out KmtEntry newentry)
        {
            StringValue ReturnInvalidValue(XmlNode node)
            {
                return new StringValue(
                    "Invalid {0} value: \"{1}\""
                    , node.Name, node.InnerText);
            }

            newentry = null;

            #region Default Region Values
            KmtEntry nentry = new KmtEntry();
            nentry.MissionRunFile = 0x0000;
            nentry.GameMode = KmtGameMode.Miniturbo;
            nentry.Course = KmtCourse.MarioCircuit;
            nentry.Character = KmtCharacter.Mario;
            nentry.Vehicle = KmtVehicle.StandardKartM;
            nentry.EngineClass = KmtEngineClass.e50cc;
            nentry.TimeLimit = 60;
            nentry.ControllerRestriction = 0;
            nentry.Score = 10;
            nentry.Minimap = 0;
            nentry.CannonFlag = 0;
            #endregion

            #region Define Entry
            Dictionary<KmtCharacter, KmtVehicle> cpu_defaults =
                new Dictionary<KmtCharacter, KmtVehicle>();
            cpu_defaults.Add(KmtCharacter.Luigi, KmtVehicle.StandardKartM);
            cpu_defaults.Add(KmtCharacter.Peach, KmtVehicle.StandardKartM);
            cpu_defaults.Add(KmtCharacter.Daisy, KmtVehicle.StandardKartM);
            cpu_defaults.Add(KmtCharacter.BabyMario, KmtVehicle.StandardKartS);
            cpu_defaults.Add(KmtCharacter.BabyLuigi, KmtVehicle.StandardKartS);
            cpu_defaults.Add(KmtCharacter.BabyPeach, KmtVehicle.StandardKartS);
            cpu_defaults.Add(KmtCharacter.BabyDaisy, KmtVehicle.StandardKartS);
            cpu_defaults.Add(KmtCharacter.Wario, KmtVehicle.StandardKartL);
            cpu_defaults.Add(KmtCharacter.Waluigi, KmtVehicle.StandardKartL);
            cpu_defaults.Add(KmtCharacter.DonkeyKong, KmtVehicle.StandardKartL);
            cpu_defaults.Add(KmtCharacter.Bowser, KmtVehicle.StandardKartL);
            KmtCharacter[] cpu_default_chr = cpu_defaults.Keys.ToArray();
            KmtVehicle[] cpu_default_veh = cpu_defaults.Values.ToArray();
            bool TryParse(string s, 
                Array keys, StringAndList[] values,
                Type type,
                out object result)
            {
                int IndexIn_GameMode(StringAndList[] valuess, string ss)
                {
                    int indexx = -1;
                    int n = 0;
                    string str = ss.ToLower();
                    while (n < valuess.Length & indexx == -1)
                    {
                        StringAndList valuee = valuess[n];
                        if (str == valuee.Str_Simple)
                        {
                            indexx = n;
                        }
                        else if (valuee.Arr != null)
                        {
                            int indd = valuee.Arr.IndexOf(str);
                            if (indd >= 0)
                            {
                                indexx = n;
                            }
                        }
                        n += 1;
                    }
                    return indexx;
                }

                Type enumtype = null;
                uint value;
                bool validnumber = false;
                if (TryParse_UInt32(s, out value))
                {
                    if (
                        type == typeof(KmtGameMode) |
                        type == typeof(KmtCameraMode)
                        )
                    {
                        enumtype = typeof(ushort);
                        if (value <= ((uint)ushort.MaxValue))
                        {
                            validnumber = true;

                            if (type == typeof(KmtCameraMode) & value == 0) value = 3;
                        }
                    }
                    else if (
                        type == typeof(KmtCourse) |
                        type == typeof(KmtCharacter) |
                        type == typeof(KmtVehicle) |
                        type == typeof(KmtEngineClass)
                        )
                    {
                        enumtype = typeof(byte);
                        if (value <= ((uint)byte.MaxValue))
                        {
                            validnumber = true;
                        }
                    }
                }

                int index = IndexIn_GameMode(values, s);
                if (index >= 0)
                {
                    result = keys.GetValue(index);
                    return true;
                }
                else if (validnumber)
                {
                    object sss = 1;
                    bool isdefined = false;
                    result = null;
                    if (enumtype==typeof(ushort))
                    {
                        if (Enum.IsDefined(type, (ushort)value))
                        {
                            result = (ushort)value;
                            isdefined = true;
                        }
                    }
                    else if (enumtype == typeof(byte))
                    {
                        if (Enum.IsDefined(type, (byte)value))
                        {
                            result = (byte)value;
                            isdefined = true;
                        }
                    }
                    if (isdefined)
                    {
                        return true;
                    }
                }

                result = null;
                return false;
            }
            XmlNodeList nodelist = entry.ChildNodes;
            foreach (XmlNode node in nodelist)
            {
                if (node.Name == name_filenumber)
                {
                    ushort value;
                    if (!TryParse_UInt16(node.InnerText, out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.MissionRunFile = value;
                }
                else if (node.Name == name_timelimit)
                {
                    ushort value;
                    if (!TryParse_UInt16(node.InnerText, out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.TimeLimit = value;
                }
                else if (node.Name == name_controllerrestriction)
                {
                    byte value;
                    if (!TryParse_Byte(node.InnerText, out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.ControllerRestriction = value;
                }
                else if (node.Name == name_score)
                {
                    uint value;
                    if (!TryParse_UInt32(node.InnerText, out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.Score = value;
                }
                else if (node.Name == name_minimap)
                {
                    ushort value;
                    if (!TryParse_UInt16(node.InnerText, out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.Minimap = value;
                }
                else if (node.Name == name_cannonflag)
                {
                    ushort value;
                    if (!TryParse_UInt16(node.InnerText, out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.CannonFlag = value;
                }
                else if (node.Name == name_gamemode)
                {
                    KmtGameMode[] keys = exx.DictGameMode.Keys.ToArray();
                    StringAndList[] values = exx.DictGameMode.Values.ToArray();
                    object value;
                    if (!TryParse(node.InnerText, keys, values,
                        typeof(KmtGameMode), out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.GameMode = (KmtGameMode)value;
                }
                else if (node.Name == name_course)
                {
                    KmtCourse[] keys = exx.DictCourse.Keys.ToArray();
                    StringAndList[] values = exx.DictCourse.Values.ToArray();
                    object value;
                    if (!TryParse(node.InnerText, keys, values,
                        typeof(KmtCourse), out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.Course = (KmtCourse)value;
                }
                else if (node.Name == name_character)
                {
                    KmtCharacter[] keys = exx.DictCharacter.Keys.ToArray();
                    StringAndList[] values = exx.DictCharacter.Values.ToArray();
                    object value;
                    if (!TryParse(node.InnerText, keys, values,
                        typeof(KmtCharacter), out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.Character = (KmtCharacter)value;
                }
                else if (node.Name == name_vehicle)
                {
                    KmtVehicle[] keys = exx.DictVehicle.Keys.ToArray();
                    StringAndList[] values = exx.DictVehicle.Values.ToArray();
                    object value;
                    if (!TryParse(node.InnerText, keys, values,
                        typeof(KmtVehicle), out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.Vehicle = (KmtVehicle)value;
                }
                else if (node.Name == name_engineclass)
                {
                    KmtEngineClass[] keys = exx.DictEngineClass.Keys.ToArray();
                    StringAndList[] values = exx.DictEngineClass.Values.ToArray();
                    object value;
                    if (!TryParse(node.InnerText, keys, values,
                        typeof(KmtEngineClass), out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.EngineClass = (KmtEngineClass)value;
                }
                else if (node.Name == name_cameramode)
                {
                    KmtCameraMode[] keys = exx.DictCameraMode.Keys.ToArray();
                    StringAndList[] values = exx.DictCameraMode.Values.ToArray();
                    object value;
                    if (!TryParse(node.InnerText, keys, values,
                        typeof(KmtCameraMode), out value))
                    {
                        return ReturnInvalidValue(node);
                    }
                    nentry.CameraMode = (KmtCameraMode)value;
                }
                else if (node.Name == name_cpus)
                {
                    XmlNodeList nodelist_cpus = node.ChildNodes;
                    foreach (XmlNode node_cpus in nodelist_cpus)
                    {
                        if (node_cpus.Name == name_cpu)
                        {
                            if (nentry.CPUs.Count>=KmtCPUEntryList.MaxCount)
                            {
                                return new StringValue(
                                    "You can only have up to 11 CPUs"
                                    );
                            }
                            KmtCPUEntry newcpu = new KmtCPUEntry();
                            newcpu.Character = cpu_default_chr[nentry.CPUs.Count];
                            newcpu.Vehicle = cpu_default_veh[nentry.CPUs.Count];
                            XmlNodeList nodelist_cpu = node_cpus.ChildNodes;
                            foreach (XmlNode node_cpu in nodelist_cpu)
                            {
                                if (node_cpu.Name == name_cpu_character)
                                {
                                    KmtCharacter[] keys = exx.DictCharacter.Keys.ToArray();
                                    StringAndList[] values = exx.DictCharacter.Values.ToArray();
                                    object value;
                                    if (!TryParse(node_cpu.InnerText, keys, values,
                                        typeof(KmtCharacter), out value))
                                    {
                                        return ReturnInvalidValue(node);
                                    }
                                    newcpu.Character = (KmtCharacter)value;
                                }
                                else if (node_cpu.Name == name_cpu_vehicle)
                                {
                                    KmtVehicle[] keys = exx.DictVehicle.Keys.ToArray();
                                    StringAndList[] values = exx.DictVehicle.Values.ToArray();
                                    object value;
                                    if (!TryParse(node_cpu.InnerText, keys, values,
                                        typeof(KmtVehicle), out value))
                                    {
                                        return ReturnInvalidValue(node);
                                    }
                                    newcpu.Vehicle = (KmtVehicle)value;
                                }
                                else
                                {
                                    return new StringValue(
                                        "Unknown node in {0}: {1}"
                                        , name_cpu
                                        , node_cpu.Name);
                                }
                            }
                            nentry.CPUs.Add(newcpu);
                        }
                        else
                        {
                            return new StringValue(
                                "Unknown node in {0}: {1}"
                                , name_cpus
                                , node_cpus.Name);
                        }
                    }
                }
                else
                {
                    return new StringValue(
                        "Unknown node in entry: {0}"
                        , node.Name);
                }
            }
            #endregion

            newentry = nentry;
            return null;
        }
    }
}
