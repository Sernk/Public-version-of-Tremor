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
	public class NovaBlast : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.timeLeft = 420;
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.friendly = true;
			Main.projFrames[Projectile.type] = 10;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 2)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 10)
			{ Projectile.Kill(); }
		}
	}
}