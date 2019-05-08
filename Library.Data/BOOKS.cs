using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class BOOKS
    {
        public BOOKS()
        {
            this.COUNT = 0;
            this.BOOKS_ISSUED = new HashSet<BOOKS_ISSUED>();
        }

        public int ID { get; set; }

        [Required]
        public string ISBN { get; set; }
        [Required]
        public string NAME { get; set; }
        public string AUTHOR { get; set; }
        public string PUBLISHING { get; set; }

        public int? COUNT { get; set; }
        public string STATUS { get; set; }
        public string DESCRIPTION { get; set; }

        [Required]
        public decimal PRICE { get; set; }

        public ICollection<BOOKS_ISSUED> BOOKS_ISSUED { get; set; }
    }
}
