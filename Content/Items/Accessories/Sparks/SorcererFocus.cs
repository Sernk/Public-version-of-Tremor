using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Accessories.Sparks
{
	public class SorcererFocus : ModItem
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
			//DisplayName.SetDefault("Sorcerer Focus");
			//Tooltip.SetDefault("6% increased magic damage\n" +
			//"Increases magic critical strike chance by 12\n" +
			//"Increases maximum mana by 40");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 40;
            player.GetDamage(DamageClass.Magic) += 0.06f;
            player.GetCritChance(DamageClass.Magic) += 12;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SorcererSpark>());
			recipe.AddIngredient(ModContent.ItemType<SeaFragment>(), 1);
			recipe.AddIngredient(ItemID.Sapphire, 16);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<AltarofEnchantmentsTile>());
			recipe.Register();
		}
	}
}
