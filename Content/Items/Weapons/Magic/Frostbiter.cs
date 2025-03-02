using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class Frostbiter : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 86;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 9;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 128440;
			Item.rare = 8;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 118;
			Item.shootSpeed = 5f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Frostbiter");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<FrostoneBar>(), 20);
			recipe.AddIngredient(ItemID.Ectoplasm, 12);
			recipe.AddIngredient(ItemID.Lens, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int shotAmt = 2;
            int spread = 5;
            float spreadMult = 0.3f;

            for (int i = 0; i < shotAmt; i++)
            {
                float vX = velocity.X + Main.rand.NextFloat(-spread, spread) * spreadMult;
                float vY = velocity.Y + Main.rand.NextFloat(-spread, spread) * spreadMult;

                Vector2 newVelocity = new Vector2(vX, vY);

                Projectile.NewProjectile(source, position, newVelocity, type, damage, knockback, Main.myPlayer);
            }
            return false;
        }
    }
}