using AliasWebAPI.LL;

namespace AliasWebAPI.InternalServices
{
    public class LLFactory : ILLFactory
    {
        public T GetLL<T>() where T: class, ILL
        {
            return UnityContainerAdapter.Resolve<T>();
        }
    }
}
