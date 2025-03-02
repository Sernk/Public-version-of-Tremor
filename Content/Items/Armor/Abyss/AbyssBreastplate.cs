using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Abyss
{
	[AutoloadEquip(EquipType.Body)]
	public class AbyssBreastplate : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 18000;
			Item.rare = 7;
			Item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Abyss Breastplate");
			/* Tooltip.SetDefault("14% increased minion damage\n" +
			"Increases your max number of minions"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 2;
			player.GetDamage(DamageClass.Summon) += 0.14f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DarknessCloth>(), 13);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.Amethyst, 8);
			recipe.AddIngredient(ModContent.ItemType<PhantomSoul>(), 5);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}

	}
}
