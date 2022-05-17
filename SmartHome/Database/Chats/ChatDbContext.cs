using Microsoft.EntityFrameworkCore;
using SmartHome.Models.Chats;

namespace SmartHome.Database.Chats;

public class ChatDbContext : DbContext
{
	public ChatDbContext()
	{
	}

	public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
	{
		Database.Migrate();
	}

	public DbSet<ChatData> Chats { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		if (!options.IsConfigured)
		{
			options.UseNpgsql("Host=localhost; Port=5432;Database=smarthome;Username=postgres;Password=masterkey");
		}
	}
}