using Library.Data;
using Library.Data.BusinessLogic;
using Library.Interfaces;

namespace Library.Helpers
{
    public sealed class ManagerBook : IDbManager<BOOK>
    {
        public void AddNewRow(BOOK book)
        {
            BooksBl.AddNewCard(book);
        }

        public void UpdateRow(BOOK book)
        {
            BooksBl.UpdateBook(book);
        }

        public void RemoveRow(BOOK book)
        {
            BooksBl.BooksRemove(new[] { book.ID }); 
        }
    }
}