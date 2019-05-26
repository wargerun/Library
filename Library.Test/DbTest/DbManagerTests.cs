using System.Linq;
using Library.Data;
using Library.Data.Context;
using Library.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Test.DbTest
{
    [TestClass]
    public class DbManagerTests
    {
        const string someText = "Syka blyat!";

        [TestMethod]
        public void WithBookTest()
        {
            using (LibraryDb db = LibraryDb.GetDbContext())
            {
                BOOK book = new BOOK {ISBN = "test", COUNT = 0, NAME = "test", PRICE = 0};

                using (DbManager<BOOK> manager = new DbManager<BOOK>(new ManagerBook(), book))
                {
                    manager.AddNewRow();
                    BOOK dbBook = db.BOOKS.SingleOrDefault(b => b.ID == book.ID);
                    Assert.IsNotNull(dbBook);

                    //Change book test
                    dbBook.DESCRIPTION = someText;
                    manager.Entity = dbBook;
                    manager.UpdateRow();
                    dbBook = db.BOOKS.SingleOrDefault(b => b.ID == book.ID);
                    Assert.AreEqual(true, dbBook?.DESCRIPTION == someText);

                    //deleted test book
                    manager.RemoveRow();
                    dbBook = db.BOOKS.SingleOrDefault(b => b.ID == book.ID);
                    Assert.IsNull(dbBook);
                }
            }
        }

        [TestMethod]
        public void WithViewerTest()
        {
            using (LibraryDb db = LibraryDb.GetDbContext())
            {
                VIEWER viewer = new VIEWER { ADDRESS = "test", EMAIL = "test@test.ru", NAME = "test", PHONE = "testtest" };

                using (DbManager<VIEWER> manager = new DbManager<VIEWER>(new ManagerViewer(), viewer))
                {
                    //add viewer test
                    manager.AddNewRow();
                    VIEWER dbViewer = db.VIEWERS.SingleOrDefault(v => v.ID == viewer.ID);
                    Assert.IsNotNull(dbViewer);

                    //Change VIEWER test
                    dbViewer.MIDDLE_NAME = someText;
                    manager.Entity = dbViewer;
                    manager.UpdateRow();                                          
                    dbViewer = db.VIEWERS.SingleOrDefault(b => b.ID == viewer.ID);
                    Assert.AreEqual(true, dbViewer?.MIDDLE_NAME == someText);

                    //deleted test VIEWER
                    manager.RemoveRow();
                    dbViewer = db.VIEWERS.SingleOrDefault(b => b.ID == viewer.ID);
                    Assert.IsNull(dbViewer);
                }
            }
        }
    }
}