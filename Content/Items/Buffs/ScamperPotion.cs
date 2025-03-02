using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Buffs;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Buffs
{
	public class ScamperPotion : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 32;
			Item.maxStack = 20;
			Item.rare = 10;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 2;
			Item.UseSound = SoundID.Item3;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Scamper Potion");
			//Tooltip.SetDefault("75% increased movement speed");
		}

		public override bool? UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<ScamperBuff>(), 14400);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.Cactus, 5);
			recipe.AddIngredient(ModContent.ItemType<ConcentratedEther>(), 2);
			recipe.AddIngredient(ItemID.Blinkroot, 1);
			recipe.AddTile(ModContent.TileType<AlchemyStationTile>());
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
