using System;
using System.Collections.Generic;
using System.Windows.Forms;
//Here is the once-per-application setup information

namespace FileWatcherDemo
{
    static class Program
    {
        public static Dictionary<string, DateTime> FolderLastAccessTimeList = new Dictionary<string, DateTime>();
        //public static Dictionary<string, DateTime> FileCreationList = new Dictionary<string, DateTime>();
       // public static Dictionary<string, DateTime> FileRemainingList = new Dictionary<string, DateTime>();
        public static Dictionary<string, FileDetails> FileCreationList = new Dictionary<string, FileDetails>();

        public static Dictionary<string, FileDetails> FileRemainingList = new Dictionary<string, FileDetails>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1Ex());
        }
    }
}
