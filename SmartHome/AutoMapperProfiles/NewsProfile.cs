using AutoMapper;
using SmartHome.DTO;
using SmartHome.Models.News;

namespace SmartHome.AutoMapperProfiles;

public class NewsProfile : Profile
{
	public NewsProfile()
	{
		CreateMap<NewsData, NewsDto>()
			.ForMember(dto => dto.CreateTimeUtc, opt => opt.MapFrom(src => src.CreateTime));
		CreateMap<NewsDto, NewsData>()
			.ForMember(data => data.CreateTime, opt => opt.MapFrom(src => src.CreateTimeUtc));
	}
}