using SmartHome.Models.News;

namespace SmartHome.Services.News;

public interface INewsService
{
	public Task<List<NewsData>> GetNewsAsync();

	public Task CreateNewsAsync(NewsData news);
}