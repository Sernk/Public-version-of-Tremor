using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Flesh
{
	[AutoloadEquip(EquipType.Legs)]
	public class FleshGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 18000;
			Item.rare = 1;
			Item.defense = 7;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flesh Greaves");
			Tooltip.SetDefault("5% increased minion damage\n" +
			"Increases your max number of minions");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
            player.GetDamage(DamageClass.Summon) += 0.05f;
        }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PieceofFlesh>(), 6);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }

	}
}
