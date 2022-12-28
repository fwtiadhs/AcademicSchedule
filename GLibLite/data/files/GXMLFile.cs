using System;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Glib.data.files
{
    // ===================================================================================================
    public class GXMLFile
    {
        public string FileName { get; set; }

        // --------------------------------------------------------------------------------
        public GXMLFile(string p_sFileName)
        {
            this.FileName = p_sFileName;
        }
        // --------------------------------------------------------------------------------
        public void SaveToFile(object p_oData)
        {
            using (StreamWriter oWriter = new StreamWriter(this.FileName))
            {
                XmlSerializer oXML = new XmlSerializer(p_oData.GetType());
                oXML.Serialize(oWriter, p_oData);
            }
        }
        // --------------------------------------------------------------------------------
        public object LoadFromFile(Type p_oClassType)
        {
            object oResult;
            if (File.Exists(this.FileName))
            { 
                using (StreamReader oReader = new StreamReader(this.FileName, Encoding.UTF8))
                {
                    XmlSerializer oXML = new XmlSerializer(p_oClassType);
                    oResult = oXML.Deserialize(oReader);
                }
            }
            else
                throw new Exception(String.Format("The XML file '{0}' is not found ", this.FileName));

            return oResult;
        }
        // --------------------------------------------------------------------------------        
    }
    // ===================================================================================================
}
