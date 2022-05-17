using Microsoft.EntityFrameworkCore;
using SmartHome.Database.Chats;
using SmartHome.Models.Chats;

namespace SmartHome.Repositories.Chats;

public class ChatsRepository : IChatsRepository
{
	private readonly ChatDbContext _chatDbContext;

	public ChatsRepository(ChatDbContext chatDbContext)
	{
		_chatDbContext = chatDbContext;
	}

	public async Task<List<ChatData>> GetChatsAsync()
	{
		var chats = await _chatDbContext.Chats.ToListAsync();

		return chats;
	}

	public async Task AddChatAsync(ChatData chatData)
	{
		_chatDbContext.Chats.Add(chatData);

		await _chatDbContext.SaveChangesAsync();
	}
}