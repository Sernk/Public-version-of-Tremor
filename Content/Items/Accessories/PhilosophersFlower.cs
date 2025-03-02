using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class PhilosophersFlower : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 100;
			Item.rare = 4;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Philosophers Flower");
			//Tooltip.SetDefault("Reduces the cooldown of healing potions\n" +
			//"Automatically uses mana potions when needed");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.potionDelayTime = 2700;
			player.manaFlower = true;
			player.manaCost -= 0.10f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PhilosophersStone, 1);
			recipe.AddIngredient(ItemID.ManaFlower, 1);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();
		}
	}
}
