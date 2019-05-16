using System;
using System.Collections.Generic;

namespace Library.Data
{
    public class BOOKS_ISSUED
    {                  
        public decimal ID { get; set; }
        public DateTime ISSUED_DATE { get; set; }
        public DateTime RETURN_DATE { get; set; }

        public virtual BOOK BOOKS { get; set; }
        public virtual VIEWER VIEWERS { get; set; }   
    }
}