using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using KMT;

namespace zkmtt
{
    class Encode
    {
        //Returns error message, or null if there is none
        public static StringValue Run(string[] args)
        {
            try
            {
                Ex exx = new Ex();
                KmtXml kmtxml = new KmtXml();

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

                string destination;
                #region Destination File
                if (args.Length < 2)
                {
                    string sourcedirectory = Path.GetDirectoryName(Path.GetFullPath(source));
                    string sourcefilenamenoext = Path.GetFileNameWithoutExtension(source);
                    destination = sourcedirectory + "\\" + sourcefilenamenoext + ".kmt";
                }
                else
                {
                    destination = args[1];
                }
                if (File.Exists(destination))
                {
                    return new StringValue(
                        "\"{0}\" already exists"
                        , destination);
                }
                #endregion

                XmlDocument xmldoc = new XmlDocument();
                #region Open Xml
                try
                {
                    xmldoc.Load(source);
                }
                catch (Exception ex)
                {
                    return new StringValue(ex.Message);
                }
                #endregion
                
                Kmt kmt = new Kmt();
                #region Create KMT
                XmlNodeList xml_mainelements = xmldoc.SelectNodes("KMT");
                if (xml_mainelements.Count == 0)
                {
                    return new StringValue(
                        "\"KMT\" node does not exist"
                        );
                }
                XmlNode xml_mainelement = xml_mainelements.Item(0);
                XmlNodeList entries = xml_mainelement.ChildNodes;
                foreach (XmlNode entry in entries)
                {
                    if (entry.Name != "entry")
                    {
                        return new StringValue(
                            "Unexpected node in KMT: {0}",
                            entry.Name);
                    }
                    KmtEntry newentry;
                    StringValue errmess = kmtxml.TryReadEntry(entry, out newentry);
                    if (errmess != null)
                    {
                        return new StringValue(errmess.Value);
                    }
                    kmt.Entries.Add(newentry);
                }
                #endregion

                #region Save KMT
                kmt.Save(destination);
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
