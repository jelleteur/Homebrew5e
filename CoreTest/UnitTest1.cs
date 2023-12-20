using Homebrew5e.Core.Collections;
using Homebrew5e.Core.DTOs;
using Homebrew5e.Core.Models;
using Homebrew5e.CoreTest;

namespace CoreTest
{
	public class UnitTest1
	{
		[Fact]
		public void TestDataCollection()
		{
			//Arrange
			List<ItemDTO> itemDTOs = new List<ItemDTO>
			{
				new ItemDTO()
				{
					Name = "Test",
					Attribute = "+2 Str",
					Description = "Strong test item"
				},
				new ItemDTO()
				{
					Name = "Test",
					Attribute = "+2 Dex",
					Description = "Dexterous test item"
				}
			};

			ItemCollection itemCollection = new ItemCollection(new ItemTestRepository(itemDTOs));
			List<Item> items = new List<Item>();


			//Act
			items = itemCollection.GetAllItems();

			//Assert
			Assert.Equal(2, items.Count); //list length
			Assert.True(items[1].GetAttribute() == "+2 Dex"); //attribute assignment
		}
	}
}