using System.Collections.Generic;

namespace Library.Data
{
    public class BOOKS_ISSUED
    {
       
        public decimal ID { get; set; }
        public System.DateTime ISSUED_DATE { get; set; }
        public System.DateTime RETURN_DATE { get; set; }

        public virtual BOOKS BOOKS { get; set; }
        public virtual VIEWER VIEWER { get; set; }

    }
}