using CarBuilderWebAPI.Data;
using CarBuilderWebAPI.Interfaces;
using CarBuilderWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace CarBuilderWebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<DataContext>(option => option.UseInMemoryDatabase("local-db"));

			builder.Services.AddControllers();

			builder.Services.AddScoped<ICarPartRepository, CarPartRepository>();
			builder.Services.AddScoped<ICarPartCategoryRepository, CarPartCategoryRepository>();

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