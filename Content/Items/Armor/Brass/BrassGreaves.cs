using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Brass
{
	[AutoloadEquip(EquipType.Legs)]
	public class BrassGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 500;
			Item.rare = 5;
			Item.defense = 4;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Greaves");
			Tooltip.SetDefault("15% increased movement speed");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.15f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrassBar>(), 15);
			recipe.AddIngredient(ItemID.Cog, 14);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
