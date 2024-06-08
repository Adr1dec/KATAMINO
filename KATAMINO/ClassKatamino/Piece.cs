namespace ClassKatamino
{
    /// <summary>
    /// Représente une pièce du jeu Katamino composée de plusieurs cases.
    /// </summary>

    public class Piece
    {
        /// <summary>
        /// Obtient ou définit le numéro de la pièce.
        /// </summary>
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }

        private int num;
        /// <summary>
        /// Obtient ou définit la liste des cases constituant la pièce.
        /// </summary>
        public List<Case> LPiece
        {
            get
            {
                return piece;
            }
            set
            {
                piece = value;
            }
        }

        private List<Case> piece = new();
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Piece"/> avec le numéro spécifié.
        /// </summary>
        /// <param name="numero">Le numéro de la pièce.</param>
        public Piece(int numero)
        {
            num = numero;
            definir(num);
        }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Piece"/>.
        /// </summary>
        public Piece()
        {
        }
        /// <summary>
        /// Définit les cases de la pièce en fonction de son numéro.
        /// </summary>
        /// <param name="num">Le numéro de la pièce.</param>
        /// <returns>Ne retourne rien</returns>
        private void definir(int num)
        {
            if (num == 1)
            {
                Case case1 = new Case(0, 0, "1");
                Case case2 = new Case(0, 1, "1");
                Case case3 = new Case(0, 2, "1");
                Case case4 = new Case(0, 3, "1");
                Case case5 = new Case(0, 4, "1");
                piece.Add(case1);
                piece.Add(case2);
                piece.Add(case3);
                piece.Add(case4);
                piece.Add(case5);
            }
            if (num == 2)
            {
                Case case6 = new Case(1, 0, "2");
                Case case7 = new Case(0, 0, "2");
                Case case8 = new Case(0, 1, "2");
                Case case9 = new Case(0, 2, "2");
                Case case10 = new Case(0, 3,"2");
                piece.Add(case6);
                piece.Add(case7);
                piece.Add(case8);
                piece.Add(case9);
                piece.Add(case10);
            }
            if (num == 3)
            {
                Case case11 = new Case(1, 0, "3");
                Case case12 = new Case(1, 1, "3");
                Case case13 = new Case(0, 1, "3");
                Case case14 = new Case(1, 2, "3");
                Case case15 = new Case(1, 3, "3");
                piece.Add(case11);
                piece.Add(case12);
                piece.Add(case13);
                piece.Add(case14);
                piece.Add(case15);
            }
            if (num == 4)
            {
                Case case16 = new Case(0, 0, "4");
                Case case17 = new Case(0, 1, "4");
                Case case18 = new Case(1, 1, "4");
                Case case19 = new Case(1, 2, "4");
                Case case20 = new Case(1, 3, "4");
                piece.Add(case16);
                piece.Add(case17);
                piece.Add(case18);
                piece.Add(case19);
                piece.Add(case20);
            }
            if (num == 5)
            {
                Case case21 = new Case(0, 0, "5");
                Case case22 = new Case(1, 0, "5");
                Case case23 = new Case(2, 0, "5");
                Case case24 = new Case(2, 1, "5");
                Case case25 = new Case(2, 2, "5");
                piece.Add(case21);
                piece.Add(case22);
                piece.Add(case23);
                piece.Add(case24);
                piece.Add(case25);
            }
            if (num == 6)
            {
                Case case26 = new Case(1, 0, "6");
                Case case27 = new Case(2, 0, "6");
                Case case28 = new Case(2, 1, "6");
                Case case29 = new Case(1, 1, "6");
                Case case30 = new Case(0, 1, "6");
                piece.Add(case26);
                piece.Add(case27);
                piece.Add(case28);
                piece.Add(case29);
                piece.Add(case30);
            }
            if (num == 7)
            {
                Case case31 = new Case(0, 0, "7");
                Case case32 = new Case(0, 1, "7");
                Case case33 = new Case(1, 1, "7");
                Case case34 = new Case(2, 1, "7");
                Case case35 = new Case(2, 0, "7");
                piece.Add(case31);
                piece.Add(case32);
                piece.Add(case33);
                piece.Add(case34);
                piece.Add(case35);
            }
            if (num == 8)
            {
                Case case36 = new Case(0, 0, "8");
                Case case37 = new Case(1, 0, "8");
                Case case38 = new Case(1, 1, "8");
                Case case39 = new Case(1, 2, "8");
                Case case40 = new Case(2, 2, "8");
                piece.Add(case36);
                piece.Add(case37);
                piece.Add(case38);
                piece.Add(case39);
                piece.Add(case40);
            }
            if (num == 9)
            {
                Case case41 = new Case(0, 0, "9");
                Case case42 = new Case(1, 0, "9");
                Case case43 = new Case(1, 1, "9");
                Case case44 = new Case(2, 1, "9");
                Case case45 = new Case(1, 2, "9");
                piece.Add(case41);
                piece.Add(case42);
                piece.Add(case43);
                piece.Add(case44);
                piece.Add(case45);
            }
            if (num == 10)
            {
                Case case46 = new Case(0, 0,"a");
                Case case47 = new Case(1, 0,"a");
                Case case48 = new Case(2, 0,"a");
                Case case49 = new Case(1, 1,"a");
                Case case50 = new Case(1, 2,"a");
                piece.Add(case46);
                piece.Add(case47);
                piece.Add(case48);
                piece.Add(case49);
                piece.Add(case50);
            }
            if (num == 11)
            {
                Case case51 = new Case(2, 0, "b");
                Case case52 = new Case(1, 0, "b");
                Case case53 = new Case(1, 1, "b");
                Case case54 = new Case(0, 1, "b");
                Case case55 = new Case(0, 2, "b");
                piece.Add(case51);
                piece.Add(case52);
                piece.Add(case53);
                piece.Add(case54);
                piece.Add(case55);
            }
            if (num == 12)
            {
                Case case56 = new Case(1, 0, "c");
                Case case57 = new Case(1, 1, "c");
                Case case58 = new Case(0, 1, "c");
                Case case59 = new Case(2, 1, "c");
                Case case60 = new Case(1, 2, "c");
                piece.Add(case56);
                piece.Add(case57);
                piece.Add(case58);
                piece.Add(case59);
                piece.Add(case60);
            }
        }
    }
    
}
   