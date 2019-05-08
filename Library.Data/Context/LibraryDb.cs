using System.Data.Entity;

namespace Library.Data.Context
{
    public class LibraryDb : DbContext
    {
        public LibraryDb() : base("DbConnection")
        {
        }

        public static LibraryDb GetDbContext(LibraryDb dbContext = null)
        {
            return dbContext ?? new LibraryDb();
        }

        public DbSet<BOOKS> BOOKS { get; set; }
        public DbSet<VIEWERS> VIEWERS { get; set; }
        public DbSet<BOOKS_ISSUED> BOOKS_ISSUED { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BOOKS_Map());
        }
    }
}
