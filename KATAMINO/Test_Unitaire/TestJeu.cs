using ClassKatamino;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKatamino.Tests
{
    public class JeuTests
    {
        [Fact]
        public void CheckBienPlacer()
        {
            Jeu jeu = new Jeu();
            Regle regle = new Regle();
            int regletteSize = 3;
            jeu.AjoutReglette(regletteSize);
            jeu.AjoutReglette(8);
            //placerv2(piecesList[2] , 0, 2);
            //placerv2(piecesList[4], 0, 0);
            jeu.placer(jeu.PiecesList[1], 5, 0);
            //placerv2(piecesList[1], 3, 0);
            //placerv2(piecesList[8], 9, 1);
            //placerv2(piecesList[7], 7, 1);


            Assert.False(regle.checkBonPlacer(jeu.Plateau, jeu.PiecesList[2], 0, 2, 8));// piece en dehors de l'écran ( False )
            Assert.True(regle.checkBonPlacer(jeu.Plateau, jeu.PiecesList[4], 0, 0, 8)); // piece bien placer ( True )

            Assert.True(regle.checkBonPlacer(jeu.Plateau, jeu.Mirror(jeu.PiecesList[4]), 0, 0, 8)); // piece bien placer et Mirror ( True )
            Assert.True(regle.checkBonPlacer(jeu.Plateau, jeu.Rotate(jeu.PiecesList[4],180), 0, 0, 8)); // piece bien placer et Mirror ( True )
            Assert.False(regle.checkBonPlacer(jeu.Plateau, jeu.PiecesList[2], 5, 0, 8)); // piece placer sur une autre ( False ) 
            Assert.False(regle.checkBonPlacer(jeu.Plateau, jeu.PiecesList[8], 9, 1, 8)); // piece mal en dehors de la limite de la reglette ( False )
            Assert.False(regle.checkBonPlacer(jeu.Plateau, jeu.PiecesList[7], 6, 1, 8)); // piece placer sur la reglette ( False ) 
            Assert.False(regle.checkBonPlacer(jeu.Plateau, jeu.PiecesList[1], 3, 0, 8)); // piece placer mais deja placer ( False ) 

            Assert.NotNull(jeu.Plateau); // Vérifie si le plateau n'est pas null après l'opération

        }
        [Fact]
        public void CheckBienEnlever()
        {
            Jeu jeu = new Jeu();
            Regle regle = new Regle();
            int regletteSize = 3;
            jeu.AjoutReglette(regletteSize);
            //jeu.Plateau = regle.reglette(jeu.Plateau, regletteSize);
            jeu.placer(jeu.Rotate(jeu.PiecesList[9], 180), 0, 2);
            jeu.placer(jeu.Mirror(jeu.PiecesList[4]), 3, 2);
            jeu.placer(jeu.PiecesList[2], 1, 0);


            Assert.True(jeu.enlever(jeu.PiecesList[2]));// piece à enlever ( True )
            Assert.True(jeu.enlever(jeu.PiecesList[9])); // piece bien retourner et enlever( True )
            Assert.True(jeu.enlever(jeu.PiecesList[4])); // piece bien mirror et enlever( True )

            Assert.False(jeu.enlever(jeu.PiecesList[8])); // piece enlever qui n'est pas dans le plateau ( False ) 


            Assert.NotNull(jeu.Plateau); // Vérifie si le plateau n'est pas null après l'opération
        }

        [Fact]
        public void CheckRotation()
        {
            Jeu jeu = new Jeu();
            Regle regle = new Regle();
            int regletteSize = 3;
            jeu.AjoutReglette(regletteSize);
            Assert.True(regle.checkRotation(jeu.PiecesList[9], 0)); // rotation correspondant à 0, 90, 180 ou 360 ( True )
            Assert.True(regle.checkRotation(jeu.PiecesList[9], 90)); // rotation correspondant à 0, 90, 180 ou 360 ( True )
            Assert.True(regle.checkRotation(jeu.PiecesList[9], 180)); // rotation correspondant à 0, 90, 180 ou 360 ( True )
            Assert.True(regle.checkRotation(jeu.PiecesList[9], 360)); // rotation correspondant à 0, 90, 180 ou 360 ( True )
            Assert.False(regle.checkRotation(jeu.PiecesList[9], 200)); // rotaion différente de 0, 90, 180 ou 360 ( False )
            Assert.NotNull(jeu.Plateau); // Vérifie si le plateau n'est pas null après l'opération
        }

        [Fact]
        public void CheckWinTrue()
        {
            Jeu jeu = new Jeu();
            Regle regle = new Regle();
            int regletteSize = 3;
            jeu.AjoutReglette(regletteSize);

            jeu.placer(jeu.Rotate(jeu.PiecesList[9], 180), 0, 2);
            jeu.placer((jeu.PiecesList[1]), 0, 0);
            jeu.placer(jeu.PiecesList[2], 1, 0);

            Assert.True(regle.CheckWinNiv(jeu.Plateau,regletteSize));

            Assert.NotNull(jeu.Plateau); // Vérifie si le plateau n'est pas null après l'opération
        }

        [Fact]
        public void CheckWinFalse()
        {
            Jeu jeu = new Jeu();
            Regle regle = new Regle();
            int regletteSize = 3;
            jeu.AjoutReglette(regletteSize);

            jeu.placer(jeu.Rotate(jeu.PiecesList[9], 180), 0, 2);
            jeu.placer((jeu.PiecesList[9]), 0, 0);
            jeu.placer(jeu.PiecesList[2], 1, 0);

            Assert.False(regle.CheckWinNiv(jeu.Plateau, regletteSize));

            Assert.NotNull(jeu.Plateau); 
        }

        [Fact]
        public void Win_ShouldReturnTrue_WhenWinConditionIsMet()
        {
            var jeu = new Jeu();
            var plateau = new ObservableCollection<Case>();
            int etape = 1;

            bool result = jeu.Win(plateau, etape);

            Assert.True(result);
        }

        [Fact]
        public void DeterEtapeMax_ShouldReturnCorrectEtapeMax_ForGivenNivAndChelem()
        {
            var jeu = new Jeu();
            int etape;
            char niv = 'a';
            int chelem = 1;

            int result = jeu.DeterEtapeMax(niv, chelem, out etape);

            Assert.Equal(8, result);
            Assert.Equal(3, etape);
        }

        [Fact]
        public void NumPieceToPiece_ShouldReturnCorrectPiece_WhenPieceExists()
        {
            var jeu = new Jeu();
            int num = 1;

            Piece result = jeu.NumPieceToPiece(num);

            Assert.NotNull(result);
            Assert.Equal(num, result.Num);
        }

        [Fact]
        public void ResetPlateau_ShouldClearPlateau()
        {
            var jeu = new Jeu();

            jeu.resetPlateau();

            Assert.Equal(0, jeu.Plateau.Count);
        }

        [Fact]
        public void Placer_ShouldPlacePieceCorrectlyOnPlateau()
        {
            var jeu = new Jeu();
            var piece = new Piece(1);
            int xcoord = 0;
            int ycoord = 0;

            jeu.placer(piece, xcoord, ycoord);

        }

    }
}