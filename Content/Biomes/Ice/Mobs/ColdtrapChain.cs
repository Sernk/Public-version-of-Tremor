using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Biomes.Ice.Mobs
{
	public class ColdtrapChain : ModProjectile
	{
		public float width
		{
			get
			{
				return Projectile.ai[0];
			}
			set
			{
				Projectile.ai[0] = value;
			}
		}
		public float length
		{
			get
			{
				return Projectile.ai[1];
			}
			set
			{
				Projectile.ai[1] = value;
			}
		}
		public float minAngle
		{
			get
			{
				return Projectile.localAI[0];
			}
			set
			{
				Projectile.localAI[0] = value;
			}
		}
		public float maxAngle
		{
			get
			{
				return Projectile.localAI[1];
			}
			set
			{
				Projectile.localAI[1] = value;
			}
		}
		public float angleSpeed;
		public float lengthSpeed;
		public int arm = -1;
		private int netUpdateCounter;
		private const float maxAngleSpeed = 0.1f;
		private const float angleBuffer = (float)Math.PI / 12f;
		public const float minLength = 80f;
		private const float maxLength = 400f;
		private const float maxLengthSpeed = 2.5f;

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Coldtrap");
		}

		public override void SetDefaults()
		{
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.hostile = true;
			Projectile.timeLeft = 2;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

		public override void AI()
		{
			NPC npc = Main.npc[arm];
			if (!npc.active || npc.type != Mod.Find<ModNPC>("Dot").Type)
			{
				return;
			}
			Projectile.timeLeft = 2;
			Player player = Main.player[npc.target];
			Projectile.position = npc.Center;
			Vector2 offset = player.Center - Projectile.position;
			float distance = offset.Length() + 32f;

			Angle currAngle = new Angle(Projectile.rotation);
			Angle angleToPlayer = new Angle((float)Math.Atan2(offset.Y, offset.X));
			Angle min = new Angle(minAngle);
			Angle max = new Angle(maxAngle);
			Angle limit = new Angle((minAngle + maxAngle) / 2f);
			if (limit.Between(min, max))
			{
				limit = limit.Opposite();
			}
			Angle buffer = new Angle(angleBuffer);

			if (angleToPlayer.Between(min - buffer, max + buffer))
			{
				if (currAngle.Between(max, limit))
				{
					angleSpeed -= maxAngleSpeed / 10f;
				}
				else if (currAngle.Between(limit, min))
				{
					angleSpeed += maxAngleSpeed / 10f;
				}
				else if (currAngle.ClockwiseFrom(angleToPlayer))
				{
					angleSpeed += maxAngleSpeed / 10f;
				}
				else
				{
					angleSpeed -= maxAngleSpeed / 10f;
				}

				if (length > maxLength)
				{
					lengthSpeed -= maxLengthSpeed / 10f;
				}
				else if (length < minLength)
				{
					lengthSpeed += maxLengthSpeed / 10f;
				}
				else if (distance > length)
				{
					lengthSpeed += maxLengthSpeed / 10f;
				}
				else if (distance < length)
				{
					lengthSpeed -= maxLengthSpeed / 10f;
				}
			}
			else
			{
				if (currAngle.Between(max, limit))
				{
					angleSpeed -= maxAngleSpeed / 10f;
				}
				else if (currAngle.Between(limit, min))
				{
					angleSpeed += maxAngleSpeed / 10f;
				}
				else if (angleSpeed > 0f)
				{
					angleSpeed += maxAngleSpeed / 20f;
				}
				else if (angleSpeed < 0f)
				{
					angleSpeed -= maxAngleSpeed / 20f;
				}
				else
				{
					angleSpeed = maxAngleSpeed / 20f;
				}

				if (length > minLength)
				{
					lengthSpeed -= maxLengthSpeed / 10f;
				}
				else
				{
					lengthSpeed += maxLengthSpeed / 10f;
				}
			}

			if (angleSpeed > maxAngleSpeed)
			{
				angleSpeed = maxAngleSpeed;
			}
			else if (angleSpeed < -maxAngleSpeed)
			{
				angleSpeed = -maxAngleSpeed;
			}
			if (lengthSpeed > maxLengthSpeed)
			{
				lengthSpeed = maxLengthSpeed;
			}
			else if (lengthSpeed < -maxLengthSpeed)
			{
				lengthSpeed = -maxLengthSpeed;
			}
			Projectile.rotation += angleSpeed;
			length += lengthSpeed;

			if (Main.netMode == 2)
			{
				netUpdateCounter++;
				if (netUpdateCounter >= 300)
				{
					Projectile.netUpdate = true;
					netUpdateCounter = 0;
				}
			}
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(Projectile.rotation);
			writer.Write(minAngle);
			writer.Write(maxAngle);
			writer.Write(angleSpeed);
			writer.Write(lengthSpeed);
			writer.Write((short)arm);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			Projectile.rotation = reader.ReadSingle();
			minAngle = reader.ReadSingle();
			maxAngle = reader.ReadSingle();
			angleSpeed = reader.ReadSingle();
			lengthSpeed = reader.ReadSingle();
			arm = reader.ReadInt16();
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			float point = 0f;
			return Collision.CheckAABBvLineCollision(new Vector2(targetHitbox.X, targetHitbox.Y), new Vector2(targetHitbox.Width, targetHitbox.Height), Projectile.position, Projectile.position + length * new Vector2((float)Math.Cos(Projectile.rotation), (float)Math.Sin(Projectile.rotation)), width, ref point);
		}

		public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
		{
			if (Main.hardMode || Main.expertMode)
			{
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(1, 4) * 60);
			}
			
			Projectile.rotation %= 2f * (float)Math.PI;
			if (Projectile.rotation % (float)Math.PI == 0f)
			{
				Projectile.direction = -target.direction;
			}
			else if (Projectile.rotation % (float)Math.PI / 2f == 0f)
			{
				Projectile.direction = target.Center.X < Projectile.position.X ? -1 : 1;
			}
			else
			{
				float yOffset = target.Center.Y - Projectile.position.Y;
				float x = Projectile.position.X + yOffset / (float)Math.Tan(Projectile.rotation);
				Projectile.direction = target.Center.X < x ? -1 : 1;
			}
		}

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D unit = TextureAssets.Projectile[Projectile.type].Value;
            int unitLength = unit.Width;
            int numUnits = (int)Math.Ceiling(length / unitLength);
            float increment = 0f;
            if (numUnits > 1)
            {
                increment = (length - unitLength) / (numUnits - 1);
            }
            Vector2 direction = new Vector2((float)Math.Cos(Projectile.rotation), (float)Math.Sin(Projectile.rotation));
            SpriteEffects effects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                effects = SpriteEffects.FlipVertically;
            }
            for (int k = 1; k <= numUnits; k++)
            {
                Texture2D image = unit;
                if (k == numUnits)
                {
                    image = ModContent.Request<Texture2D>("TremorMod/Content/Biomes/Ice/Mobs/Coldtrap").Value;
                }
                Vector2 pos = Projectile.position + direction * (increment * (k - 1) + unitLength / 2f);
                Color color = Lighting.GetColor((int)(pos.X / 16f), (int)(pos.Y / 16f));
                Main.spriteBatch.Draw(image, pos - Main.screenPosition, null, Projectile.GetAlpha(color), Projectile.rotation, new Vector2(unit.Width / 2, unit.Height / 2), 1f, effects, 0f);
            }
            return false;
        }
        public override void PostDraw(Color lightColor)
		{
			Main.instance.DrawNPC(arm, false);
		}
	}
}