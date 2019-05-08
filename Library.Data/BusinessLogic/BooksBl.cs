using Library.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Transactions;

namespace Library.Data.BusinessLogic
{
    public static class BooksBl
    {
        public static IEnumerable<BOOKS> GetBooks(LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
                return db.BOOKS.ToList();
        }

        public static void AddNewCard(BOOKS book, LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    db.BOOKS.Add(book);  

                    db.SaveChanges();

                    transaction.Complete();
                }
            }
        }

        public static void UpdateBook(BOOKS book, LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    if (book == null)
                        throw new ArgumentNullException($"book: {nameof(book)}");

                    BOOKS dbBook = db.BOOKS.SingleOrDefault(b => b.ID == book.ID);
                    if (dbBook == null)
                        throw new Exception($"Книга с {book.ID} не найдена!");

                    dbBook.ISBN = book.ISBN;
                    dbBook.NAME = book.NAME;
                    dbBook.AUTHOR = book.AUTHOR;
                    dbBook.PUBLISHING = book.PUBLISHING;
                    dbBook.COUNT = book.COUNT;
                    dbBook.STATUS = book.STATUS;
                    dbBook.PRICE = book.PRICE;
                    dbBook.DESCRIPTION = book.DESCRIPTION;

                    db.SaveChanges();
                    transaction.Complete();
                }
            }
        }
    }
}
