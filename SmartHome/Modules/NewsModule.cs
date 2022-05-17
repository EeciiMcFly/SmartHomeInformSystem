using Autofac;
using Microsoft.EntityFrameworkCore;
using SmartHome.Database.News;
using SmartHome.Repositories.News;
using SmartHome.Services.News;

namespace SmartHome.Modules;

public class NewsModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.Register(c =>
			{
				var configuration = c.Resolve<IConfiguration>();
				var connectionString = configuration.GetConnectionString("DatabaseConnectionTemplateWithoutDbName");

				var optionsBuilder = new DbContextOptionsBuilder<NewsDbContext>();
				optionsBuilder.UseNpgsql(connectionString);
			
				var dbContext = new NewsDbContext(optionsBuilder.Options);
				return new NewsRepository(dbContext);
			})
			.As<INewsRepository>()
			.InstancePerLifetimeScope();

		builder.RegisterType<NewsService>()
			.As<INewsService>()
			.InstancePerLifetimeScope();
	}
}