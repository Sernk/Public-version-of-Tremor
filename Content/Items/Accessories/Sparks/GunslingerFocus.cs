using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Accessories.Sparks
{
	public class GunslingerFocus : ModItem
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
			//DisplayName.SetDefault("Gunslinger Focus");
			//Tooltip.SetDefault("6% increased ranged damage\n" +
			//"Increases ranged critical strike chance by 12");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Ranged) += 0.06f;
			player.GetCritChance(DamageClass.Ranged) += 12;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GunslingerSpark>());
			recipe.AddIngredient(ModContent.ItemType<FireFragment>(), 1);
			recipe.AddIngredient(ItemID.Topaz, 16);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<AltarofEnchantmentsTile>());
			recipe.Register();
		}
	}
}