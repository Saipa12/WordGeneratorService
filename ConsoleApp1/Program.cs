internal class Program
{
	private static async Task Main()
	{
		string serviceUrl = "http://localhost:6000/api/word";

		using (HttpClient client = new())
		{
			try
			{
				HttpResponseMessage response = await client.GetAsync(serviceUrl);
				response.EnsureSuccessStatusCode();
				string word = await response.Content.ReadAsStringAsync();
				Console.WriteLine($"Random Word: {word}");
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"HTTP Request Error: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}
	}
}