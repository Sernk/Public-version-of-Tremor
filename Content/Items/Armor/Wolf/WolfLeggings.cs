using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Wolf
{
	[AutoloadEquip(EquipType.Legs)]
	public class WolfLeggings : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 18;
			Item.rare = 1;

			Item.value = 100;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wolf Leggings");
			/* Tooltip.SetDefault("6% increased minion damage\n" +
"Increases movement speed"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.06f;
			player.moveSpeed += 0.10f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<WolfPelt>(), 10);
			recipe.AddIngredient(ModContent.ItemType<AlphaClaw>(), 1);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}
