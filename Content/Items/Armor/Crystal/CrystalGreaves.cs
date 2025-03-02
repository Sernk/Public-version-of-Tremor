using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Crystal
{
	[AutoloadEquip(EquipType.Legs)]
	public class CrystalGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.defense = 5;
			Item.width = 22;
			Item.height = 18;
			Item.value = 2500;
			Item.rare = 4;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Greaves");
			Tooltip.SetDefault("20% increased throwing critical strike chance");
		}*/

		public override void UpdateEquip(Player player)
		{
            player.GetCritChance(DamageClass.Throwing) += 20;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrystalShard, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
