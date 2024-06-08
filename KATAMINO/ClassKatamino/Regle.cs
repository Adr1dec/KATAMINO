using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKatamino
{
    /// <summary>
    /// Représente les règles du jeu Katamino.
    /// </summary>
    public class Regle
    {
        /// <summary>
        /// Obtient la liste des petits chelems.
        /// </summary>
        public Dictionary<char, List<int>> ListPetitChelem
        {
            get => listPetitChelem;
        }
        private Dictionary<char, List<int>> listPetitChelem;
        /// <summary>
        /// Obtient la liste des grands chelems.
        /// </summary>
        public Dictionary<char, List<int>> ListGrandChelem
        {
            get => listGrandChelem;
        }
        private Dictionary<char, List<int>> listGrandChelem;
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Regle"/> et définit les petits et grands chelems.
        /// </summary>
        public Regle()
        {
            listPetitChelem = new Dictionary<char, List<int>>
            {
                { 'a', new List<int> { 2, 3, 10, 6, 11, 8, 5, 4 } },
                { 'b', new List<int> { 4, 6, 7, 2, 8, 3, 10, 11 } },
                { 'c', new List<int> { 2, 5, 6, 3, 4, 7, 8, 9 } },
                { 'd', new List<int> { 3, 6, 7, 4, 5, 9, 11, 10 } },
                { 'e', new List<int>() { 2, 4, 5, 8, 7, 10, 3, 4, 2, 11 } },
                { 'f', new List<int>() { 6, 7, 9, 3, 10, 4, 2, 11 } },
                { 'g', new List<int>() { 2, 5, 6, 8, 3, 11, 4, 9 } },
            };

            listGrandChelem = new Dictionary<char, List<int>>
            {
                { 'a', new List<int> { 2, 6, 7, 9, 11, 3, 8, 4, 5 } },
                { 'b', new List<int> { 3, 4, 6, 7, 8, 5, 10, 2, 9 } },
                { 'c', new List<int> { 2, 3, 5, 10, 11, 8, 9, 7, 6 } },
                { 'd', new List<int> { 4, 5, 6, 7, 9, 11, 2, 8, 10 } },
                { 'e', new List<int> { 2, 3, 4, 6, 11, 10, 5, 9, 7 } },
                { 'f', new List<int> { 2, 6, 7, 3, 8, 10, 9, 4, 3 } },
                { 'g', new List<int> { 2, 5, 6, 7, 11, 4, 3, 10, 8 } },
                { 'h', new List<int> { 2, 4, 6, 10, 11, 8, 3, 9, 5 } },
                { 'i', new List<int> { 2, 3, 5, 7, 8, 9, 11, 4, 10 } },
                { 'j', new List<int> { 2, 3, 4, 7, 11, 3, 7, 10, 4 } },
                { 'k', new List<int> { 2, 3, 4, 7, 11, 9, 6, 5, 8 } },
                { 'l', new List<int> { 3, 5, 6, 8, 11, 4, 9, 10, 7 } },
                { 'm', new List<int> { 2, 3, 5, 6, 9, 7, 10, 8, 11 } },
                { 'n', new List<int> { 2, 3, 6, 8, 11, 4, 7, 5, 10 } },
                { 'o', new List<int> { 2, 3, 4, 7, 9, 10, 8, 6 } },
                { 'p', new List<int> { 2, 4, 5, 6, 8, 9, 10, 3 } },
                { 'q', new List<int> { 2, 3, 6, 8, 9, 11, 5, 7 } },
                { 'r', new List<int> { 2, 4, 5, 6, 7, 10, 11, 9 } },
                { 's', new List<int> { 3, 5, 6, 7, 10, 11, 2, 8 } },
                { 't', new List<int> { 2, 3, 5, 8, 9, 10, 6, 11 } },
                { 'u', new List<int> { 2, 4, 5, 6, 7, 9, 8, 10 } },
                { 'v', new List<int> { 4, 5, 6, 7, 8, 10, 9, 3 } },
                { 'w', new List<int> { 4, 5, 6, 7, 8, 9, 3, 11 } },
                { 'x', new List<int> { 3, 4, 5, 6, 10, 11, 8, 7 } },
                { 'y', new List<int> { 2, 4, 7, 8, 9, 10, 5, 3 } },
                { 'z', new List<int> { 2, 3, 6, 9, 10, 11, 7, 8 } },
            };


        }
        /// <summary>
        /// Vérifie si le niveau est gagné.
        /// </summary>
        /// <param name="plateau">Le plateau de jeu.</param>
        /// <param name="etape">L'étape actuelle du jeu.</param>
        /// <returns>Retourne <c>true</c> si le niveau est gagné; sinon, <c>false</c>.</returns>
        public bool CheckWinNiv(ObservableCollection<Case> plateau, int etape)
        {
            ObservableCollection<Case> platAnalyse = new ObservableCollection<Case>();
            if (plateau == null)
            {
                Console.WriteLine("plateau Null");
                return false;
            }
            foreach (Case c in plateau)
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < etape; y++)
                    {
                        if (c.X < etape)
                        {
                            platAnalyse.Add(c);
                        }


                    }

                }
            }
            foreach (Case c in platAnalyse)
            {
                if (c.Val == "0")
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Vérifie si une pièce est correctement placée sur le plateau.
        /// </summary>
        /// <param name="plateau">Le plateau de jeu.</param>
        /// <param name="p">La pièce à placer.</param>
        /// <param name="xcoord">La coordonnée X de placement.</param>
        /// <param name="ycoord">La coordonnée Y de placement.</param>
        /// <param name="etape">L'étape actuelle du jeu.</param>
        /// <returns>Retourne <c>true</c> si la pièce est bien placée; sinon, <c>false</c>.</returns>
        public bool checkBonPlacer(ObservableCollection<Case> plateau, Piece p, int xcoord, int ycoord, int etape)
        {
            // Vérifier si la pièce dépasse les limites du plateau
            foreach (Case cPiece in p.LPiece)
            {
                Case tempCase = new Case();
                tempCase.X = xcoord + cPiece.X;
                tempCase.Y = ycoord + cPiece.Y;

                foreach (Case cPlateau in plateau)
                {
                    if (cPlateau.X == tempCase.X && cPlateau.Y == tempCase.Y)
                    {
                        if (cPlateau.Val != "0") // Collision avec une autre pièce déjà placée
                        {
                            return false;
                        }
                        if (cPlateau.X >= etape)
                        {
                            return false;// sup à etape 
                        }
                    }
                }

            }
            foreach (Case cPiece in p.LPiece)
            {

                Case tempCase = new Case();
                tempCase.X = xcoord + cPiece.X;
                tempCase.Y = ycoord + cPiece.Y;

                if (tempCase.X < 0 || tempCase.X >= 12 || tempCase.Y < 0 || tempCase.Y >= 5)
                {
                    return false; // La pièce dépasse les limites du plateau
                }


            }

            foreach (Case c in plateau)
            {
                if (c.Val == p.Num.ToString())
                {
                    return false;
                }

            }
            foreach (Case cPiece in p.LPiece)
            {
                Case tempCase = new Case();
                tempCase.X = xcoord + cPiece.X;
                tempCase.Y = ycoord + cPiece.Y;

                foreach (Case cPlateau in plateau)
                {
                    if (cPlateau.X == tempCase.X && cPlateau.Y == tempCase.Y)
                    {
                        if (cPlateau.Val != "0") // Collision avec une autre pièce déjà placée
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }
        /// <summary>
        /// Met à jour le plateau avec une réglette pour l'étape donnée.
        /// </summary>
        /// <param name="plateau">Le plateau de jeu.</param>
        /// <param name="etape">L'étape actuelle du jeu.</param>
        /// <returns>Le plateau mis à jour.</returns>
        public ObservableCollection<Case> reglette(ObservableCollection<Case> plateau, int etape)
        {
            foreach (Case c in plateau)
            {
                if (c.X == etape)
                {
                    c.Val = "/";
                }
            }
            return plateau;

        }

        public bool checkRotation(Piece p, double angle)
        {
            List<Case> ListPiecePossible = new List<Case>();
            if (angle != 0 && angle != 90 && angle != 180 && angle != 270 && angle != 360)
            {
                return false;
            }


            return true;
        }

    }
}
