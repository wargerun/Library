using System.Data.Common;
using System.Data.Entity;

namespace Library.Data.Context
{
    public class LibraryDb : DbContext
    {
        public LibraryDb() : base("LibraryDb")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryDb>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<LibraryDb>());
            Database.SetInitializer(new DropCreateDatabaseAlways<LibraryDb>());
        }

        protected LibraryDb(DbConnection connection) : base(connection, true)
        {

        }

        public static LibraryDb GetDbContext(LibraryDb dbContext = null)
        {
            return dbContext ?? new LibraryDb();
        }

        // TODO Узнать ПОЧЕМУ СОЗДАЕТСЯ ТАБЛИЦА VIEWERs сукаааааааааааааа!!!=( 
        // TODO Настроить правильно связи

        public virtual DbSet<BOOKS> BOOKS { get; set; }
        public virtual DbSet<VIEWER> VIEWER { get; set; }
        public virtual DbSet<BOOKS_ISSUED> BOOKS_ISSUED { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BOOKS_Map());
            modelBuilder.Configurations.Add(new VIEWER_Map());
            modelBuilder.Configurations.Add(new BOOKS_ISSUED_Map());
        }
    }
}
