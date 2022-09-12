using AliasWebAPI.LL;

namespace AliasWebAPI.InternalServices
{
    public interface ILLFactory
    {
        T GetLL<T>() where T : class, ILL;
    }
}
