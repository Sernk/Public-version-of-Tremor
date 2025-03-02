using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Plague
{
	[AutoloadEquip(EquipType.Legs)]
	public class PlagueGreaves : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 25000;
			Item.rare = 2;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Plague Greaves");
			// Tooltip.SetDefault("10% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.1f;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 16);
            recipe.AddIngredient(ModContent.ItemType<PhantomSoul>(), 4);
            recipe.AddIngredient(ModContent.ItemType<TearsofDeath>(), 8);
            recipe.AddTile(16);
            recipe.Register();
        }

    }
}
