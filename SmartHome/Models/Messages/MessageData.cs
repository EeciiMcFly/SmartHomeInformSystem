using Microsoft.EntityFrameworkCore;

namespace SmartHome.Models.Messages;

[Index(nameof(ChatId))]
public class MessageData
{
	public long Id { get; set; }

	public long ChatId { get; set; }

	public string UserName { get; set; }

	public string Text { get; set; }

	public DateTime TimeUtc { get; set; }
}