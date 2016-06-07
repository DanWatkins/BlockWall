using BlockWall;
using BlockWall.Client.Desktop.Controls;
using Eto.Drawing;
using Eto.Forms;
using Eto.Serialization.Xaml;

namespace BlockWall.Client.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            XamlReader.Load(this);

            var board = Board.StandardBoard;
            board.InsertWall(new Wall
            {
                TilePosition = new Point(1, 2),
                Orientation = Orientation.Horizontal
            });
            board.InsertWall(new Wall
            {
                TilePosition = new Point(2, 2),
                Orientation = Orientation.Horizontal
            });
            board.InsertWall(new Wall
            {
                TilePosition = new Point(3, 2),
                Orientation = Orientation.Vertical
            });
            board.InsertWall(new Wall
            {
                TilePosition = new Point(3, 3),
                Orientation = Orientation.Horizontal
            });

            GameBoardStackLayout.Items.Add(new StackLayoutItem(
                    new BoardControl(board),
                    true));
        }
    }
}