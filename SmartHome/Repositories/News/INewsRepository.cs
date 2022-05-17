using SmartHome.Models.News;

namespace SmartHome.Repositories.News;

public interface INewsRepository
{
	public Task<List<NewsData>> GetAllNewsAsync();

	public Task AddNewsAsync(NewsData news);
}