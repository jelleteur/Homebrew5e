using Homebrew5e.Core.Models;
using Homebrew5e.DAL;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Asn1.Ocsp;

public class ItemInfoModel : PageModel
{
	public Item ItemDetails { get; private set; }

	public ItemInfoModel()
	{
		ItemDetails = new Item();
	}

	public void OnGet()
	{
		if (int.TryParse(Request.Query["id"], out int itemId))
		{
			ItemRepository repository = new ItemRepository();
			ItemDetails = ItemDetails.GetByID(repository, itemId);
		}
		else
		{
			Redirect($"/Error");
		}
	}
}
