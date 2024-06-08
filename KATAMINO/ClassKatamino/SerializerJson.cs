using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassKatamino
{
    public class SerializerJson : ISerialiser
    {
        public void Serialize(Jeu game, string directoryPath, string fileName)
        {
            string jsonFilePath = Path.Combine(directoryPath, fileName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string jsonString = JsonSerializer.Serialize(game, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(jsonFilePath, jsonString);
        }
        public Jeu Deserialize(string directoryPath, string fileName)
        {
            string jsonFilePath = Path.Combine(directoryPath, fileName);

            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException($"The file '{jsonFilePath}' does not exist.");
            }

            string jsonString = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<Jeu>(jsonString);
        }

    }

}
