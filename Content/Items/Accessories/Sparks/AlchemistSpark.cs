using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories.Sparks
{
	public class AlchemistSpark : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Alchemist Spark");
			/* Tooltip.SetDefault("3% increased alchemical damage\n" +
			                   "8% increased alchemical critical strike chance"); */
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
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.03f;
			player.GetModPlayer<MPlayer>().alchemicalCrit += 8;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AdventurerSpark>());
			recipe.Register();
		}
	}
}
