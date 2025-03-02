using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using Terraria.ID;
using TremorMod;
using TremorMod.Content.Items;
using TremorMod.Content.NPCs;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using TremorMod.Utilities;
using Terraria.GameInput;
using Terraria.GameContent.Events;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.Graphics.Effects;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Items;

namespace TremorMod.Content.Items.Weapons.Alchemical
{
	public class NovaSprayer : ModItem
	{
        public override void SetDefaults()
		{
            Item.DamageType = TremorMod.alchemicalDamage ?? DamageClass.Generic; 
            Item.damage = 84;
			Item.width = 62;
			Item.height = 32;
			Item.useTime = 6;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 100000;
			Item.rare = 10;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = Mod.Find<ModProjectile>("NovaFlask_ProjBall").Type;
			Item.shootSpeed = 15f;
			Item.crit = 12;
			Item.reuseDelay = 60;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Nova Sprayer");
			/* Tooltip.SetDefault("Shoots a burst of nova balls which explode into flames when hit enemy or after some time,\n" +
			" flames explode into damaging bursts when hit enemy or after some time."); */
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void UpdateInventory(Player player)
		{
			MPlayer modPlayer = MPlayer.GetModPlayer(player);
			if (modPlayer.core)
			{
				Item.autoReuse = true;
			}
			if (!modPlayer.core)
			{
				Item.autoReuse = false;
			}
			if (player.FindBuffIndex(Mod.Find<ModBuff>("LongFuseBuff").Type) != -1)
			{
				Item.shootSpeed = 21f;
			}
			if (player.FindBuffIndex(Mod.Find<ModBuff>("LongFuseBuff").Type) < 1)
			{
				Item.shootSpeed = 15f;
			}
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            if (modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    if (player.FindBuffIndex(Mod.Find<ModBuff>("BottledSpiritBuffs").Type) != -1)
                    {
                        Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), 297, damage, knockback, Main.myPlayer);
                    }
                    if (player.FindBuffIndex(Mod.Find<ModBuff>("BigBottledSpiritBuffs").Type) != -1)
                    {
                        Projectile.NewProjectile(source, position, velocity + new Vector2(3, 3), 297, damage, knockback, Main.myPlayer);
                        Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), 297, damage, knockback, Main.myPlayer);
                    }
                    Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, Main.myPlayer);
                    Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            if (player.FindBuffIndex(Mod.Find<ModBuff>("BottledSpiritBuffs").Type) != -1 && !modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), 297, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            if (player.FindBuffIndex(Mod.Find<ModBuff>("BigBottledSpiritBuffs").Type) != -1 && !modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), 297, damage, knockback, Main.myPlayer);
                    Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), 297, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            return true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NovaFragment>(), 18);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
