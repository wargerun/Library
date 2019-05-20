using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class VIEWER
    {   
        public decimal ID { get; set; }

        [Required]
        public string NAME { get; set; }

        public string SURNAME { get; set; }

        public string MIDDLE_NAME { get; set; }

        public string ADDRESS { get; set; }  

        [Required]
        public string PHONE { get; set; }

        [Required]
        public string EMAIL{ get; set; }

        public virtual ICollection<BOOKS_ISSUED> BOOKS_ISSUED { get; set; }
    }
}