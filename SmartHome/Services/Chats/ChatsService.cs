using SmartHome.Models.Chats;
using SmartHome.Repositories.Chats;

namespace SmartHome.Services;

public class ChatsService : IChatsService
{
	private readonly IChatsRepository _chatsRepository;

	public ChatsService(IChatsRepository chatsRepository)
	{
		_chatsRepository = chatsRepository;
	}

	public async Task<List<ChatData>> GetChatsAsync()
	{
		var chatsData = await _chatsRepository.GetChatsAsync();

		return chatsData;
	}

	public async Task CreateChatAsync(ChatData chatData)
	{
		await _chatsRepository.AddChatAsync(chatData);
	}
}