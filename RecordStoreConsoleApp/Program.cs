using Cocona;
using RecordStore.Services;
using RecordStore.Repository;
using RecordStore;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RecordStoreConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = CoconaApp.CreateBuilder();

            //if (builder.Environment.IsDevelopment())
            //{
            //    if (builder.Configuration.GetValue<bool>("UseInMemoryDatabase")) builder.Services.AddDbContext<RecordStoreDbContext>(options => options.UseInMemoryDatabase("RecordStore"));
            //    else builder.Services.AddDbContext<RecordStoreDbContext>(options => options.UseSqlServer("Server=DESKTOP-39KBH2H\\SQLEXPRESS;Database=RecordStore;User Id=sa;Password=database;TrustServerCertificate=True"));
            //}
            //else
            //{
            //    builder.Services.AddDbContext<RecordStoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //}

            //i'll fix this later
            builder.Services.AddDbContext<RecordStoreDbContext>(options => options.UseSqlServer("Server=DESKTOP-39KBH2H\\SQLEXPRESS;Database=RecordStore;User Id=sa;Password=database;TrustServerCertificate=True"));
            builder.Services.AddScoped<IRecordService, RecordService>();
            builder.Services.AddScoped<IRecordRepository, RecordRepository>();

            var app = builder.Build();

            //Console app commands
            //TODO - move into seperate RecordCommands class
            app.AddCommand("getallrecords", (IRecordService RecordService) =>
            {
                var result = RecordService.GetAllRecords();
                if (result.Item1 == false) Console.WriteLine("Unable to find any records");
                else result.Item2.ForEach(r => Console.WriteLine(JsonSerializer.Serialize(r, new JsonSerializerOptions { WriteIndented = true })));
            });
            app.AddCommand("getrecordbyid", (int id, IRecordService RecordService) =>
            {
                var result = RecordService.GetRecordById(id);
                if (result.Item1 == false) Console.WriteLine("Unable to find any records");
                else Console.WriteLine(JsonSerializer.Serialize(result.Item2, new JsonSerializerOptions { WriteIndented = true }));
            });
            app.AddCommand("getrecordsbyartist", (string artist, IRecordService RecordService) =>
            {
                var result = RecordService.GetRecordsByArtist(artist);
                if (result.Item1 == false) Console.WriteLine("Unable to find any records");
                else Console.WriteLine(JsonSerializer.Serialize(result.Item2, new JsonSerializerOptions { WriteIndented = true }));
            });
            app.AddCommand("getrecordsbygenre", (string genre, IRecordService RecordService) =>
            {
                var result = RecordService.GetRecordsByGenre(genre);
                if (result.Item1 == false) Console.WriteLine("Unable to find any records");
                else Console.WriteLine(JsonSerializer.Serialize(result.Item2, new JsonSerializerOptions { WriteIndented = true }));
            });
            app.AddCommand("getrecordsbyreleaseyear", (int year, IRecordService RecordService) =>
            {
                var result = RecordService.GetRecordsByReleaseYear(year);
                if (result.Item1 == false) Console.WriteLine("Unable to find any records");
                else Console.WriteLine(JsonSerializer.Serialize(result.Item2, new JsonSerializerOptions { WriteIndented = true }));
            });
            app.AddCommand("getrecordinfobyname", (string name, IRecordService RecordService) =>
            {
                var result = RecordService.GetRecordInfoByName(name);
                if (result.Item1 == false) Console.WriteLine("Unable to find any records");
                else Console.WriteLine(JsonSerializer.Serialize(result.Item2, new JsonSerializerOptions { WriteIndented = true }));
            });

            app.Run();
        }
    }
}
