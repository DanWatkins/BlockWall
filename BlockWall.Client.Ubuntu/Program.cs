using System;
using Eto;
using Eto.Forms;

namespace BlockWall.Client.Ubuntu
{
	public class Program
	{
		[STAThread]
		public static void Main (string[] args)
		{
			new Application (Platforms.Gtk2).Run (new MainForm ());
		}
	}
}
