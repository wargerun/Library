using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Library.Data.Context;

namespace Library.Test
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