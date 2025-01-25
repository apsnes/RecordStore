using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using RecordStore.Entities;


namespace RecordStore.Repository
{
    public interface IArtistRepository
    {
        bool AddArtist(Artist artist);
        bool DeleteArtistById(int id);
        (bool, List<Artist>) GetAllArtists();
        (bool, Artist) GetArtistById(int id);
        bool UpdateArtist(Artist artist);
    }

    public class ArtistRepository : IArtistRepository
    {
        private readonly RecordStoreDbContext _db;
        public ArtistRepository(RecordStoreDbContext db)
        {
            _db = db;
        }
        public (bool, List<Artist>) GetAllArtists()
        {
            var result = _db.Artists.ToList();
            return (!result.IsNullOrEmpty(), result);
        }
        public (bool, Artist) GetArtistById(int id)
        {
            var result = _db.Artists.FirstOrDefault(a => a.Id == id);
            return (result != null && result.Id > 0, result);
        }
        public bool AddArtist(Artist artist)
        {
            _db.Artists.Add(artist);
            _db.SaveChanges();
            return true;
        }
        public bool DeleteArtistById(int id)
        {
            var artist = _db.Artists.FirstOrDefault(a => a.Id == id);
            if (artist == null) return false;
            _db.Artists.Remove(artist);
            _db.SaveChanges();
            return true;
        }
        public bool UpdateArtist(Artist artist)
        {
            var foundArtist = _db.Artists.FirstOrDefault(r => r.Id == artist.Id);
            if (foundArtist == null)
            {
                return false;
            }
            if (artist.Description != null) foundArtist.Description = artist.Description;
            _db.Update(foundArtist);
            var result = _db.SaveChanges();
            return result == 1;
        }
    }
}
