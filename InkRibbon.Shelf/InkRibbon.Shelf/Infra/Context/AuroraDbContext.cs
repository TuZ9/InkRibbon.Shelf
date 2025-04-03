using InkRibbon.Shelf.Application.Static;
using Npgsql;
using System.Data;

namespace InkRibbon.Shelf.Infra.Context
{
    public class AuroraDbContext : IDisposable
    {

        public AuroraDbContext()
        {
        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(RunTimeConfig.Auroraconnection);

        public void Dispose()
        {
        }
    }
}