using Unity;

namespace AliasWebAPI.InternalServices
{
    public class UnityContainerAdapter
    {
        private static IUnityContainer _unityContainer { get; set; }

        public UnityContainerAdapter(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public static T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }
    }
}
