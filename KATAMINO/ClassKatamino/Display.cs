using ClassKatamino.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKatamino
{
    /// <summary>
    /// La classe Display gère l'affichage des notifications des évènements.
    /// </summary>
    public class Display
    {
        /// <summary>
        /// Méthode appelée lorsqu'une pièce est tournée.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="args">Les arguments de l'événement de rotation.</param>
        public void RotationNotified(object sender, RotationNotifiedEventArgs args)
        {
            Console.WriteLine($"La pièce {args.P.Num} a été tourner de {args.d} degré ! \n");
        }

        /// <summary>
        /// Méthode appelée lorsqu'une pièce est retourné en miroir.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="args">Les arguments de l'événement de miroir.</param>
        public void MirorNotified(object sender, MirorNotifiedEventArgs args)
        {
            Console.WriteLine($"La pièce {args.P.Num} a été tourner en miroir \n");
        }
        /// <summary>
        /// Méthode appelée lorsqu'une pièce est enlevé du plateau.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="args">Les arguments de l'événement d'enlever.</param>
        public void EnleverNotified(object sender, EnleverNotifiedEventArgs args)
        {
            Console.WriteLine($"La pièce {args.piece} a été enlevé du plateau ! \n");
        }
        /// <summary>
        /// Méthode appelée lorsqu'une pièce est placé sur le plateau.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="args">Les arguments de l'événement de placer.</param>
        public void PlacerNotified(object sender, PlacerNotifiedEventArgs args)
        {
            Console.WriteLine($"La pièce {args.piece} a été placé aux coordonnées {args.x} ; {args.y} ! \n");
        }
        /// <summary>
        /// Méthode appelée lorsqu'une pièce est mal placé.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="args">Les arguments de l'événement de mauvais placement.</param>
        public void MalPlacerNotified(object sender, MalPlacerNotifiedEventArgs args)
        {
            Console.WriteLine($"désolé la piece {args.piece} ne peux pas etre posee ici...\n");
        }
    }
}
