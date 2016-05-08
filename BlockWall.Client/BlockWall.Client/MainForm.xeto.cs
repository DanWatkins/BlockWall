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

            MainScrollable.Content = new StackLayout
            {
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                Items =
                {
                    new StackLayoutItem(
                    new Controls.GameBoard(new Size(9, 7), new Size(50, 50), 10, 30),
                    true)
                }
            };
            Width = 1024;
            Height = 768;
        }
    }
}