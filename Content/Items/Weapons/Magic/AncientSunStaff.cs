using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class AncientSunStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 16;
			Item.width = 88;
			Item.height = 88;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = 5;
			Item.shoot = ModContent.ProjectileType<AncientSunPro>();
			Item.shootSpeed = 10f;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 10;
			Item.UseSound = SoundID.Item75;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.staff[Item.type] = true;

		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Sun Staff");
			// Tooltip.SetDefault("Summons an fiery exploding bolt");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 64);
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AncientTablet>(), 12);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
