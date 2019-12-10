using System.Collections.Generic;
using System.Threading.Tasks;
using Comcept.Legacy.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Comcept.Legacy.Infrastructure.Data.Repositories
{
    public class CMSClientRepository : IStoredProcedureRepository
    {
        private readonly IConnectionStringService _connectionStringService;

        public CMSClientRepository(IConnectionStringService connectionStringService)
        {
            _connectionStringService = connectionStringService;
        }

        public async Task<List<T>> ExecuteStoredProcedure<T>(string query, params object[] parameters) where T : class
        {
            var optionsBuilder = new DbContextOptionsBuilder<CMSClientContext>();
            var connectionString = await _connectionStringService.GetConnectionString();

            optionsBuilder.UseSqlServer(connectionString);

            await using var context = new CMSClientContext(optionsBuilder.Options);

            return await context.Set<T>().FromSqlRaw(query, parameters).ToListAsync();
        }
    }
}
