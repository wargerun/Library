using Library.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {     
            using (var db = new LibraryDb())
            {
                db.Database.Initialize(true);
                var book = db.BOOKS.ToList();
                var viewersve = db.VIEWER.ToList();

            }
        }
    }
}
