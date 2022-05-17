using System.ComponentModel.DataAnnotations;

namespace SmartHome.DTO;

public class NewsDto
{
	public long Id { get; init; }

	[Required]
	public string Title { get; init; }

	[Required]
	public string Author { get; init; }

	[Required]
	public string Text { get; init; }

	public DateTime CreateTimeUtc { get; init; }
}