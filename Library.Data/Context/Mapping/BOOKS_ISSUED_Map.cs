using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Data.Context
{
    internal class BOOKS_ISSUED_Map : EntityTypeConfiguration<BOOKS_ISSUED>
    {
        public BOOKS_ISSUED_Map()
        {      
            //Primary key
            HasKey(d => d.ID);

            //Properties
            Property(d => d.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasPrecision(38, 0);
        }
    }
}