using Library.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new LibraryDb())
            //{
            //    db.Database.Initialize(true);
            //    var book = db.BOOKS.ToList();
            //    var viewersve = db.VIEWERS.ToList();    
            //}

            using (LibraryDb db = LibraryDb.GetDbContext())
            {
                var qwer = db.Database.ExecuteSqlCommand("SELECT * FROM BOOKs");

                Thread.Sleep(5000);                        
            }
            
            Console.ReadKey();                              
        }
    }
}
                              