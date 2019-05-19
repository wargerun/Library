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
                return db.VIEWERS.ToList();
        }

        public static void AddNewViewer(VIEWER viewer, LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    db.VIEWERS.Add(viewer);

                    db.SaveChanges();

                    transaction.Complete();
                }
            }
        }

        public static void UpdateViewer(VIEWER viewer, LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    if (viewer == null)
                        throw new ArgumentNullException($"book: {nameof(viewer)}");

                    VIEWER dbViewer = db.VIEWERS.SingleOrDefault(v => v.ID == viewer.ID);
                    if (dbViewer == null)
                        throw new Exception($"Книга с {viewer.ID} не найдена!");

                    dbViewer.NAME = viewer.NAME;
                    dbViewer.SURNAME = viewer.SURNAME;
                    dbViewer.MIDDLE_NAME = viewer.MIDDLE_NAME;
                    dbViewer.ADDRESS = viewer.ADDRESS;
                    dbViewer.PHONE = viewer.PHONE;
                    dbViewer.EMAIL = viewer.EMAIL;

                    db.SaveChanges();
                    transaction.Complete();
                }
            }
        }

        public static void ViewersRemove(decimal[] idViewers, LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    foreach (decimal id in idViewers)
                    {
                        VIEWER viewer = db.VIEWERS.SingleOrDefault(b => b.ID == id);

                        if (viewer != null)
                            db.VIEWERS.Remove(viewer);
                    }

                    db.SaveChanges();

                    transaction.Complete();
                }
            }
        }
    }
}