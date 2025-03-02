using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Magium
{
	[AutoloadEquip(EquipType.Body)]
	public class MagiumBreastplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 18000;
			Item.rare = 5;
			Item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Magium Breastplate");
			//Tooltip.SetDefault("10% increased magic damage\n" +
			//"Increases maximum mana by 40");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) += 0.1f;
            player.statManaMax2 += 40;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RuneBar>(), 12);
			recipe.AddIngredient(ModContent.ItemType<MagiumShard>(), 10);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}

	}
}
