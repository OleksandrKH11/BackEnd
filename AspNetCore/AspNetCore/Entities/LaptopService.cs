using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Entities
{
    public class LaptopService
    {
        private readonly IMongoCollection<Laptop> laptop;

        public LaptopService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            laptop = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Laptop>("Laptop");
        }

        public async Task<List<Laptop>> Get()
        {
            return await laptop.Find(_ => true).ToListAsync();
        }
        public async Task<Laptop> Get(string id)
        {
            return await laptop.Find(m => m.Id == id).FirstOrDefaultAsync();
        }
        public async Task Create(Laptop newTicket)
        {
            await laptop.InsertOneAsync(newTicket);
        }
        public async Task Update(string id, Laptop updateTicket)
        {
            await laptop.ReplaceOneAsync(m => m.Id == id, updateTicket);
        }
        public async Task Remove(string id)
        {
            await laptop.DeleteOneAsync(m => m.Id == id);
        }
    }
}
