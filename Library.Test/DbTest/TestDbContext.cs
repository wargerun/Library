using System.Data.Common;
using Library.Data.Context;

namespace Library.Test.DbTest
{
    public class TestDbContext : LibraryDb
    {
        public TestDbContext(DbConnection connection) : base(connection)
        {

        }

        protected override void Dispose(bool disposing)
        {

        }
    }
}