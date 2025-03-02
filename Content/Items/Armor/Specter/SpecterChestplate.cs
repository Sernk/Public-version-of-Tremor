using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Specter
{
	[AutoloadEquip(EquipType.Body)]
	public class SpecterChestplate : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 10000;
			Item.rare = 11;
			Item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Specter Chestplate");
			/* Tooltip.SetDefault("12% increased melee damage\n" +
	  "Increases maximum number of minions by 2"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.2f;
			player.GetDamage(DamageClass.Melee) += 0.12f;
			player.maxMinions += 2;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CryptStone>(), 8);
			recipe.AddIngredient(ModContent.ItemType<CursedCloth>(), 10);
			recipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
			recipe.Register();
		}
	}
}
