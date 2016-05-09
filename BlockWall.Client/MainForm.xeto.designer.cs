using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eto.Forms;

namespace BlockWall.Client
{
    public partial class MainForm
    {
        private StackLayout GameBoardStackLayout { get; set; }

        private Label OpponentWallsLabel { get; set; }

        private Label PlayerWallsLabel { get; set; }
    }
}