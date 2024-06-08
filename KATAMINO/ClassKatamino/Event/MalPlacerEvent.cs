namespace ClassKatamino.Event
{
    /// <summary>
    /// Fournit des données pour l'événement de notification de mauvais placement d'une pièce.
    /// </summary>
    public class MalPlacerNotifiedEventArgs : EventArgs
    {
        /// <summary>
        /// Obtient la pièce qui a été tournée.
        /// </summary>
        public int piece {  get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MalPlacerNotifiedEventArgs"/>.
        /// </summary>
        /// <param name="piece">La pièce qui a été tournée.</param>
        public MalPlacerNotifiedEventArgs(int piece)
        {
            this.piece = piece;
        }

    }
}