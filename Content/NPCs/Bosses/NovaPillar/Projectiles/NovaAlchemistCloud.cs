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

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles
{
	public class NovaAlchemistCloud : ModProjectile
	{

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Cloud");
		}*/

		public override void SetDefaults()
		{
			Projectile.width = 40;
			Projectile.height = 38;
			Projectile.penetrate = 8;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 600;
			Projectile.hostile = true;
			Projectile.damage = 100;
		}

		public override void AI()
		{
			Projectile.tileCollide = false;
			Projectile.ai[1] += 1f;
			if (Projectile.ai[1] > 60f)
			{
				Projectile.ai[0] += 10f;
			}
			if (Projectile.ai[0] > 255f)
			{
				Projectile.Kill();
				Projectile.ai[0] = 255f;
			}
			Projectile.alpha = (int)(100.0 + Projectile.ai[0] * 0.7);
			Projectile.rotation += Projectile.velocity.X * 0.1f;
			Projectile.rotation += Projectile.direction * 0.003f;
			Projectile.velocity *= 0.96f;
		}
	}
}