using Microsoft.AspNetCore.Mvc;

namespace WordGeneratorService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WordController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetRandomWord()
		{
			string[] words = { "apple", "banana", "orange", "grape", "kiwi" };
			Random random = new();
			int index = random.Next(words.Length);
			string randomWord = words[index];

			return Ok(new { RandomWord = randomWord });
		}
	}
}