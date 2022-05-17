using AutoMapper;
using SmartHome.DTO;
using SmartHome.Models.Chats;

namespace SmartHome.AutoMapperProfiles;

public class ChatProfile : Profile
{
	public ChatProfile()
	{
		CreateMap<ChatData, ChatDto>();
		CreateMap<ChatDto, ChatData>();
	}
}