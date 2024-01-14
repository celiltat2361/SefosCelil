using Microsoft.OpenApi.Models;
using SefosApi.Models;
using SefosApi.Services;

namespace SefosApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.Configure<SefosApiConfig>(builder.Configuration.GetSection("SefosApiConfig"));
            builder.Services.AddHttpClient<MessageService>();
            builder.Services.AddTransient<IMessageService, MessageService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}