using ClassKatamino;
using ClassKatamino.Event;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKatamino.Tests
{
    public class DisplayTests
    {
        [Fact]
        public void RotationNotified_AfficheMessageCorrect()
        {
            var display = new Display();
            var piece = new Piece(1);
            var args = new RotationNotifiedEventArgs(piece, 90);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                display.RotationNotified(this, args);
                var result = sw.ToString().Trim();
                Assert.Equal("La pièce 1 a été tourner de 90 degré !", result);
            }
        }

        [Fact]
        public void MirorNotified_AfficheMessageCorrect()
        {
            var display = new Display();
            var piece = new Piece(2);
            var args = new MirorNotifiedEventArgs(piece);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                display.MirorNotified(this, args);
                var result = sw.ToString().Trim();
                Assert.Equal("La pièce 2 a été tourner en miroir", result);
            }
        }

        [Fact]
        public void EnleverNotified_AfficheMessageCorrect()
        {
            var display = new Display();
            var piece = 3;
            var args = new EnleverNotifiedEventArgs(piece);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                display.EnleverNotified(this, args);
                var result = sw.ToString().Trim();
                Assert.Equal("La pièce 3 a été enlevé du plateau !", result);
            }
        }

        [Fact]
        public void PlacerNotified_AfficheMessageCorrect()
        {
            var display = new Display();
            var piece = 4;
            var x = 5;
            var y = 6;
            var args = new PlacerNotifiedEventArgs(piece, x, y);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                display.PlacerNotified(this, args);
                var result = sw.ToString().Trim();
                Assert.Equal("La pièce 4 a été placé aux coordonnées 5 ; 6 !", result);
            }
        }

        [Fact]
        public void MalPlacerNotified_AfficheMessageCorrect()
        {
            var display = new Display(); 
            var piece = 5;
            var args = new MalPlacerNotifiedEventArgs(piece);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                display.MalPlacerNotified(this, args);
                var result = sw.ToString().Trim();
                Assert.Equal("désolé la piece 5 ne peux pas etre posee ici...", result);
            }
        }
    }
}
