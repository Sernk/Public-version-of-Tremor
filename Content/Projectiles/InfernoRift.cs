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
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles
{
	public class InfernoRift : ModProjectile
	{
		const int ShootRate = 20; 
		const float ShootDistance = 500f; 
		const float ShootSpeed = 12f; 
		const int ShootDamage = 450; 
		const float ShootKnockback = 2; 
		int ShootType = 668; 
		int TimeToShoot = ShootRate;
		//string ShootTypeMod;

		public override void SetDefaults()
		{

			Projectile.width = 38;
			Projectile.height = 38;
			Projectile.scale = 1.1f;
            Projectile.aiStyle = 0; // Например, стиль взрыва
            AIType = ProjectileID.Grenade; // Ссылается на поведение другого снаряда
            Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 1;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Rift");
		}*/

        /*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, Color.White, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}*/
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 6, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f);
            }
            SoundEngine.PlaySound(SoundID.Item109, Projectile.position); // Заменено Main.PlaySound
        }

        void Shoot()
        {
            if (--TimeToShoot <= 0)
            {
                TimeToShoot = ShootRate;
                if (ShootType == -1)
                    ShootType = ModContent.ProjectileType<AdamantiteBolt>(); // Укажите реальный тип

                float nearestNPCDist = ShootDistance;
                int nearestNPC = -1;

                foreach (NPC npc in Main.npc)
                {
                    if (!npc.active || npc.friendly || npc.lifeMax <= 5)
                        continue;

                    if ((nearestNPCDist == -1 || npc.Distance(Projectile.Center) < nearestNPCDist) &&
                        Collision.CanHitLine(Projectile.Center, 16, 16, npc.Center, 16, 16))
                    {
                        nearestNPCDist = npc.Distance(Projectile.Center);
                        nearestNPC = npc.whoAmI;
                    }
                }

                if (nearestNPC == -1)
                    return;

                Vector2 velocity = Helper.VelocityToPoint(Projectile.Center, Main.npc[nearestNPC].Center, ShootSpeed);
                IEntitySource source = Projectile.GetSource_FromThis();
                Projectile.NewProjectile(source, Projectile.Center, velocity, ShootType, ShootDamage, ShootKnockback, Projectile.owner);
            }
        }


        public override void AI()
		{
			Shoot();
			Projectile.ai[1] = 1;
			base.AI();
			Projectile.light = 0.9f;
			int DustID1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default(Color), 1.75f);
			int DustID2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default(Color), 1.75f);
			int DustID3 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default(Color), 1.75f);
			Main.dust[DustID1].noGravity = true;
			Main.dust[DustID2].noGravity = true;
			Main.dust[DustID3].noGravity = true;
			if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
			{
				if (Main.player[Projectile.owner].channel)
				{
					float num146 = 12f;
					Vector2 vector10 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
					float num147 = Main.mouseX + Main.screenPosition.X - vector10.X;
					float num148 = Main.mouseY + Main.screenPosition.Y - vector10.Y;
					if (Main.player[Projectile.owner].gravDir == -1f)
					{
						num148 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector10.Y;
					}
					float num149 = (float)Math.Sqrt(num147 * num147 + num148 * num148);
					num149 = (float)Math.Sqrt(num147 * num147 + num148 * num148);
					if (num149 > num146)
					{
						num149 = num146 / num149;
						num147 *= num149;
						num148 *= num149;
						int num150 = (int)(num147 * 1000f);
						int num151 = (int)(Projectile.velocity.X * 1000f);
						int num152 = (int)(num148 * 1000f);
						int num153 = (int)(Projectile.velocity.Y * 1000f);
						if (num150 != num151 || num152 != num153)
						{
							Projectile.netUpdate = true;
						}
						Projectile.velocity.X = num147;
						Projectile.velocity.Y = num148;
					}
					else
					{
						int num154 = (int)(num147 * 1000f);
						int num155 = (int)(Projectile.velocity.X * 1000f);
						int num156 = (int)(num148 * 1000f);
						int num157 = (int)(Projectile.velocity.Y * 1000f);
						if (num154 != num155 || num156 != num157)
						{
							Projectile.netUpdate = true;
						}
						Projectile.velocity.X = num147;
						Projectile.velocity.Y = num148;
					}
				}
				else
				{
					if (Projectile.ai[0] == 0f)
					{
						Projectile.ai[0] = 1f;
						Projectile.netUpdate = true;
						float num158 = 12f;
						Vector2 vector11 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
						float num159 = Main.mouseX + Main.screenPosition.X - vector11.X;
						float num160 = Main.mouseY + Main.screenPosition.Y - vector11.Y;
						if (Main.player[Projectile.owner].gravDir == -1f)
						{
							num160 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector11.Y;
						}
						float num161 = (float)Math.Sqrt(num159 * num159 + num160 * num160);
						if (num161 == 0f)
						{
							vector11 = new Vector2(Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2, Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2);
							num159 = Projectile.position.X + Projectile.width * 0.5f - vector11.X;
							num160 = Projectile.position.Y + Projectile.height * 0.5f - vector11.Y;
							num161 = (float)Math.Sqrt(num159 * num159 + num160 * num160);
						}
						num161 = num158 / num161;
						num159 *= num161;
						num160 *= num161;
						Projectile.velocity.X = num159;
						Projectile.velocity.Y = num160;
						if (Projectile.velocity.X == 0f && Projectile.velocity.Y == 0f)
						{
							Projectile.Kill();
						}
					}
				}
			}
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
		}
	}
}
