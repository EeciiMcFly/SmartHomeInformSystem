using Autofac;
using Microsoft.EntityFrameworkCore;
using SmartHome.Database.Messages;
using SmartHome.Repositories.Messages;
using SmartHome.Services;

namespace SmartHome.Modules;

public class MessagesModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.Register(c =>
			{
				var configuration = c.Resolve<IConfiguration>();
				var connectionString = configuration.GetConnectionString("DatabaseConnectionTemplateWithoutDbName");

				var optionsBuilder = new DbContextOptionsBuilder<MessageDbContext>();
				optionsBuilder.UseNpgsql(connectionString);
			
				var dbContext = new MessageDbContext(optionsBuilder.Options);
				return new MessagesRepository(dbContext);
			})
			.As<IMessagesRepository>()
			.InstancePerLifetimeScope();

		builder.RegisterType<MessagesService>()
			.As<IMessagesService>()
			.InstancePerLifetimeScope();
	}
}