using BuildingBlocks.Core.Persistence.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Core.Persistence.MsSQL;
public class MsSQLDatabaseContext : DatabaseContextBase {
    public const String MsSQL_CONNECTION_STRING = "MsSQLConnectionString";
    public MsSQLDatabaseContext(DbContextOptions options) : base(options) { }
}