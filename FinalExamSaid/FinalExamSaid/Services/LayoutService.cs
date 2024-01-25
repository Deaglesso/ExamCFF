using FinalExamSaid.DAL;
using Microsoft.EntityFrameworkCore;

namespace FinalExamSaid.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _db;

        public LayoutService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Dictionary<string,string>> GetSettingsAsync()
        {
            
            return await _db.Settings.ToDictionaryAsync(x => x.Key,x=>x.Value);
        }
    }
}
