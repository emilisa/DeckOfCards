namespace DeckOfCards
{
    using System;
    using System.Collections.Generic;
    
    public class Card
    {
        private string cardRank; // 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace
        private string suitName; // spades, hearts, diamonds, clubs
        private char suitSign; // ♠, ♥, ♦, ♣
        private ConsoleColor suitColor; // red, cyan, green, gray
        private int[,] cardPicture;

        private string CardRank
        {
            get { return this.cardRank; }

            set { this.cardRank = value; }
        }
        
        private string SuitName
        {
            get { return this.suitName; }

            set { this.suitName = value; }
        }

        /// <summary>
        /// This property inherits suitName string variable and converts it 
        /// in appropriate char sign coresponding with the suit
        /// Example: string suitName = spades, char suitSign = '♠'
        /// </summary>
        private char SuitSign
        {
            get { return this.suitSign; }
            set { 

                switch (suitName.ToLower())
                {
                    case "spades": this.suitSign = '♠'; break;
                    case "hearts": this.suitSign = '♥'; break;
                    case "diamonds": this.suitSign = '♦'; break;
                    case "clubs": this.suitSign = '♣'; break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// This property inherits suitName string variable and converts it 
        /// in appropriate color coresponding with the suit
        /// Example: string suitName = spades, ConsoleColor suitColor = Gray
        /// </summary>
        private ConsoleColor SuitColor
        {
            get { return this.suitColor; }

            set { this.suitColor = value;

                switch (suitName.ToLower())
                {
                    case "spades": this.suitColor = ConsoleColor.Gray;  break;
                    case "hearts": this.suitColor = ConsoleColor.Red; break;
                    case "diamonds": this.suitColor = ConsoleColor.Cyan; break;
                    case "clubs": this.suitColor = ConsoleColor.Green; break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// This property is used to save as matrix array the appropriate card picture
        /// The array consist of 10 numbers from 0 to 9
        /// Example:
        /// 0 = empty space sign ' '
        /// 1 = upper horizontal border sign u2580
        /// 2 = lower horizontal border sign u2584
        /// 3 = upper left vertical border sign  u258C
        /// 4 = upper right vertical border sign  u2590
        /// 5 = corner border sign  u2588
        /// 6 = free space in which CardRank and SuitSign are displayed
        /// 7 = free space in which Card Rank Name is displayed
        /// 8 = free space in which string "of" is displayed
        /// 9 = free space in which Card Suit Name is displayed
        /// </summary>
        private int[, ] CardPicture
        {
            get { return this.cardPicture; }

            set { this.cardPicture = new int[,] 
                                     {{5,1,1,1,1,1,1,1,1,1,1,1,1,5},
                                      {3,6,6,6,0,0,0,0,0,0,0,0,0,4},
                                      {3,0,5,1,1,1,1,1,1,1,1,5,0,4},
                                      {3,0,3,0,0,0,0,0,0,0,0,4,0,4},
                                      {3,0,3,0,7,7,7,7,7,0,0,4,0,4},
                                      {3,0,3,0,0,0,0,0,0,0,0,4,0,4},
                                      {3,0,3,0,0,0,0,0,0,0,0,4,0,4},
                                      {3,0,3,0,0,0,8,8,0,0,0,4,0,4},
                                      {3,0,3,0,0,0,0,0,0,0,0,4,0,4},
                                      {3,0,3,0,0,0,0,0,0,0,0,4,0,4},
                                      {3,0,3,9,9,9,9,9,9,9,9,4,0,4},
                                      {3,0,3,0,0,0,0,0,0,0,0,4,0,4},
                                      {3,0,5,2,2,2,2,2,2,2,2,5,0,4},
                                      {3,0,0,0,0,0,0,0,0,0,6,6,6,4},
                                      {5,2,2,2,2,2,2,2,2,2,2,2,2,5}};
            }
        }

        /// <summary>
        /// Card class constructor - accepts two parameters
        /// </summary>
        public Card(string cardRank, string suitName)
        {
            this.CardRank = cardRank;
            this.SuitName = suitName;
            this.SuitSign = suitSign;
            this.SuitColor = suitColor;
            this.CardPicture = cardPicture;
        }
        
        /// <summary>
        /// This method is used to draw (visualize) the card on the console
        /// Depending on cardPicture matrix members value it prints coresponding sign
        /// Example: 
        /// If certain cardPicture matrix members value is 1 it prints upperHorizontalBorder char
        /// upperHorizontalBorder is char with number (u2580) in windows charchter map
        /// If certain cardPicture matrix members value is 0 it prints emptySpace char 
        /// and etc.
        /// </summary>
        public void Show()
        {
            char emptySpace = ' ';
            char upperHorizontalBorder = '\u2580';
            char lowerHorizontalBorder = '\u2584';
            char leftVerticalBorder = '\u258C';
            char rightVerticalBorder = '\u2590';
            char cornerBorderSign = '\u2588';
            string of = "of";

            Console.ForegroundColor = suitColor;

            for (int row = 0; row < cardPicture.GetLength(0); row++)
            {
                int sixCount = 0;
                int sevenCount = 0;
                int eightCount = 0;
                int nineCount = 0;
                
                for (int col = 0; col < cardPicture.GetLength(0) - 1; col++)
                {
                    #region MainDrawLogic_With_SwitchCase_var1

                    switch (cardPicture[row, col])
                    {
                        case 0: Console.Write(emptySpace); break;
                        case 1: Console.Write(upperHorizontalBorder); break;
                        case 2: Console.Write(lowerHorizontalBorder); break;
                        case 3: Console.Write(leftVerticalBorder); break;
                        case 4: Console.Write(rightVerticalBorder); break;
                        case 5: Console.Write(cornerBorderSign); break;
                        case 6: 
                            Console.Write(ConcatCardRankSuitSign(row)[sixCount]);
                            sixCount++;
                            break;
                        case 7: 
                            Console.Write(ConcatCardRankName()[sevenCount]);
                            sevenCount++;
                            break;
                        case 8: 
                            Console.Write(of[eightCount]);
                            eightCount++;
                            break;
                        case 9:
                            Console.Write(ConcatSuitName()[nineCount]);
                            nineCount++;
                            break;
                        default: break; 
                    }

                    #endregion

                #region MainDrawLogic_With_IfElse_var2

                //    if (cardPicture[row, col] == 1)
                //    {
                //        Console.Write(upperHorizontalBorder);
                //    }

                //    else if (cardPicture[row, col] == 2)
                //    {
                //        Console.Write(lowerHorizontalBorder);
                //    }

                //    else if (cardPicture[row, col] == 3)
                //    {
                //        Console.Write(leftVerticalBorder);
                //    }

                //    else if (cardPicture[row, col] == 4)
                //    {
                //        Console.Write(rightVerticalBorder);
                //    }

                //    else if (cardPicture[row, col] == 5)
                //    {
                //        Console.Write(cornerBorderSign);
                //    }

                //    else if (cardPicture[row, col] == 6)
                //    {
                //        Console.Write(ConcatCardRankSuitSign(row)[sixCount]);
                //        sixCount++;
                //    }

                //    else if (cardPicture[row, col] == 7)
                //    {
                //        Console.Write(ConcatCardRankName()[sevenCount]);
                //        sevenCount++;
                //    }

                //    else if (cardPicture[row, col] == 8)
                //    {
                //        Console.Write(of[eightCount]);
                //        eightCount++;
                //    }

                //    else if (cardPicture[row, col] == 9)
                //    {
                //        Console.Write(ConcatSuitName()[nineCount]);
                //        nineCount++;
                //    }

                //    else if (cardPicture[row, col] == 0)
                //    {
                //        Console.Write(emptySpace);
                //    }

                #endregion

                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }

        /// <summary>
        /// This method returns concatenation between Card Rank string name and Suit Sign char
        /// also if the concatenated string lenght is to small it appends empty space
        /// This is used to optimize the new string center position on its proper location
        /// Location numbers 6 in cardPicture matrix
        /// </summary>
        private string ConcatCardRankSuitSign(int row)
        {
            string concatenation = cardRank + suitSign;

            if (concatenation.Length == 2 && row == 1)
            {
                concatenation = cardRank + suitSign + " ";
            }

            else if (concatenation.Length == 2 && row == 13)
            {
                concatenation = " " + cardRank + suitSign;
            }

            return concatenation;
        }

        /// <summary>
        /// This method returns concatenation between Card Rank string name and empty space
        /// if the Card Rank strin lenght is to small
        /// This is used to optimize the new string center position on its proper location
        /// Location numbers 7 in cardPicture matrix
        /// </summary>
        private string ConcatCardRankName()
        {
            string concatenation = CardRankToStringName();

            if (concatenation.Length == 3)
            {
                concatenation = " " + CardRankToStringName() + " ";
            }

            else if (concatenation.Length == 4)
            {
                concatenation = " " + CardRankToStringName();
            }

            return concatenation;
        }

        /// <summary>
        /// This method returns concatenation between Suit Name string and empty space
        /// if the Suit Name string lenght is to small
        /// This is used to optimize the new string center position on its proper location
        /// Location numbers 9 in cardPicture matrix
        /// </summary>
        private string ConcatSuitName()
        {
            string concatenation = suitName;

            if (concatenation.Length == 5)
            {
                concatenation = "  " + suitName + " ";
            }

            else if (concatenation.Length == 6)
            {
                concatenation = " " + suitName + " ";
            }

            return concatenation;
        }

        /// <summary>
        /// This method is used to convert char card rank in string card rank name
        /// Example: if char card rank = 'A', string card rank name = "Ace"
        /// </summary>
        private string CardRankToStringName()
        {
            string name = "";

            switch (cardRank)
            {
                case "A": name = "Ace"; break;
                case "K": name = "King"; break;
                case "Q": name = "Queen"; break;
                case "J": name = "Jack"; break;
                case "2": name = "Two"; break;
                case "3": name = "Three"; break;
                case "4": name = "Four"; break;
                case "5": name = "Five"; break;
                case "6": name = "Six"; break;
                case "7": name = "Seven"; break;
                case "8": name = "Eight"; break;
                case "9": name = "Nine"; break;
                case "10": name = "Ten"; break;
                default: break;
            }
            
            return name;
        }
    }
}
