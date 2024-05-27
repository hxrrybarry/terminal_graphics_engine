using System;
using System.Text;

namespace terminal_graphics_engine;

internal class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Scene sc = new(125, 125);

        // Sprite obj = new("#\n#\n#m", 10, 20);
        // Sprite obj2 = new("#####", 10, 25);

        string playerTexture = File.ReadAllText(@"C:\Users\harib\source\repos\terminal_graphics_engine\piece1.txt");
        playerTexture = playerTexture.Replace("\r", "");

        Sprite obj = new(playerTexture, 20, 20);

        List<Sprite> spritesToRender = new();
        spritesToRender.Add(obj);
        // spritesToRender.Add(obj2);
        // spritesToRender.Add(obj3);
        string renderString = sc.GetRenderString(spritesToRender);
        Console.Write(renderString);

        // main loop
        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                Vector2 pivot = spritesToRender[0].Center;
                // Vector2 pivot = new(0, 0);

                switch (key)
                {
                    case ConsoleKey.D:
                        if (spritesToRender[0].Position.X < sc.YSize - spritesToRender[0].BoundingBox.X)
                            spritesToRender[0].Position.X++; break;
                    case ConsoleKey.A:
                        if (spritesToRender[0].Position.X > 0)
                            spritesToRender[0].Position.X--; break;
                    case ConsoleKey.W:
                        if (spritesToRender[0].Position.Y > 0)
                            spritesToRender[0].Position.Y--; break;
                    case ConsoleKey.S:
                        if (spritesToRender[0].Position.Y < sc.XSize - spritesToRender[0].BoundingBox.Y)
                            spritesToRender[0].Position.Y++; break;
                    case ConsoleKey.LeftArrow:
                        spritesToRender[0].Rotate(-0.05f, pivot); break;
                    case ConsoleKey.RightArrow:
                        spritesToRender[0].Rotate(0.05f, pivot); break;
                }

                try
                {
                    renderString = sc.GetRenderString(spritesToRender);
                } catch { }
                
                Console.SetCursorPosition(0, 0);
                Console.Write(renderString);
            }
        }
    }
}