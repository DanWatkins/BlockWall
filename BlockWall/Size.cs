using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockWall
{
    public class Size
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public static Size operator +(Size size, int amount)
        {
            return new Size(size.Width + amount, size.Height + amount);
        }
    }
}
