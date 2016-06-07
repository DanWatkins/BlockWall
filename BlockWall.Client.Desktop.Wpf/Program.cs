using System;
using BlockWall.Client.Desktop;
using Eto;
using Eto.Forms;

namespace BlockWall.Client.Desktop.Wpf
{
	public class Program
	{
		[STAThread]
		public static void Main (string[] args)
		{
			new Application (Platforms.Wpf).Run (new MainForm ());
		}
	}
}
