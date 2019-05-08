namespace Library.Data
{
    public class BOOKS_ISSUED
    {
        public int ID { get; set; }
        public int BOOKS_ID { get; set; }
        public int VIEWERS_ID { get; set; }
        public System.DateTime ISSUED_DATE { get; set; }
        public System.DateTime RETURN_DATE { get; set; }

        public BOOKS BOOKS { get; set; }
        public VIEWERS VIEWERS { get; set; }
    }
}