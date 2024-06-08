namespace ClassKatamino.Event
{
    /// <summary>
    /// Fournit des données pour l'événement de notification d'enlever d'une pièce.
    /// </summary>
    public class EnleverNotifiedEventArgs : EventArgs
    {
        /// <summary>
        /// Obtient la pièce qui a été tournée.
        /// </summary>
        public int piece { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="EnleverNotifiedEventArgs"/>.
        /// </summary>
        /// <param name="piece">La pièce qui a été tournée.</param>
        public EnleverNotifiedEventArgs(int l) { piece = l; }
    }
}