using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories.Sparks
{
	public class SummonerSpark : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Summoner Spark");
			/* Tooltip.SetDefault("5% increased minion damage\n" +
			                   "Increases your max number of minions"); */
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.rare = 1;
			Item.accessory = true;
			Item.value = Item.buyPrice(silver: 1);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.maxMinions += 1;
            player.GetDamage(DamageClass.Summon) += 0.05f;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AdventurerSpark>());
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
