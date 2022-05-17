using AutoMapper;
using SmartHome.DTO;
using SmartHome.Models.Messages;

namespace SmartHome.AutoMapperProfiles;

public class MessageProfile : Profile
{
	public MessageProfile()
	{
		CreateMap<MessageData, MessageDto>();

		CreateMap<MessageDto, MessageData>();
	}
}