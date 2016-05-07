using Eto.Drawing;
using Eto.Forms;

namespace BlockWall.Client.Controls
{
    public class GameBoard : Scrollable
    {
        private readonly Size _boardSize;
        private readonly Size _tileSize;
        private readonly int _spacing;
        private readonly Drawable _drawable;

        public GameBoard(Size boardSize, Size tileSize, int spacing)
        {
            _boardSize = boardSize;
            _tileSize = tileSize;
            _spacing = spacing;
            _drawable = CreateBoard();

            Content = new StackLayout
            {
                Spacing = 10,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                Items = { new StackLayoutItem(_drawable, true) }
            };
        }

        private Drawable CreateBoard()
        {
            var drawable = new Drawable();

            drawable.Paint += (sender, args) =>
            {
                var rect = new RectangleF(drawable.ClientSize);

                args.Graphics.SaveTransform();
                args.Graphics.SetClip(new RectangleF(
                    0, 0,
                    _boardSize.Width * (_tileSize.Width + _spacing) - _spacing,
                    _boardSize.Height * (_tileSize.Height + _spacing) - _spacing));
                args.Graphics.FillRectangle(Color.Parse("Gray"), rect);

                for (int w = 0; w < _boardSize.Width; w++)
                {
                    for (int h = 0; h < _boardSize.Height; h++)
                    {
                        args.Graphics.SetClip(new RectangleF(
                            w * (_tileSize.Width + _spacing),
                            h * (_tileSize.Height + _spacing),
                            _tileSize.Width,
                            _tileSize.Height));
                        args.Graphics.FillRectangle(Color.Parse("White"), rect); 
                    }
                }


                args.Graphics.RestoreTransform();
            };

            return drawable;
        }
    }
}