using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Sandstone
{
	[AutoloadEquip(EquipType.Legs)]
	public class SandStoneGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 500;
			Item.rare = 2;
			Item.defense = 4;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Greaves");
			Tooltip.SetDefault("10% increased movement speed");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SandstoneBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<AntlionShell>(), 1);
            recipe.AddIngredient(ModContent.ItemType<PetrifiedSpike>(), 4);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }
	}
}
