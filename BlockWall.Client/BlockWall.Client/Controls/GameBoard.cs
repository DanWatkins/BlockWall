using Eto.Drawing;
using Eto.Forms;

namespace BlockWall.Client.Controls
{
    public class GameBoard : Scrollable
    {
        public GameBoard()
        {
            var drawable = new Drawable();

            drawable.Paint += (sender, args) =>
            {
                var rect = new RectangleF(drawable.ClientSize);

                args.Graphics.SaveTransform();
                args.Graphics.SetClip(new RectangleF(0, 0, 200, 200));
                args.Graphics.FillRectangle(Color.Parse("RED"), rect);
                args.Graphics.RestoreTransform();
            };

            Content = new StackLayout
            {
                Spacing = 10,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                Items = { new StackLayoutItem(drawable, true) }
            };
        }
    }
}