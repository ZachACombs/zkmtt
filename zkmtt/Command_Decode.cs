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
    class Decode
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
                    destination = sourcedirectory + "\\" + sourcefilenamenoext + ".xml";
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

                XmlDocument xmldoc = new XmlDocument();
                #region Create Xml
                XmlElement xml_mainelement = xmldoc.CreateElement("KMT");
                for (int n = 0; n < kmt.Entries.Count; n += 1)
                {
                    KmtEntry entry = kmt.Entries[n];
                    xml_mainelement.AppendChild(
                        kmtxml.MakeEntry(xmldoc, entry)
                        );
                }
                xmldoc.AppendChild(xml_mainelement);
                #endregion

                #region Save XML
                xmldoc.Save(destination);
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
