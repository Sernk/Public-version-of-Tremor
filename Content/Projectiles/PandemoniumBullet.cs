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
	public class PandemoniumBullet : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(14);
			Projectile.light = 0.5f;
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.extraUpdates = 1;
			Projectile.alpha = 255;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
			//AiType = ProjectileID.Bullet;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandemonium Bullet");
		}*/

        const int ShootDirection = 7;
        public override void OnKill(int timeLeft)
        {
            // »сточник создани€ проектил€ Ч использование EntitySource_Death, который применим в данном случае
            var source = new Terraria.DataStructures.EntitySource_Death(Projectile);

            // ѕозици€ проектил€
            Vector2 startPosition = Projectile.position + new Vector2(40, 40);

            // —оздание проектилей в разных направлени€х
            int[] projectiles = new int[8];
            projectiles[0] = Projectile.NewProjectile(source, startPosition, new Vector2(-ShootDirection, 0), 711, 50, 1f, Main.myPlayer);
            projectiles[1] = Projectile.NewProjectile(source, startPosition, new Vector2(ShootDirection, 0), 711, 50, 1f, Main.myPlayer);
            projectiles[2] = Projectile.NewProjectile(source, startPosition, new Vector2(0, ShootDirection), 711, 50, 1f, Main.myPlayer);
            projectiles[3] = Projectile.NewProjectile(source, startPosition, new Vector2(0, -ShootDirection), 711, 50, 1f, Main.myPlayer);
            projectiles[4] = Projectile.NewProjectile(source, startPosition, new Vector2(-ShootDirection, -ShootDirection), 711, 50, 1f, Main.myPlayer);
            projectiles[5] = Projectile.NewProjectile(source, startPosition, new Vector2(ShootDirection, -ShootDirection), 711, 50, 1f, Main.myPlayer);
            projectiles[6] = Projectile.NewProjectile(source, startPosition, new Vector2(-ShootDirection, ShootDirection), 711, 50, 1f, Main.myPlayer);
            projectiles[7] = Projectile.NewProjectile(source, startPosition, new Vector2(ShootDirection, ShootDirection), 711, 50, 1f, Main.myPlayer);

            // Ќастройка созданных проектилей
            foreach (int proj in projectiles)
            {
                if (proj >= 0) // ѕроверка, что проектиль был успешно создан
                {
                    Main.projectile[proj].friendly = true;
                    Main.projectile[proj].tileCollide = false;
                    Main.projectile[proj].timeLeft = 120;
                }
            }
        }


    }
    /*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
    {
        Vector2 drawOrigin = new Vector2(Main.ProjectileTexture[Projectile.type].Width * 0.5f, Projectile.height * 0.5f);
        for (int k = 0; k < Projectile.oldPos.Length; k++)
        {
            Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
            spriteBatch.Draw(Main.ProjectileTexture[Projectile.type], drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
        }
        return true;
    }*/
}

