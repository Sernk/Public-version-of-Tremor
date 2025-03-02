using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Accessories.Sparks
{
	public class SummonerFocus : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 22;

			Item.rare = 2;
			Item.accessory = true;
			Item.value = 50000;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Summoner Focus");
			/* Tooltip.SetDefault("8% increased minion damage\n" +
"Increases your max number of minions"); */
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 1;
            player.GetDamage(DamageClass.Summon) += 0.08f;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SummonerSpark>());
			recipe.AddIngredient(ModContent.ItemType<EarthFragment>(), 1);
			recipe.AddIngredient(ItemID.Emerald, 16);
			//recipe.SetResult(this);/
			recipe.AddTile(ModContent.TileType<AltarofEnchantmentsTile>());
			recipe.Register();
		}
	}
}
