using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Reproductor
{
    class Player
    {
        private string Pcommand;
	    private bool isOpen;
		private bool isPlaying = false;
        private ulong Lng;
		
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
		    isOpen = false;
			isPlaying = false;
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

        public void Seek(ulong Millisecs, ulong Lng)
        //Permite reproducir una cancion a partir del desplazamiento de la trackbar.
        {
            if (isOpen && Millisecs <= Lng)
            {
                    if (!isPlaying)
                    {
                            Pcommand = String.Format("seek MediaFile to {0}", Millisecs);
                            mciSendString(Pcommand, null, 0, IntPtr.Zero);
                    }
                    else
                    {
                        Pcommand = String.Format("seek MediaFile to {0}", Millisecs);
                        mciSendString(Pcommand, null, 0, IntPtr.Zero);
                        Pcommand = "play MediaFile";
                        mciSendString(Pcommand, null, 0, IntPtr.Zero);
                    }
            }
        }

        public ulong CurrentPosition
        {
            get
            {
                if (isOpen)
                {
                    StringBuilder s = new StringBuilder(128);
                    Pcommand = "status MediaFile position";
                    mciSendString(Pcommand, s, 128, IntPtr.Zero);
                    return Convert.ToUInt64(s.ToString());
                }
                else return 0;
            }
        }

        private void CalculateLength()
        {        
            StringBuilder str = new StringBuilder(128);
            mciSendString("status MediaFile length", str, 128, IntPtr.Zero);
            Lng = Convert.ToUInt64(str.ToString());        
        }
                
        public ulong AudioLength    
        {            
            get 
            {
                if (isOpen)
                {
                    CalculateLength();
                    return Lng;
                }
                else return 0;
            }
        }

    }
}
