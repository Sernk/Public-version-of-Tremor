using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.TheDarkEmperor;

namespace TremorMod.Content.Projectiles
{
	public class FallingDarkServant : ModProjectile
	{

		public override void SetDefaults()
		{

			Projectile.width = 72;
			Projectile.height = 64;
			Projectile.hostile = true;
			Projectile.light = 0.8f;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 6;
			Main.projFrames[Projectile.type] = 4;
			Projectile.aiStyle = 1;
			Projectile.timeLeft = 600;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("FallingDarkSlime");

		}

		public override void AI()
		{
			if (Projectile.frameCounter < 5)
				Projectile.frame = 0;
			else if (Projectile.frameCounter >= 5 && Projectile.frameCounter < 10)
				Projectile.frame = 1;
			else if (Projectile.frameCounter >= 10 && Projectile.frameCounter < 15)
				Projectile.frame = 2;
			else if (Projectile.frameCounter >= 15 && Projectile.frameCounter < 20)
				Projectile.frame = 3;
			else
				Projectile.frameCounter = 0;
			Projectile.frameCounter++;
		}
		public override void OnKill(int timeLeft)
		{
            IEntitySource source = Projectile.GetSource_FromThis();
            NPC.NewNPC(source, (int)Projectile.Center.X, (int)Projectile.Center.Y, ModContent.NPCType<DarkServant>());
        }
	}
}
