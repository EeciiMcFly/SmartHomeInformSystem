using SmartHome.Models.Chats;

namespace SmartHome.Repositories.Chats;

public interface IChatsRepository
{
	public Task<List<ChatData>> GetChatsAsync();

	public Task AddChatAsync(ChatData chatData);
}