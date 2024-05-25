using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace terminal_graphics_engine;

public class Sprite(string texture, float x, float y)
{
    public string Texture = texture;
    public Vector2 Position = new(x, y);
}
