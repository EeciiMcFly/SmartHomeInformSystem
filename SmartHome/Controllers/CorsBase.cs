namespace SmartHome.Controllers;

public static class CorsBase
{
	public static void AddCorsHeader(IHeaderDictionary headerDictionary)
	{
		headerDictionary.Add("Access-Control-Allow-Origin", "*");
		headerDictionary.Add("Access-Control-Allow-Methods", "GET, POST");
		headerDictionary.Add("Access-Control-Allow-Headers", "Origin, Content-Type, Authorization");
	}
}