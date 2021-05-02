using ConsoleApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Cidade)
                .WithMany()
                .HasForeignKey(x => x.CidadeId);
        }
    }
}