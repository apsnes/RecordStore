using RecordStore.Entities;
using RecordStore.Repository;

namespace RecordStore.Services
{
    public interface IRecordService
    {
        (bool, Record) AddRecord(Record record);
        (bool, Record) DeleteRecordById(int id);
        (bool, List<Record>) GetAllRecords();
        (bool, Record) GetRecordById(int id);
        (bool, Record) UpdateRecord(Record record);
    }

    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }
        public (bool, List<Record>) GetAllRecords()
        {
            return _recordRepository.GetAllRecords();
        }
        public (bool, Record) GetRecordById(int id)
        {
            return _recordRepository.GetRecordById(id);
        }
        public (bool, Record) AddRecord(Record record)
        {
            return _recordRepository.AddRecord(record);
        }
        public (bool, Record) DeleteRecordById(int id)
        {
            return _recordRepository.DeleteRecordById(id);
        }
        public (bool, Record) UpdateRecord(Record record)
        {
            return _recordRepository.UpdateRecord(record);
        }
    }
}
