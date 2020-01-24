using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Texter
{
    class Board
    {
        private Tile[,] tiles;
        public int startingX;
        public int startingY;
        private int sizeX;
        private int sizeY;

        //double dimension specified
        public Board(string filePath, Game game)
        {
            System.IO.StreamReader streamReader;
            if (System.IO.File.Exists(@"../../../Levels/" + filePath + ".Txt"))
            {
                streamReader = new System.IO.StreamReader(@"../../../Levels/" + filePath + ".Txt");
            }
            else
            {
                game.Win();
                return;
            }

            string line;

            sizeX = 120;
            sizeY = 29;

            //initialize 2D array of tiles
            tiles = new Tile[120, 29];

            int counter = -1;

            while(true)
            {
                line = streamReader.ReadLine();
                if (line == null) break;
                counter++;

                for (int x = 0; x < line.Length; x++)
                {
                    tiles[x, counter] = new Tile(x, counter, line[x]);

                    if (tiles[x, counter].IsHero())
                    {
                        //set hero starting location X
                        startingX = x;

                        //set sizeX to the size of the X of the map
                        sizeX = line.Length;

                        //set hero starting location Y
                        startingY = counter;
                    }
                    else if (tiles[x, counter].IsArrowMonster())
                    {
                        int dirX = 0;
                        int dirY = 0;

                        //identify direction
                        if (line[x] == '\u25B2') dirY = -1;
                        else if (line[x] == '\u25BC') dirY = 1;
                        else if (line[x] == '\u25C4') dirX = -1;
                        else dirX = 1;

                        //create monster
                        ArrowMonster newArrowMonster = new ArrowMonster(x, counter, dirX, dirY);
                        game.AddArrowMoster(newArrowMonster);
                    }
                }
            }
            sizeY = counter + 1;

        }


        public void Draw()
        {
            string row;

            for (int i = 0; i < sizeY; i++)
            {
                //add rows
                row = "";

                for (int l = 0; l < sizeX; l++)
                {
                    if (tiles[l, i] != null)
                    {
                        if (tiles[l, i].GetChar() == ' ' || tiles[l, i].GetChar() == '▓')
                        {
                            //its a block or empty space
                            row += tiles[l, i].GetChar();
                        }
                        else if (tiles[l, i].IsArrowMonster())
                        {
                            //its a monster
                            Console.Write(row);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(tiles[l, i].GetChar());
                            Console.ForegroundColor = ConsoleColor.White;
                            row = "";
                        }
                        else if (tiles[l, i].IsPortal())
                        {
                            //its a portal
                            Console.Write(row);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(tiles[l, i].GetChar());
                            Console.ForegroundColor = ConsoleColor.White;
                            row = "";
                        }
                        else if (tiles[l, i].IsHero())
                        {
                            //its our hero
                            Console.Write(row);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(tiles[l, i].GetChar());
                            Console.ForegroundColor = ConsoleColor.White;
                            row = "";
                        }
                        else if (tiles[l, i].IsGoodie())
                        {
                            //its a goodie!
                            Console.Write(row);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(tiles[l, i].GetChar());
                            Console.ForegroundColor = ConsoleColor.White;
                            row = "";
                        }
                        else
                        {
                            //its just text
                            row += tiles[l, i].GetChar();
                        }
                    }
                }

                //write the row
                Console.WriteLine(row);
            }
        }

        public int GetSizeX()
        {
            return sizeX;
        }

        public int GetSizeY()
        {
            return sizeY;
        }

        public Tile GetTileAt(int x, int y)
        {
            return tiles[x, y];
        }

        public void SetTileAt(int x, int y, char newVal)
        {
            tiles[x, y].SetChar(newVal);
        }
    }
}
