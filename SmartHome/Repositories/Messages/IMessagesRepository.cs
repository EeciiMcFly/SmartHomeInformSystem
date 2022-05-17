using SmartHome.Models.Messages;

namespace SmartHome.Repositories.Messages;

public interface IMessagesRepository
{
	public Task<List<MessageData>> GetMessagesAsync(long chatId);

	public Task AddMessageAsync(MessageData messageData);

	public Task AddMessageRangeAsync(IEnumerable<MessageData> messagesData);
}