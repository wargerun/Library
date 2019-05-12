using System.Linq;
using Library.Data;
using Library.Data.BusinessLogic;
using Library.Data.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Test
{
    [TestClass]
    public class DbBlTests
    {
        //TODO TDD development?
        const string someText = "Syka blyat!";
           
        [TestMethod]
        public void TestBook()
        {  
            using (LibraryDb db = LibraryDb.GetDbContext())
            {
                var books = BooksBl.GetBooks();
                
                //add book test
                BOOKS book = new BOOKS { ISBN = "test", COUNT = 0, NAME = "test", PRICE = 0 };  
                BooksBl.AddNewCard(book);
                BOOKS dbBook = db.BOOKS.SingleOrDefault(b => b.ID == book.ID); 
                Assert.IsNotNull(dbBook);
                     
                //Change book test
                dbBook.DESCRIPTION = someText;
                BooksBl.UpdateBook(dbBook);
                dbBook = db.BOOKS.SingleOrDefault(b => b.ID == book.ID);
                Assert.AreEqual(true, dbBook.DESCRIPTION == someText);

                //deleted test book
                BooksBl.BooksRemove(new[] { book.ID });
                dbBook = db.BOOKS.SingleOrDefault(b => b.ID == book.ID);
                Assert.IsNull(dbBook);
            }
        }

        [TestMethod]
        public void TestViewer()
        {
            using (LibraryDb db = LibraryDb.GetDbContext())
            {
                var viewers = ViewerBl.GetViewers();

                //add viewer test
                VIEWER viewer = new VIEWER()
                {
                    ADDRESS = "test",
                    EMAIL = "test@test.ru",
                    NAME = "test" ,
                    PHONE = "testtest" 
                };

                ViewerBl.AddNewViewer(viewer);
                throw;
                //todo дописать 
            }
        }
    }
}
