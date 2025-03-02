using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Tools
{
	public class CrystalWarhamaxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.hammer = 100;
			Item.axe = 22;
			Item.tileBoost++;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 15000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Warhamaxe");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ChaosBar>(), 15);
			recipe.AddIngredient(ItemID.CrystalShard, 22);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 71);
			}
		}

		public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.OnFire, 60); // Пример: добавляем эффект горения на 60 кадров
        }
    }
}
