using SmartHome.Models.News;
using SmartHome.Repositories.News;

namespace SmartHome.Services.News;

public class NewsService : INewsService
{
	private readonly INewsRepository _newsRepository;

	public NewsService(INewsRepository newsRepository)
	{
		_newsRepository = newsRepository;
	}

	public async Task<List<NewsData>> GetNewsAsync()
	{
		var newsData = await _newsRepository.GetAllNewsAsync();

		return newsData;
	}

	public async Task CreateNewsAsync(NewsData news)
	{
		news.CreateTime = DateTime.UtcNow;
		await _newsRepository.AddNewsAsync(news);
	}
}