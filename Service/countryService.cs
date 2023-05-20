using System;
using universidades.Models;

namespace universidades.Service
{
    public class countryService : IcountryService
    {
        context context;
        public countryService(context _context){
            context=_context;
        }

//CRUD
        public async Task CreateAsync(country newCountry){
            newCountry.id=Guid.NewGuid();
            await context.AddAsync<country>(newCountry);
            await context.SaveChangesAsync();
        }

        public IEnumerable<country> Get(){
            return context.country;
        }
    }
}

public interface IcountryService{
    Task CreateAsync(country newCountry);
    IEnumerable<country> Get();
}