﻿using Microsoft.IdentityModel.Tokens;
using RecordStore.Entities;

namespace RecordStore.Repository
{
    public interface IRecordRepository
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

    public class RecordRepository : IRecordRepository
    {
        private readonly RecordStoreDbContext _db;
        public RecordRepository(RecordStoreDbContext db)
        {
            _db = db;
        }
        //---------Get Requests---------
        public (bool, List<Record>) GetAllRecords()
        {
            var result = _db.Records.ToList();
            return (!result.IsNullOrEmpty(), result);
        }
        public (bool, Record) GetRecordById(int id)
        {
            var result = _db.Records.FirstOrDefault(r => r.Id == id);
            return (result != null && result.Id > 0, result);
        }
        public (bool, List<Record>) GetRecordsByArtist(string artist)
        {
            var result = _db.Records.Where(r => r.Artist == artist).ToList();
            return (result.Count > 0, result);
        }
        public (bool, List<Record>) GetRecordsByReleaseYear(int year)
        {
            var result = _db.Records.Where(r => r.ReleaseYear == year).ToList();
            return (!result.IsNullOrEmpty(), result);
        }
        public (bool, List<Record>) GetRecordsByGenre(string genre)
        {
            var result = _db.Records.Where(r => r.Genre == genre).ToList();
            return (!result.IsNullOrEmpty(), result);
        }
        public (bool, Record) GetRecordInfoByName(string recordName)
        {
            var result = _db.Records.FirstOrDefault(r => r.Title == recordName);
            return (result != null && result.Id != 0, result);
        }
        public (bool, string) GetArtistNameByArtistId(int artistId)
        {
            var result = _db.Records.FirstOrDefault(a => a.ArtistId == artistId);
            return (result != null && result.Id != 0, result.Artist);
        }
        //---------Post Requests---------
        public (bool, Record) AddRecord(Record record)
        {
            _db.Records.Add(record);
            var result = _db.SaveChanges();
            return (result == 1, record);
        }
        //---------Delete Requests---------
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
        //---------Put Requests-----------
        public (bool, Record) UpdateRecord(Record record)
        {
            var foundRecord = _db.Records.FirstOrDefault(r => r.Id == record.Id);
            if (foundRecord == null)
            {
                return (false, null);
            }
            if (record.Title != null) foundRecord.Title = record.Title;
            if (record.Artist != null) foundRecord.Artist = record.Artist;
            if (record.Genre != null) foundRecord.Genre = record.Genre;
            if (record.ReleaseYear != 0) foundRecord.ReleaseYear = record.ReleaseYear;
            if (record.ArtistId != 0) foundRecord.ArtistId = record.ArtistId;
            if (record.SpotifyEmbed != null) foundRecord.SpotifyEmbed = record.SpotifyEmbed;
            _db.Update(foundRecord);
            var result = _db.SaveChanges();
            return (result == 1, record);
        }
    }
}
