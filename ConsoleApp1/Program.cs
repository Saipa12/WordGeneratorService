internal class Program
{
	private static async Task Main(string[] args)
	{
		Console.WriteLine("Console Application with Saga Pattern");

		try
		{
			// Шаг 1: Вызов микросервиса для получения случайного слова
			string randomWord = await CallRandomWordService("http://localhost:6000/api/word");
			Console.WriteLine($"Random Word: {randomWord}");

			// Шаг 2: Другие действия или вызовы микросервисов
			//await PerformOtherActions(randomWord);
			randomWord = await CallRandomWordService("http://localhost:6001/api/word");
			Console.WriteLine($"Random Word: {randomWord}");

			Console.WriteLine("Saga completed successfully.");
		}
		catch (Exception ex)
		{
			// Шаг 3: Обработка ошибок и запуск компенсирующих действий
			Console.WriteLine($"Saga failed: {ex.Message}");
			await RollbackActions();
		}
	}

	private static async Task<string> CallRandomWordService(string serviceUrl)
	{
		// Ваш код для вызова микросервиса RandomWordService
		// Используйте HttpClient, gRPC или другие средства взаимодействия с микросервисом.
		// Пример использования HttpClient:
		// var httpClient = new HttpClient();
		// var response = await httpClient.GetAsync("http://localhost:5000/api/RandomWord");
		// return await response.Content.ReadAsStringAsync();
		//return "SampleWord";
		//string serviceUrl = "http://localhost:6000/api/word";

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

	//private static async Task PerformOtherActions(string randomWord)
	//{
	//	// Ваш код для выполнения других действий или вызова других микросервисов
	//	// Можно сгенерировать ошибку для демонстрации сбоя
	//	throw new InvalidOperationException("Simulated failure in other actions");
	//}

	private static async Task RollbackActions()
	{
		\
		Console.WriteLine("Performing rollback actions...");
	}
}