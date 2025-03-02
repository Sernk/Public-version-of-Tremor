using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class NightFury : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 10;
			Item.value = Item.sellPrice(2, 0, 0, 0);
			Item.rare = 4;
			//Item.noMelee = true;
			Item.useStyle = 5;
			Item.useAnimation = 40;
			Item.useTime = 40;
			Item.knockBack = 7.5F;
			Item.damage = 36;
			Item.scale = 1.1F;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<NightFuryPro>();
			Item.shootSpeed = 15.9F;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Night Fury");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Sunfury, 1);
			recipe.AddIngredient(ModContent.ItemType<LeafBall>(), 1);
			recipe.AddIngredient(ItemID.BallOHurt, 1);
			recipe.AddIngredient(ItemID.BlueMoon, 1);
			//recipe.SetResult(this);
			recipe.AddTile(26);
			recipe.Register();
		}
	}
}
