using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic;
using System.Timers;
using Timer = System.Timers.Timer;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ClassKatamino.Event;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;


namespace ClassKatamino
{
    [DataContract(Name = "jeu")]
    public class Jeu : INotifyPropertyChanged
    {

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Piece> piecesList = new ObservableCollection<Piece>();
        public ObservableCollection<Piece> PiecesList
        {
            get { return piecesList; }
            set
            {
                if (piecesList != value)
                {
                    piecesList = value;
                    OnPropertyChanged(nameof(PiecesList));
                }
            }
        }

        public bool Win(ObservableCollection<Case> Plateau, int etape)
        {
            return regle.CheckWinNiv(Plateau, etape);
        }

       


        public void ChargePlateauPersistance(char nivAVerif,int chelemAVerif,out int etape,out int etapeMax,out Jeu jeu)
        {
            string fileNameJson = "jeu.json";
            SerializerJson serializer = new SerializerJson();
            string directoryPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "C:/SaveGame/");

            Jeu jeuVide = new Jeu();
            Jeu jeuAverif = new Jeu();
            jeuAverif = serializer.Deserialize(directoryPath, fileNameJson);
            jeu = jeuVide;
            if (chelemAVerif == 1)
            {
                etape = 3;
                etapeMax = 8;
            }
            else
            {
                etape = 5;
                if (nivAVerif == 'a' || nivAVerif == 'b' || nivAVerif == 'c' || nivAVerif == 'd' || nivAVerif == 'e' || nivAVerif == 'f' || nivAVerif == 'g' || nivAVerif == 'h' || nivAVerif == 'i' || nivAVerif == 'j' || nivAVerif == 'k' || nivAVerif == 'l' || nivAVerif == 'm' || nivAVerif == 'n')
                {
                    etapeMax = 9;
                }
                else
                {
                    etapeMax = 8;
                }

            }
            if (jeuAverif.chelemDuJeu == chelemAVerif)
            {
                if(jeuAverif.nivDuJeu == nivAVerif)
                {
                    foreach(Case c in jeuAverif.Plateau)
                    {
                        if(c.Val != "0" || c.Val != "/")
                        {
                            etape = jeuAverif.etapeDuJeu;
                            jeu = jeuAverif;
                        }
                    }
                }
            }
            
        }

        public int DeterEtapeMax(char niv, int chelem, out int etape)
        {
            if (chelem == 1)
            {
                etape = 3;
                etapeMax = 8;
            }
            else
            {
                etape = 5;
                if (niv == 'a' || niv == 'b' || niv == 'c' || niv == 'd' || niv == 'e' || niv == 'f' || niv == 'g' || niv == 'h' || niv == 'i' || niv == 'j' || niv == 'k' || niv == 'l' || niv == 'm' || niv == 'n')
                {
                    etapeMax = 9;
                }
                else
                {
                    etapeMax = 8;
                }


            }
            return etapeMax;
        }
        [IgnoreDataMember]
        [JsonIgnore]
        [XmlIgnoreAttribute]

        public Regle regle = new Regle();

        [DataMember(Name = "listPiecesManche")]
        public List<Piece> listPiecesManche { get; set; } = new List<Piece>();
        [DataMember(Name = "etapeDuJeu")]
        public int etapeDuJeu { get; set; } = new int();
        [DataMember(Name = "chelemDuJeu")]
        public int chelemDuJeu { get; set; } = new int();
        [DataMember(Name = "nivDuJeu")]
        public char nivDuJeu { get; set; } = new char();
        [DataMember(Name = "etapeMax")]
        public int etapeMax { get; set; } = new char();

        private ObservableCollection<Case> plateau = new ObservableCollection<Case>();

        [DataMember(Name = "plateau")]
        public ObservableCollection<Case> Plateau
        {
            get { return plateau; }
            set
            {
                if (plateau != value)
                {
                    plateau = value;
                    OnPropertyChanged(nameof(Plateau));
                }
            }
        }

        /// <summary>
        /// Affiche le plateau de jeu dans la console.
        /// </summary>
        /// <param name="plateau">Le plateau de jeu.</param>
        /// <param name="xpos">La largeur du plateau.</param>
        /// <param name="ypos">La hauteur du plateau.</param>
        public void affichePlateau(ObservableCollection<Case> plateau, int xpos, int ypos)
        {
            for (int y = 0; y <= ypos; y++)   // Parcours des lignes de Y de 0 à 12
            {
                for (int x = 0; x <= xpos; x++) // Parcours des colonnes de X de 0 à 5
                {
                    Case caseToDisplay = plateau.FirstOrDefault(c => c.Y == y && c.X == x); // Recherche de la case correspondante

                    if (caseToDisplay != null)
                    {
                        if (caseToDisplay.Val == "0")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "1")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "2")
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "3")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "4")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "5")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "6")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "7")
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "8")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "9")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "a")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "b")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "c")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }
                        if (caseToDisplay.Val == "/")
                        {
                            Console.ResetColor();
                            Console.Write("|" + caseToDisplay.Val + "|");
                        }

                    }
                    else
                    {
                        Console.Write("| |"); // Case vide si aucune correspondance trouvée
                    }
                }
                Console.WriteLine(); // Nouvelle ligne après avoir affiché une ligne complète
            }
            Console.ResetColor();
            Console.WriteLine("");
        }

        public Piece NumPieceToPiece(int num)
        {
            Piece pieceErreur = new Piece();
            foreach(Piece p in PiecesList)
            {
                if (p.Num == num)
                {
                    return p;
                }
            }
            return pieceErreur;
        }

        public void afficheListPiece(List<Piece> ListPiece)
        {


            foreach (Piece p in ListPiece)
            {
                ObservableCollection<Case> tabPiece = new ObservableCollection<Case>();
                for (int x = 0; x <= 5; x++)
                {
                    for (int y = 0; y <= 5; y++)
                    {
                        tabPiece.Add(new Case(x, y, "0"));
                    }
                }
                foreach (Case cList in p.LPiece)
                {
                    foreach (Case cTab in tabPiece)
                    {
                        if (cTab.Y == cList.Y && cTab.X == cList.X)
                        {
                            cTab.Val = cList.Val;
                        }
                    }

                }
                affichePlateau(tabPiece, 4, 4);
                Console.WriteLine("");
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Jeu()
        {
            piecesList.Clear();
            for (int i = 1; i < 13; i++)
            {
                Piece p = new Piece(i);
                piecesList.Add(p);
            }
            resetPlateau();
            initialiserPlateau();
        }

        public void initialiserPlateau()
        {
            for (int x = 0; x <= 11; x++)
            {
                for (int y = 0; y <= 4; y++)
                {
                    plateau.Add(new Case(x, y, "0"));

                }
            }
        }

        public void resetPlateau()
        {
            plateau.Clear();
            OnPropertyChanged(nameof(Plateau));
        }

        public void AjoutReglette(int regletteSize)
        {
            plateau = regle.reglette(plateau, regletteSize);
        }
            
        public event EventHandler<MirorNotifiedEventArgs> MirorNotified;

        public virtual void OnMirorNotified(MirorNotifiedEventArgs args)
            => MirorNotified?.Invoke(this, args);

        /// <summary>
        /// Événement déclenché lorsqu'une rotation est effectuée sur une pièce.
        /// </summary>
        public event EventHandler<RotationNotifiedEventArgs> RotationNotified;
        /// <summary>
        /// Méthode virtuelle pour notifier les abonnés de l'événement de rotation.
        /// </summary>
        /// <param name="args">Les arguments de l'événement de rotation.</param>
        public virtual void OnRotationNotified(RotationNotifiedEventArgs args)
            => RotationNotified?.Invoke(this, args);
        /// <summary>
        /// Effectue une rotation sur une pièce sélectionnée par l'utilisateur.
        /// La pièce est choisie parmi une liste de pièces et est ensuite tournée d'un angle spécifié.
        /// </summary>
        /// <param name="listPiece">La liste des pièces disponibles pour la rotation.</param>
        /// <param name="degre">L'angle de rotation en degrés.</param>
        /// <returns>La liste des pièces avec la pièce sélectionnée ayant subi la rotation.</returns>

        public void etapeRotate(List<Piece> listPiece, int degre, Piece piece)
        {
            List<Piece> newListPiece = new List<Piece>();
            if (piece.Num != 13)
            {
                for (int i = 0; i < listPiece.Count; i++)
                {
                    if (listPiece[i].Num == piece.Num)
                    {
                        listPiece[i] = Rotate(listPiece[i], degre);
                        OnRotationNotified(new RotationNotifiedEventArgs(listPiece[i], degre));
                    }

                }

            }
            listPiecesManche = listPiece;
        }

        /// <summary>
        /// Événement déclenché lorsqu'une pièce est enlevé du plateau.
        /// </summary>
        public event EventHandler<EnleverNotifiedEventArgs> EnleverNotified;
        /// <summary>
        /// Méthode virtuelle pour notifier les abonnés de l'événement d'enlever.
        /// </summary>
        /// <param name="args">Les arguments de l'événement d'enlever.</param>
        public virtual void OnEnleverNotified(EnleverNotifiedEventArgs args)
            => EnleverNotified?.Invoke(this, args);

        /// <summary>
        /// Effectue la suppression d'une pièce sélectionnée par l'utilisateur sur le plateau.
        /// La pièce est choisie parmi une liste de pièces, validée, et ensuite supprimée du plateau.
        /// </summary>
        /// <param name="listPiece">La liste des pièces disponibles pour la suppression.</param>
        /// <returns>La liste des pièces après suppression de la pièce sélectionnée.</returns>

        public void etapeEnlever(List<Piece> listPiece, Piece piece)
        {
            bool check;
            for (int i = 0; i < listPiece.Count; i++)
            {
                listPiece[i] = MajNumPiece(listPiece[i]);
            }
            if (piece.Num != 13)
            {
                check = enlever(piecesList[piece.Num - 1]);
                if (check)
                {
                    listPiece.Add(piecesList[piece.Num - 1]);
                }
            }
            listPiecesManche = listPiece;
        }

        public void placer(Piece piece, int xcoord, int ycoord)
        {
            foreach (Case c in plateau)
            {
                foreach (Piece p in piecesList)
                {
                    foreach (Case cPiece in p.LPiece)
                    {
                        foreach (Case testPiece in piece.LPiece)
                        {
                            if (cPiece.Val == testPiece.Val)
                            {
                                Case tempCase = new Case();
                                tempCase.X = xcoord + testPiece.X;
                                tempCase.Y = ycoord + testPiece.Y;
                                tempCase.Val = testPiece.Val;
                                if (c.X == tempCase.X && c.Y == tempCase.Y)
                                {
                                    c.Val = tempCase.Val;

                                }
                            }
                        }
                    }

                }
            }
            OnPropertyChanged(nameof(Plateau));

        }
        /// <summary>
        /// Événement déclenché lorsqu'une pièce est placer sur le plateau.
        /// </summary>
        public event EventHandler<PlacerNotifiedEventArgs> PlacerNotified;
        /// <summary>
        /// Méthode virtuelle pour notifier les abonnés de l'événement de placer.
        /// </summary>
        /// <param name="args">Les arguments de l'événement de placer.</param>
        public virtual void OnPlacerNotified(PlacerNotifiedEventArgs args)
            => PlacerNotified?.Invoke(this, args);
        /// <summary>
        /// Événement déclenché lorsqu'une pièce est mal placé sur le plateau.
        /// </summary>
        public event EventHandler<MalPlacerNotifiedEventArgs> MalPlacerNotified;
        /// <summary>
        /// Méthode virtuelle pour notifier les abonnés de l'événement de mal placer.
        /// </summary>
        /// <param name="args">Les arguments de l'événement de mal placer.</param>
        public virtual void OnMalPlacerNotified(MalPlacerNotifiedEventArgs args)
            => MalPlacerNotified?.Invoke(this, args);

        public bool etapePlacer(List<Piece> listPiece, int etape, Piece piece, int xcoord, int ycoord)
        {
            if (piece.Num != 13)
            {
                for (int i = 0; i < listPiece.Count; i++)
                {
                    if (listPiece[i].Num == piece.Num)
                    {
                        if (regle.checkBonPlacer(plateau, listPiece[i], xcoord, ycoord, etape))
                        {
                            placer(listPiece[i], xcoord, ycoord);
                            listPiece.Remove(listPiece[i]);
                            listPiecesManche = listPiece;
                            OnPlacerNotified(new PlacerNotifiedEventArgs(piece.Num, xcoord, ycoord));
                            return true;
                        }
                        else
                        {
                            OnMalPlacerNotified(new MalPlacerNotifiedEventArgs(piece.Num));
                        }
                    }

                }
            }
            return false;

        }


        public List<Piece> ListPieceManche(char niv, int manche, int typeChelem)
        {
            List<int> listVerif = new List<int>();
            List<Piece> listPieceManche = new List<Piece>();

            if (typeChelem == 1)
            {
                regle.ListPetitChelem.TryGetValue(niv, out listVerif);
                for (int i = 0; i < manche; i++)
                {
                    listPieceManche.Add(piecesList[listVerif[i] - 1]);
                }
            }
            if (typeChelem == 2)
            {
                regle.ListGrandChelem.TryGetValue(niv, out listVerif);
                for (int i = 0; i < manche; i++)
                {
                    listPieceManche.Add(piecesList[listVerif[i] - 1]);
                }
            }
            return listPieceManche;
        }

        private static Piece MajNumPiece(Piece p)
        {
            string temp;
            foreach (Case c in p.LPiece)
            {
                temp = c.Val;
                if (c.Val == "a")
                {
                    temp = "10";
                }
                if (c.Val == "b")
                {
                    temp = "11";
                }
                if (c.Val == "c")
                {
                    temp = "12";
                }
                if (c.Val != "0")
                {
                    p.Num = int.Parse(temp);
                }
            }
            return p;
        }

        public string MajValPiece(Case c)
        {
            string temp;
            temp = c.Val;
            if (c.Val == "a")
            {
                temp = "10";
            }
            if (c.Val == "b")
            {
                temp = "11";
            }
            if (c.Val == "c")
            {
                temp = "12";
            }
            return temp;
        }
        public static Piece initialiserPos(Piece p)
        {
            // Trouver les coordonnées minimales pour décaler la pièce à la position (0, 0)
            int minX = int.MaxValue;
            int minY = int.MaxValue;

            foreach (Case c in p.LPiece)
            {
                if (c.X < minX)
                {
                    minX = c.X;
                }
                if (c.Y < minY)
                {
                    minY = c.Y;
                }
            }

            // Créer une nouvelle pièce avec les coordonnées réinitialisées
            Piece newPiece = new Piece();

            foreach (Case c in p.LPiece)
            {
                newPiece.LPiece.Add(new Case(c.X - minX, c.Y - minY, c.Val));
            }

            newPiece = MajNumPiece(newPiece);
            return newPiece;
        }



        public Piece Mirror(Piece p)
        {
            // Trouver la coordonnée maximale en X pour effectuer la symétrie miroir
            int maxX = int.MinValue;

            foreach (Case c in p.LPiece)
            {
                if (c.X > maxX)
                {
                    maxX = c.X;
                }
            }

            // Créer une nouvelle pièce avec les coordonnées miroir
            Piece mirroredPiece = new Piece();

            foreach (Case c in p.LPiece)
            {
                int mirroredX = maxX - (c.X - maxX); // Calcul de la coordonnée miroir en X
                mirroredPiece.LPiece.Add(new Case(mirroredX, c.Y, c.Val));
            }

            return initialiserPos(mirroredPiece);
        }

        public void etapeMiror(List<Piece> listPiece, Piece piece)
        {
            if (piece.Num != 13)
            {
                for (int i = 0; i < listPiece.Count; i++)
                {
                    if (listPiece[i].Num == piece.Num)
                    {
                        listPiece[i] = Mirror(listPiece[i]);
                        OnMirorNotified(new MirorNotifiedEventArgs(listPiece[i]));
                    }

                }

            }
            listPiecesManche = listPiece;
        }

        public Piece Rotate(Piece p, double angle)
        {

            Piece rotatedPiece = new Piece();

            // Calcul du point de pivot
            int pivotX = 2; // Centre de la grille 5x5
            int pivotY = 2; // Centre de la grille 5x5

            // Conversion degrés en radians
            double angleRad = angle * Math.PI / 180.0;

            foreach (Case c in p.LPiece)
            {
                // Calcul des coordonnées relatives au pivot
                int relativeX = c.X - pivotX;
                int relativeY = c.Y - pivotY;

                // Application de la rotation
                int rotatedX = (int)Math.Round(relativeX * Math.Cos(angleRad) - relativeY * Math.Sin(angleRad));
                int rotatedY = (int)Math.Round(relativeX * Math.Sin(angleRad) + relativeY * Math.Cos(angleRad));

                // Ajustement des coordonnées pour les replacer sur la grille
                rotatedX += pivotX;
                rotatedY += pivotY;

                // Ajout de la case pivotée à la nouvelle pièce
                rotatedPiece.LPiece.Add(new Case(rotatedX, rotatedY, c.Val));

            }

            return initialiserPos(rotatedPiece);
        }


        public bool enlever(Piece p)
        {
            int temp = 0;
            string tempVal;
            if (p.Num == 10)
            {
                tempVal = "a";
            }
            else if (p.Num == 11)
            {
                tempVal = "b";
            }
            else if (p.Num == 12)
            {
                tempVal = "c";
            }
            else
            {
                tempVal = p.Num.ToString();
            }
            foreach (Case c in plateau)
            {

                if (c.Val == tempVal)
                {
                    c.Val = "0";
                    temp = 1;
                }
            }
            if (temp == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

}




