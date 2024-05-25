namespace terminal_graphics_engine;

public class Sprite(string texture, float x, float y)
{
    public string Texture = texture;
    public Vector2 Position = new(x, y);
}
