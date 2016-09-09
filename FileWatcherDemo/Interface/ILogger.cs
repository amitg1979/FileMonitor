using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDemo
{
    public interface ILogger
    {
        void WritelogInfo(string message);
        void WritelogWaning(string message);
        bool LogInfoEnabled();
    }
}
