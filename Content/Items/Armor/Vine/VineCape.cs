using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Vine
{
	[AutoloadEquip(EquipType.Body)]
	public class VineCape : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 30;
			Item.height = 22;

			Item.value = 100;
			Item.rare = 1;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vine Cape");
			// Tooltip.SetDefault("5% increased ranged damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Ranged) += 0.05f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.VineRope, 60);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}

	}
}
