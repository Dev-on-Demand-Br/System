using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class ProductRepository : IProductRepository {

    private readonly SystemDbContext _context;

    public ProductRepository(SystemDbContext context) {
        _context = context;
    }

    public async Task<ICollection<Product>> GetProductAsync() {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id) {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product> CreateAsync(Product product) {
        _context.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task EditAsync(Product product) {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product) {
        _context.Remove(product);
        await _context.SaveChangesAsync();
    }
}
