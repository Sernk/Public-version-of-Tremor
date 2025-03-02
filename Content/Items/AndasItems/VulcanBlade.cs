using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Filters = Terraria.Graphics.Effects.Filters;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.AndasItems
{
	public class VulcanBlade : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 545;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 48;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.shoot = ModContent.ProjectileType<VulcanBladePro>();
			Item.shootSpeed = 12f;
			Item.value = 600000;
			Item.rare = 0;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = false;
			Item.useTurn = false;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (var tooltip in tooltips)
            {
                // Меняем цвет текста для названия предмета
                if (tooltip.Mod == "Terraria" && tooltip.Name == "ItemName")
                {
                    tooltip.OverrideColor = new Color(238, 194, 73); // Цвет золота
                }
            }
        }
    }
}
