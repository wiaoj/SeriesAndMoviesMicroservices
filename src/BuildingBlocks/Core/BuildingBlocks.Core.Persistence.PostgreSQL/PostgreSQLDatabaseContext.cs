using BuildingBlocks.Core.Persistence.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Core.Persistence.PostgreSQL;
public class PostgreSQLDatabaseContext : DatabaseContextBase {
    public const String PostgreSQL_CONNECTION_STRING = "PostgreSQLConnectionString";
    public PostgreSQLDatabaseContext(DbContextOptions options) : base(options) { }
}