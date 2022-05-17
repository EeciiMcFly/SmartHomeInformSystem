using Microsoft.EntityFrameworkCore;
using SmartHome.Database.Messages;
using SmartHome.Models.Messages;

namespace SmartHome.Repositories.Messages;

public class MessagesRepository : IMessagesRepository
{
	private readonly MessageDbContext _messageDbContext;

	public MessagesRepository(MessageDbContext messageDbContext)
	{
		_messageDbContext = messageDbContext;
	}

	public async Task<List<MessageData>> GetMessagesAsync(long chatId)
	{
		var messages = await _messageDbContext.Messages
			.Where(data => data.ChatId == chatId)
			.ToListAsync();

		return messages;
	}

	public async Task AddMessageAsync(MessageData messageData)
	{
		_messageDbContext.Add(messageData);

		await _messageDbContext.SaveChangesAsync();
	}

	public async Task AddMessageRangeAsync(IEnumerable<MessageData> messagesData)
	{
		foreach (var messageData in messagesData)
		{
			_messageDbContext.Add(messageData);
		}

		await _messageDbContext.SaveChangesAsync();
	}
}