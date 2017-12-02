using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozma_BlackJack
{
    class Program
    {

        static int cardValue(string cards)
        {
            if (cards.Contains("Ace"))
            {
                return 11;
            }
            else if (cards.Contains("King") || cards.Contains("Queen") || cards.Contains("Jack") || cards.Contains("Ten"))
            {
                return 10;
            }
            else if (cards.Contains("Nine"))
            {
                return 9;
            }
            else if (cards.Contains("Eight"))
            {
                return 8;
            }
            else if (cards.Contains("Seven"))
            {
                return 7;
            }
            else if (cards.Contains("Six"))
            {
                return 6;
            }
            else if (cards.Contains("Five"))
            {
                return 5;
            }
            else if (cards.Contains("Four"))
            {
                return 4;
            }
            else if (cards.Contains("Three"))
            {
                return 3;
            }
            else if (cards.Contains("Two"))
            {
                return 2;
            }
            else
            {
                return 0;
            }
        } //Converts string numbers to int numbers

        static void Main(string[] args)
        {

            Random random = new Random();

            const int BLACKJACK = 21; //Constant to determine Blackjack or bust
            const int SOFT = 16; //Constant for dealer to hit card if card total is less than 16

            //To store the value of the player's cards Ex. 2
            int player_value1,
              player_value2,
              player_value3,
              player_value4,
              player_value5,
              player_value6;

            //To store the value of the dealer's cards Ex. 3
            int dealer_value1,
              dealer_value2,
              dealer_value3,
              dealer_value4,
              dealer_value5;

            int playertotal; //To hold the value of cards player has
            int dealertotal; //To hold the value of cards dealer has

            //Strings to hold different suits + numbers
            string[] cards = new string[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            string[] suits = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };

            //To store the player's cards Ex. "Two"
            string player_card1,
                player_card2,
                player_card3,
                player_card4,
                player_card5,
                player_card6;

            //To store the dealer's cards Ex. "Three"
            string dealer_card1,
                dealer_card2,
                dealer_card3,
                dealer_card4,
                dealer_card5;
    
            string hit; //To store hit or stand input

            //Dealer's cards//
            dealer_card1 = cards[random.Next(12)]; //Picks and stores dealers first card number
            Console.WriteLine("Dealer's hand:\n" + dealer_card1 + " of " + suits[random.Next(3)]); // Shows dealer's first card + suit
            dealer_value1 = (cardValue(dealer_card1)); // Assigns value of card drawn

            dealer_card2 = cards[random.Next(12)]; // + " of " + suits[random.Next(3)]; //Picks and stores dealer's second card number ///REMEBER TO ADD SUIT COLOR AT END/////
            Console.WriteLine("Card face down \n"); // Hides dealer's second card
            dealer_value2 = (cardValue(dealer_card2)); // Assigns value of card drawn


            //Player's cards//
            player_card1 = (cards[random.Next(12)]); //Picks and stores player's first card number
            Console.WriteLine("Player's hand:\n" + player_card1 + " of " + suits[random.Next(3)]); //Shows player's first card + suit
            player_value1 = (cardValue(player_card1)); // Assigns value of card drawn
            if (player_card1 == "Ace") //If player draws an ace, do this:
            {
                Console.Write("Would you like to use the Ace as a 1 or 11:"); //Ask what to use ace as
                player_card1 = Console.ReadLine(); //Stores input
                Console.WriteLine(""); //Skip line
                if ((player_card1 == "11") || (player_card1 == "eleven")) //if player chooses 11, assign 11 to card
                {
                    player_value1 = 11;
                }
                else if ((player_card1 == "1") || (player_card1 == "one")) //If player chooses 1, assign 1 to card
                {
                    player_value1 = 1;
                }
                //If player inputs something other than 1 or 11, do this
                while ((player_card1 != "1") || (player_card1 != "11") || (player_card1 != "one") || (player_card1 != "eleven")) 
                {
                    Console.WriteLine("Invalid input.");
                    Console.Write("Would you like to use the Ace as a 1 or 11:");
                    player_card1 = Console.ReadLine(); //Stores input
                    Console.WriteLine("");
                }
            }

            player_card2 = cards[random.Next(12)]; ; //Picks and stores player's second card number
            Console.Write(player_card2 + " of " + suits[random.Next(3)] + "\n\n"); //Shows player's second card + suit
            player_value2 = (cardValue(player_card2)); // Assigns value of card drawn
            if (player_card2 == "Ace") //If player draws an ace, do this:
            {
                Console.Write("Would you like to use the Ace as a 1 or 11:"); //Ask what to use ace as
                player_card2 = Console.ReadLine(); //Stores input
                Console.WriteLine(""); //Skip line
                if ((player_card2 == "11") || (player_card2 == "eleven")) //if player chooses 11, assign 11 to card
                {
                    player_value2 = 11;
                }
                else if ((player_card2 == "1") || (player_card2 == "one")) //If player chooses 1, assign 1 to card
                {
                    player_value2 = 1;
                }
                //If player inputs something other than 1 or 11, do this
                while ((player_card2 != "1") || (player_card2 != "11") || (player_card2 != "one") || (player_card2 != "eleven"))
                {
                    Console.WriteLine("Invalid input.");
                    Console.Write("Would you like to use the Ace as a 1 or 11:");
                    player_card2 = Console.ReadLine(); //Stores input
                    Console.WriteLine("");
                }
            }

            playertotal = player_value1 + player_value2; //Adds up player's current hand
            Console.WriteLine("You have " + playertotal + ".\n"); //Outputs player's total

            Console.Write("HIT? (H for HIT, S for STAND): "); // Asks Player to hit or stand
            hit = Console.ReadLine(); // Stores input
            Console.WriteLine("");

            //If player puts in any input other than stand or hit, do this:
            while ((hit != "S") && (hit != "H") && (hit != "h") && (hit != "s"))
            {
                Console.WriteLine("Please enter a valid input.");
                Console.Write("HIT? (H for HIT, S for STAND): "); // Asks Player to hit or stand
                hit = Console.ReadLine(); // Stores input
                Console.WriteLine("");
            }

            //If player has choosen to hit, do this:
            if ((hit == "H") || (hit == "h"))
            {
                player_card3 = cards[random.Next(12)]; //Picks and stores player's third card number
                Console.Write(player_card3 + " of " + suits[random.Next(3)] + "\n\n"); //Shows player's third card + suit
                player_value3 = (cardValue(player_card3)); //Assigns value of card drawn
                if (player_card3 == "Ace") //If player draws an ace, do this:
                {
                    Console.Write("Would you like to use the Ace as a 1 or 11:"); //Ask what to use ace as
                    player_card3 = Console.ReadLine(); //Stores input
                    Console.WriteLine(""); //Skip line
                    if ((player_card3 == "11") || (player_card3 == "eleven")) //if player chooses 11, assign 11 to card
                    {
                        player_value3 = 11;
                    }
                    else if ((player_card3 == "1") || (player_card3 == "one")) //If player chooses 1, assign 1 to card
                    {
                        player_value3 = 1;
                    }
                    //If player inputs something other than 1 or 11, do this
                    while ((player_card3 != "1") || (player_card3 != "11") || (player_card3 != "one") || (player_card3 != "eleven"))
                    {
                        Console.WriteLine("Invalid input.");
                        Console.Write("Would you like to use the Ace as a 1 or 11:");
                        player_card3 = Console.ReadLine(); //Stores input
                        Console.WriteLine("");
                    }
                }
                playertotal = player_value1 + player_value2 + player_value3; //Adds up player's total
                Console.WriteLine("You have " + playertotal + "."); // Outputs player's total

                if (playertotal == BLACKJACK) //If player has hit blackjack, output:
                {
                    Console.WriteLine("You have hit Blackjack!\n");
                }
                else if (playertotal > BLACKJACK) //If player has gone over 21, output:
                {
                    Console.WriteLine("You have busted over 21.\n\n");
                }
                else if (playertotal < BLACKJACK) //If player has less than 21, output:
                {
                    Console.Write("HIT? (H for HIT, S for STAND): "); // Asks Player to hit or stand
                    hit = Console.ReadLine(); // Stores input
                    Console.WriteLine("");
                    
                    //If player puts in any input other than stand or hit, do this:
                    while ((hit != "S") && (hit != "H") && (hit != "s") && (hit != "h"))
                    {
                        Console.WriteLine("Please enter a valid input.");
                        Console.Write("HIT? (H for HIT, S for STAND): "); // Asks Player to hit or stand
                        hit = Console.ReadLine(); // Stores input
                        Console.WriteLine("");
                    }

                    if ((hit == "H") || (hit == "h"))
                    {
                        player_card4 = cards[random.Next(12)]; //Picks and stores player's fourth card number
                        Console.Write(player_card4 + " of " + suits[random.Next(3)] + "\n\n"); //Shows player's fourth card + suit
                        player_value4 = (cardValue(player_card4)); //Assigns value of card drawn
                        if (player_card4 == "Ace") //If player draws an ace, do this:
                        {
                            Console.Write("Would you like to use the Ace as a 1 or 11:"); //Ask what to use ace as
                            player_card4 = Console.ReadLine(); //Stores input
                            Console.WriteLine(""); //Skip line
                            if ((player_card4 == "11") || (player_card4 == "eleven")) //if player chooses 11, assign 11 to card
                            {
                                player_value4 = 11;
                            }
                            else if ((player_card4 == "1") || (player_card4 == "one")) //If player chooses 1, assign 1 to card
                            {
                                player_value4 = 1;
                            }
                            //If player inputs something other than 1 or 11, do this
                            while ((player_card4 != "1") || (player_card4 != "11") || (player_card4 != "one") || (player_card4 != "eleven"))
                            {
                                Console.WriteLine("Invalid input.");
                                Console.Write("Would you like to use the Ace as a 1 or 11:");
                                player_card4 = Console.ReadLine(); //Stores input
                                Console.WriteLine("");
                            }
                        }
                        playertotal = player_value1 + player_value2 + player_value3 + player_value4; //Adds up player's total
                        Console.WriteLine("You have " + playertotal + "."); // Outputs player's total

                        if (playertotal == BLACKJACK)
                        {
                            Console.WriteLine("You have hit Blackjack!\n");
                        }
                        else if (playertotal > BLACKJACK)
                        {
                            Console.WriteLine("You have busted over 21.\n\n");
                        }
                        else if (playertotal < BLACKJACK)
                        {
                            Console.Write("HIT? (H for HIT, S for STAND): "); // Asks Player to hit or stand
                            hit = Console.ReadLine(); // Stores input
                            Console.WriteLine("");

                            //If player puts in any input other than stand or hit, do this:
                            while ((hit != "S") && (hit != "H") && (hit != "s") && (hit != "h"))
                            {
                                Console.WriteLine("Please enter a valid input.");
                                Console.Write("HIT? (H for HIT, S for STAND): "); // Asks Player to hit or stand
                                hit = Console.ReadLine(); // Stores input
                                Console.WriteLine("");
                            }

                            if ((hit == "H") || (hit == "h"))
                            {
                                player_card5 = cards[random.Next(12)]; //Picks and stores player's fifth card number
                                Console.Write(player_card5 + " of " + suits[random.Next(3)] + "\n\n"); //Shows player's fifth card + suit
                                player_value5 = (cardValue(player_card5)); //Assigns value of card drawn
                                if (player_card5 == "Ace") //If player draws an ace, do this:
                                {
                                    Console.Write("Would you like to use the Ace as a 1 or 11:"); //Ask what to use ace as
                                    player_card5 = Console.ReadLine(); //Stores input
                                    Console.WriteLine(""); //Skip line
                                    if ((player_card5 == "11") || (player_card5 == "eleven")) //if player chooses 11, assign 11 to card
                                    {
                                        player_value5 = 11;
                                    }
                                    else if ((player_card5 == "1") || (player_card5 == "one")) //If player chooses 1, assign 1 to card
                                    {
                                        player_value5 = 1;
                                    }
                                    //If player inputs something other than 1 or 11, do this
                                    while ((player_card5 != "1") || (player_card5 != "11") || (player_card5 != "one") || (player_card5 != "eleven"))
                                    {
                                        Console.WriteLine("Invalid input.");
                                        Console.Write("Would you like to use the Ace as a 1 or 11:");
                                        player_card5 = Console.ReadLine(); //Stores input
                                        Console.WriteLine("");
                                    }
                                }
                                playertotal = player_value1 + player_value2 + player_value3 + player_value4 + player_value5; //Adds up player's total
                                Console.WriteLine("You have " + playertotal + "."); // Outputs player's total

                                if (playertotal == BLACKJACK)
                                {
                                    Console.WriteLine("You have hit Blackjack!\n");
                                }
                                else if (playertotal > BLACKJACK)
                                {
                                    Console.WriteLine("You have busted over 21.\n\n");
                                }
                                else if (playertotal < BLACKJACK)
                                {
                                    Console.Write("HIT? (H for HIY, S for STAND): "); // Asks Player to hit or stand
                                    hit = Console.ReadLine(); // Stores input
                                    Console.WriteLine("");

                                    //If player puts in any input other than stand or hit, do this:
                                    while ((hit != "S") && (hit != "H") && (hit != "s") && (hit != "h"))
                                    {
                                        Console.WriteLine("Please enter a valid input.");
                                        Console.Write("HIT? (H for HIT, S for STAND): "); // Asks Player to hit or stand
                                        hit = Console.ReadLine(); // Stores input
                                        Console.WriteLine("");
                                    }

                                    if ((hit == "H") || (hit == "h"))
                                    {
                                        player_card6 = cards[random.Next(12)]; //Picks and stores player's sixth card number
                                        Console.Write(player_card6 + " of " + suits[random.Next(3)] + "\n\n"); //Shows player's sixth card + suit
                                        player_value6 = (cardValue(player_card6)); //Assigns value of card drawn
                                        playertotal = player_value1 + player_value2 + player_value3 + player_value4 
                                            + player_value5 + player_value6; //Adds up player's total
                                        Console.WriteLine("You have " + playertotal + 
                                            ", but you have gone over 5 cards, you have lost."); // Outputs player's total
                                    }
                                    else if ((hit == "S") || (hit == "s")) //If player has choosen to stand, do this:
                                    {
                                        Console.WriteLine("You have chosen to stand at a score of " + playertotal + ".\n");
                                    }
                                } //End if player has less than 21 statement
                            } //End if player chooses to hit statement
                            else if ((hit == "S") || (hit == "s")) //If player has choosen to stand, do this:
                            {
                                Console.WriteLine("You have chosen to stand at a score of " + playertotal + ".\n");
                            }
                        } //End if player has less than 21 statement
                    }  //End if player chooses to hit statement
                    else if ((hit == "S") || (hit == "s")) //If player has choosen to stand, do this:
                    {
                        Console.WriteLine("You have chosen to stand at a score of " + playertotal + ".\n");
                    }
                } //End if player has less than 21 statement
            } //End if player chooses to hit statement  
            else if ((hit == "S") || (hit == "s")) //If player has choosen to stand, do this:
            {
                Console.WriteLine("You have chosen to stand at a score of " + playertotal + ".\n");
            }
            
            ////If player hasn't busted, dealer's turn, do this:////
            if (playertotal <= 21) 
            {
                dealertotal = dealer_value1 + dealer_value2; //Add dealer's total
                Console.Write("The dealer has a total of " + dealertotal + ". "); //Output total

                //If the dealer has 16 or more, do this:
                if (dealertotal >= SOFT)
                {
                    Console.WriteLine("The dealer must stand."); //Output dealer stands

                    if (dealertotal > playertotal) //If dealer is higher than player, do this:
                    {
                        Console.WriteLine("The dealer has the higher hand, you lose. \n\n");
                    }
                    else if (dealertotal < playertotal) //If dealer has less than player, do this:
                    {
                        Console.WriteLine("You have won! \n\n");
                    }
                    else if (dealertotal == playertotal) //If dealer is equal to player, do this:
                    {
                        Console.WriteLine("The dealer and you have the same total, the round has resulted in a push. \n\n");
                    }
                }
                
                //If player is higher than dealer and dealer has less than 16, do this:
                else if ((playertotal > dealertotal) && (dealertotal < SOFT))
                {
                    dealer_card3 = cards[random.Next(12)]; //Picks and stores dealer's third card number
                    Console.Write("The dealer must hit. \n" + dealer_card3 + " of " 
                        + suits[random.Next(3)] + "\n\n"); //Shows dealer's third card + suit
                    dealer_value3 = (cardValue(dealer_card3)); //Assigns value of card drawn
                    dealertotal = dealer_value1 + dealer_value2 + dealer_value3; //Adds up dealer's total
                    Console.WriteLine("The dealer has a total of " + dealertotal + "."); // Outputs dealer's total

                    if ((dealertotal > playertotal) && (dealertotal <= BLACKJACK)) //If dealer is higher than player and hasn't bust, do this:
                    {
                        Console.WriteLine("The dealer has the higher hand, you lose. \n\n");
                    }
                    else if ((dealertotal == playertotal) && (dealertotal >= SOFT)) //If dealer has 16 or more and is equal to player, do this:
                    {
                        Console.WriteLine("The dealer and you have the same total, the round has resulted in a push. \n\n");
                    }
                    else if((dealertotal >= SOFT) && (dealertotal < playertotal)) //If dealer has 16 or more and is less than player, do this:
                    {
                        Console.WriteLine("The dealer must stand, you have won the hand! \n");
                    }
                    else if (dealertotal > BLACKJACK) //If dealer has more than 21, do this:
                    {
                        Console.WriteLine("The dealer has busted, you win! \n");
                    }
                    else if ((dealertotal < playertotal) && (dealertotal < SOFT)) //If dealer has less than player and less than 16, do this:
                    {
                        dealer_card4 = cards[random.Next(12)]; //Picks and stores dealer's fourth card number
                        Console.Write("The dealer must hit. \n" + dealer_card4 + " of "
                            + suits[random.Next(3)] + "\n\n"); //Shows dealer's fourth card + suit
                        dealer_value4 = (cardValue(dealer_card4)); //Assigns value of card drawn
                        dealertotal = dealer_value1 + dealer_value2 + dealer_value3 + dealer_value4; //Adds up dealer's total
                        Console.WriteLine("The dealer has a total of " + dealertotal + "."); // Outputs dealer's total

                        if ((dealertotal > playertotal) && (dealertotal <= BLACKJACK)) //If dealer's total is more than player and hasn't bust, do this:
                        {
                            Console.WriteLine("The dealer has the higher hand, you lose. \n\n");
                        }
                        else if ((dealertotal == playertotal) && (dealertotal >= SOFT)) //If dealer is equal to player with 16 or more, do this:
                        {
                            Console.WriteLine("The dealer and you have the same total, the round has resulted in a push. \n\n");
                        }
                        else if ((dealertotal >= SOFT) && (dealertotal < playertotal)) //If dealer is 16 or higher and less than player, do this:
                        {
                            Console.WriteLine("The dealer must stand, you have won the hand! \n");
                        }
                        else if (dealertotal > BLACKJACK) //If dealer has higher than 21, do this:
                        {
                            Console.WriteLine("The dealer has busted, you win! \n");
                        }
                        else if ((dealertotal < playertotal) && (dealertotal < SOFT)) //If dealer is lower than player and 16, do this:
                        {
                            dealer_card5 = cards[random.Next(12)]; //Picks and stores dealer's fifth card number
                            Console.Write("The dealer must hit. \n" + dealer_card5 + " of "
                                + suits[random.Next(3)] + "\n\n"); //Shows dealer's fifth card + suit
                            dealer_value5 = (cardValue(dealer_card5)); //Assigns value of card drawn
                            dealertotal = dealer_value1 + dealer_value2 + dealer_value3 + dealer_value4 + dealer_value5; //Adds up dealer's total
                            Console.WriteLine("The dealer has a total of " + dealertotal + "."); // Outputs dealer's total

                            if ((dealertotal > playertotal) && (dealertotal <= BLACKJACK)) //If dealer has more than player and hasn't busted, do this:
                            {
                                Console.WriteLine("The dealer has the higher hand, you lose. \n\n");
                            }
                            else if ((dealertotal == playertotal) && (dealertotal >= SOFT)) //If dealer is equal to player with 16 or more, do this:
                            {
                                Console.WriteLine("The dealer and you have the same total, the round has resulted in a push. \n\n");
                            }
                            else if ((dealertotal >= SOFT) && (dealertotal < playertotal)) //If dealer is 16 or higher, but less than player, do this:
                            {
                                Console.WriteLine("The dealer must stand, you have won the hand! \n");
                            }
                            else if (dealertotal > BLACKJACK) //If dealer has gone over 21, do this:
                            {
                                Console.WriteLine("The dealer has busted, you win! \n");
                            }
                        } //End if dealer has less than player and less than 16 statement
                    } //End if dealer has less than player and less than 16 statement
                } //End if dealer has less than player and less than 16 statement
            } //End if player hasn't busted statement
            Console.ReadLine();//So I don't have to press CTRL + F5 every time
        } //End Main
    } //End Class
}