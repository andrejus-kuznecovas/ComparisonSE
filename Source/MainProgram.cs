﻿using CSE.Source;
using System;
using System.Windows.Forms;

namespace CSE
{
    static class MainProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          /*  if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            } 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            */
            ImgRecogn obj = new ImgRecogn();
            obj.ImageToText();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
