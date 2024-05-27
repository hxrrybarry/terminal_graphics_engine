using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace terminal_graphics_engine;

public class SpritePart(char tex, Vector2 relativePosition)
{
    public char Texture = tex;
    public Vector2 Position = relativePosition;
}
