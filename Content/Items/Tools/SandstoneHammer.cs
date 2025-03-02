using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Tools
{
	public class SandstoneHammer : ModItem
	{
		public override void SetDefaults()
		{
			Item.autoReuse = true;
			Item.useStyle = 1;
			Item.useAnimation = 45;
			Item.useTime = 19;
			Item.hammer = 55;
			Item.width = 24;
			Item.height = 28;
			Item.damage = 18;
			Item.knockBack = 6f;
			Item.scale = 1.3f;
			Item.UseSound = SoundID.Item1;
			Item.rare = 1;
			Item.value = 13500;
			Item.DamageType = DamageClass.Melee;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Hammer");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AntlionShell>(), 1);
			recipe.AddIngredient(ItemID.Topaz, 2);
			recipe.AddIngredient(ItemID.AntlionMandible, 4);
			recipe.AddTile(16);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
