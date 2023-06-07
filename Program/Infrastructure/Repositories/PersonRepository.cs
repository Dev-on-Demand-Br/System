using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PersonRepository : IPersonRepository {

    private readonly SystemDbContext _context;

    public PersonRepository(SystemDbContext context) {
        _context = context;
    }

    public async Task<ICollection<Person>> GetPeopleAsync() {
        return await _context.People.ToListAsync();
    }

    public async Task<Person> GetByIdAsync(int id) {
        return await _context.People.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Person> CreateAsync(Person person) {
        _context.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task EditAsync(Person person) {
        _context.Update(person);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Person person) {
        _context.Remove(person);
        await _context.SaveChangesAsync();
    }
}
