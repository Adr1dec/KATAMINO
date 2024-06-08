using System;

namespace ClassKatamino.Event
{
    /// <summary>
    /// Fournit des données pour l'événement de notification de rotation d'une pièce.
    /// </summary>
    public class RotationNotifiedEventArgs : EventArgs
    {
        /// <summary>
        /// Obtient la pièce qui a été tournée.
        /// </summary>
        public Piece P { get; set; }

        /// <summary>
        /// Obtient le degré de rotation appliqué à la pièce.
        /// </summary>
        public int d {  get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RotationNotifiedEventArgs"/>.
        /// </summary>
        /// <param name="p">La pièce qui a été tournée.</param>
        /// <param name="degre">Le degré de rotation appliqué à la pièce.</param>
        public RotationNotifiedEventArgs(Piece l, int degre) { P = l; d = degre; }

    }
}