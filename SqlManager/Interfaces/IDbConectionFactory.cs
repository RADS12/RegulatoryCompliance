using System.Data;

namespace SqlManager.Interfaces
{
    public interface IDbConectionFactory
    {
        IDbConnection CreateConnection();
    }
}
