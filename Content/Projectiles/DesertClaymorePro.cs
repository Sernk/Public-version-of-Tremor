using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class DesertClaymorePro : ModProjectile
	{
		const int MaxYOffset = 5;
		const int SpeedMulti = 2;
		const int XOffset = 24; // На сколько блоков от игрока будет появлятся меч. (16ед. == 1 блок.)

		int YOffset;
		int YOffsetStep = -1;
		bool UP = true;
		float YPos;

		public override void SetDefaults()
		{

			Projectile.width = 30;
			Projectile.tileCollide = false;
			Projectile.height = 60;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 1080; // Время которое он будет стоять на месте (60ед. == 1сек.)
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Desert Claymore");

		}

		bool FirstAI = true;
		public override void AI()
		{
			if (FirstAI)
			{
				YPos = Projectile.position.Y;
				if (Projectile.ai[0] == -1)
					Projectile.position.X -= XOffset;
				else
					Projectile.position.X += XOffset;
				FirstAI = false;
			}
			if (Projectile.aiStyle == 0)
			{
				if (UP)
				{
					YOffset += YOffsetStep;
					if (YOffset <= -MaxYOffset)
						UP = false;
				}
				else
				{
					YOffset -= YOffsetStep;
					if (YOffset >= MaxYOffset)
						UP = true;
				}
				Projectile.position = new Vector2(Projectile.position.X, YPos + YOffset);
			}
			if (Projectile.timeLeft == 2)
			{
				++Projectile.timeLeft;
				Projectile.aiStyle = 3;
			}
			if (Projectile.aiStyle == 3)
				Projectile.position += Projectile.velocity * (SpeedMulti - 1);
		}
	}
}
