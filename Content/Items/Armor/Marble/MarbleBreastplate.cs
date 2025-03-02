using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Marble
{
	[AutoloadEquip(EquipType.Body)]
	public class MarbleBreastplate : ModItem
	{
		public override void SetDefaults()
		{

			Item.defense = 6;
			Item.width = 22;
			Item.height = 30;
			Item.value = 5000;
			Item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Marble Breastplate");
			// Tooltip.SetDefault("10% increased throwing damage");
		}

		public override void UpdateEquip(Player p)
		{
			p.GetDamage(DamageClass.Throwing) += 0.1f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MarbleBlock, 80);
			recipe.AddIngredient(ModContent.ItemType<StoneofLife>(), 1);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
