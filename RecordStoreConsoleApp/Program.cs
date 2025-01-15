using Cocona;
using RecordStore.Services;
using RecordStore.Repository;
using RecordStore;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RecordStoreConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = CoconaApp.CreateBuilder();

            //ignore logs for pretty output
            builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.None);

            //Tell cocona to access user secrets
            builder.Configuration.AddUserSecrets<Program>();

            if (builder.Environment.IsDevelopment())
            {
                if (builder.Configuration.GetValue<bool>("UseInMemoryDatabase")) builder.Services.AddDbContext<RecordStoreDbContext>(options => options.UseInMemoryDatabase("RecordStore"));
                else builder.Services.AddDbContext<RecordStoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            }
            else
            {
                builder.Services.AddDbContext<RecordStoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            }
            builder.Services.AddScoped<IRecordService, RecordService>();
            builder.Services.AddScoped<IRecordRepository, RecordRepository>();

            var app = builder.Build();

            app.AddCommands<RecordCommands>();

            app.Run();
        }
    }
}
