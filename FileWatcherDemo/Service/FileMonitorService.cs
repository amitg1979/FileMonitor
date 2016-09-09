using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDemo
{
   public  class FileMonitorService
    {

       public static IFileMonitor CreateFolderWatcher()
      {

          LightInject.ServiceContainer _container = new LightInject.ServiceContainer();
          _container.Register(typeof(IFileMonitor),typeof(FileMonitor));
          IFileMonitor obj = _container.GetInstance<IFileMonitor>();
          return obj;
      }
    }
    
}
