using System.Text;

namespace terminal_graphics_engine;

// it is very worth-while noting that the appeared X and Y are flipped due to how multi-dimensional arrays are handled, so we account for that here
// this may make working with this incredibly annoying
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

            // iterate over each character in the sprite's texture
            int targettedScreenX = roundedX;
            int targettedScreenY = (int)MathF.Floor(sprite.Position.Y);
            foreach (char targettedCharTex in sprite.Texture)
            {
                if (targettedCharTex == '\n')
                {
                    targettedScreenY++;
                    targettedScreenX = roundedX;
                    continue;
                }

                // this can be used to prevent overlap on sprites where the character is a space
                // instead of rendering a space as a character, we instead just increment x position at which the next character should be rendered
                if (targettedCharTex == ' ')
                    targettedScreenX++;          
                else  
                    screen[targettedScreenY, targettedScreenX++] = targettedCharTex;
            }
        }

        // convert the screen array to a string to be rendered
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
