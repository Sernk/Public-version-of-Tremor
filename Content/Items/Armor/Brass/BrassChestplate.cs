using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Brass
{
	[AutoloadEquip(EquipType.Body)]
	public class BrassChestplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 18;
			Item.value = 600;
			Item.rare = 5;
			Item.defense = 22;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Chestplate");
			Tooltip.SetDefault("Increases maximum life by 50");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 50;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrassBar>(), 18);
            recipe.AddIngredient(ItemID.Cog, 16);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
