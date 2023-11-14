using System;
using System.Threading;
class Program
{
    static int width = 50; //hur bret consolen ska vara
    static int height = 30; //hur lång consolen ska vara
    static int windowWidth; //hur bret consolen
    static int windowHeight;
    static bool keepPlaying = true;
    static bool gameRunning;
    static bool consoleSizeError = false;

    
    static void Main()
    {
        Console.CursorVisible = false; //gömmer cursor
        try
        {
            Initialize(); //Initializar spelet 
            LaunchScreen(); //vad som ska vissas i början
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
                    HandleInput(); //handlar spelarens input
                    Update(); //updaterar spelets status
                    Render(); //render spelets game scene
                    if (gameRunning)
                    {
                        Thread.Sleep(TimeSpan.FromMilliseconds(33)); //en delay på controllet game screen
                    }
                }
                if (keepPlaying)
                {
                    GameOverScreen(); //Ska vissa game over scene (jag gör allt i odning först)
                }
            }
            //om console är för stor eller för litten
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
            Console.CursorVisible = true; // vissar cursor
        }
    }
        static void Initialize()
    {
        //får consolens bred och högd
        windowWidth = Console.WindowWidth;
        windowHeight = Console.WindowHeight;
        //kollar om system är i window
        if (OperatingSystem.IsWindows())
        {
            // Kontrollera om fönstrets bredd är mindre än det önskadde bredden
            if (windowWidth < width && OperatingSystem.IsWindows())
            {
                // Ställ in fönstrets bredd till önskad bredd + 1
                windowWidth = Console.WindowWidth = width + 1;
            }
            
            // Kontrollera om fönsterhöjden är mindre än det önskadde höjden
            if (windowHeight < height && OperatingSystem.IsWindows())
            {   
                // samma här ställer in fönsterhöjden till önskad höjd + 1
                windowHeight = Console.WindowHeight = height + 1;
            }
            
            // Ställ in konsolbuffertens bredd och höjd till fönstrets bredd och höjd
            Console.BufferWidth = windowWidth;
            Console.BufferHeight = windowHeight;
        }
    }
    static void LaunchScreen()
    {
        Console.Clear();
        Console.WriteLine("Detta är ett bilspel.");
        Console.WriteLine();
        Console.WriteLine("Håll dig på vägen!");
        Console.WriteLine();
        Console.WriteLine("Använd A, W och D för att styra din hastighet.");
        Console.WriteLine();
        Console.Write("Tryck enter för att starta...");
        PressEnterToContinue();
    }
    static void InitializeScene()
    {

    }
    
    static void Render()
    {

    }
}




