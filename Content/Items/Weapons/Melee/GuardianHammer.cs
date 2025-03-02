using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class GuardianHammer : ModItem
	{
		public override void SetDefaults()
		{
			//item.noMelee = true;
			Item.useStyle = 1;
			Item.shootSpeed = 14f;
			Item.shoot = ModContent.ProjectileType<GuardianHammerPro>();
			Item.damage = 125;
			Item.knockBack = 9f;
			Item.width = 14;
			Item.height = 28;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.noUseGraphic = true;
			Item.rare = 11;
			Item.value = Item.sellPrice(0, 20, 0, 0);
			Item.DamageType = DamageClass.Melee;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Guardian Hammer");
			//Tooltip.SetDefault("");
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-1, -1), type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PaladinsHammer, 1);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 16);
			recipe.AddTile(412);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
