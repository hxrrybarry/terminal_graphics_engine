namespace terminal_graphics_engine;

public class Sprite(string texture, float x, float y)
{
    public string Texture = texture;
    public Vector2 Position = new(x, y);
    public Vector2 BoundingBox = GetBoundingBox(texture);

    private static Vector2 GetBoundingBox(string tex)
    {
        string[] splitTexture = tex.Split('\n');

        // the max string length on the x componenent will always be the x bound
        int boundingX = splitTexture.Max(x => x.Length);
        // this just returns the y size, which will act as the y bound
        int boundingY = splitTexture.Length;

        return new Vector2(boundingX, boundingY);
    }
}
