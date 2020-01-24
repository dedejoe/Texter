using System;
using System.Diagnostics;
using System.Threading;

namespace Texter
{
    class Runtime
    {
        static void Main(string[] args)
        {
            bool gameRunning = true;
            Console.SetWindowSize(100, 40);
            Game game = new Game();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //editor.OutputTemplate("C:\\Users\\josep\\Desktop\\test.txt");
            Console.WriteLine("Press any key to start playing...");

            ConsoleKeyInfo response = Console.ReadKey();

            //Clear startup message for game
            Console.Clear();

            //Keep Program Running Smoothly by locking up when holding down a key
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (gameRunning)
            {
                //Draw the board
                stopwatch.Stop();
                if (stopwatch.ElapsedMilliseconds > 50)
                {
                    //Update the Game State
                    game.Update();

                    //Draw the Game
                    Console.SetCursorPosition(0, 0);
                    game.GetBoard().Draw();

                    //Display Score
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Score: " + game.GetScore());
                    Console.ForegroundColor = ConsoleColor.White;
                    stopwatch.Reset();
                    stopwatch.Start();
                }
                else
                {
                    stopwatch.Start();
                }

                //Read keypress
                if (Console.KeyAvailable)
                {
                    response = Console.ReadKey();

                    //Take action based on keypress
                    switch (response.Key)
                    {
                        case ConsoleKey.Escape:
                            gameRunning = false;
                            Environment.Exit(0);
                            break;
                        case ConsoleKey.F2:
                            game.Start();
                            break;
                        case ConsoleKey.UpArrow:
                            game.GetHero().MoveUp(game);
                            break;
                        case ConsoleKey.DownArrow:
                            game.GetHero().MoveDown(game);
                            break;
                        case ConsoleKey.LeftArrow:
                            game.GetHero().MoveLeft(game);
                            break;
                        case ConsoleKey.RightArrow:
                            game.GetHero().MoveRight(game);
                            break;
                    }
                }

                if (game.IsOver())
                {
                    if (Console.CursorTop > 0) {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                    }
                    if (game.Won())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You won!  Your final score was: " + game.GetScore());
                    }
                    else if (!game.Won())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You lost!  Your final score was: " + game.GetScore());
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                    Console.WriteLine("Press any key to start playing again...");
                    response = Console.ReadKey();
                    game = new Game();
                }

            }
        }

    }
}
