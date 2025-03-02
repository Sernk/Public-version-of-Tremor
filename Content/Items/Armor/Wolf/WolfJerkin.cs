using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Wolf
{
	[AutoloadEquip(EquipType.Body)]
	public class WolfJerkin : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 26;
			Item.rare = 1;

			Item.value = 100;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wolf Jerkin");
			/* Tooltip.SetDefault("6% increased minion damage\n" +
"Increases your max number of minions"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.GetDamage(DamageClass.Summon) += 0.06f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<WolfPelt>(), 16);
			recipe.AddIngredient(ModContent.ItemType<AlphaClaw>(), 2);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}
