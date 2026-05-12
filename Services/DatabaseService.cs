//using SQLite;
//using System.IO;
//using WEWE.Maui.Models;

//namespace WEWE.Maui.Services
//{
//    public class DatabaseService
//    {
//        private readonly SQLiteConnection _db;

//        public DatabaseService()
//        {
//            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "WEWE_NGO_DB.db");
//            _db = new SQLiteConnection(dbPath);
//            _db.CreateTable<WidowRegistration>();
//            _db.CreateTable<Orphan>();
//            _db.CreateTable<Benefit>();
//            _db.CreateTable<Case>();
//            _db.CreateTable<CaseLog>();
//        }

//        public void AddWidow(WidowRegistration widow) => _db.Insert(widow);
//        public void AddOrphan(Orphan orphan) => _db.Insert(orphan);
//        public void AddBenefit(Benefit benefit) => _db.Insert(benefit);
//        public void AddCase(Case caseItem) => _db.Insert(caseItem);
//        public void AddCaseLog(CaseLog log) => _db.Insert(log);
//        public List<WidowRegistration> GetWidows() =>
//        _db.Table<WidowRegistration>().ToList();
//        public List<Orphan> GetOrphans(Guid widowId) => _db.Table<Orphan>().Where(o =>
//        o.WidowID == widowId).ToList();
//        public List<Benefit> GetBenefits() => _db.Table<Benefit>().ToList();
//        public List<Case> GetCases(Guid widowId) => _db.Table<Case>().Where(c =>
//        c.WidowID == widowId).ToList();
//        public List<CaseLog> GetCaseLogs(Guid caseId) => _db.Table<CaseLog>().Where(l =>
//        l.CaseID == caseId).ToList();
//    }
//}
using SQLite;
using System.IO;
using WEWE.Maui.Models;

namespace WEWE.Maui.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;

        public DatabaseService()
        {
            // DO NOT do async work here
        }

        private async Task InitAsync()
        {
            if (_db != null)
                return;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "WEWE_NGO_DB.db");

            _db = new SQLiteAsyncConnection(dbPath);

            await _db.CreateTableAsync<WidowRegistration>();
            await _db.CreateTableAsync<Orphan>();
            await _db.CreateTableAsync<Benefit>();
            await _db.CreateTableAsync<Case>();
            await _db.CreateTableAsync<CaseLog>();
        }

        // ---------------- INSERTS ----------------

        public async Task AddWidow(WidowRegistration widow)
        {
            await InitAsync();
            await _db.InsertAsync(widow);
        }

        public async Task AddOrphan(Orphan orphan)
        {
            await InitAsync();
            await _db.InsertAsync(orphan);
        }

        public async Task AddBenefit(Benefit benefit)
        {
            await InitAsync();
            await _db.InsertAsync(benefit);
        }

        public async Task AddCase(Case caseItem)
        {
            await InitAsync();
            await _db.InsertAsync(caseItem);
        }

        public async Task AddCaseLog(CaseLog log)
        {
            await InitAsync();
            await _db.InsertAsync(log);
        }

        // ---------------- GETS ----------------

        public async Task<List<WidowRegistration>> GetWidows()
        {
            await InitAsync();
            return await _db.Table<WidowRegistration>().ToListAsync();
        }

        public async Task<List<Orphan>> GetOrphans(Guid widowId)
        {
            await InitAsync();
            return await _db.Table<Orphan>()
                             .Where(o => o.WidowID == widowId)
                             .ToListAsync();
        }

        public async Task<List<Benefit>> GetBenefits()
        {
            await InitAsync();
            return await _db.Table<Benefit>().ToListAsync();
        }

        public async Task<List<Case>> GetCases(Guid widowId)
        {
            await InitAsync();
            return await _db.Table<Case>()
                             .Where(c => c.WidowID == widowId)
                             .ToListAsync();
        }

        public async Task<List<CaseLog>> GetCaseLogs(Guid caseId)
        {
            await InitAsync();
            return await _db.Table<CaseLog>()
                             .Where(l => l.CaseID == caseId)
                             .ToListAsync();
        }
    }
}