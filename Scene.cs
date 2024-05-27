using System.Text;

namespace terminal_graphics_engine;

public class Scene(int xSize, int ySize)
{
    public readonly int XSize = ySize;
    public readonly int YSize = xSize;

    public string GetRenderString(List<Sprite> sprites)
    {
        // initialize the screen with empty spaces
        char[,] screen = new char[XSize,YSize];
        for (int i = 0; i < XSize; i++)
            for (int j = 0; j < YSize; j++)
                screen[i, j] = ' ';

        foreach (Sprite sprite in sprites)
        {
            int roundedX = (int)MathF.Floor(sprite.Position.X);
            int roundedY = (int)MathF.Floor(sprite.Position.Y);

            // iterate over each character in the sprite's texture
            foreach (SpritePart targettedSpritePart in sprite.Texture)
            {
                int targettedScreenX = roundedX + (int)MathF.Floor(targettedSpritePart.Position.X);
                int targettedScreenY = roundedY + (int)MathF.Floor(targettedSpritePart.Position.Y);

                // it is very worth-while noting that the appeared X and Y are flipped due to how multi-dimensional arrays are handled, so we account for that here
                // this may make working with this incredibly annoying
                // if you are looking and/or modifying this, please be VERY aware and careful of this principal - as it can completely obfuscate rendering if handled incorrectly
                screen[targettedScreenY, targettedScreenX] = targettedSpritePart.Texture;
            }
        }

        // convert the screen array to a string to be rendered
        StringBuilder resultantRender = new(XSize * YSize);
        for (int i = 0; i < XSize; i++)
        {
            for (int j = 0; j < YSize; j++)
                resultantRender.Append(screen[i, j]);
            resultantRender.AppendLine();
        }

        return resultantRender.ToString();
    }
}
