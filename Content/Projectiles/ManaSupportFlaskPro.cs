using System;
using Terraria.Audio;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Content;
using TremorMod.Content.Buffs;
using TremorMod.Content.Projectiles;
using TremorMod.Utilities;
using Utils = Terraria.Utils;

namespace TremorMod.Content.Projectiles
{
	public class ManaSupportFlaskPro : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 28;
			Projectile.friendly = true;
			Projectile.aiStyle = 2;
			Projectile.timeLeft = 1200;
		}
        public override void OnKill(int timeLeft)
        {
            if (Main.LocalPlayer.HasBuff(ModContent.BuffType<DesertEmperorSetBuff>()))
            {
                int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FlaskWasp>(), Projectile.damage * 2, 1.5f, Projectile.owner);
                int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FlaskWasp>(), Projectile.damage * 2, 1.5f, Projectile.owner);
            }
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
            IEntitySource source = Projectile.GetSource_FromThis();
            Gore.NewGore(source, Projectile.position, -Projectile.oldVelocity * 0.2f, 704, 1f);
            Gore.NewGore(source, Projectile.position, -Projectile.oldVelocity * 0.2f, 705, 1f);
            if (Projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(3, 6);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= Main.rand.Next(10, 201) * 0.01f;
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, value17.X, value17.Y, ModContent.ProjectileType<ManaSupportCloudPro>(), Projectile.damage, 1f, Projectile.owner, 0f, Main.rand.Next(-45, 1));
                }
            }
        }
    }
}