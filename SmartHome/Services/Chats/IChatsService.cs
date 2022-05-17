using SmartHome.Models.Chats;

namespace SmartHome.Services;

public interface IChatsService
{
	public Task<List<ChatData>> GetChatsAsync();

	public Task CreateChatAsync(ChatData chatData);
}