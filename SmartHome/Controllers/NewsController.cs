using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DTO;
using SmartHome.Models.News;
using SmartHome.Services.News;

namespace SmartHome.Controllers;

[ApiController]
public class NewsController : ControllerBase
{
	private readonly INewsService _newsService;
	private readonly IMapper _mapper;

	public NewsController(INewsService newsService,
		IMapper mapper)
	{
		_newsService = newsService;
		_mapper = mapper;
	}

	[HttpGet("api/v1/news")]
	public async Task<NewsResponseDto> GetAllNews()
	{
		var news = await _newsService.GetNewsAsync();
		var newsDto = _mapper.Map<List<NewsDto>>(news);
		var newsResponseDto = new NewsResponseDto
		{
			News = newsDto
		};

		CorsBase.AddCorsHeader(Response.Headers);

		return newsResponseDto;
	}

	[HttpPost("api/v1/news")]
	public async Task<IActionResult> CreateNews(NewsDto news)
	{
		var newsData = _mapper.Map<NewsData>(news);
		await _newsService.CreateNewsAsync(newsData);

		CorsBase.AddCorsHeader(Response.Headers);

		return Ok();
	}
}