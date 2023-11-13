using System;
using System.Threading;
class Program
{
    static bool keepPlaying = true;
    static bool gameRunning;
    
    static void Main()
    {
        Console.CursorVisible = false;
        try
        {
            Initialize();
            LaunchScreen();
            while (keepPlaying)
            {
                InitializeScene();
                while (gameRunning)
                {
                if (Console.WindowHeight < height || Console.WindowWidth < width)
                    {
                        consoleSizeError = true;
                        keepPlaying = false;
                        break;
                    }
                    HandleInput();
                    Update();
                    Render();
                    if (gameRunning)
                    {
                        Thread.Sleep(TimeSpan.FromMilliseconds(33));
                    }
                }
                if (keepPlaying)
                {
                    GameOverScreen();
                }
            }
            Console.Clear();
            if (consoleSizeError)
            {
                Console.WriteLine("Console window är för liten.");
                Console.WriteLine($"Minimum storlek är {width} width x {height} height.");
                Console.WriteLine("Increase storleken du har");
            }
            Console.WriteLine("stänger ner");
        }
        finally
        {
            Console.CursorVisible = true;
        }
    }
}




