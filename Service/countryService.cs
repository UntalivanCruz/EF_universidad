using System;
using universidades.Models;

namespace universidades.Service
{
    public class countryService : IcountryService
    {
        context context;
        public countryService(context _context)
        {
            context = _context;
        }

        //CRUD
        public async Task CreateAsync(country newCountry)
        {
            newCountry.id = Guid.NewGuid();
            await context.AddAsync<country>(newCountry);
            await context.SaveChangesAsync();
        }

        public IEnumerable<country> Get()
        {
            return context.country;
        }

        public async Task Update(Guid id, country updCountry)
        {
            var country = context.country.Find(id);
            if (country != null)
            {
                country.country_name = updCountry.country_name;
                context.Update(country);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var country = context.country.Find(id);
            if (country != null)
            {
                context.Remove(country);
                await context.SaveChangesAsync();
            }
        }
    }
}

public interface IcountryService
{
    Task CreateAsync(country newCountry);
    IEnumerable<country> Get();
    Task Update(Guid id, country updCountry);
    Task Delete(Guid id);
}