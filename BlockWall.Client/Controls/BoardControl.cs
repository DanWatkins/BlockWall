using Eto.Drawing;
using Eto.Forms;

namespace BlockWall.Client.Controls
{
    public class BoardControl : Drawable
    {
        private readonly Board _board;

        public Color BaseColor { get; set; } = Colors.Blue;

        public Color TileColor { get; set; } = Colors.Black;

        public Color GrooveColor { get; set; } = Colors.SaddleBrown;

        public BoardControl(Board board)
        {
            _board = board;

            InitializeBoard();
        }

        private void InitializeBoard()
        {
            int boardWidthPx = _board.Size.Width * (_board.TileSize.Width + _board.GrooveThickness) - _board.GrooveThickness;
            int boardHeightPx = _board.Size.Height * (_board.TileSize.Height + _board.GrooveThickness) - _board.GrooveThickness;

            int baseWidthPx = boardWidthPx + _board.BorderThickness * 2;
            int baseHeightPx = boardHeightPx + _board.BorderThickness * 2;

            //update control size
            Width = baseWidthPx;
            Height = baseHeightPx;

            Paint += (sender, args) =>
            {
                var rect = new RectangleF(ClientSize);

                //draw the base
                args.Graphics.SaveTransform();
                args.Graphics.SetClip(new RectangleF(
                        0, 0,
                        baseWidthPx,
                        baseHeightPx));
                args.Graphics.FillRectangle(BaseColor, rect);

                //draw the grooves
                args.Graphics.SaveTransform();
                args.Graphics.SetClip(new RectangleF(
                        _board.BorderThickness, _board.BorderThickness,
                        boardWidthPx,
                        boardHeightPx));
                args.Graphics.FillRectangle(GrooveColor, rect);

                //draw the tiles
                for (int w = 0; w < _board.Size.Width; w++)
                {
                    for (int h = 0; h < _board.Size.Height; h++)
                    {
                        args.Graphics.SetClip(new RectangleF(
                                w * (_board.TileSize.Width + _board.GrooveThickness) + _board.BorderThickness,
                                h * (_board.TileSize.Height + _board.GrooveThickness) + _board.BorderThickness,
                                _board.TileSize.Width,
                                _board.TileSize.Height));
                        args.Graphics.FillRectangle(TileColor, rect); 
                    }
                }

                args.Graphics.RestoreTransform();
            };
        }
    }
}