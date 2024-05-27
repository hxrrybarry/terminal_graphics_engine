using System;
using System.Text;

namespace terminal_graphics_engine;

internal class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Scene sc = new(250, 250);

        Sprite obj = new("#\n#\n#m", 10, 20);
        Sprite obj2 = new("#####", 10, 25);

        string playerTexture = File.ReadAllText(@"C:\Users\harib\source\repos\terminal_graphics_engine\smiley.txt");
        playerTexture = playerTexture.Replace("\r", "");

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

                Vector2 pivot = spritesToRender[2].Center;

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
                    case ConsoleKey.LeftArrow:
                        spritesToRender[2].Rotate(-0.05f, pivot); break;
                    case ConsoleKey.RightArrow:
                        spritesToRender[2].Rotate(0.05f, pivot); break;
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