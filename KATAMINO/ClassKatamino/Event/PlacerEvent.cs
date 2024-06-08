namespace ClassKatamino.Event
{
    /// <summary>
    /// Fournit des données pour l'événement de notification de placement d'une pièce.
    /// </summary>
    public class PlacerNotifiedEventArgs : EventArgs
    {
        /// <summary>
        /// Obtient la pièce qui a été tournée.
        /// </summary>
        public int piece {  get; set; }
        /// <summary>
        /// Obtient la coordonnée x de la pièce qui a été tournée.
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// Obtient la coordonée y de la pièce qui a été tournée.
        /// </summary>
        public int y { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="PlacerNotifiedEventArgs"/>.
        /// </summary>
        /// <param name="piece">La pièce qui a été tournée.</param>
        /// <param name="x">La coordonnée x de la pièce qui a été tournée.</param>
        /// <param name="y">La coordonnée y de la pièce qui a été tournée.</param>
        public PlacerNotifiedEventArgs(int piece, int x, int y)
        {
            this.piece = piece;
            this.x = x;
            this.y = y;
        }
    }
}