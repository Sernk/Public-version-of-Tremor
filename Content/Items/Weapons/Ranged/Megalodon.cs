using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using Terraria.DataStructures;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class Megalodon : ModItem
	{
		public override void SetDefaults()
		{
			Item.useStyle = 5;
			Item.autoReuse = true;
			Item.useAnimation = 4;
			Item.useTime = 4;
			Item.width = 50;
			Item.height = 18;
			Item.shoot = 10;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.damage = 73;
			Item.shootSpeed = 14f;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = 10;
			Item.knockBack = 1.75f;
			Item.DamageType = DamageClass.Ranged;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Megalodon");
			//Tooltip.SetDefault("50% chance not to consume ammo");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 0);
		}

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(3);
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
			recipe.AddIngredient(ModContent.ItemType<EyeofOblivion>(), 1);
			recipe.AddIngredient(ItemID.Megashark, 1);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 20);
			recipe.AddIngredient(ModContent.ItemType<CarbonSteel>(), 10);
			recipe.AddIngredient(ModContent.ItemType<DeadTissue>(), 5);
			recipe.AddTile(412);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
