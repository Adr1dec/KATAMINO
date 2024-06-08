using ClassKatamino;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKatamino.Tests
{
    public class RegleTests
    {
        public void CheckWinNiv_DoîtRetournerVrai_QuandToutesLesCasesSontRemplies()
        {
            var regle = new Regle();
            var plateau = new ObservableCollection<Case>
            {
                new Case { X = 0, Y = 0, Val = "1" },
                new Case { X = 1, Y = 0, Val = "2" },
                new Case { X = 2, Y = 0, Val = "3" }
            };
            int etape = 3;

            bool result = regle.CheckWinNiv(plateau, etape);

            Assert.True(result);
        }

        [Fact]
        public void CheckWinNiv_DoîtRetournerFaux_QuandUneCaseEstVide()
        {
            var regle = new Regle();
            var plateau = new ObservableCollection<Case>
            {
                new Case { X = 0, Y = 0, Val = "1" },
                new Case { X = 1, Y = 0, Val = "0" },
                new Case { X = 2, Y = 0, Val = "3" }
            };
            int etape = 3;

            bool result = regle.CheckWinNiv(plateau, etape);

            Assert.False(result);
        }

        [Fact]
        public void CheckBonPlacer_DoîtRetournerVrai_QuandLaPieceEstCorrectementPlacee()
        {
            var regle = new Regle();
            var plateau = new ObservableCollection<Case>
            {
                new Case { X = 0, Y = 0, Val = "0" },
                new Case { X = 1, Y = 0, Val = "0" },
                new Case { X = 2, Y = 0, Val = "0" }
            };
            var piece = new Piece(1)
            {
                LPiece = new List<Case>
                {
                    new Case { X = 0, Y = 0 },
                    new Case { X = 1, Y = 0 }
                }
            };
            int xcoord = 0;
            int ycoord = 0;
            int etape = 3;

            bool result = regle.checkBonPlacer(plateau, piece, xcoord, ycoord, etape);

            Assert.True(result);
        }


        [Fact]
        public void CheckRotation_DoîtRetournerVrai_QuandLAngleEstValide()
        {
            var regle = new Regle();
            var piece = new Piece(1);
            double angle = 90;

            bool result = regle.checkRotation(piece, angle);

            Assert.True(result);
        }

        [Fact]
        public void CheckRotation_DoîtRetournerFaux_QuandLAngleEstInvalide()
        {
            var regle = new Regle();
            var piece = new Piece(1);
            double angle = 45;

            bool result = regle.checkRotation(piece, angle);

            Assert.False(result);
        }
    }
}
