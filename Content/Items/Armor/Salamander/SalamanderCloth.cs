using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Salamander
{
	[AutoloadEquip(EquipType.Body)]
	public class SalamanderCloth : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 26;
			Item.rare = 1;
			Item.value = 100;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Salamander Cloth");
			//Tooltip.SetDefault("Increases movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.2f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SalamanderSkin>(), 10);
			//recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}
