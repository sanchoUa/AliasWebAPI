using AliasWebAPI.InternalServices;

namespace AliasWebAPI.DAL
{
    interface IBaseDAL
    {
        SqlQueryService SqlQueryServiceFactory();
    }
}
