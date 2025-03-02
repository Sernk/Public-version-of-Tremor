using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Buffs;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Buffs
{

	public class SunfuryPotion : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 32;
			Item.maxStack = 20;

			Item.rare = 11;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 2;
			Item.UseSound = SoundID.Item3;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Sunfury Potion");
			// Tooltip.SetDefault("Increases all stats during daytime");
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			player.AddBuff(ModContent.BuffType<DayHunting>(), 14400);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ModContent.ItemType<AngryShard>(), 1);
			recipe.AddIngredient(ModContent.ItemType<AlienTongue>(), 1);
			recipe.AddIngredient(ModContent.ItemType<PinkGelCube>(), 1);
			recipe.AddTile(ModContent.TileType<AlchemyStationTile>());
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
