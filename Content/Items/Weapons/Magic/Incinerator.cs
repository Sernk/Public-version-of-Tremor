using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class Incinerator : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 82;
			Item.mana = 12;
			Item.width = 20;
			Item.height = 12;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 27;
			Item.useAnimation = 27;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 6, 0, 0);
			Item.rare = 8;
			Item.crit = 3;
			Item.useStyle = 5;
			Item.UseSound = SoundID.Item36;
			//Item.noMelee = true;
			Item.autoReuse = true;
			Item.shoot = 260;
			Item.shootSpeed = 10f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Incinerator");
			//Tooltip.SetDefault("");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i)
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity - new Vector2(2, 2), type, damage, knockback, Main.myPlayer);
            }
            return false;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(2);
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GolemCore>(), 1);
			recipe.AddIngredient(ItemID.HeatRay, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 16);
			recipe.AddIngredient(ItemID.SoulofFright, 16);
			recipe.AddIngredient(ItemID.SoulofSight, 16);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<GolemCore>(), 1);
			recipe1.AddIngredient(ItemID.HeatRay, 1);
			recipe1.AddIngredient(ModContent.ItemType<SoulofMind>(), 16);
			recipe1.AddIngredient(ItemID.SoulofFright, 16);
			recipe1.AddIngredient(ItemID.SoulofSight, 16);
			//recipe.SetResult(this);
			recipe1.AddTile(134);
			recipe1.Register();
		}
	}
}
