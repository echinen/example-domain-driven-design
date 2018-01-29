using ExampleDDDArchitecture.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExampleDDDArchitecture.Infra.Data.EntityConfig
{
    public class CotacaoConfiguration : EntityTypeConfiguration<Cotacao>
    {
        public CotacaoConfiguration()
        {
            HasKey(p => p.CotacaoId);

            Property(p => p.TempoLigacao)
                .IsRequired();

            Property(p => p.ComFaleMais)
                .IsRequired()
                .HasPrecision(6, 2);

            Property(p => p.SemFaleMais)
                .IsRequired()
                .HasPrecision(6, 2);

            Property(p => p.OrigemDDD)
                //.IsRequired()
                .HasMaxLength(3);

            Property(p => p.DestinoDDD)
                //.IsRequired()
                .HasMaxLength(3);
        }
    }
}
