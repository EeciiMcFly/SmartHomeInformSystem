using System.ComponentModel.DataAnnotations;

namespace SmartHome.DTO;

public class MessageDto
{
	[Required]
	public long ChatId { get; init; }

	[Required]
	public string UserName { get; init; }

	[Required]
	public string Text { get; init; }

	public DateTime TimeUtc { get; init; }
}