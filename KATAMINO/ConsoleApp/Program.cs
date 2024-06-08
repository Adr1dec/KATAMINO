// See https://aka.ms/new-console-template for more information
using ClassKatamino;
using System.Timers;
using Timer = System.Timers.Timer;


namespace ConsoleApp
{
    class Program
    {

        private static Timer aTimer;
        private static DateTime startTime;

        private static Timer aTimerTotal;
        private static DateTime startTimeTotal;

        /// <summary>
        /// Demande à l'utilisateur de choisir un mouvement à effectuer sur les pièces.
        /// Les choix possibles sont Rotation, Miroir, Placer et Enlever.
        /// </summary>
        /// <returns>Le choix de mouvement sélectionné par l'utilisateur.</returns>
        static char choixMouvement()
        {
            char choix;
            Console.WriteLine("Quelle mouvement faire ? Rotation en fonction de degre (r) Rotation Miroir (m) Placer (p) Enlever (e)");
            string choixstr = Console.ReadLine();
            while (choixstr.ToLower() != "rotate" && choixstr.ToLower() != "r" && choixstr.ToLower() != "miroir" && choixstr.ToLower() != "mirror" && choixstr.ToLower() != "m" && choixstr.ToLower() != "placer" && choixstr.ToLower() != "p" && choixstr.ToLower() != "enlever" && choixstr.ToLower() != "e")
            {
                Console.WriteLine("Action invalide. Veuillez choisir entre Rotation en fonction de degre (r) Rotation Miroir (m) Placer (p) Enlever (e)");
                choixstr = Console.ReadLine();
            }
            if (choixstr.ToLower() == "rotate" || choixstr.ToLower() == "r")
            {
                choix = 'r';
            }
            if (choixstr.ToLower() == "miroir" || choixstr.ToLower() == "mirror" || choixstr.ToLower() == "m")
            {
                choix = 'm';
            }
            if (choixstr.ToLower() == "enlever" || choixstr.ToLower() == "e")
            {
                choix = 'e';
            }
            else
            {
                choix = 'p';
            }
            char.TryParse(choixstr, out choix);
            return choix;
        }

        /// <summary>
        /// Demande à l'utilisateur de choisir un niveau en fonction du type de chelem sélectionné.
        /// Pour le Petit chelem, les niveaux disponibles sont de 'a' à 'g'.
        /// Pour le Grand chelem, les niveaux disponibles sont de 'a' à 'z'.
        /// </summary>
        /// <param name="chelem">Le type de chelem choisi (1 pour Petit chelem, 2 pour Grand chelem).</param>
        /// <returns>Le niveau choisi par l'utilisateur.</returns>
        static char choixniv(int chelem)
        {
            char niv;
            if (chelem == 1)
            {
                Console.WriteLine("choississez un niveau a, b, c, d, e, f, g : ");

                char.TryParse(Console.ReadLine(), out niv);
                while (niv != 'a' && niv != 'b' && niv != 'c' && niv != 'd' && niv != 'e' && niv != 'f' && niv != 'g')
                {
                    Console.WriteLine(niv);
                    Console.WriteLine("Veuillez entrer un choix valide a, b, c, d, e, f, g :.");
                    char.TryParse(Console.ReadLine(), out niv);
                }
            }
            else
            {
                Console.WriteLine("choississez un niveau a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z :");
                char.TryParse(Console.ReadLine(), out niv);
                while (niv == 'a' && niv == 'b' && niv == 'c' && niv == 'd' && niv == 'e' && niv == 'f' && niv == 'g' && niv == 'h' && niv == 'i' && niv == 'j' && niv == 'k' && niv == 'l' && niv == 'm' && niv == 'n' && niv == 'o' && niv == 'p' && niv == 'q' && niv == 'r' && niv == 's' && niv == 't' && niv == 'u' && niv == 'v' && niv == 'w' && niv == 'x' && niv == 'y' && niv == 'z')
                {
                    Console.WriteLine("Veuillez entrer un choix valide a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z :.");
                    char.TryParse(Console.ReadLine(), out niv);
                }

            }

            return niv;
        }

        /// <summary>
        /// Demande à l'utilisateur de choisir entre un Petit chelem ou un Grand chelem.
        /// Renvoie 1 pour Petit chelem et 2 pour Grand chelem.
        /// </summary>
        /// <returns>Le choix de l'utilisateur : 1 pour Petit chelem, 2 pour Grand chelem.</returns>
        static int choixChelem()
        {
            int chelem;
            Console.WriteLine("1 pour Petit chelem ou 2 pour Grand chelem ? : ");
            int.TryParse(Console.ReadLine(), out chelem);
            while (chelem != 1 && chelem != 2)
            {
                Console.WriteLine("Veuillez entrer un choix valide (1 pour Petit chelem ou 2 pour Grand chelem).");
                int.TryParse(Console.ReadLine(), out chelem);
            }
            return chelem;
        }

        /// <summary>
        /// Vérifie si une pièce sélectionnée par l'utilisateur est valide parmi une liste de pièces.
        /// </summary>
        /// <param name="listPiece">La liste des pièces disponibles.</param>
        /// <returns>Le numéro de la pièce valide choisie par l'utilisateur, ou 13 pour quitter.</returns>

        static int checkGoodPiece(List<Piece> listPiece)
        {
            int temp = 0, piece = new int();
            Console.WriteLine("Quelle piece choisir ? (13) pour quitter");
            string piecestr = Console.ReadLine();
            int.TryParse(piecestr, out piece);
            if (piece != 13)
            {
                while (temp != 1)
                {
                    foreach (Piece p in listPiece)
                    {

                        if (p.Num == piece)
                        {
                            temp = 1;
                        }
                    }
                    if (temp == 0)
                    {
                        Console.WriteLine("Choissisez une piece valable ?");

                        int.TryParse(Console.ReadLine(), out piece);
                    }
                }
                return piece;
            }
            else
            {
                return 13;
            }

        }

        /// <summary>
        /// Gère l'application, la boucle de jeu
        /// </summary>
        /// 


        static void Main(string[] args)
        {
            Console.WriteLine("Lancement du jeu ...");

            Jeu partie = new Jeu();
            Display display = new Display();

            partie.RotationNotified += display.RotationNotified;
            partie.MirorNotified += display.MirorNotified;
            partie.EnleverNotified += display.EnleverNotified;


            int chelem, etape, etapeMax, tempEtape = 0, degre, piece = new int();
            int temp = 0, temp2 = 0, xcoord, ycoord;
            string tempVal;
            char niv, mouv;
            List<Piece> listPieceActuelle = new List<Piece>();
            chelem = Program.choixChelem();
            niv = Program.choixniv(chelem);
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
            listPieceActuelle = partie.ListPieceManche(niv, etape, chelem);
            partie.AjoutReglette(etape);
            aTimer = new Timer(2000);
            startTime = DateTime.Now;

            aTimerTotal = new Timer(2000);
            startTimeTotal = DateTime.Now;

            aTimerTotal.Start();
            aTimer.Start();
            while (etape != etapeMax)
            {

                if (tempEtape == 1)
                {
                    aTimer.Stop();
                    TimeSpan elapsedTime = DateTime.Now - startTime;
         
                    Console.WriteLine("Bravo ! Vous avez réussi l'étape : " + etape + " , du niveau : " + niv + " en : " + elapsedTime.TotalSeconds + " s");
                    Console.WriteLine("");
                    etape++;
                    partie.resetPlateau();
                    partie.initialiserPlateau();
                    partie.AjoutReglette(etape);
                    listPieceActuelle = partie.ListPieceManche(niv, etape, chelem);
                    startTime = DateTime.Now;
                    aTimer.Start();
                }
                while (!partie.regle.CheckWinNiv(partie.Plateau, etape))
                {
                    partie.afficheListPiece(listPieceActuelle);
                    partie.affichePlateau(partie.Plateau, 11, 4);
                    mouv = Program.choixMouvement();
                    if (mouv == 'r')
                    {
                        piece = Program.checkGoodPiece(listPieceActuelle);
                        Console.WriteLine("de combien de degré voulez vous tourner la piece ? 90 ? 180 ? 260 ?");
                        int.TryParse(Console.ReadLine(), out degre);
                        while (degre != 90 && degre != 180 && degre != 260)
                        {
                            Console.WriteLine("Veuillez rentrer un degre valable 90 ? 180 ? 260 ?");
                            int.TryParse(Console.ReadLine(), out degre);
                        }

                        partie.etapeRotate(listPieceActuelle, degre, partie.NumPieceToPiece(piece));
                    }
                    if (mouv == 'p')
                    {
                        piece = checkGoodPiece(listPieceActuelle);
                        while (temp != 1)
                        {
                            foreach (Piece p in listPieceActuelle)
                            {
                                if (p.Num == piece)
                                {
                                    temp = 1;
                                }
                            }
                            if (temp == 0)
                            {
                                Console.WriteLine("desolé la piece est déja pose");
                                piece = checkGoodPiece(listPieceActuelle);
                            }
                        }
                        Console.WriteLine("Quelle est la coordonné pour x ?");
                        int.TryParse(Console.ReadLine(), out xcoord);
                        while (xcoord < 0 && xcoord > 5)
                        {
                            Console.WriteLine("Veuillez rentrer un x valable ");
                            int.TryParse(Console.ReadLine(), out xcoord);
                        }
                        Console.WriteLine("Quelle est la coordonné pour y ?");
                        int.TryParse(Console.ReadLine(), out ycoord);
                        while (ycoord < 0 && ycoord > 12)
                        {
                            Console.WriteLine("Veuillez rentrer un y valable ");
                            int.TryParse(Console.ReadLine(), out xcoord);
                        }
                        partie.etapePlacer(listPieceActuelle, etape, partie.NumPieceToPiece(piece), xcoord, ycoord);
                    }
                    if (mouv == 'm')
                    {
                        piece = checkGoodPiece(listPieceActuelle);
                        partie.etapeMiror(listPieceActuelle, partie.NumPieceToPiece(piece));
                    }
                    if (mouv == 'e')
                    {
                        Console.WriteLine("Quelle piece choisir ? (13) pour quitter");
                        int.TryParse(Console.ReadLine(), out piece);
                        if (piece != 13)
                        {
                            while (temp2 != 1)
                            {
                                foreach (Case c in partie.Plateau)
                                {
                                    if (c.Val == "a")
                                    {
                                        tempVal = "10";
                                    }
                                    else if (c.Val == "b")
                                    {
                                        tempVal = "11";
                                    }
                                    else if (c.Val == "c")
                                    {
                                        tempVal = "12";
                                    }
                                    else
                                    {
                                        tempVal = c.Val;
                                    }

                                    if (tempVal == piece.ToString())
                                    {
                                        temp2 = 1;
                                    }
                                }
                                if (temp2 == 0)
                                {
                                    Console.WriteLine("Choissisez une piece valable ?");
                                    int.TryParse(Console.ReadLine(), out piece);
                                }
                            }

                        }
                        partie.etapeEnlever(listPieceActuelle, partie.NumPieceToPiece(piece));
                    }
                    tempEtape = 1;

                }
                string fileNameJson = "jeu.json";
                var xmlSerialiser = new SerialiserXML();
                SerializerJson serializer = new SerializerJson();
                string directoryPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "C:/Users/SaveGame/");
                string fileNameXml = "jeu.xml";
                serializer.Serialize(partie, directoryPath, fileNameJson);
                xmlSerialiser.Serialize(partie, directoryPath, fileNameXml);
            }

            aTimerTotal.Stop();
            TimeSpan elapsedTimeTotal = DateTime.Now - startTimeTotal;
            Console.WriteLine("Bravo ! Vous avez réussi le niveau : " + niv + " en : " + elapsedTimeTotal.TotalSeconds + " s");
        }
    }
}