using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ResumeApplication.ForbiddenIsland
{
    class GameBoard
    {
        List<Tile> Board;

        public GameBoard()
        {
            using (StreamReader sr = new StreamReader("TileNames.txt"))
            {
                string fileContents = sr.ReadLine();
                while (fileContents != "|")
                {
                    Board.Add(new Tile(fileContents));
                    fileContents = sr.ReadLine();
                }
            }

            ShuffleTiles();
            ShuffleTiles();
            SetTileLocations();
        }

        private void ShuffleTiles()
        {
            for (int i = 0; i <= Board.Count(); i++)
            {
                Random rand = new Random();
                int randomNum = rand.Next(i, Board.Count());
                Tile temp = Board[i];
                Board[i] = Board[randomNum];
                Board[randomNum] = temp;
            }
        }

        private void SetTileLocations()
        {
            int[] tileNumbers = new int[] { 13, 14, 22, 23, 24, 25, 31, 32, 33, 34, 35, 36, 41, 42, 43, 44, 45, 46, 52, 53, 54, 55, 63, 64 };
            for (int i = 0; i <= Board.Count(); i++)
            {
                Board[i].setLocation(tileNumbers[i]);
            }
        }
    }
}
