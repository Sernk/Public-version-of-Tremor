using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Buffs;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Buffs
{
	public class SavingPotion : ModItem
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
			//DisplayName.SetDefault("Saving Potion");
			//Tooltip.SetDefault("Greatly reduces mana cost");
		}

		public override bool? UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<ManaSaving>(), 14400);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(314, 2);
			recipe.AddIngredient(ModContent.ItemType<ClusterShard>(), 1);
			recipe.AddIngredient(ModContent.ItemType<ManaFruit>(), 5);
			recipe.AddTile(ModContent.TileType<AlchemyStationTile>());
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
