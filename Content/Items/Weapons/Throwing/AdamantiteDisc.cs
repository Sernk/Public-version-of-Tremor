using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class AdamantiteDisc : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 44;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 20;
			Item.shootSpeed = 12f;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 3f;
			Item.value = 27600;
			Item.rare = 4;
			Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<AdamantiteDiscPro>();
			Item.shootSpeed = 12f;
			Item.autoReuse = true;
		}

		

		public override bool CanUseItem(Player player)
		{
			for (int i = 0; i < 1000; ++i)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
				{
					return false;
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
