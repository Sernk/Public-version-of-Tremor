using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Tiles;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class DangerBlade : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Starfury);
			Item.shootSpeed *= 0.75f;
			Item.useTime = 6;
			Item.useAnimation = 30;
			Item.autoReuse = true;
			Item.rare = 0;
			Item.damage = 255;
			Item.DamageType = DamageClass.Melee;
        }

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Danger Blade");
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (var tooltip in tooltips)
            {               
                if (tooltip.Mod == "Terraria" && tooltip.Name == "ItemName")
                {
                    tooltip.OverrideColor = new Color(238, 194, 73);
                }
			}
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<DangerBladePro>(), damage, knockback, player.whoAmI);

            return false; 
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CollapsiumBar>(), 16);
			recipe.AddIngredient(ModContent.ItemType<ClusterShard>(), 16);
			recipe.AddIngredient(ModContent.ItemType<AngryShard>(), 5);
			recipe.AddIngredient(ModContent.ItemType<TrueEssense>(), 3);
			recipe.AddIngredient(ModContent.ItemType<GoldenClaw>(), 3);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<DivineForgeTile>());
			recipe.Register();
		}
	}
}
