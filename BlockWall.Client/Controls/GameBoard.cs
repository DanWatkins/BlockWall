using Eto.Drawing;
using Eto.Forms;

namespace BlockWall.Client.Controls
{
    public class GameBoard : Drawable
    {
        private readonly Size _boardSizeTiles;
        private readonly Size _tileSizePx;
        private readonly int _spacing;
        private readonly int _border;

        public Color BaseColor { get; set; } = Colors.Black;

        public Color TileColor { get; set; } = Colors.Black;

        public Color GrooveColor { get; set; } = Colors.SaddleBrown;

        public GameBoard(Size boardSize, Size tileSize, int spacing, int border)
        {
            _boardSizeTiles = boardSize;
            _tileSizePx = tileSize;
            _spacing = spacing;
            _border = border;

            CreateBoard();
        }

        private void CreateBoard()
        {
            int boardWidthPx = _boardSizeTiles.Width * (_tileSizePx.Width + _spacing) - _spacing;
            int boardHeightPx = _boardSizeTiles.Height * (_tileSizePx.Height + _spacing) - _spacing;

            int baseWidthPx = boardWidthPx + _border * 2;
            int baseHeightPx = boardHeightPx + _border * 2;

            // update control size
            Width = baseWidthPx;
            Height = baseHeightPx;

            Paint += (sender, args) =>
            {
                var rect = new RectangleF(ClientSize);

                // draw the base
                args.Graphics.SaveTransform();
                args.Graphics.SetClip(new RectangleF(
                        0, 0,
                        baseWidthPx,
                        baseHeightPx));
                args.Graphics.FillRectangle(BaseColor, rect);

                //draw the grooves
                args.Graphics.SaveTransform();
                args.Graphics.SetClip(new RectangleF(
                        _border, _border,
                        boardWidthPx,
                        boardHeightPx));
                args.Graphics.FillRectangle(GrooveColor, rect);

                //draw the tiles
                for (int w = 0; w < _boardSizeTiles.Width; w++)
                {
                    for (int h = 0; h < _boardSizeTiles.Height; h++)
                    {
                        args.Graphics.SetClip(new RectangleF(
                                w * (_tileSizePx.Width + _spacing) + _border,
                                h * (_tileSizePx.Height + _spacing) + _border,
                                _tileSizePx.Width,
                                _tileSizePx.Height));
                        args.Graphics.FillRectangle(TileColor, rect); 
                    }
                }

                args.Graphics.RestoreTransform();
            };
        }
    }
}