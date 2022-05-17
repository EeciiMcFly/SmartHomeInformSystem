using System.ComponentModel.DataAnnotations;

namespace SmartHome.DTO;

public class ChatDto
{
	public long Id { get; init; }

	[Required]
	public string Name { get; set; }
}