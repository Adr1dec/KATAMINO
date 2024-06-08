using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKatamino.Event
{
    /// <summary>
    /// Fournit des données pour l'événement de notification de rotation miroir d'une pièce.
    /// </summary>
    public class MirorNotifiedEventArgs : EventArgs
    {
        /// <summary>
        /// Obtient la pièce qui a été tournée.
        /// </summary>
        public Piece P { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MirorNotifiedEventArgs"/>.
        /// </summary>
        /// <param name="P">La pièce qui a été tournée.</param>
        public MirorNotifiedEventArgs(Piece piece) { P = piece; }
    }
}
