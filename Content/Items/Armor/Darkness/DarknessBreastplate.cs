using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Darkness
{
	[AutoloadEquip(EquipType.Body)]
	public class DarknessBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 18;

			Item.value = 600000;
			Item.rare = 11;
			Item.defense = 30;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Breastplate of Darkness");
			// Tooltip.SetDefault("Increases life regeneration");
		}

		public override void UpdateEquip(Player player)
		{
			player.lifeRegen += 5;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DarkGel>(), 38);
			recipe.AddIngredient(ModContent.ItemType<DarkMatter>(), 38);
			recipe.AddIngredient(ModContent.ItemType<DarkMass>(), 1);
			recipe.AddTile(247);
			recipe.Register();
		}
	}
}
