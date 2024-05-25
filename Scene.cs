using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace terminal_graphics_engine;

public class Scene(int size)
{
    int Size = size;

    public string GetRenderString(List<Sprite> sprites)
    {
        // ultimtaely, the rendered screen is an array of characters
        // 2D for X and Y
        char[,] screen = new char[Size, Size];

        foreach (Sprite sprite in sprites)
        {
            for (int i = 0; i < sprite.Texture.Length; i++)
            {
                int targettedIndex = i;
                char currentSpriteCharTexture = sprite.Texture[i];

                // if the current texture index is one for the next line, we increment targettedInddex
                // this ultimately decides where the char should be drawn
                targettedIndex += (currentSpriteCharTexture == '\n') ? 1 : 0;

                int roundedSpriteX = (int)Math.Round(sprite.Position.X);
                int roundedSpriteY = (int)Math.Round(sprite.Position.Y) + targettedIndex;

                screen[roundedSpriteX, roundedSpriteY] = sprite.Texture[i];
            }

            for (int i = 0; i = Siz)
        }

        string resultantRender = string.Join(' ', screen);
        return resultantRender;
    }
}
