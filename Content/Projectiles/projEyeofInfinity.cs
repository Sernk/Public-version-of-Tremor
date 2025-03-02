using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Utilities;
using TremorMod;

////////////////////

namespace TremorMod.Content.Projectiles
{
	public class projEyeofInfinity : ModProjectile
	{
		const float Distanse = 25f; // Дистанция на которой вращяются половины друг от друга
		const int DrawCount = 10; // кол-во "шлейфов" за одной половиной
		const float AngleStep = 0.005f; // Поворот за кадр
		int TimeToReturn = 20; // Время, через которое бумеранг возворотится к игроку
		const int SpeedMulti = 2; // Увеличение скорости при возвращении

		float AngleLeft = 0.005f; // Начальный поворот первой половины
		float AngleRight = 0.050f; // Начальный поворот второй половины (Должон быть ровно в 10 раз больше чем AngleLeft)

		public override void SetDefaults()
		{

			Projectile.width = 42;
			Projectile.height = 42;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 3600;
			Projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Eye of Infinity");

		}

		void TryToReturn()
		{
			if (--TimeToReturn <= 0)
			{
				Projectile.aiStyle = 3;
				Projectile.ai[0] = 1;
			}
		}

		void Angle()
		{
			AngleLeft -= AngleStep;
			AngleRight += AngleStep;
		}

		void ImproveSpeed()
		{
			Projectile.position += (Projectile.aiStyle == 3) ? Projectile.velocity * (SpeedMulti - 1) : new Vector2(0, 0);
		}

		//////////////////////////////////////////////////////////////////////////////////
		List<Vector2> OldPositionsLeft = new List<Vector2>();
		List<Vector2> OldPositionsRight = new List<Vector2>();
		List<float> OldRotations = new List<float>();
		const int SavePosRate = 1;
		int TimeToSavePos;
		void TestDrawing()
		{
			if (--TimeToSavePos <= 0)
			{
				TimeToSavePos = SavePosRate;
				List<Vector2> newOldPositions = new List<Vector2>();
				newOldPositions.Add(Helper.PolarPos(Projectile.position, Distanse, AngleLeft, 0, 0) - Main.screenPosition);
				for (int i = 0; i < OldPositionsLeft.Count && i < DrawCount - 1; i++)
					newOldPositions.Add(OldPositionsLeft[i]);
				OldPositionsLeft = newOldPositions;

				newOldPositions = new List<Vector2>();
				newOldPositions.Add(Helper.PolarPos(Projectile.position, Distanse, AngleRight, 0, 0) - Main.screenPosition - Projectile.Size / 2);
				for (int i = 0; i < OldPositionsRight.Count && i < DrawCount - 1; i++)
					newOldPositions.Add(OldPositionsRight[i]);
				OldPositionsRight = newOldPositions;

				List<float> newOldRotations = new List<float>();
				newOldRotations.Add(Projectile.rotation);
				for (int i = 0; i < OldRotations.Count && i < DrawCount - 1; i++)
					newOldRotations.Add(OldRotations[i]);
				OldRotations = newOldRotations;
			}
		}
		//////////////////////////////////////////////////////////////////////////////////

		public override void AI()
		{
			TryToReturn(); // Пытаемся вернутся
			Angle(); // Поворачиваем
			ImproveSpeed(); // Изменяем скорость

			TestDrawing(); //////////////////////////////////////////////////////////////////////////////////
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			for (int i = 0; i < DrawCount; i++)
			{
				Vector2 pP = Helper.PolarPos(Projectile.position, Distanse, AngleLeft - (AngleStep * i * 1.5f), 0, 0);
				projHitbox = new Rectangle((int)pP.X, (int)pP.Y, Projectile.width, Projectile.height);
				if (projHitbox.Intersects(targetHitbox))
					return true;
				pP = Helper.PolarPos(Projectile.position, Distanse, AngleRight - (AngleStep * i * 1.5f), 0, 0) - Projectile.Size / 2;
				projHitbox = new Rectangle((int)pP.X, (int)pP.Y, Projectile.width, Projectile.height);
				if (projHitbox.Intersects(targetHitbox))
					return true;
			}
			return false;
		}

        /*public override bool PreDraw(ref Color lightColor) // 1 и 2  метод
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Color color = new Color(250, 250, 250, 0);
            Color color2 = new Color(0, 0, 0, 250);

            // Отрисовка текущих позиций следов
            for (int i = 0; i < DrawCount; i++)
            {
                Vector2 leftPos = Helper.PolarPos(Projectile.position, Distanse, AngleLeft - (AngleStep * i * 1.5f), 0, 0) - Main.screenPosition;
                Vector2 rightPos = Helper.PolarPos(Projectile.position, Distanse, AngleRight - (AngleStep * i * 1.5f), 0, 0) - Main.screenPosition - Projectile.Size / 2;

                spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, leftPos, null, color, AngleLeft, new Vector2(2, 2), 1, SpriteEffects.None, 0f);
                spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, rightPos, null, color, AngleRight, new Vector2(2, 2), 1, SpriteEffects.None, 0f);

                color = new Color(color.R - 250 / DrawCount, color.G - 250 / DrawCount, color.B - 250 / DrawCount, color.A + 250 / DrawCount);
                color2 = new Color(color2.R + 250 / DrawCount, color2.G + 250 / DrawCount, color2.B + 250 / DrawCount, color2.A - 250 / DrawCount);
            }

            // Отрисовка сохранённых предыдущих позиций (эффект следа)
            color = new Color(250, 250, 250, 0);
            for (int i = 0; i < OldPositionsLeft.Count; i++)
            {
                color = new Color(color.R - 250 / DrawCount, color.G - 250 / DrawCount, color.B - 250 / DrawCount, color.A + 250 / (OldPositionsLeft.Count * 2));

                spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, OldPositionsLeft[i], null, color, OldRotations[i], new Vector2(2, 2), 1, SpriteEffects.None, 0);
                spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, OldPositionsRight[i], null, color, -OldRotations[i], new Vector2(2, 2), 1, SpriteEffects.None, 0);
            }

            return false;
        }*/


        /*public override bool PreDraw(ref Color lightColor) // метод 1 в комментариях 
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Color color = new Color(250, 250, 250, 0);
            Color color2 = new Color(0, 0, 0, 250);

            for (int i = 0; i < DrawCount; i++)
            {
                spriteBatch.Draw(
                    TextureAssets.Projectile[Projectile.type].Value,
                    Helper.PolarPos(Projectile.position, Distanse, AngleLeft - (AngleStep * i * 1.5f), 0, 0) - Main.screenPosition,
                    null, color, AngleLeft, new Vector2(2, 2), 1, SpriteEffects.None, 0f);

                spriteBatch.Draw(
                    TextureAssets.Projectile[Projectile.type].Value,
                    Helper.PolarPos(Projectile.position, Distanse, AngleRight - (AngleStep * i * 1.5f), 0, 0) - Main.screenPosition - Projectile.Size / 2,
                    null, color, AngleRight, new Vector2(2, 2), 1, SpriteEffects.None, 0f);

                color = new Color(
                    color.R - 250 / DrawCount,
                    color.G - 250 / DrawCount,
                    color.B - 250 / DrawCount,
                    color.A + 250 / DrawCount);

                color2 = new Color(
                    color2.R + 250 / DrawCount,
                    color2.G + 250 / DrawCount,
                    color2.B + 250 / DrawCount,
                    color2.A - 250 / DrawCount);
            }
            return false;
        }*/

        public override bool PreDraw(ref Color lightColor) // 2 метод 
		{
            SpriteBatch spriteBatch = Main.spriteBatch;
            Color color = new Color(250, 250, 250, 0);
			for (int i = 0; i < OldPositionsLeft.Count; i++)
			{
				color = new Color(color.R - 250 / DrawCount, color.G - 250 / DrawCount, color.B - 250 / DrawCount, color.A + 250 / (OldPositionsLeft.Count * 2));
				spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, OldPositionsLeft[i], null, color, OldRotations[i], new Vector2(2, 2), 1, SpriteEffects.None, 0);
				spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, OldPositionsRight[i], null, color, -OldRotations[i], new Vector2(2, 2), 1, SpriteEffects.None, 0);
			}
			return false;
		}
	}
}
