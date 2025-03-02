using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Ranged
{

	public class Stynginator : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 49;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 20;
			Item.height = 12;
			Item.useTime = 20;
			Item.useAnimation = 20;

			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 6, 0, 0);
			Item.rare = 8;
			Item.crit = 3;
			Item.useStyle = 5;
			Item.UseSound = SoundID.Item36;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.StyngerBolt;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Stynginator");
			// Tooltip.SetDefault("Uses Styngers Bolts as ammo");
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

        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextBool(2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GolemCore>(), 1);
			recipe.AddIngredient(ItemID.Stynger, 1);
			recipe.AddIngredient(ItemID.Ectoplasm, 18);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
