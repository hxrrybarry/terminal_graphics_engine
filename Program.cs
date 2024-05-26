using System;
using System.Text;

namespace terminal_graphics_engine;

internal class Program
{
    public static void Main()
    {
        Scene sc = new(100, 50);

        Sprite obj = new("#\n#\n#m", 10, 20);
        Sprite obj2 = new("#####", 10, 25);

        string playerTexture = File.ReadAllText(@"C:\Users\harib\source\repos\terminal_graphics_engine\smiley.txt");

        Sprite obj3 = new(playerTexture, 25, 25);

        List<Sprite> spritesToRender = new();
        spritesToRender.Add(obj);
        spritesToRender.Add(obj2);
        spritesToRender.Add(obj3);
        string renderString = sc.GetRenderString(spritesToRender);
        Console.Write(renderString);

        // main loop
        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D:
                        if (spritesToRender[2].Position.X < sc.YSize - spritesToRender[2].BoundingBox.X)
                            spritesToRender[2].Position.X++; break;
                    case ConsoleKey.A:
                        if (spritesToRender[2].Position.X > 0)
                            spritesToRender[2].Position.X--; break;
                    case ConsoleKey.W:
                        if (spritesToRender[2].Position.Y > 0)
                            spritesToRender[2].Position.Y--; break;
                    case ConsoleKey.S:
                        if (spritesToRender[2].Position.Y < sc.XSize - spritesToRender[2].BoundingBox.Y)
                            spritesToRender[2].Position.Y++; break;
                }

                renderString = sc.GetRenderString(spritesToRender);
                Console.Clear();
                Console.Write(renderString);
            }
        }
    }
}