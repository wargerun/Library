using System.Collections.Generic;
using System.Linq;
using Library.Data.Context;

namespace Library.Data.BusinessLogic
{
    public static class BooksIssuedBl
    {
        public static IEnumerable<BOOKS_ISSUED> GetBooksIssueds(LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
                return db.BOOKS_ISSUED.ToList();
        }
    }
}