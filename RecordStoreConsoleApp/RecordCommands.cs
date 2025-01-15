using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RecordStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecordStoreConsoleApp
{
    public class RecordCommands
    {
        private readonly IRecordService _recordService;
        public RecordCommands(IRecordService recordService)
        {
            _recordService = recordService;
        }
        //Ignore async await warnings until i fix it :)
        #pragma warning disable CS1998
        public async Task GetAllRecords()
        {
            var result = _recordService.GetAllRecords();
            if (result.Item1 == false) Console.WriteLine("Unable to find any records");
            else result.Item2.ForEach(r => Console.WriteLine(JsonSerializer.Serialize(r, new JsonSerializerOptions { WriteIndented = true })));
        }
        public async Task GetRecordById(int id)
        {
            var result = _recordService.GetRecordById(id);
            if (result.Item1 == false) Console.WriteLine("Unable to find any records");
            else Console.WriteLine(JsonSerializer.Serialize(result.Item2, new JsonSerializerOptions { WriteIndented = true }));
        }
        public async Task GetRecordsByArtist(string artist)
        {
            var result = _recordService.GetRecordsByArtist(artist);
            if (result.Item1 == false) Console.WriteLine("Unable to find any records");
            else Console.WriteLine(JsonSerializer.Serialize(result.Item2, new JsonSerializerOptions { WriteIndented = true }));
        }
        public async Task GetRecordsByGenre(string genre)
        {
            var result = _recordService.GetRecordsByGenre(genre);
            if (result.Item1 == false) Console.WriteLine("Unable to find any records");
            else Console.WriteLine(JsonSerializer.Serialize(result.Item2, new JsonSerializerOptions { WriteIndented = true }));
        }
        public async Task GetRecordsByReleaseYear(int year)
        {
            var result = _recordService.GetRecordsByReleaseYear(year);
            if (result.Item1 == false) Console.WriteLine("Unable to find any records");
            else Console.WriteLine(JsonSerializer.Serialize(result.Item2, new JsonSerializerOptions { WriteIndented = true }));
        }
        public async Task GetRecordInfoByName(string name)
        {
            var result = _recordService.GetRecordInfoByName(name);
            if (result.Item1 == false) Console.WriteLine("Unable to find any records");
            else Console.WriteLine(JsonSerializer.Serialize(result.Item2, new JsonSerializerOptions { WriteIndented = true }));
        }
        #pragma warning restore CS1998
    }
}
