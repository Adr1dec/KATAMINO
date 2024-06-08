using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace ClassKatamino
{
    public class SerialiserXML : ISerialiser
    {
        public void Serialize(Jeu game, string directoryPath, string fileName)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string xmlFilePath = Path.Combine(directoryPath, fileName);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Jeu));

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
            };

            using (TextWriter textWriter = new StreamWriter(xmlFilePath))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    xmlSerializer.Serialize(xmlWriter, game);
                }
            }

        }

        public Jeu Deserialize(string directoryPath, string fileName)
        {
            string xmlFilePath = Path.Combine(directoryPath, fileName);

            if (!File.Exists(xmlFilePath))
            {
                throw new FileNotFoundException($"The file '{xmlFilePath}' does not exist.");
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Jeu));

            using (StreamReader streamReader = new StreamReader(xmlFilePath))
            {
                return (Jeu)xmlSerializer.Deserialize(streamReader);
            }
        }
    }

}
