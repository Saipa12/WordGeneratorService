using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WordGeneratorService.Pages
{
	public class WordModel : PageModel
	{
		public string? RandomWord { get; private set; }

		public void OnGet()
		{
			string[] words = { "apple", "banana", "orange", "grape", "kiwi" };
			Random random = new();
			int index = random.Next(words.Length);
			RandomWord = words[index];
		}

		public IActionResult OnGetWord()
		{
			OnGet();
			return new JsonResult(new { RandomWord });
		}
	}
}