using System;
using System.Collections.Generic;
using System.Text;

namespace Texter
{
    class Tile
    {
        private char text;
        private int x;
        private int y;

        public Tile(int newX, int newY, char newText)
        {
            x = newX;
            y = newY;
            text = newText;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public char GetChar()
        {
            return text;

        }
        public void SetChar(char newText)
        {
            text = newText;
        }

        public bool IsObstacle()
        {
            return (text == '▓');
        }

        public bool IsPortal()
        {
            return (text == '@');
        }

        public bool IsHero()
        {
            if (text >= 48 && text <= 58)
            {
                return true;
            }
            else return false;
        }

        public bool IsGoodie()
        {
            if (text == 'ѽ') return true;
            else return false;
        }

        public bool IsArrowMonster()
        {
            if (text == '\u25B2' || text == '\u25BA' || text == '\u25BC' || text == '\u25C4') return true;
            else return false;
        }
    }
}
