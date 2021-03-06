﻿using Library.Data.Context; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Library.Data.BusinessLogic
{
    public static class BooksBl
    {
        public static IEnumerable<BOOK> GetBooks(LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
                return db.BOOKS.ToList();
        }

        public static void AddNewCard(BOOK book, LibraryDb dbContext = null)
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

        public static void UpdateBook(BOOK book, LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    if (book == null)
                        throw new ArgumentNullException($"book: {nameof(book)}");

                    BOOK dbBook = db.BOOKS.SingleOrDefault(b => b.ID == book.ID);
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

        public static void BooksRemove(decimal[] booksId, LibraryDb dbContext = null)
        {
            using (LibraryDb db = LibraryDb.GetDbContext(dbContext))
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    foreach (decimal id in booksId)
                    {
                        BOOK book = db.BOOKS.SingleOrDefault(b => b.ID == id);

                        if (book != null)
                            db.BOOKS.Remove(book);
                    }

                    db.SaveChanges();

                    transaction.Complete();
                }
            }
        }
    }
}
