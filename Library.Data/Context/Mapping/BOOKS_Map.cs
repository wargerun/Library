using System.Data.Entity.ModelConfiguration;
using System.Reflection.Emit;

namespace Library.Data.Context
{
    internal class BOOKS_Map : EntityTypeConfiguration<BOOKS>
    {
        public BOOKS_Map()
        {
            //Primary key
            HasKey(d => d.ID);

            //Properties
            Property(d => d.ISBN).HasMaxLength(20).IsRequired();

            Property(d => d.NAME).HasMaxLength(100).IsRequired();

            Property(b => b.AUTHOR).HasMaxLength(30);

            Property(b => b.PUBLISHING).HasMaxLength(50);

            Property(b => b.COUNT);

            Property(b => b.STATUS).HasMaxLength(50);

            Property(b => b.DESCRIPTION).IsMaxLength();

            Property(b => b.PRICE).HasPrecision(18, 2).IsRequired();
        }
    }
}