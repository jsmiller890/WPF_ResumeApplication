using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ResumeApplication.ForbiddenIsland
{
    class Deck
    {
        string name;
        List<Card> cards;
        List<Card> disCards;

        public Deck(string name)
        {
            this.name = name;
            StackDeck();
        }

        private void StackDeck()
        {
            switch (name)
            {
                case "FloodDeck":
                    using (StreamReader sr = File.OpenText("TileNames.txt"))
                    {
                        string fileContents = sr.ReadLine();
                        while (fileContents != "||")
                        {
                            if (fileContents == "|")
                            {
                                fileContents = sr.ReadLine();
                                continue;
                            }
                            cards.Add(new Card(fileContents));
                            fileContents = sr.ReadLine();
                        }
                    }
                    break;

                case "ItemDeck":
                    using (StreamReader sr = File.OpenText("ItemNames.txt"))
                    {
                        string fileContents = sr.ReadLine();
                            while (fileContents != "|")
                            {
                                cards.Add(new Card(fileContents));
                                fileContents = sr.ReadLine();
                            }
                    }
                    break;
                default:
                    break;
            }
        }

        public Card DrawCard()
        {
            if(cards.Count() == 0)
            {
                Shuffle(disCards);
                Shuffle(disCards);
                cards = disCards;
                disCards.Clear();
            }
            return cards[0];
        }

        public void Shuffle(List<Card> c)
        {
            for(int i = 0; i <= cards.Count(); i++)
            {
                Random rand = new Random();
                int randomNum = rand.Next(i, c.Count());
                Card temp = c[i];
                c[i] = c[randomNum];
                c[randomNum] = temp;
            }
        }

        public void DiscardCard(Card c)
        {
            disCards.Add(c);
        }
    }
}
