using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories
{
	public class Candent : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 10000;
			Item.rare = 3;
			Item.defense = 3;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Candent");
			//Tooltip.SetDefault("7% increased melee damage and critical strike chance");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetDamage(DamageClass.Melee) += 0.13f;
            player.GetCritChance(DamageClass.Melee) += 7;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<FireFragment>(), 12);
			recipe.AddIngredient(ItemID.HellstoneBar, 20);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<GreatAnvilTile>());
			recipe.Register();
		}
	}
}
