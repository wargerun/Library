using System.Collections.Generic;

namespace Library.Data
{
    public class VIEWERS
    {
        public VIEWERS()
        {
            this.BOOKS_ISSUED = new HashSet<BOOKS_ISSUED>();
        }

        public int ID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string MIDDLE_NAME { get; set; }
        public string ADRESS { get; set; }
        public string PHONE { get; set; }
        public string EMAIL{ get; set; }

        public ICollection<BOOKS_ISSUED> BOOKS_ISSUED { get; set; }
    }
}