using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDemo
{
    public  class RuleFileRemain
    {

        public string filetype;
        public DateTime folderLastAccessTime;
        public DateTime lastFileAccessTime;
        public int expectedTimeLimit;

        private static Object thisLock = new Object();
        public static bool chekFileRemains(string filetype, DateTime folderLastAccessTime, DateTime lastFileAccessTime, int expectedTimeLimit)
        {
            lock (thisLock)
            {

                if (folderLastAccessTime.Subtract(lastFileAccessTime).TotalMilliseconds > expectedTimeLimit)
                {
                    return true;
                }
                return false;
            }
        }

      
    }
}
