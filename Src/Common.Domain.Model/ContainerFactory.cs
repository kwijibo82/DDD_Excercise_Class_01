using Unity;

namespace Common.Domain.Model
{
    public static class ContainerFactory
    {
        private static IUnityContainer Container;

        public static void EnsureContainer()
        {
            if(Container == null)
            {
                Container = new UnityContainer();
            }
        }

        public static void RegisterAsSingleton<TInterface,TInstance>() where TInstance : TInterface
        {
            Container.RegisterSingleton<TInterface, TInstance>();
        }

        public static TInterface Resolve<TInterface>()
        {
            return Container.Resolve<TInterface>();
        }
    }
}
