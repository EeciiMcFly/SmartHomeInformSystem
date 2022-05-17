using Microsoft.EntityFrameworkCore;
using SmartHome.Models.Messages;

namespace SmartHome.Database.Messages;

public class MessageDbContext : DbContext
{
	public MessageDbContext()
	{
	}

	public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
	{
		Database.Migrate();
	}

	public DbSet<MessageData> Messages { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		if (!options.IsConfigured)
		{
			options.UseNpgsql("Host=localhost; Port=5432;Database=smarthome;Username=postgres;Password=masterkey");
		}
	}
}