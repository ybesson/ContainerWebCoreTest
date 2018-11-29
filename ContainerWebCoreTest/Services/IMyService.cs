using System;
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
            using (var disposable = new Disposable(Container))
            {

            }
            dummy = Container.GetInstance<IDummy>();
        }
    }

    public class Disposable : IDisposable
    {
        private readonly IContainer _container;

        public Disposable(IContainer container)
        {
            _container = container;
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}