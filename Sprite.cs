namespace terminal_graphics_engine;

public class Sprite(string texture, float x, float y)
{
    public SpritePart[] Texture = GetTexture(texture);
    public Vector2 Position = new(x, y);
    public Vector2 BoundingBox = GetBoundingBox(GetTexture(texture));

    public void Rotate(float angleRadians, Vector2 pivot)
    {
        SpritePart[] newTexture = new SpritePart[Texture.Length];

        for (int i = 0; i < Texture.Length; i++)
        {
            SpritePart texturePart = Texture[i];
            Vector2 oldPosition = texturePart.Position;

            oldPosition -= pivot;

            float newX = oldPosition.X * MathF.Cos(angleRadians) - oldPosition.Y * MathF.Sin(angleRadians);
            float newY = oldPosition.Y * MathF.Cos(angleRadians) + oldPosition.X * MathF.Sin(angleRadians);

            Vector2 newPosition = new(newX, newY);
            SpritePart newTexturePart = new(texturePart.Texture, newPosition);
            newTexture[i] = newTexturePart;
        }

        Texture = newTexture;
        BoundingBox = GetBoundingBox(newTexture);
    }

    public Vector2 Center
    {
        get
        {
            // we can calculate the center of the sprite by just getting the average of the two components
            float centerX = Texture.Average(part => part.Position.X);
            float centerY = Texture.Average(part => part.Position.Y);

            return new Vector2(centerX, centerY);
        }    
    }

    public static Vector2 GetBoundingBox(SpritePart[] tex)
    {
        // the max string length on the x componenent will always be the x bound
        float boundingX = tex.Max(x => x.Position.X);
        // this just returns the y size, which will act as the y bound
        float boundingY = tex.Max(y => y.Position.Y);

        return new Vector2(boundingX, boundingY);
    }

    public static SpritePart[] GetTexture(string tex)
    {
        List<SpritePart> spriteParts = new();

        int targettedSpriteX = 0;
        int targettedSpriteY = 0;
        foreach (char c in tex)
        {
            if (c == '\n')
            {
                targettedSpriteX = 0;
                targettedSpriteY++;
                continue;
            }

            spriteParts.Add(new SpritePart(c, new Vector2(targettedSpriteX, targettedSpriteY)));
            targettedSpriteX++;
        }

        return spriteParts.ToArray();
    }
}
