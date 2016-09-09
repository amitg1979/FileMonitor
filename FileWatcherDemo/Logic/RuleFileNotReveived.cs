using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDemo
{
    public class RuleFileNotReceived
    {
        public string filetype;
        public DateTime currentTime;
        public int expectedTimeLimit;
        private static Object thisLock = new Object();
        public static bool chekFileNotReceived(string filetype, DateTime fileLastAccessTime, DateTime FileCreationTime, int expectedTimeLimit)
        {
            lock (thisLock)
            {
                if (fileLastAccessTime.Subtract(FileCreationTime).TotalMilliseconds > expectedTimeLimit)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
