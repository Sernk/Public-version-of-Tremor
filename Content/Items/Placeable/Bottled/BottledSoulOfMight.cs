using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles.Bottled;

namespace TremorMod.Content.Items.Placeable.Bottled
{
	public class BottledSoulOfMight : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 24;
			Item.height = 24;
			Item.maxStack = 1;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;

			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.rare = 5;
			Item.createTile = ModContent.TileType<BottledSoulOfMightTile>();
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bottled Soul of Might");
			/* Tooltip.SetDefault("12% increased damage if worn\n" +
"5% increased damage if placed"); */
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(548, 5);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddTile(114);
			recipe.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Melee) += 0.12f;
			player.GetDamage(DamageClass.Ranged) += 0.12f;
			player.GetDamage(DamageClass.Throwing) += 0.12f;
			player.GetDamage(DamageClass.Summon) += 0.12f;
			player.GetDamage(DamageClass.Magic) += 0.12f;
		}
	}
}
