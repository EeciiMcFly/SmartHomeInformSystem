using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DTO;
using SmartHome.Models.Messages;
using SmartHome.Services;

namespace SmartHome.Controllers;

[ApiController]
public class MessagesController : ControllerBase
{
	private IMessagesService _messagesService;
	private IMapper _mapper;

	public MessagesController(IMessagesService messagesService,
		IMapper mapper)
	{
		_messagesService = messagesService;
		_mapper = mapper;
	}

	[HttpGet("api/v1/messages/{chatId:long}")]
	public async Task<MessagesResponseDto> GetMessages(long chatId)
	{
		var messages = await _messagesService.GetMessagesByChatIdAsync(chatId);
		var messagesDto = _mapper.Map<List<MessageDto>>(messages);
		var messagesResponseDto = new MessagesResponseDto
		{
			Messages = messagesDto
		};

		CorsBase.AddCorsHeader(Response.Headers);

		return messagesResponseDto;
	}

	[HttpPost("api/v1/messages/save")]
	public async Task<IActionResult> SaveMessage(MessageDto message)
	{
		var messageData = _mapper.Map<MessageData>(message);
		await _messagesService.SaveMessageAsync(messageData);

		CorsBase.AddCorsHeader(Response.Headers);

		return Ok();
	}

	[HttpPost("api/v1/messages/save-range")]
	public async Task<IActionResult> SaveMessages(SaveMessagesRequestDto saveMessagesRequestDto)
	{
		var messagesData = _mapper.Map<List<MessageData>>(saveMessagesRequestDto.Messages);
		await _messagesService.SaveMessageRangeAsync(messagesData);

		CorsBase.AddCorsHeader(Response.Headers);

		return Ok();
	}
}