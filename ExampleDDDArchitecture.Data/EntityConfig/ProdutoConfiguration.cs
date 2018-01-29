using ExampleDDDArchitecture.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace ExampleDDDArchitecture.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => new { p.OrigemDDD, p.DestinoDDD });

            Property(p => p.OrigemDDD)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_OrigemDDD_DestinoDDD", 1) {IsUnique = true }));

            Property(p => p.DestinoDDD)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_OrigemDDD_DestinoDDD", 2) { IsUnique = true }));

            Property(p => p.Tarifa)
                .IsRequired()
                .HasPrecision(6, 2);
        }
    }
}
