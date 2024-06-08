using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClassKatamino
{
    /// <summary>
    ///  represente une case avec x pour abcisse, y pour ordonnée et une valeur
    /// </summary>
    public class Case
    {
        private int x;
        private int y;
        private string val;

        /// <summary>
        /// Obtient ou définit l'abscisse (x) de la case.
        /// </summary
        public int X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged();
                }
            }
        }
        
        /// <summary>
        /// Obtient ou définit l'ordonnée (y) de la case.
        /// </summary
        public int Y
        {
            get { return y; }
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Obtient ou définit la valeur de la case.
        /// </summary>
        public string Val
        {
            get { return val; }
            set
            {
                if (this.val != value)
                {
                    this.val = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Case"/>.
        /// </summary>
        ///

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Case"/>.
        /// </summary>
        public Case()
        {
        }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Case"/> avec les coordonnées spécifiées et une valeur.
        /// </summary>
        /// <param name="x">L'abscisse (x) de la case.</param>
        /// <param name="y">L'ordonnée (y) de la case.</param>
        /// <param name="val">La valeur de la case.</param>
        public Case(int x, int y, string val)
        {
            this.x = x;
            this.y = y;
            this.val = val;
        }
    }
}