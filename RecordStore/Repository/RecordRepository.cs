using Microsoft.IdentityModel.Tokens;
using RecordStore.Entities;

namespace RecordStore.Repository
{
    public interface IRecordRepository
    {
        (bool, Record) AddRecord(Record record);
        (bool, Record) DeleteRecordById(int id);
        (bool, List<Record>) GetAllRecords();
        (bool, Record) GetRecordById(int id);
        (bool, Record) UpdateRecord(Record record);
    }

    public class RecordRepository : IRecordRepository
    {
        private readonly RecordStoreDbContext _db;
        public RecordRepository(RecordStoreDbContext db)
        {
            _db = db;
        }
        public (bool, List<Record>) GetAllRecords()
        {
            var result = _db.Records.ToList();
            return (!result.IsNullOrEmpty(), result);
        }
        public (bool, Record) GetRecordById(int id)
        {
            var result = _db.Records.FirstOrDefault(r => r.Id == id);
            return (result != null, result);
        }
        public (bool, Record) AddRecord(Record record)
        {
            _db.Records.Add(record);
            var result = _db.SaveChanges();
            return (result == 1, record);
        }
        public (bool, Record) DeleteRecordById(int id)
        {
            var record = _db.Records.FirstOrDefault(r => r.Id == id);
            if (record == null)
            {
                return (false, null);
            }
            _db.Records.Remove(record);
            var result = _db.SaveChanges();
            return (result == 1, record);
        }
        public (bool, Record) UpdateRecord(Record record)
        {
            var foundRecord = _db.Records.FirstOrDefault(r => r.Id == record.Id);
            if (foundRecord == null)
            {
                return false;
            }
            _db.Entry(foundRecord).CurrentValues.SetValues(record);
            var result = _db.SaveChanges();
            return (result == 1, record);
        }
    }
