using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;


namespace TremorMod.Content.Projectiles.Minions

{
	public class Bramble : ModProjectile
    {
 
        public override void SetDefaults()
        {

            Projectile.width = 48;
            Projectile.height = 44;  
            Projectile.hostile = false;  
            Projectile.friendly = false;   
            Projectile.ignoreWater = true; 
            Main.projFrames[Projectile.type] = 1;
            Projectile.timeLeft = 900;  
            Projectile.penetrate = -1; 
            Projectile.tileCollide = true; 
            Projectile.sentry = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

        }

        public override void AI()
        {
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                float shootToX = target.position.X + target.width * 0.5f - Projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - Projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 520f && !target.friendly && target.active)
                {
                    if (Projectile.ai[0] > 45f) // Time in (60 = 1 second) 
                    {
                        distance = 1.6f / distance;

                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 30;
                        Vector2 position = Projectile.Center;
                        Vector2 velocity = new Vector2(shootToX, shootToY);
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, velocity, 374, damage, 0, Main.myPlayer);
                        Projectile.ai[0] = 0f;
                    }
                }
            }
            Projectile.ai[0] += 1f;
        }
    }
}
