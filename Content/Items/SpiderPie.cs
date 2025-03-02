using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Buffs;
using TremorMod.Content.Mounts;

namespace TremorMod.Content.Items
{
	public class SpiderPie : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 28;
			Item.height = 30;

			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 30000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item79;
			Item.noMelee = true;
			Item.mountType = ModContent.MountType<Spider>();
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Spider Pie");
			// Tooltip.SetDefault("Summons a rideable Fat Spider mount");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bowl, 1);
			recipe.AddIngredient(ModContent.ItemType<SpiderMeat>(), 15);
			recipe.AddIngredient(ItemID.Cobweb, 100);
			//recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.Register();
		}
	}
}
