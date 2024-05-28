using System;
using System.Text;

namespace terminal_graphics_engine;

internal class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Scene sc = new(100, 54);

        string playerTexture = File.ReadAllText(@"C:\Users\HarrisonO’Leary\Source\Repos\terminal_graphics\piece1.txt");
        playerTexture = playerTexture.Replace("\r", "");

        string clockFace = File.ReadAllText(@"C:\Users\HarrisonO’Leary\Source\Repos\terminal_graphics\clcok-face.txt");
        clockFace = clockFace.Replace("\r", "");

        const string secondHand = "####";
        const string hour = "@@";

        Sprite clock = new(clockFace, 40, 40, false);
        Sprite handSecond = new(secondHand, 61, 46);
        Sprite hourHand = new(hour, 61, 46);

        Sprite obj = new(playerTexture, 30, 30);

        string cross = File.ReadAllText(@"C:\Users\HarrisonO’Leary\Source\Repos\terminal_graphics\line.txt");
        cross = cross.Replace("\r", "");

        Sprite crossHair = new(cross, 65, 30);

        List<Sprite> spritesToRender = new();
        spritesToRender.Add(clock);
        spritesToRender.Add(handSecond);
        spritesToRender.Add(hourHand);
        spritesToRender.Add(obj);
        spritesToRender.Add(crossHair);

        string renderString = sc.GetRenderString(spritesToRender);
        Console.Write(renderString);

        Vector2 pivot = new(0, 0);

        // main loop
        while (true)
        {
            spritesToRender[1].Rotate(0.05f, pivot);
            spritesToRender[2].Rotate(0.0025f, pivot);
            spritesToRender[3].Rotate(0.025f, spritesToRender[3].Center);

            spritesToRender[4].Rotate(0.05f, spritesToRender[4].Center);

            try
            {
                renderString = sc.GetRenderString(spritesToRender);
            }
            catch { }

            Console.SetCursorPosition(0, 0);
            Console.Write(renderString);

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                // Vector2 pivot = spritesToRender[0].Center;
                

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

                
            }

            Thread.Sleep(20);
        }
    }
}