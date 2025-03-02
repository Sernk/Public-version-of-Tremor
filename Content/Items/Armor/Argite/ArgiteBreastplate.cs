using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Argite
{
	[AutoloadEquip(EquipType.Body)]
	public class ArgiteBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 25000;
			Item.rare = 3;
			Item.defense = 9;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Argite Breastplate");
			Tooltip.SetDefault("12% increased melee damage");
		}*/

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Melee) += 0.12f;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ArgiteBar>(), 22);
            //recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
