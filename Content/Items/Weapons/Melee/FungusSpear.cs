using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Fungus;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class FungusSpear : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.width = 54;
			Item.height = 54;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<FungusSpearPro>();
			Item.shootSpeed = 3f;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 1000;
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;

		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Spear");
			Tooltip.SetDefault("Has a chance to inflict confusion on enemies");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<FungusElement>(), 11);
			recipe1.AddIngredient(ItemID.GlowingMushroom, 10);
			recipe1.AddIngredient(ModContent.ItemType<GoldSpear>(), 1);
			//recipe.SetResult(this);
			recipe1.AddTile(16);
			recipe1.Register();

			Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<FungusElement>(), 11);
            recipe2.AddIngredient(ItemID.GlowingMushroom, 10);
            recipe2.AddIngredient(ModContent.ItemType<GoldSpear>(), 1);
            //recipe.SetResult(this);
			recipe2.AddTile(16);
			recipe2.Register();
		}
	}
}
