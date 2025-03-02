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

namespace TremorMod.Content.Items.NPCsDrop
{
	public class LivingWoodThreepeater : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 45;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 29;
			Item.useAnimation = 29;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 30000;
			Item.rare = 6;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 1;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Living Wood Threepeater");
			// Tooltip.SetDefault("");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-1, -1), type, damage, knockback, player.whoAmI);
            }
            return false;
        }


    }
}
