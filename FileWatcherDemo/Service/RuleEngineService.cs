namespace FileWatcherDemo
{
   public class RuleEngineService
    {
       public static IRuleEngine CreateInstance()
       {
           LightInject.ServiceContainer _container = new LightInject.ServiceContainer();
           _container.Register(typeof(IRuleEngine),typeof(RuleEngine));
           IRuleEngine obj = _container.GetInstance<IRuleEngine>();
           return obj;
       }      
    }
}
