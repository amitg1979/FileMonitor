
namespace FileWatcherDemo
{
    public class LoggerService
    {
        public static ILogger CreateLogger()
        {
            LightInject.ServiceContainer _container = new LightInject.ServiceContainer();
            _container.Register(typeof(ILogger), typeof(Logger));
            ILogger obj = _container.GetInstance<ILogger>();
            return obj;
        }
    }
}
