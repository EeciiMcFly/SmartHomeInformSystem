using Autofac;
using Autofac.Extensions.DependencyInjection;
using SmartHome.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
{
	containerBuilder.RegisterModule<MessagesModule>();
	containerBuilder.RegisterModule<ChatsModule>();
	containerBuilder.RegisterModule<NewsModule>();
}));

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: "_myAllowSpecificOrigins",
		corsPolicyBuilder =>
		{
			corsPolicyBuilder.WithOrigins("http://*");
		});
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// 	
// }

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();