using Microsoft.EntityFrameworkCore;

namespace HomeMgmt.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
