using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDemo
{
    public interface IRuleEngine
    {
        void UpdateDictionary(string NewFile, string folderName, string eventName, string folderPath, int interval);       
        void CheckFileRemain(FileDetails objFileDetails, DateTime LastFileAccessTime);
        void FileTimer(DateTime startTime, string folderName, int interval);
        void StopFileTimer();
    }
}
