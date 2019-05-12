using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Data.Context
{
    internal class VIEWER_Map : EntityTypeConfiguration<VIEWER>
    {
        public VIEWER_Map()
        {
            //Primary key
            HasKey(d => d.ID);

            //Properties
            Property(d => d.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasPrecision(38, 0);

            Property(d => d.NAME).HasMaxLength(100).IsUnicode(false).IsRequired();

            Property(d => d.SURNAME).HasMaxLength(100).IsUnicode(false);

            Property(d => d.MIDDLE_NAME).HasMaxLength(100).IsUnicode(false);   

            Property(d => d.ADDRESS).HasMaxLength(200).IsUnicode(false);

            Property(d => d.PHONE).HasMaxLength(50).IsRequired().IsUnicode(false);

            Property(d => d.EMAIL).HasMaxLength(100).IsUnicode(false);

            // Relationships
            //HasRequired(b => b.BOOKS_ISSUED)
            //    .WithMany(b => b.VIEWER)
            //    .HasForeignKey(b => b.ID);
        }
    }
}