using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Tools
{
	public class StarDrill : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 20;
			Item.height = 12;
			Item.useTime = 5;
			Item.useAnimation = 25;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.pick = 250;
			Item.tileBoost += 8;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 12, 50, 0);
			Item.rare = 0;
			Item.UseSound = SoundID.Item23;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<StarDrillPro>();
			Item.shootSpeed = 40f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Star Drill");
			// Tooltip.SetDefault("");
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

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TrueEssense>(), 3);
			recipe.AddIngredient(ModContent.ItemType<NightCore>(), 3);
			recipe.AddIngredient(ModContent.ItemType<CometiteBar>(), 15);
			recipe.AddIngredient(ModContent.ItemType<HardCometiteBar>(), 3);
			recipe.AddIngredient(ModContent.ItemType<StarBar>(), 3);
			recipe.AddIngredient(ModContent.ItemType<LunarRoot>(), 25);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<StarvilTile>());
			recipe.Register();
		}
	}
}
