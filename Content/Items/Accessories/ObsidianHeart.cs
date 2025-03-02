using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories
{
	public class ObsidianHeart : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 1200;
			Item.rare = 2;
			Item.accessory = true;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Obsidian Heart");
			//Tooltip.SetDefault("Increases life regeneration\n" +
			//"Grants immunity to fire blocks");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 1;
			player.fireWalk = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<HeartofAtis>(), 1);
			recipe.AddIngredient(ItemID.ObsidianSkull, 1);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();
		}

	}
}
