using Autofac;
using Microsoft.EntityFrameworkCore;
using SmartHome.Database.Chats;
using SmartHome.Repositories.Chats;
using SmartHome.Services;

namespace SmartHome.Modules;

public class ChatsModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.Register(c =>
			{
				var configuration = c.Resolve<IConfiguration>();
				var connectionString = configuration.GetConnectionString("DatabaseConnectionTemplateWithoutDbName");

				var optionsBuilder = new DbContextOptionsBuilder<ChatDbContext>();
				optionsBuilder.UseNpgsql(connectionString);

				var dbContext = new ChatDbContext(optionsBuilder.Options);
				return new ChatsRepository(dbContext);
			})
			.As<IChatsRepository>()
			.InstancePerLifetimeScope();

		builder.RegisterType<ChatsService>()
			.As<IChatsService>()
			.InstancePerLifetimeScope();
	}
}