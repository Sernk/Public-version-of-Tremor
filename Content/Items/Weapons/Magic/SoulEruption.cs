using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class SoulEruption : ModItem
	{
		public override void SetDefaults()
		{

			Item.mana = 8;
			Item.UseSound = SoundID.Item43;
			Item.useStyle = 5;
			Item.damage = 192;
			Item.autoReuse = true;
			Item.useAnimation = 16;
			Item.useTime = 16;
			Item.width = 40;
			Item.height = 40;
			Item.shoot = 297;
			Item.shootSpeed = 6f;
			Item.knockBack = 6f;
			Item.value = Item.sellPrice(0, 12, 0, 0);
			Item.DamageType = DamageClass.Magic;
            Item.staff[Item.type] = true;
            Item.noMelee = true;
			Item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Soul Eruption");
			// Tooltip.SetDefault("");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i)
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(+1, +1), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-1, -1), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
            }
            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpectreBar, 20);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 12);
			recipe.AddIngredient(ModContent.ItemType<PurpleQuartz>(), 15);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
