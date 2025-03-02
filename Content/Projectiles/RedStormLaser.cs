using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TremorMod.Content.Projectiles
{
    public class RedStormLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 300; // Лазер длинный
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = -1; // Лазер будет наносить урон несколько раз
            Projectile.timeLeft = 300;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false; // Лазер не будет взаимодействовать с плитками
        }

        public override void AI()
        {
            // Лазер всегда двигается вниз
            Projectile.velocity = new Vector2(0, 10f);

            // Добавление визуальных эффектов
            if (Main.rand.NextBool(5))
            {
                int dustID = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleCrystalShard);
                Main.dust[dustID].noGravity = true;
            }
        }
    }
}
