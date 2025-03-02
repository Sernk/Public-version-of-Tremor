using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
    public class BestNightmarePro : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(106);
            AIType = 106;
            Projectile.width = 54;
            Projectile.height = 54;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("BestNightmarePro");
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            if (Main.rand.NextBool())
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 62, Projectile.velocity.X * 0.9f, Projectile.velocity.Y * 0.9f);
            }
            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 59, Projectile.velocity.X * 0.9f, Projectile.velocity.Y * 0.9f);
            }
            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 61, Projectile.velocity.X * 0.9f, Projectile.velocity.Y * 0.9f);
            }
            Vector2 vector63 = Main.player[Projectile.owner].Center - Projectile.Center;
            if (Main.player[Projectile.owner].dead)
            {
                Projectile.Kill();
                return;
            }
            if (Projectile.ai[0] == 0f && vector63.Length() > 400f)
            {
                Projectile.ai[0] = 1f;
            }
            if (Projectile.ai[0] == 1f || Projectile.ai[0] == 2f)
            {
                float num810 = vector63.Length();
                if (num810 > 1500f)
                {
                    Projectile.Kill();
                    return;
                }
                if (num810 > 600f)
                {
                    Projectile.ai[0] = 2f;
                }
                float num811 = 20f;
                if (Projectile.ai[0] == 2f)
                {
                    num811 = 40f;
                }
                if (vector63.Length() < num811)
                {
                    Projectile.Kill();
                    return;
                }
            }
            Projectile.ai[1] += 1f;
            if (Projectile.ai[1] > 5f)
            {
                Projectile.alpha = 0;
            }
            if ((int)Projectile.ai[1] % 3 == 0 && Projectile.owner == Main.myPlayer)
            {
                // Источник создания снаряда
                IEntitySource source = Projectile.GetSource_FromAI();

                // Позиция и скорость
                Vector2 position = Projectile.Center;
                Vector2 velocity = vector63 * -1f;
                velocity.Normalize();
                velocity *= Main.rand.Next(5, 25) * 0.9f;

                // Создание нового снаряда
                Projectile.NewProjectile(
                    source,                           // Источник
                    position,                         // Позиция (Vector2)
                    velocity,                         // Скорость (Vector2)
                    Mod.Find<ModProjectile>("ChaosStarPro").Type, // Тип снаряда
                    Projectile.damage / 3,            // Урон (int)
                    Projectile.knockBack,             // Отбрасывание (float)
                    Projectile.owner,                 // Владелец (int)
                    -10f,                             // AI0 (float)
                    0f                                // AI1 (float)
                );
            }
        }
    }
}