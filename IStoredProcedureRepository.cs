using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comcept.Legacy.Core.Interfaces
{
    public interface IStoredProcedureRepository
    {
        Task<List<T>> ExecuteStoredProcedure<T>(string query, params object[] parameters) where T : class;
    }
}
