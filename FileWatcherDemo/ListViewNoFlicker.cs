﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileWatcherDemo
{
	//////////////////////////////////////////////////////////////////////////////////////
	/// <summary>
	/// This class provides a non-flickering ListView.  A heartfelt "thank you" goes to 
	/// stormenet on StackOverflow.
	/// </summary>
	public class ListViewNoFlicker : System.Windows.Forms.ListView
	{
		//--------------------------------------------------------------------------------
		public ListViewNoFlicker()
		{
			// Activate double buffering
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

			// Enable the OnNotifyMessage event so we get a chance to filter out 
			// Windows messages before they get to the form's WndProc
			this.SetStyle(ControlStyles.EnableNotifyMessage, true);
		}

		//--------------------------------------------------------------------------------
		protected override void OnNotifyMessage(Message m)
		{
			// Filter out the WM_ERASEBKGND message
			if (m.Msg != 0x14)
			{
				base.OnNotifyMessage(m);
			}
		}

	}
}
