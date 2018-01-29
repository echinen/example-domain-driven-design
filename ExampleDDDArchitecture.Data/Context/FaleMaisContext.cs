using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExampleDDDArchitecture.Infra.Data.Context
{
    public class FaleMaisContext : DbContext
    {
        public FaleMaisContext()
            : base("FaleMaisCtx") { }

        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Plano> Planos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(c => c.Name == c.ReflectedType.Name + "Id")
                .Configure(c => c.IsKey());

            modelBuilder.Properties<string>()
                .Configure(c => c.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(c => c.HasMaxLength(50));

            modelBuilder.Properties<decimal>()
                .Configure(c => c.HasPrecision(6, 2));

            modelBuilder.Configurations.Add(new CotacaoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new PlanoConfiguration());
        }
    }
}