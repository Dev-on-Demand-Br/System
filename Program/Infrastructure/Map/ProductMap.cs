using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Map;
public class ProductMap : IEntityTypeConfiguration<Product> {
    public void Configure(EntityTypeBuilder<Product> builder) {

        builder.ToTable("Produto");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdProduto")
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .HasColumnName("Nome");

        builder.Property(x => x.Code)
            .HasColumnName("Código");

        builder.Property(x => x.Price)
            .HasColumnName("Preço");


        builder.HasMany(x => x.Purchases)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);
    }
}
