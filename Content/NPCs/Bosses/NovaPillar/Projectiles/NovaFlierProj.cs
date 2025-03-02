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
using TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles
{
	public class NovaFlierProj : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Nova Stinger");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(348);
			Projectile.timeLeft = 500;
			AIType = 348;
			Projectile.friendly = false;
			Projectile.tileCollide = true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
		}

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
            }
            for (int k = 0; k < 5; k++)
            {
                Vector2 velocity = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                velocity.Normalize();
                velocity *= Main.rand.Next(10, 201) * 0.01f;

                // Correct IEntitySource here
                IEntitySource source = Projectile.GetSource_FromThis();

                // Correct parameters
                int i = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<NovaAlchemistCloud>(), 14, 1f, Main.myPlayer, 0f, Main.rand.NextFloat(-45f, 1f));

                Main.projectile[i].friendly = false;
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			Projectile.Kill();
		}

		public override bool CanHitPlayer(Player target)
		{
			return true;
		}
	}
}