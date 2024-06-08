using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKatamino
{
    public interface ISerialiser
    {
        void Serialize(Jeu game, string directoryPath, string fileName);
        Jeu Deserialize(string directoryPath, string fileName);
    }

}
