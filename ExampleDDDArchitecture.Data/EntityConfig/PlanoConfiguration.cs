using ExampleDDDArchitecture.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExampleDDDArchitecture.Infra.Data.EntityConfig
{
    public class PlanoConfiguration : EntityTypeConfiguration<Plano>
    {
        public PlanoConfiguration()
        {
            HasKey(p => p.PlanoId);

            Property(p => p.TipoPlano)
                .IsRequired();
        }
    }
}
