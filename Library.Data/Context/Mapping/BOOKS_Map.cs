using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Data.Context
{
    internal class BOOKS_Map : EntityTypeConfiguration<BOOKS>
    {
        public BOOKS_Map()
        {
            //Primary key
            HasKey(d => d.ID);

            //Properties
            Property(d => d.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasPrecision(38, 0);         

            Property(d => d.ISBN).HasMaxLength(20).IsUnicode(false).IsRequired();

            Property(d => d.NAME).HasMaxLength(100).IsRequired().IsUnicode(false);

            Property(b => b.AUTHOR).HasMaxLength(30).IsUnicode(false);

            Property(b => b.PUBLISHING).HasMaxLength(50).IsUnicode(false);

            Property(b => b.COUNT);

            Property(b => b.STATUS).HasMaxLength(50).IsUnicode(false);

            Property(b => b.DESCRIPTION).IsMaxLength().IsUnicode(false);

            Property(b => b.PRICE).HasPrecision(18, 2).IsRequired();

            //// Relationships
            //HasRequired(b => b.BOOKS_ISSUED)
            //    .WithMany(b => b.BOOKS)
            //    .HasForeignKey(b => b.BOOKS_ISSUED_ID); 
        }   
    }
}
