using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Armor.Chain;
using TremorMod.Content.Items.Armor.Leather;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Chemist
{
	[AutoloadEquip(EquipType.Legs)]
	public class ChemistPants : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = 2;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chemist Pants");
			// Tooltip.SetDefault("6% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.06f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ChainGreaves>(), 1);
			recipe.AddIngredient(ModContent.ItemType<LeatherGreaves>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.Register();
		}

	}
}
