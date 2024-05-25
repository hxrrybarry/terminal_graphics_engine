using System;

namespace terminal_graphics_engine;

internal class Program
{
    public static void Main()
    {
        Scene sc = new(100, 50);

        Sprite obj = new("#\n#\n#m", 10, 20);
        Sprite obj2 = new("#####", 10, 25);
        Sprite obj3 = new(" #\n#@#\n #", 25, 25);

        List<Sprite> spritesToRender = new();
        spritesToRender.Add(obj);
        spritesToRender.Add(obj2);
        spritesToRender.Add(obj3);

        string renderString = sc.GetRenderString(spritesToRender);

        Console.WriteLine(renderString);
    }
}