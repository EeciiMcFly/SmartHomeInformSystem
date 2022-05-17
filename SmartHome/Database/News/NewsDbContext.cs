using Microsoft.EntityFrameworkCore;
using SmartHome.Models.News;

namespace SmartHome.Database.News;

public class NewsDbContext : DbContext
{
	public NewsDbContext()
	{
	}

	public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
	{
		Database.Migrate();
	}

	public DbSet<NewsData> News { get; set; }

	// Метод переопределяется для создания миграций
	// При работе сервиса контекст определяется в autofac и IsConfigured будет true
	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		if (!options.IsConfigured)
		{
			options.UseNpgsql("Host=localhost; Port=5432;Database=smarthome;Username=postgres;Password=masterkey");
		}
	}
}