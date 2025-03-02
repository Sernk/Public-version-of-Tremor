using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class DivineClaymore : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 232;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 48;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.shoot = ModContent.ProjectileType<DivineClaymorePro>();
			Item.shootSpeed = 12f;
			Item.value = 12400;
			Item.rare = 0;
			Item.UseSound = SoundID.Item15;
			Item.autoReuse = true;
			Item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Divine Claymore");
			//Tooltip.SetDefault("");
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
			recipe.AddIngredient(ModContent.ItemType<VoidBlade>(), 1);
			recipe.AddIngredient(ModContent.ItemType<AngeliteBar>(), 30);
			recipe.AddIngredient(ModContent.ItemType<Aquamarine>(), 8);
			recipe.AddIngredient(ModContent.ItemType<AngryShard>(), 3);
			recipe.AddIngredient(ModContent.ItemType<Doomstone>(), 3);
			recipe.AddIngredient(ItemID.SoulofLight, 25);
			recipe.AddIngredient(ModContent.ItemType<PurpleQuartz>(), 5);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<DivineForgeTile>());
			recipe.Register();
		}
	}
}
