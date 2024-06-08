using ClassKatamino;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Diagnostics;

namespace KATAMINO
{
    public partial class PagePlateau : ContentPage
    {
        Jeu jeu = new Jeu();
        Piece pieceAutiliser = new Piece();
        int coordX, coordY = new int();
        int etape , chelem, etapeMax;
        List<Piece> listPieceActuelle = new List<Piece>();
        bool check = false;
        char niv;

        List<Color> colorlist = [Colors.Blue, Colors.PaleTurquoise, Colors.AliceBlue,Colors.Gray, Colors.Green, Colors.Yellow, Colors.YellowGreen, Colors.LightBlue, Colors.Purple, Colors.Orange, Colors.DarkOrange, Colors.Chocolate];
        
        public PagePlateau(string niv, string chelem)
        {
            InitializeComponent();
            BindingContext = jeu;
            niv = niv.ToLower();
            

            // Convertir niv en char
            char.TryParse(niv, out char valNiv);
            this.niv = valNiv;

            // Convertir chelem en int
            int.TryParse(chelem, out int valChelem);
            this.chelem = valChelem;

            jeu.nivDuJeu = this.niv;
            jeu.chelemDuJeu = this.chelem;

            jeu.etapeMax = jeu.DeterEtapeMax(this.niv, this.chelem, out etape);

            //jeu.ChargePlateauPersistance(this.niv, this.chelem, out etape, out etapeMax, out jeu);
            jeu.etapeMax = etapeMax;
            Game();
            jeu.etapeDuJeu = etape;
        }


        public void AjouterListPiece(List<Piece> pieceList)
        {
            GridPiece.Children.Clear();
            int i = 0;
            foreach (Piece piece in pieceList)
            {
                Microsoft.Maui.Controls.Grid g = AjoutePiece(piece);
                GridPiece.SetRow(g, 0);
                GridPiece.SetColumn(g, i);
                g.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() => OnPieceTapped(piece, i)),
                });
                GridPiece.Children.Add(g);
                i++;
            }
        }


        private void OnPieceTapped(Piece piece, int column)
        {
            pieceAutiliser = piece;


        }
        public Microsoft.Maui.Controls.Grid AjoutePiece(Piece p)
        {
            Microsoft.Maui.Controls.Grid g = new Microsoft.Maui.Controls.Grid();
            foreach (Case c in p.LPiece)
            {
                while (g.RowDefinitions.Count <= c.Y)
                {
                    g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                }

                while (g.ColumnDefinitions.Count <= c.X)
                {
                    g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
                }
                int.TryParse(c.Val, out int val);
                var rectangle1 = new Rectangle()
                {

                    Fill = new SolidColorBrush(colorlist[p.Num-1]),
                    WidthRequest = 30,
                    HeightRequest = 30
                };
                g.SetRow(rectangle1, c.Y);
                g.SetColumn(rectangle1, c.X);
                g.Add(rectangle1);
            }
            return g;
        }

        public void Game()
        {
            listPieceActuelle = jeu.ListPieceManche(niv, etape, chelem);
            AjouterListPiece(listPieceActuelle);
            jeu.AjoutReglette(etape);
            Gameboard();
            string fileNameJson = "jeu.json";
            var xmlSerialiser = new SerialiserXML();
            SerializerJson serializer = new SerializerJson();
            string directoryPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "C:/SaveGame/");
            string fileNameXml = "jeu.xml";
            serializer.Serialize(jeu, directoryPath, fileNameJson);
            xmlSerialiser.Serialize(jeu, directoryPath, fileNameXml);

        }

        
        private void OnMiroiterButtonClicked(object sender, EventArgs e)
        {
            jeu.etapeMiror(listPieceActuelle, pieceAutiliser);
            listPieceActuelle = jeu.listPiecesManche;
            AjouterListPiece(listPieceActuelle);
            string fileNameJson = "jeu.json";
            var xmlSerialiser = new SerialiserXML();
            SerializerJson serializer = new SerializerJson();
            string directoryPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "C:/SaveGame/");
            string fileNameXml = "jeu.xml";
            serializer.Serialize(jeu, directoryPath, fileNameJson);
            xmlSerialiser.Serialize(jeu, directoryPath, fileNameXml);
        }
        private void OnPlacerButtonClicked(object sender, EventArgs e)
        {
            
            check = jeu.etapePlacer(listPieceActuelle, etape, pieceAutiliser, coordY, coordX);
            if (check)
            {
                listPieceActuelle = jeu.listPiecesManche;
                AjouterListPiece(listPieceActuelle);
                Gameboard();
            }
            if (jeu.Win(jeu.Plateau, etape))
            {
                etape++;
                jeu.etapeDuJeu = etape;
                jeu.resetPlateau();
                jeu.initialiserPlateau();
                listPieceActuelle = jeu.ListPieceManche(niv, etape, chelem);
                AjouterListPiece(listPieceActuelle);
                jeu.AjoutReglette(etape);
                Gameboard();

            }
            if(etape == jeu.etapeMax)
            {
                Navigation.PushAsync(new Victory());
            }
            string fileNameJson = "jeu.json";
            var xmlSerialiser = new SerialiserXML();
            SerializerJson serializer = new SerializerJson();
            string directoryPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "C:/SaveGame/");
            string fileNameXml = "jeu.xml";
            serializer.Serialize(jeu, directoryPath, fileNameJson);
            xmlSerialiser.Serialize(jeu, directoryPath, fileNameXml);
        }

        private void OnEnleverButtonClicked(object sender, EventArgs e)
        {
            
            int val = 0;
            foreach (Case c in jeu.Plateau)
            {
                if(c.X == coordY && c.Y == coordX)
                {
                    int.TryParse(c.Val, out val);
                }
            }
            foreach(Piece p in jeu.PiecesList)
            {
                if(p.Num == val)
                {
                    pieceAutiliser = p;
                }
            }
            jeu.etapeEnlever(listPieceActuelle,pieceAutiliser);
            listPieceActuelle = jeu.listPiecesManche;
            AjouterListPiece(listPieceActuelle);
            Gameboard();
            string fileNameJson = "jeu.json";
            var xmlSerialiser = new SerialiserXML();
            SerializerJson serializer = new SerializerJson();
            string directoryPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "C:/SaveGame/");
            string fileNameXml = "jeu.xml";
            serializer.Serialize(jeu, directoryPath, fileNameJson);
            xmlSerialiser.Serialize(jeu, directoryPath, fileNameXml);
        }


        private void OnPivoterButtonClicked(object sender, EventArgs e)
        {
            jeu.etapeRotate(listPieceActuelle, 90 ,pieceAutiliser);
            listPieceActuelle = jeu.listPiecesManche;
            AjouterListPiece(listPieceActuelle);
        }
        private void OnCasePlateauTapped(int row, int column)
        {
            coordX = row;
            coordY = column;
        }


        private void ResetGridElements()
        {
            // Clear all children elements
            PlateauGrid.Children.Clear();

            // Optional: Reset the grid rows and columns definitions if needed
            PlateauGrid.RowDefinitions.Clear();
            PlateauGrid.ColumnDefinitions.Clear();
        }
        public void Gameboard()
        {
            PlateauGrid.Children.Clear();

            string valeur;
            foreach (Case c in jeu.Plateau)
            {
                for (int x = 0; x < 12; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (c.X == x && c.Y == y)
                        {

                            // Créez un élément et ajoutez le gestionnaire d'événements directement à cet élément.
                            if (c.Val == "/")
                            {
                                var rectangle1 = new Rectangle()
                                {
                                    Fill = new SolidColorBrush(Colors.Black),
                                    WidthRequest = 60,
                                    HeightRequest = 60
                                };
                                PlateauGrid.SetRow(rectangle1, c.Y);
                                PlateauGrid.SetColumn(rectangle1, c.X);

                                rectangle1.GestureRecognizers.Add(new TapGestureRecognizer
                                {
                                    Command = new Command(() => OnCasePlateauTapped(c.Y, c.X))
                                });

                                PlateauGrid.Children.Add(rectangle1);
                            }
                            else if (c.Val == "0")
                            {
                                var frame = new Frame
                                {
                                    BackgroundColor = Colors.DarkSalmon,
                                    BorderColor = Colors.Black,
                                    CornerRadius = 0,
                                    HasShadow = false,
                                    WidthRequest = 60,
                                    HeightRequest = 60,
                                    Padding = 0,
                                    Margin = 0
                                };
                                PlateauGrid.SetRow(frame, c.Y);
                                PlateauGrid.SetColumn(frame, c.X);

                                frame.GestureRecognizers.Add(new TapGestureRecognizer
                                {
                                    Command = new Command(() => OnCasePlateauTapped(c.Y, c.X))
                                });

                                PlateauGrid.Children.Add(frame);
                            }
                            else
                            {
                                valeur = jeu.MajValPiece(c);
                                int.TryParse(valeur, out int val);
                                var rectangle1 = new Rectangle()
                                {
                                    Fill = new SolidColorBrush(colorlist[val-1]),
                                    WidthRequest = 60,
                                    HeightRequest = 60
                                };
                                PlateauGrid.SetRow(rectangle1, c.Y);
                                PlateauGrid.SetColumn(rectangle1, c.X);

                                rectangle1.GestureRecognizers.Add(new TapGestureRecognizer
                                {
                                    Command = new Command(() => OnCasePlateauTapped(c.Y, c.X))
                                });

                                PlateauGrid.Children.Add(rectangle1);
                            }
                        }
                    }
                }
            }
        }

    }
}
