using StructureMap;

namespace ContainerWebCoreTest.Services
{
    public interface IDummy { }
    public class Dummy : IDummy { }

    public interface IMyService
    {
        void DoWork();
    }

    public class MyService : IMyService
    {
        public IContainer Container { get; }

        public MyService(IContainer container)
        {
            Container = container;
        }

        public void DoWork()
        {
            var dummy = Container.GetInstance<IDummy>();
        }
    }
}