using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class MeatShield : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.value = 11000;
			Item.rare = 6;
			Item.accessory = true;
			Item.defense = 12;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Meat Shield");
			//Tooltip.SetDefault("");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed -= 0.40f;
			player.aggro += 400;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FleshKnuckles, 1);
			recipe.AddIngredient(ModContent.ItemType<HardBulwark>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.PutridScent, 1);
			recipe1.AddIngredient(ModContent.ItemType<HardBulwark>(), 1);
			//recipe1.SetResult(this);
			recipe1.AddTile(114);
			recipe1.Register();
		}
	}
}
