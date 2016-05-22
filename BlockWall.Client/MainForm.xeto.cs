using BlockWall.Client.Controls;
using Eto.Drawing;
using Eto.Forms;
using Eto.Serialization.Xaml;

namespace BlockWall.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            XamlReader.Load(this);

            GameBoardStackLayout.Items.Add(new StackLayoutItem(
                    new BoardControl(Board.StandardBoard),
                    true));
        }
    }
}