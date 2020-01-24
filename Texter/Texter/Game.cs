using System;
using System.Collections.Generic;
using System.Text;

namespace Texter
{
    class Game
    {
        private Board board;
        private bool over;
        private Hero hero;
        private LinkedList<ArrowMonster> arrowMonsters;
        private int level;
        private int score;
        private bool won;

        public Game()
        {
            level = 1;
            this.Start();
            score = 0;
        }

        public Board GetBoard()
        {
            return board;
        }

        public void AddArrowMoster(ArrowMonster arrowMonster)
        {
            arrowMonsters.AddLast(arrowMonster);
        }
        public void KillArrowMoster(int x, int y)
        {
            for (LinkedListNode<ArrowMonster> arrowMonster = arrowMonsters.First; arrowMonster != null; arrowMonster = arrowMonster.Next)
            {
                if (arrowMonster.Value.GetX() == x && arrowMonster.Value.GetY() == y)
                {
                    arrowMonsters.Remove(arrowMonster);
                    score += 10;
                }
            }
        }
        public int GetScore()
        {
            return score;
        }

        public void Start()
        {
            Console.Clear();
            over = false;
            arrowMonsters = new LinkedList<ArrowMonster>();
            board = new Board("level" + level, this);
            hero = new Hero(board.startingX, board.startingY, 0);
        }
        public void RestartLevel()
        {
            this.Start();
        }

        public void Update()
        {
            for (LinkedListNode<ArrowMonster> arrowMonster = arrowMonsters.First; arrowMonster != null; arrowMonster = arrowMonster.Next)
            {
                if (arrowMonster.Value.GetDirectionX() == 0)
                {
                    arrowMonster.Value.Move(this);
                }
                else
                {
                    arrowMonster.Value.Move(this);
                }
            }
        }

        public void NextLevel()
        {
            score += level * 10;
            level++;
            this.Start();
        }

        public bool Won()
        {
            return won;
        }

        public void Win()
        {
            won = true;
            over = true;
        }
        public void Lose()
        {
            won = false;
            over = true;
        }

        public Hero GetHero()
        {
            return hero;
        }

        public bool IsOver()
        {
            return over;
        }
        public void SetScore(int newScore)
        {
            score = newScore;
        }
    }
}
