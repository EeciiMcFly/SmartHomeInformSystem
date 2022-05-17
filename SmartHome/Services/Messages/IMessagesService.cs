using SmartHome.Models.Messages;

namespace SmartHome.Services;

public interface IMessagesService
{
	public Task<List<MessageData>> GetMessagesByChatIdAsync(long chatId);

	public Task SaveMessageAsync(MessageData message);

	public Task SaveMessageRangeAsync(List<MessageData> messages);
}