namespace SmartHome.Models.News;

public class NewsData
{
	public long Id { get; set; }

	public string Title { get; set; }

	public string Author { get; set; }

	public string Text { get; set; }

	public DateTime CreateTime { get; set; }
}