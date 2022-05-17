using SmartHome.Models.Messages;
using SmartHome.Repositories.Messages;

namespace SmartHome.Services;

public class MessagesService : IMessagesService
{
	private readonly IMessagesRepository _messagesRepository;

	public MessagesService(IMessagesRepository messagesRepository)
	{
		_messagesRepository = messagesRepository;
	}

	public async Task<List<MessageData>> GetMessagesByChatIdAsync(long chatId)
	{
		var messagesData = await _messagesRepository.GetMessagesAsync(chatId);

		return messagesData;
	}

	public async Task SaveMessageAsync(MessageData message)
	{
		message.TimeUtc = DateTime.UtcNow;
		await _messagesRepository.AddMessageAsync(message);
	}

	public async Task SaveMessageRangeAsync(List<MessageData> messages)
	{
		foreach (var messageData in messages)
			messageData.TimeUtc = DateTime.UtcNow;

		await _messagesRepository.AddMessageRangeAsync(messages);
	}
}