using System;

namespace terminal_graphics_engine;

internal class Program
{
    public static void Main()
    {
        Scene sc = new(50);

        Sprite batLeft = new("#\n#\n#\nm", 0, 0);

        List<Sprite> spritesToRender = new();
        spritesToRender.Add(batLeft);

        string renderString = sc.GetRenderString(spritesToRender);

        Console.WriteLine(renderString);
    }
}