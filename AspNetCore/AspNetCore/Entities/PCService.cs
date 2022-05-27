using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Entities
{
    public class PCService
    {
        private readonly IMongoCollection<PC> pc;

        public PCService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            pc = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<PC>("Laptop");
        }

        public async Task<List<PC>> Get()
        {
            return await pc.Find(_ => true).ToListAsync();
        }
        public async Task<PC> Get(string id)
        {
            return await pc.Find(m => m.Id == id).FirstOrDefaultAsync();
        }
        public async Task Create(PC newPC)
        {
            await pc.InsertOneAsync(newPC);
        }
        public async Task Update(string id, PC updatePC)
        {
            await pc.ReplaceOneAsync(m => m.Id == id, updatePC);
        }
        public async Task Remove(string id)
        {
            await pc.DeleteOneAsync(m => m.Id == id);
        }
    }
}
