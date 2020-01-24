using System;
using System.Collections.Generic;
using System.Text;

namespace Texter
{
    class ArrowMonster
    {
        private bool visible;
        private bool alive;
        private int x;
        private int y;
        private int speed;
        private int timer;
        private int directionX;
        private int directionY;
        public ArrowMonster(int startingX, int startingY, int startingDirectionX, int startingDirectionY)
        {
            x = startingX;
            y = startingY;
            speed = 0;
            timer = 0;
            if (startingDirectionY != 0) speed = 1;
            directionX = startingDirectionX;
            directionY = startingDirectionY;
            alive = true;
            visible = true;
        }

        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public int GetDirectionX()
        {
            return directionX;
        }
        public int GetDirectionY()
        {
            return directionY;
        }
        public bool IsVisible()
        {
            return visible;
        }
        public bool IsAlive()
        {
            return alive;
        }
        public void Kill()
        {
            alive = false;
        }
        public void Revive()
        {
            alive = true;
        }
        public void MakeInvisible()
        {
            visible = false;
        }
        public void MakeVisible()
        {
            visible = true;
        }
        public void Move(Game game)
        {
            if (timer != speed)
            {
                timer++;
                return;
            }
            else
            {
                timer = 0;
            }

            int newX = x + directionX;
            int newY = y + directionY;

            //Are we within the bounds?
            if (game.GetBoard().GetTileAt(newX, newY).IsObstacle())
            {
                if (directionX != 0)
                {
                    directionX *= -1;
                    if (directionX == -1) game.GetBoard().SetTileAt(x, y, '\u25C4');
                    else game.GetBoard().SetTileAt(x, y, '\u25BA');
                }
                else
                {
                    directionY *= -1;
                    if (directionY == -1) game.GetBoard().SetTileAt(x, y, '\u25B2');
                    else game.GetBoard().SetTileAt(x, y, '\u25BC');
                }
                return;
            }
            else if(game.GetBoard().GetTileAt(newX, newY).IsHero())
            {
                //Are we hitting a hero?
                game.GetBoard().SetTileAt(newX, newY, game.GetBoard().GetTileAt(x, y).GetChar());
                game.GetBoard().SetTileAt(x, y, ' ');
                x = newX;
                y = newY;
                game.GetHero().TakeDamage(game);
                return;
            }

            //Nope its empty space, proceed as normal
            if (!game.GetBoard().GetTileAt(newX, newY).IsArrowMonster())
            {
                game.GetBoard().SetTileAt(newX, newY, game.GetBoard().GetTileAt(x, y).GetChar());
            }
            game.GetBoard().SetTileAt(x, y, ' ');
            x = newX;
            y = newY;
        }
    }
}
