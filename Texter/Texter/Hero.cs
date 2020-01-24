using System;
using System.Collections.Generic;
using System.Text;

namespace Texter
{
    class Hero
    {
        private bool visible;
        private bool alive;
        private int x;
        private int y;
        private int level;

        public Hero(int startingX, int startingY, int startingLevel)
        {
            x = startingX;
            y = startingY;
            level = startingLevel;
            alive = true;
            visible = true;
        }

        public int GetLevel()
        {
            return level;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public void SetX(int newVal)
        {
            x = newVal;
        }
        public void SetY(int newVal)
        {
            y = newVal;
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
        public void LevelUp()
        {
            level += 1;
        }

        public void TakeDamage(Game game)
        {
            level--;
            if (level < 0)
            {
                game.Lose();
            }
            else
            {
                game.SetScore(0);
                game.RestartLevel();
            }
        }
        public void MoveTo(int newX, int newY, Game game)
        {
            //Are we within the bounds?
            if (game.GetBoard().GetTileAt(newX, newY).IsObstacle())
            {
                return;
            }
            else if (game.GetBoard().GetTileAt(newX, newY).IsGoodie())
            {
                level++;
            }
            else if (game.GetBoard().GetTileAt(newX, newY).IsArrowMonster())
            {
                if (level > 0)
                {
                    game.KillArrowMoster(newX, newY);
                }
                else
                {
                    TakeDamage(game);
                }
            }
            else if(game.GetBoard().GetTileAt(newX, newY).IsPortal())
            {
                game.NextLevel();
                return;
            }

            //Yes we are, lets move.
            game.GetBoard().SetTileAt(x, y, ' ');
            x = newX;
            y = newY;
            game.GetBoard().SetTileAt(x, y, (char)(level + 48));
        }

        public void MoveUp(Game game)
        {
            this.MoveTo(x, y - 1, game);
        }

        public void MoveDown(Game game)
        {
            this.MoveTo(x, y + 1, game);
        }

        public void MoveLeft(Game game)
        {
            this.MoveTo(x - 1, y, game);
        }

        public void MoveRight(Game game)
        {
            this.MoveTo(x + 1, y, game);
        }
    }
}
