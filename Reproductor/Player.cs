using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Reproductor
{
    class Player
    {
        private string Pcommand;
	    private bool isOpen;
		private bool isPlaying = false;
		
		[DllImport("winmm.dll")]
		private static extern long mciSendString(string strCommand,StringBuilder strReturn,int iReturnLength, IntPtr hwndCallback);
		
		public Player()
		{
		}
		
		public bool Reproduciendo()
		{
			return isPlaying;				
		}
		
		public void Close()
		{
			Pcommand = "close MediaFile";
			mciSendString(Pcommand, null, 0, IntPtr.Zero);
		      	isOpen=false;
			isPlaying=false;
		}

		public void Open(string sFileName)
			{
				Pcommand = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
				mciSendString(Pcommand, null, 0, IntPtr.Zero);
				isOpen = true;
			}

		public void Play(bool loop)
		{
			if(isOpen)
				if(isPlaying)
				{
					Pcommand = "pause MediaFile";
					mciSendString(Pcommand, null, 0, IntPtr.Zero);
					isPlaying = false;
				}				
				else
				{
					isPlaying = true;
					Pcommand = "play MediaFile";
					if (loop)
						Pcommand += " REPEAT";
						mciSendString(Pcommand, null, 0, IntPtr.Zero);
				}
		}
		
		public void Pause()
		{
			if(isOpen)
				if(isPlaying)
				{
					Pcommand = "pause MediaFile";
					mciSendString(Pcommand, null, 0, IntPtr.Zero);
					isPlaying = false;
				}
				else
				{
					isPlaying = true;
					mciSendString(Pcommand, null, 0, IntPtr.Zero);
				}
				
		}

    }
}
