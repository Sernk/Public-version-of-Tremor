using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class LightningOrb : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Magic;
			Item.width = 10;
			Item.height = 10;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = 5;
			Item.UseSound = SoundID.Item81;
			//Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = 10000;
			Item.rare = 5;
			Item.autoReuse = false;
			Item.shoot = 580;
			Item.shootSpeed = 7f;
			Item.mana = 30;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Lightning Orb");
			//Tooltip.SetDefault("Creates a divine lightning");
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 vector82 = -Main.player[Main.myPlayer].Center + Main.MouseWorld;
            float ai = Main.rand.Next(100);
            Vector2 vector83 = Vector2.Normalize(vector82) * Item.shootSpeed;
            Projectile.NewProjectile(source, player.Center.X, player.Center.Y, vector83.X, vector83.Y, type, damage, knockback, player.whoAmI, vector82.ToRotation(), ai);
            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Glass, 30);
			recipe.AddIngredient(ModContent.ItemType<AirFragment>(), 16);
			recipe.AddIngredient(ItemID.SoulofLight, 12);
			recipe.AddIngredient(ItemID.SoulofNight, 12);
			recipe.AddIngredient(ItemID.Diamond, 15);
			recipe.AddIngredient(ItemID.RainCloud, 25);
			recipe.Register();
		}
	}
}
