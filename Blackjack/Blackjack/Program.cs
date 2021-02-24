using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }
        void Start()
        {
            List<CardItself> Deck = new List<CardItself>();
            List<CardItself> BlackDeck = new List<CardItself>();
            GenerateDeck(ref Deck);
            string userinput = " ";
            
            
            int BJScore = InitHand(ref Deck,ref BlackDeck);
            
            
            while (userinput!="stop")
            {
                if(CardCounter(BJScore)==false)
                {
                    
                    break;
                }
                Console.WriteLine("Do you want to draw a card??(go/stop)");
                userinput = Console.ReadLine();
                if(userinput=="go")
                {
                    BJScore = BJScore + DrawACard(ref Deck,ref BlackDeck);
                    Console.WriteLine("Current score : {0}",BJScore);

                }
                else if(userinput=="stop")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Do you want to draw a card??(go/stop)");
                    userinput = Console.ReadLine();
                }

            }
            if (CardCounter(BJScore) == false)
            {
                Console.WriteLine("You have more than 21 points, player loses table wins.");

            }
            else
            {
               
                Console.WriteLine("Now we will see the table's hand");
                List<CardItself> BlackDeck2 = new List<CardItself>();
                int BJScore1 = InitHand(ref Deck, ref BlackDeck2);
                userinput = "";
                while (userinput != "stop")
                {
                    if (CardCounter(BJScore1) == false)
                    {

                        break;
                    }
                    Console.WriteLine("Do you want to draw a card??(go/stop)");
                    userinput = Console.ReadLine();
                    if (userinput == "go")
                    {
                        BJScore1 = BJScore1 + DrawACard(ref Deck, ref BlackDeck2);
                        Console.WriteLine("Current score : {0}", BJScore1);

                    }
                    else if (userinput == "stop")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Do you want to draw a card??(go/stop)");
                        userinput = Console.ReadLine();

                    }
                }

                    if(CardCounter(BJScore1)==false)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\nPlayer wins");
                        Console.ResetColor();
                        
                    }
                    else
                    {
                        if(BJScore>BJScore1)
                        {
                            Console.ForegroundColor=ConsoleColor.Green;
                            Console.WriteLine("\n\nPlayer wins");
                            Console.ResetColor();
                            
                        }
                        else if(BJScore1>BJScore)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\nTable wins");
                            Console.ResetColor();
                            
                        }
                    }

                

            }








            Console.ReadKey();

            

        }
        int InitHand(ref List<CardItself> Deck,ref  List<CardItself> Blackdeck)
        {
            Random rnd = new Random();
            int something1 = rnd.Next(0, 52);
            int something2 =rnd.Next(0, 52);
           while(Blackdeck.Contains(Deck[something1]))
            {
                something1 = rnd.Next(0, 52);

            }
            while (Blackdeck.Contains(Deck[something2]))
            {
                something2 = rnd.Next(0, 52);
            }
            Blackdeck.Add(Deck[something1]);
            Blackdeck.Add(Deck[something2]);

            int card1= Calculator(Deck[something1].Cardno);
            int card2 = Calculator(Deck[something2].Cardno);
            Console.WriteLine("You have  {0} / {1}  and {2} / {3} ",Deck[something1].type,Deck[something1].Cardno,Deck[something2].type,Deck[something2].Cardno);
            
            
            int overallScore = card1 + card2;
            Console.WriteLine("Your overall point is : {0} ", overallScore);
            return overallScore;
        }
        int DrawACard(ref List <CardItself>Deck,ref List<CardItself>Blackdeck)
        {
            Random rnd = new Random();
            int location = rnd.Next(0, 52);
            while (Blackdeck.Contains(Deck[location]))
            {
              location = rnd.Next(0, 52);
                
            }
            Blackdeck.Add(Deck[location]);
            int card = Calculator(Deck[location].Cardno);
            Console.WriteLine("You have drawn {0} {1}",Deck[location].type,Deck[location].Cardno );
            return card;


        }
        int Calculator(CardNo c)
        {
            int answer = 0;
            if(c==CardNo.Ace)
            {
                
                Console.WriteLine("You have an Ace is it 1 or 10");
                 answer = int.Parse(Console.ReadLine());
                while(!(answer==10||answer==1))
                {
                    Console.WriteLine("Don't be a bastard pick a normal value(1/10)");
                    answer = int.Parse(Console.ReadLine());
                }
                return answer;
            }
           else if(c==CardNo.Jock)
            {
                 answer = 10;
                return answer;
            }
          else  if ((c == CardNo.Jock|| c == CardNo.Queen)|| c == CardNo.King)
            {
                 answer = 10;
                return answer;
            }
            else if (c == CardNo.Two)
            {
                 answer = 2;
                return answer;
            }
            else if (c == CardNo.Three)
            {
                 answer = 3;
                return answer;
            }
            else if (c == CardNo.Four)
            {
                 answer = 4;
                return answer;
            }
            else if (c == CardNo.Five)
            {
                 answer = 5;
                return answer;
            }
            else if (c == CardNo.Six)
            {
                answer = 6;
                return answer;
            }
            else if (c == CardNo.Seven)
            {
                 answer = 7;
                return answer;
            }
            else if (c==CardNo.Eight)
            {
                 answer = 8;
                return answer;
            }
            else if (c==CardNo.Nine)
            {
                 answer = 9;
                return answer;
            }
            else if(c==CardNo.Ten)
            {
                 answer = 10;
                return answer;
            }
            return answer;
            

        }

        void GenerateDeck(ref List <CardItself>Deck)
        {
            Random rnd = new Random();


            for (int i = 0; i < 52; i++)
            {
                CardItself tempcard = new CardItself();
                tempcard.Cardno = (CardNo)rnd.Next(1, 14);
                tempcard.type = (CardType)rnd.Next(1, 5);
                while (Deck.Contains(tempcard))
                {
                    tempcard.Cardno = (CardNo)rnd.Next(1, 14);
                    tempcard.type = (CardType)rnd.Next(1, 5);

                }
                Deck.Add(tempcard);
            }
        }
        bool CardCounter(int GeneralScore)
        {
            bool BJ;
           
             if(GeneralScore<=21)
            {
                BJ = true;
            }
            else
            {
                BJ = false;
            }
            return BJ;
        }
    }
}
