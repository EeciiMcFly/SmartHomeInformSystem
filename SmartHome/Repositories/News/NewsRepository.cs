using Microsoft.EntityFrameworkCore;
using SmartHome.Database.News;
using SmartHome.Models.News;

namespace SmartHome.Repositories.News;

public class NewsRepository : INewsRepository
{
	private readonly NewsDbContext _newsDbContext;

	public NewsRepository(NewsDbContext newsDbContext)
	{
		_newsDbContext = newsDbContext;
	}

	public async Task<List<NewsData>> GetAllNewsAsync()
	{
		var news = await _newsDbContext.News.ToListAsync();

		return news;
	}

	public async Task AddNewsAsync(NewsData news)
	{
		_newsDbContext.News.Add(news);

		await _newsDbContext.SaveChangesAsync();
	}
}