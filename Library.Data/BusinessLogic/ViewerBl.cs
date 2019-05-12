using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Library.Data.Context;

namespace Library.Data.BusinessLogic
{
    public static class ViewerBl
    {
        public static IEnumerable<VIEWER> GetViewers(LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
                return db.VIEWER.ToList();
        }

        public static void AddNewViewer(VIEWER viewer, LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    db.VIEWER.Add(viewer);

                    db.SaveChanges();

                    transaction.Complete();
                }
            }
        }
    }
}