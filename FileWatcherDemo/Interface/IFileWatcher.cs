using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDemo
{
    public interface IFileWatcher
    {
        void CreateFileWatcher(string filePath, string searchCriteria, bool includeSubfolder,int interval);
        void Start(int count);
        void Stop(int count);
        void Dispose();
    }
}
