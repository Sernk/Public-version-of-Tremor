using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories
{
	public class TheCadence : ModItem
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Cadence");
			// Tooltip.SetDefault("Flasks attack your enemies with souls");
		}
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 26;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
			Item.defense = 7;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<TheCadenceBuff>(), 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DragonCapsule>(), 10);
			recipe.AddIngredient(ModContent.ItemType<EarthFragment>(), 8);
			recipe.AddIngredient(ItemID.Sapphire, 6);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}