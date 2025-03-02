using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Armor.Paraxyde
{
	[AutoloadEquip(EquipType.Legs)]
	public class ParaxydeGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = 5;
			Item.defense = 17;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Paraxyde Greaves");
			//Tooltip.SetDefault("Increases maximum mana by 40");
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 40;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ParaxydeShard>(), 15);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<AlchematorTile>());
			recipe.Register();
		}
	}
}