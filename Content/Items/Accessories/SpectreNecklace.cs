using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class SpectreNecklace : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 20;
			Item.value = 110;
			Item.rare = 8;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Spectre Necklace");
			//Tooltip.SetDefault("The less mana, the more defense...");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statMana < 25)
			{
				player.statDefense += 10;
			}
			if (player.statMana < 100)
			{
				player.statDefense += 8;
			}
			if (player.statMana < 200)
			{
				player.statDefense += 6;
			}
			if (player.statMana < 300)
			{
				player.statDefense += 3;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpectreBar, 25);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
