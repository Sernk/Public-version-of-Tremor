using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class ShiningAxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.autoReuse = true;
			Item.useStyle = 1;
			Item.shootSpeed = 8f;
			Item.shoot = ModContent.ProjectileType<ShiningAxePro>();
			Item.damage = 234;
			Item.width = 18;
			Item.height = 20;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 14;
			Item.useTime = 17;
			Item.noUseGraphic = true;
			Item.value = 6000;
			Item.knockBack = 4f;
			Item.DamageType = DamageClass.Melee;
			Item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Shining Axe");
			//Tooltip.SetDefault("Magical throwing axe!");
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
			recipe.AddIngredient(ItemID.PossessedHatchet, 1);
			recipe.AddIngredient(ModContent.ItemType<WhiteGoldBar>(), 15);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<DivineForgeTile>());
			recipe.Register();
		}
	}
}
