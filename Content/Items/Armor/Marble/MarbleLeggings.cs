using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Marble
{
	[AutoloadEquip(EquipType.Legs)]
	public class MarbleLeggings : ModItem
	{

		public override void SetDefaults()
		{

			Item.defense = 2;
			Item.width = 22;
			Item.height = 18;
			Item.value = 2500;
			Item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Marble Leggings");
			// Tooltip.SetDefault("10% increased throwing critical strike chance");
		}

		public override void UpdateEquip(Player p)
		{
			p.GetCritChance(DamageClass.Throwing) += 10;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MarbleBlock, 45);
			recipe.AddIngredient(ModContent.ItemType<StoneofLife>(), 1);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
