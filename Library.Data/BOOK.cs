using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class BOOK
    {
        public BOOK()
        {
            this.COUNT = 0;
        }

        public decimal ID { get; set; }

        [Required]
        public string ISBN { get; set; }
        [Required]
        public string NAME { get; set; }
        public string AUTHOR { get; set; }
        public string PUBLISHING { get; set; }

        public decimal? COUNT { get; set; }
        public string STATUS { get; set; }
        public string DESCRIPTION { get; set; }

        [Required]
        public decimal PRICE { get; set; }

        public virtual ICollection<BOOKS_ISSUED> BOOKS_ISSUED { get; set; }
    }
}
