using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using TremorMod;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles.Minions
{
    public class SandstormMinion : ModProjectile
    {
        const int Frames = 6; // Кол-во кадров
        const int AnimationRate = 12; // Частота анимации
        const int ShootRate = 30; // Частота выстрела (1 секунда = 60ед.)
        const float ShootDistance = 300f; // Дальность стрельбы
        const float ShootSpeed = 12f; // Скорость снаряда
        const int ShootDamage = 30; // Урон снаряда
        const float ShootKnockback = 2; // Отброс снаряда
        const int DustType = 19; // Тип дастов
        const float DustChance = 0.09f; // Шанс спавна дастов
        int ShootType = -1; // Тип выстрела (Если из ванильной терки)
        int Frame;
        int TimeToAnimation = AnimationRate;
        int TimeToShoot = ShootRate;

        Rectangle FrameRect;

        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 38;
            Projectile.timeLeft = 5;
            Projectile.aiStyle = 62;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        void Animation()
        {
            if (--TimeToAnimation <= 0)
            {
                TimeToAnimation = AnimationRate;
                if (++Frame >= Frames)
                    Frame = 0;
            }
            FrameRect = new Rectangle(0, Projectile.height * Frame, Projectile.width, Projectile.height);
        }

        void Shoot()
        {
            if (--TimeToShoot <= 0)
            {
                TimeToShoot = ShootRate;

                // Указываем тип снаряда Sandgun
                ShootType = ProjectileID.SandBallGun;

                float NearestNPCDist = ShootDistance;
                int NearestNPC = -1;

                foreach (NPC npc in Main.npc)
                {
                    if (!npc.active || npc.friendly || npc.lifeMax <= 5)
                        continue;

                    if (npc.Distance(Projectile.Center) < NearestNPCDist && Collision.CanHitLine(Projectile.Center, 16, 16, npc.Center, 16, 16))
                    {
                        NearestNPCDist = npc.Distance(Projectile.Center);
                        NearestNPC = npc.whoAmI;
                    }
                }

                if (NearestNPC == -1)
                    return;

                // Расчёт скорости для выстрела
                Vector2 velocity = Helper.VelocityToPoint(Projectile.Center, Main.npc[NearestNPC].Center, ShootSpeed);

                // Создание снаряда
                Projectile.NewProjectile(
                    Projectile.GetSource_FromAI(),
                    Projectile.Center,
                    velocity,
                    ShootType,
                    ShootDamage,
                    ShootKnockback,
                    Projectile.owner
                );
            }
        }


        void SpawnDust()
        {
            if (Main.rand.NextFloat() < DustChance)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustType);

            foreach (Dust dust in Main.dust)
            {
                if (!dust.active)
                    break;

                if (Projectile.Distance(dust.position) > Math.Max(Projectile.width, Projectile.height))
                    continue;

                if (dust.type == 217)
                {
                    dust.active = false;
                    dust.alpha = 0;
                }
            }
        }

        public override void AI()
        {
            Animation();
            Shoot();
            SpawnDust();
            Projectile.ai[1] = 1;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.Draw(
                TextureAssets.Projectile[Projectile.type].Value,
                new Rectangle(
                    (int)(Projectile.position.X - Main.screenPosition.X),
                    (int)(Projectile.position.Y - Main.screenPosition.Y),
                    Projectile.width,
                    Projectile.height
                ),
                FrameRect,
                lightColor,
                Projectile.rotation,
                Vector2.Zero,
                Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally,
                0f
            );
            return false;
        }
    }
}
