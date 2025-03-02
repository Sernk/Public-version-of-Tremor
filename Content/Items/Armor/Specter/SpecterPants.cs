using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Specter
{
	[AutoloadEquip(EquipType.Legs)]
	public class SpecterPants : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;

			Item.value = 10000;
			Item.rare = 11;
			Item.defense = 15;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Specter Pants");
			/* Tooltip.SetDefault("10% increased melee damage\n" +
			                   "10% increased minion damage"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += 0.1f;
			player.GetDamage(DamageClass.Summon) += 0.1f;
		}
	
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CryptStone>(), 5);
            recipe.AddIngredient(ModContent.ItemType<CursedCloth>(), 6);
            recipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
            recipe.Register();
        }
    }
}
