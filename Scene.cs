using System.Text;

namespace terminal_graphics_engine;

// it is very worth-while noting that the appeared X and Y are flipped due to how multi-dimensional arrays are handled, so we account for that here
// this may make working with this incredibly annoying
public class Scene(int xSize, int ySize)
{
    readonly int XSize = ySize;
    readonly int YSize = xSize;

    public string GetRenderString(List<Sprite> sprites)
    {
        // Initialize the screen with empty spaces
        char[,] screen = new char[XSize,YSize];
        for (int i = 0; i < XSize; i++)
            for (int j = 0; j < YSize; j++)
                screen[i, j] = ' ';

        // Iterate over each sprite
        foreach (Sprite sprite in sprites)
        {
            int roundedX = (int)MathF.Round(sprite.Position.X);
            int roundedY = (int)MathF.Round(sprite.Position.Y);

            // Iterate over each character in the sprite's texture
            int targettedScreenX = roundedX;
            int targettedScreenY = roundedY;
            foreach (char targettedCharTex in sprite.Texture)
            {
                if (targettedCharTex == '\n')
                {
                    targettedScreenY++;
                    targettedScreenX = roundedX;
                    continue;
                }
                
                screen[targettedScreenY, targettedScreenX++] = targettedCharTex;
            }
        }

        // Convert the screen array to a string
        StringBuilder resultantRender = new();
        for (int i = 0; i < XSize; i++)
        {
            for (int j = 0; j < YSize; j++)
                resultantRender.Append(screen[i, j]);
            resultantRender.AppendLine();
        }

        return resultantRender.ToString();
    }
}
