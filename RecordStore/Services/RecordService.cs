using RecordStore.Entities;
using RecordStore.Repository;

namespace RecordStore.Services
{
    public interface IRecordService
    {
        (bool, List<Record>) GetAllRecords();
        (bool, Record) GetRecordById(int id);
        (bool, List<Record>) GetRecordsByArtist(string artist);
        (bool, List<Record>) GetRecordsByReleaseYear(int year);
        (bool, List<Record>) GetRecordsByGenre(string genre);
        (bool, Record) GetRecordInfoByName(string recordName);
        (bool, Record) AddRecord(Record record);
        (bool, Record) DeleteRecordById(int id);
        (bool, Record) UpdateRecord(Record record);
        (bool, string) GetArtistNameByArtistId(int artistId);
    }

    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }
        //---------Get Requests---------
        public (bool, List<Record>) GetAllRecords()
        {
            return _recordRepository.GetAllRecords();
        }
        public (bool, Record) GetRecordById(int id)
        {
            return _recordRepository.GetRecordById(id);
        }
        public (bool, List<Record>) GetRecordsByArtist(string artist)
        {
            return _recordRepository.GetRecordsByArtist(artist);
        }
        public (bool, List<Record>) GetRecordsByReleaseYear(int year)
        {
            return _recordRepository.GetRecordsByReleaseYear(year);
        }
        public (bool, List<Record>) GetRecordsByGenre(string genre)
        {
            return _recordRepository.GetRecordsByGenre(genre);
        }
        public (bool, Record) GetRecordInfoByName(string recordName)
        {
            return _recordRepository.GetRecordInfoByName(recordName);
        }
        public (bool, string) GetArtistNameByArtistId(int artistId)
        {
            return _recordRepository.GetArtistNameByArtistId(artistId);
        }
        //---------Post Requests---------
        public (bool, Record) AddRecord(Record record)
        {
            return _recordRepository.AddRecord(record);
        }
        //---------Delete Requests---------
        public (bool, Record) DeleteRecordById(int id)
        {
            return _recordRepository.DeleteRecordById(id);
        }
        //---------Patch Requests----------
        public (bool, Record) UpdateRecord(Record record)
        {
            return _recordRepository.UpdateRecord(record);
        }
    }
}
