using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Crystal
{
	[AutoloadEquip(EquipType.Body)]
	public class CrystalChestplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 200;
			Item.rare = 4;
			Item.defense = 9;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Chestplate");
			Tooltip.SetDefault("30% increased throwing velocity");
		}*/

		public override void UpdateEquip(Player player)
		{
            player.GetAttackSpeed(DamageClass.Throwing) += 0.3f;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
