﻿using System;
using System.Threading;

//De här är Bil spel som har en infinity loop (spelet tar aldrig slut) och det händer nya grejer hela tiden
class Program
{
    static int width = 50; //hur bret consolen ska vara
    static int height = 30; //hur lång consolen ska vara
    static int windowWidth; //hur bret consolen
    static int windowHeight;
    static int carPosition; // Vart bilen ska vara någonstans
    static int carSpeed; 
    static char[,] scene; // 2D-array för att representera spelscenen
    static bool keepPlaying = true; //om man vill fortsätta spela
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
                    GameOverScreen(); //Ska vissa game over scene (ska göra koden till det här vid slutet)
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
        Console.WriteLine("Detta är ett bilspel Gjort av Rofus.");
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
        const int roadWidth = 10; // Vägens bredd
        gameRunning = true;
        carPosition = width / 2; // Bilens utgångsläge
        carSpeed = 0; // Initial hastighet av bilen
        int leftEdge = (width - roadWidth) / 2; // Vänster kant av vägen
        int rightEdge = leftEdge + roadWidth + 1; // Höger kanten av vägen
        scene = new char[height, width]; // Initiera spelscenen https://stackoverflow.com/questions/3106110/what-is-move-semantics/3109981#3109981
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                if (x < leftEdge || x > rightEdge)
                {
                    scene[x, y] = '.'; // Ritar vägen
                }
                else
                {
                    scene[x, y] = ' '; // Draw the empty space som man kan åka på
                }
            }
        }
    }
    
    static void Render()
    {

    }


    static void GameOverScreen()
    {
        Console.Clear();
        Console.WriteLine("Game Over");
        Console.WriteLine("Score: {score}");
        Console.WriteLine("Play again (Y/N)?");
    }
