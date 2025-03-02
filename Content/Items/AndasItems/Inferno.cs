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
	public class Inferno : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 520;
			Item.width = 62;
			Item.height = 62;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 20;
            Item.shoot = 706;
            Item.shootSpeed = 12f;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 600000;
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
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
