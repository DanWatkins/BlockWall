using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;

namespace BlockWall.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            XamlReader.Load(this);
            Content = new Controls.GameBoard(new Size(9,9), new Size(50,50), 10);
        }
    }
}