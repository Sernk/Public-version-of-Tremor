using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Granite
{
	[AutoloadEquip(EquipType.Body)]
	public class GraniteChestplate : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 18;
			Item.value = 2500;
			Item.rare = 1;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Granite Chestplate");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GraniteBlock, 75);
			recipe.AddIngredient(ModContent.ItemType<StoneofLife>(), 1);
			recipe.AddTile(16);
			recipe.Register();
		}

	}
}
