using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DTO;
using SmartHome.Models.Chats;
using SmartHome.Services;

namespace SmartHome.Controllers;

[ApiController]
public class ChatsController : ControllerBase
{
	private readonly IChatsService _chatsService;
	private readonly IMapper _mapper;

	public ChatsController(IChatsService chatsService, 
		IMapper mapper)
	{
		_chatsService = chatsService;
		_mapper = mapper;
	}

	[HttpGet("api/v1/chats")]
	public async Task<ChatResponseDto> GetChats()
	{
		var chats = await _chatsService.GetChatsAsync();
		var chatsDto = _mapper.Map<List<ChatDto>>(chats);
		var chatResponseDto = new ChatResponseDto
		{
			Chats = chatsDto
		};

		CorsBase.AddCorsHeader(Response.Headers);

		return chatResponseDto;
	}

	[HttpPost("api/v1/chats/create")]
	public async Task<IActionResult> CreateChat(ChatDto chatDto)
	{
		var chatData = _mapper.Map<ChatData>(chatDto);
		await _chatsService.CreateChatAsync(chatData);

		CorsBase.AddCorsHeader(Response.Headers);

		return Ok();
	}
}