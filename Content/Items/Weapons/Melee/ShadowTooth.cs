using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class ShadowTooth : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 46;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = 121;
			Item.shootSpeed = 6f;
			Item.useStyle = 1;
			Item.knockBack = 2;
			Item.value = 46000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Shadow Tooth");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ItemID.SoulofSight, 8);
			recipe.AddIngredient(ModContent.ItemType<ColdTooth>(), 1);
			recipe.AddTile(ModContent.TileType<GreatAnvilTile>());
			//recipe.SetResult(this);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.SoulofNight, 8);
			recipe1.AddIngredient(ItemID.SoulofSight, 8);
			recipe1.AddIngredient(ModContent.ItemType<FlamingTooth>(), 1);
            recipe1.AddTile(ModContent.TileType<GreatAnvilTile>());
            //recipe.SetResult(this);
            recipe1.Register();
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(153, 120);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool())
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 65);
			}
		}
	}
}
