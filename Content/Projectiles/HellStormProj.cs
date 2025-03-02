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

namespace TremorMod.Content.Projectiles
{
	public class HellStormProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 78;
			Projectile.height = 32;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Ranged;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hell Storm");
		}*/

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            float num = 1.57079637f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);

            if (Projectile.type == ModContent.ProjectileType<HellStormProj>())
            {
                Projectile.ai[0] += 1f;
                int num2 = 0;
                if (Projectile.ai[0] >= 120f) num2++;
                if (Projectile.ai[0] >= 200f) num2++;
                if (Projectile.ai[0] >= 280f) num2++;

                int num3 = 24;
                int num4 = 6;
                Projectile.ai[1] += 1f;
                bool flag = false;

                if (Projectile.ai[1] >= num3 - num4 * num2)
                {
                    Projectile.ai[1] = 0f;
                    flag = true;
                }

                Projectile.frameCounter += 1 + num2;
                if (Projectile.frameCounter >= 4)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;
                    if (Projectile.frame >= 3) Projectile.frame = 0;
                }

                if (Projectile.soundDelay <= 0)
                {
                    Projectile.soundDelay = num3 - num4 * num2;
                    if (Projectile.ai[0] != 1f)
                    {
                        SoundEngine.PlaySound(SoundID.Item5, Projectile.position);
                    }
                }

                if (flag && Main.myPlayer == Projectile.owner)
                {
                    bool flag2 = player.channel && player.CheckMana(player.inventory[player.selectedItem].mana, true, false) && !player.noItems && !player.CCed;
                    if (flag2)
                    {
                        float scaleFactor = player.inventory[player.selectedItem].shootSpeed * Projectile.scale;
                        Vector2 value2 = vector;
                        Vector2 value3 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - value2;

                        if (player.gravDir == -1f)
                        {
                            value3.Y = Main.screenHeight - Main.mouseY + Main.screenPosition.Y - value2.Y;
                        }

                        Vector2 vector3 = Vector2.Normalize(value3);
                        if (float.IsNaN(vector3.X) || float.IsNaN(vector3.Y))
                        {
                            vector3 = -Vector2.UnitY;
                        }

                        vector3 *= scaleFactor;
                        if (vector3.X != Projectile.velocity.X || vector3.Y != Projectile.velocity.Y)
                        {
                            Projectile.netUpdate = true;
                        }

                        Projectile.velocity = vector3;
                        int num6 = ModContent.ProjectileType<HellStormArrow>();
                        float scaleFactor2 = 14f;
                        int num7 = 7;

                        value2 = Projectile.Center + new Vector2(Main.rand.Next(-num7, num7 + 1), Main.rand.Next(-num7, num7 + 1));
                        Vector2 spinningpoint = Vector2.Normalize(Projectile.velocity) * scaleFactor2;
                        spinningpoint = spinningpoint.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default(Vector2));

                        if (float.IsNaN(spinningpoint.X) || float.IsNaN(spinningpoint.Y))
                        {
                            spinningpoint = -Vector2.UnitY;
                        }

                        IEntitySource source = Projectile.GetSource_FromThis();
                        Projectile.NewProjectile(source, value2.X, value2.Y, spinningpoint.X, spinningpoint.Y, num6, Projectile.damage, Projectile.knockBack, Projectile.owner);
                    }
                    else
                    {
                        Projectile.Kill();
                    }
                }
            }
        

        Projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - Projectile.Size / 2f;
			Projectile.rotation = Projectile.velocity.ToRotation() + num;
			Projectile.spriteDirection = Projectile.direction;
			Projectile.timeLeft = 2;
			player.ChangeDir(Projectile.direction);
			player.heldProj = Projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(Projectile.velocity.Y * Projectile.direction, Projectile.velocity.X * Projectile.direction);
		}
	}
}
