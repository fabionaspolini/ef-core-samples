using ConsoleApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp.Infra.Mappings
{
    public class FreteMap : IEntityTypeConfiguration<Frete>
    {
        public void Configure(EntityTypeBuilder<Frete> builder)
        {
            builder.ToTable("frete");
            builder.HasKey(x => x.Id);
            
            builder
                .HasOne(x => x.Destinatario)
                .WithMany()
                .HasForeignKey(x => x.DestinatarioId);
            
            builder
                .HasOne(x => x.Remetente)
                .WithMany()
                .HasForeignKey(x => x.RemetenteId);
        }
    }
}