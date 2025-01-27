using Microsoft.AspNetCore.Mvc;
using RecordStore.Entities;
using RecordStore.Repository;

namespace RecordStore.Services
{
    public interface IArtistService
    {
        bool AddArtist(Artist artist);
        bool DeleteArtistById(int id);
        (bool, List<Artist>) GetAllArtists();
        (bool, Artist) GetArtistById(int id);
        bool UpdateArtist(Artist artist);
    }

    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public (bool, List<Artist>) GetAllArtists()
        {
            return _artistRepository.GetAllArtists();
        }
        public (bool, Artist) GetArtistById(int id)
        {
            return _artistRepository.GetArtistById(id);
        }
        public bool AddArtist(Artist artist)
        {
            return _artistRepository.AddArtist(artist);
        }
        public bool DeleteArtistById(int id)
        {
            return _artistRepository.DeleteArtistById(id);
        }
        public bool UpdateArtist(Artist artist)
        {
            return _artistRepository.UpdateArtist(artist);
        }
    }
}
