using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;
using System.Configuration;

namespace FileWatcherDemo
{
    public class Logger : ILogger
    {
        public log4net.ILog _log;
        private Object thisLock = new Object();
        public Logger()
        {
            lock (thisLock)
            {
                _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

                log4net.Config.XmlConfigurator.Configure();
            }
        }


        public void WritelogInfo(string message)
        {
            lock (thisLock)
            {
                _log.Info(message);
            }

        }

        public void WritelogWaning(string message)
        {
            lock (thisLock)
            {
                _log.Warn(message);
            }

        }

        public bool LogInfoEnabled()
        {
            lock (thisLock)
            {
                return _log.IsInfoEnabled;
            }
        }
    }
}
