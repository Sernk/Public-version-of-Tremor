using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Accessories.Sparks
{
	public class GunslingerSoul : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 22;

			Item.rare = 3;
			Item.accessory = true;
			Item.value = 100000;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Gunslinger Soul");
			/* Tooltip.SetDefault("10% increased ranged damage\n" +
"Increases ranged critical strike chance by 15"); */
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 6));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Ranged) += 0.1f;
			player.GetCritChance(DamageClass.Ranged) += 15;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GunslingerFocus>());
			recipe.AddIngredient(ModContent.ItemType<Opal>(), 3);
			recipe.AddIngredient(ItemID.RangerEmblem, 1);
			recipe.AddTile(ModContent.TileType<AltarofEnchantmentsTile>());
			recipe.Register();
		}
	}
}
