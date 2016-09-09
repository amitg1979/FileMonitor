using FileWatcher;

namespace FileWatcherDemo
{
    public class FileWatcherService
    {
        public static IFileWatcher CreateFileWatcher()
        {
            LightInject.ServiceContainer _container = new LightInject.ServiceContainer();
            _container.Register(typeof(IFileWatcher), typeof(WatcherEx));
            IFileWatcher obj = _container.GetInstance<IFileWatcher>();
            return obj;
        }
    }
}
