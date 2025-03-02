using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class BloodmoonPotion : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 32;
			Item.maxStack = 20;
			Item.rare = 6;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 2;
			Item.UseSound = SoundID.Item3;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Bloodmoon Potion");
			//Tooltip.SetDefault("Summons Blood Moon");
		}

		public override bool CanUseItem(Player player)
		{
			if (!Main.dayTime && !Main.bloodMoon)
				return true;
			return false;
		}

		public override bool? UseItem(Player player)
		{
			Main.bloodMoon = true;
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(520, 1);
			recipe.AddIngredient(521, 1);
			recipe.AddIngredient(ModContent.ItemType<SkullTeeth>(), 1);
			recipe.AddTile(13);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
