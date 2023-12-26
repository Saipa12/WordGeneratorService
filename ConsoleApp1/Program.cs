internal class Program
{
	private static async Task Main(string[] args)
	{
		Console.WriteLine("Console Application with Saga Pattern");

		try
		{
			string randomWord = await CallRandomWordService("http://localhost:6000/api/word");
			Console.WriteLine($"Random Word: {randomWord}");

			randomWord = await CallRandomWordService("http://localhost:6001/api/word");
			Console.WriteLine($"Random Word: {randomWord}");

			Console.WriteLine("Saga completed successfully.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Saga failed: {ex.Message}");
			await RollbackActions();
		}
	}

	private static async Task<string> CallRandomWordService(string serviceUrl)
	{
		using HttpClient client = new();
		try
		{
			HttpResponseMessage response = await client.GetAsync(serviceUrl);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync();
			//Console.WriteLine($"Random Word: {word}");
		}
		catch (HttpRequestException ex)
		{
			Console.WriteLine($"HTTP Request Error: {ex.Message}");
			throw ex;
			//return ex.Message;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
			throw ex;
			//return ex.Message;
		}
	}

	private static async Task RollbackActions()
	{
		Console.WriteLine("Performing rollback actions...");
	}
}