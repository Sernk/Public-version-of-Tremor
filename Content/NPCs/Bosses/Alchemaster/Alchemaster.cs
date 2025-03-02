using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Utilities;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Weapons.Alchemical;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items;

namespace TremorMod.Content.NPCs.Bosses.Alchemaster
{
	[AutoloadBossHead]
	public class Alchemaster : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Alchemaster");
		}

		#region "Константы"
		const int FlameShootRate = 250; // Частота выстрела
		const int FlameShootDamage = 60; // Урон от лазера.
		const float FlameShootKN = 1.0f; // Отбрасывание
		const int FlameShootType = 100; // Тип проджектайла которым будет произведён выстрел.
		const float FlameShootSpeed = 4; // Это, я так понимаю, влияет на дальность выстрела

		int TimeToFlameShoot = FlameShootRate; // Время до выстрела.
		const int AnimationRate = 8; // Частота смены кадров (То, сколько кадров не будет сменятся кадр)
		const int FrameCount = 4; // Кол-во кадров

		const int ShootRate = 50; // Частота выстрела. Будет производить 60/ShootRate выстрелов в секунду
		const int ShootDamage = 75; // Урон от выстрела
		int ShootType; // Тип выстрела (задаётся в SetDefaults())
		const float ShootKnockback = 1; // Отбрасование от выстрела
		const float ShootSpeed = 10; // Скорость выстрела

		const float DistortPercent = 0.15f; // Процент деформации статов (неточности) (1.0 == 100%)

		const int MinionsID = 61; // ID вуртулек
		const int MinionsCount = 6; // Кол-во вуртулек которых заспавнит

		const int StateTime_Flying = 600; // Сколько будет летать в воздухе до призыва миньонов
		const int StateTime_Minions = 120; // Сколько времени будет спавнить вуртулек

		const int FlyingAI = 2;
		const int MinionsAI = 0;

		const float MinionsState_XDeaccelerationPower = 0.05f; // Скорость замедления по X
		const float MinionsState_YMaxSpeed = 2.80f; // Макс. скорость взлёта во время спавна миньонов
		const float MinionsStete_YSpeedStep = 0.02f; // Скорость увеличения скорости по Y во время спавна миньонов

		const int States = 2;
		#endregion

		#region "Переменные"
		int TimeToAnimation = AnimationRate;
		int Frame;
		bool Shoots = true;
		int TimeToShoot = ShootRate;
		int State;
		int TimeToState = StateTime_Flying;
		bool runAway;
		#endregion

		public override void SetDefaults()
		{
			NPC.lifeMax = 30000;
			NPC.damage = 82;
			NPC.defense = 40;
			NPC.knockBackResist = 0f;
			NPC.width = 190;
			NPC.height = 210;
			NPC.aiStyle = 2;
			NPC.noGravity = true;
			Music = 17;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath42;
			NPC.value = Item.buyPrice(0, 9, 75, 0);
			NPC.boss = true;
			ShootType = ModContent.ProjectileType<PlagueFlaskEvil>();
			//bossBag/* tModPorter Note: Removed. Spawn the treasure bag alongside other loot via npcLoot.Add(ItemDropRule.BossBag(type)) */ = Mod.Find<ModItem>("AlchemasterTreasureBag").Type;
			NPC.noTileCollide = true;
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AlchemasterGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AlchemasterGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AlchemasterGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AlchemasterGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AlchemasterGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AlchemasterGore4").Type, 1f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 3.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
			}
		}

		public override void AI()
		{
			if (--TimeToFlameShoot <= 0 && NPC.target != -1) FlameShoot(); // В этой строке из переменной TimeToShot отнимается 1, и если TimeToShot < или = 0, то вызывается метод FlameShoot()
			PlayAnimation(); // Проигрывание анимации
			if (CheckRunConditions())
				return;
			ChangeState(); // Смена стадии
			Shoot(); // Выстрел
			DoAI(); // Сам искуственный интеллект
		}

		void PlayAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				TimeToAnimation = (int)Helper.DistortFloat(AnimationRate, DistortPercent);
				if (++Frame >= FrameCount)
					Frame = 0;
			}
		}

		Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
		{
			Vector2 move = pos2 - pos1;
			return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}

		void FlameShoot()
		{
			TimeToFlameShoot = FlameShootRate; // Устанавливаем кулдаун выстрелу
			Vector2 velocity = VelocityFPTP(NPC.Center, Main.player[NPC.target].Center, FlameShootSpeed); // Тут мы получим нужную velocity (пояснение аргументов ниже)
																										  // 1 аргумент - позиция из которой будет вылетать выстрел
																										  // 2 аргумент - позиция в которую он должен полететь 
																										  // 3 аргумент - скорость выстрела
			Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, velocity.X, velocity.Y, ModContent.ProjectileType<SparkingFlaskEvil>(), FlameShootDamage, FlameShootKN);
		}

		bool CheckRunConditions()
		{
			if (runAway)
			{
				NPC.aiStyle = 0;
				if (NPC.velocity.Y >= 0)
					NPC.velocity.Y = -1f;
				NPC.velocity.Y *= 1.01f;
				return true;
			}
			int Target = Helper.GetNearestPlayer(NPC.Center, true);
			if (Target == -1)
			{ runAway = true; return true; }
			return false;
		}

		void ChangeState()
		{
			if (--TimeToState < 0)
			{
				State++;
				if (State >= States)
					State = 0;
				switch (State)
				{
					case 0:
						Shoots = true;
						NPC.aiStyle = FlyingAI;
						TimeToState = StateTime_Flying;
						break;
					case 1:
						Shoots = false;
						NPC.aiStyle = MinionsAI;
						TimeToState = StateTime_Minions;
						break;
				}
			}
		}

		void Shoot()
		{
			if (!Shoots && NPC.target < 0)
				return;
			if (--TimeToShoot > 0)
				return;
			TimeToShoot = (int)Helper.DistortFloat(ShootRate, DistortPercent);
			for (int i = 0; i < ((Main.expertMode) ? 3 : 1); i++)
			{
				Vector2 Velocity = Helper.VelocityToPoint(NPC.Center, Helper.RandomPointInArea(new Vector2(Main.player[NPC.target].Center.X - 10, Main.player[NPC.target].Center.Y - 10), new Vector2(Main.player[NPC.target].Center.X + 20, Main.player[NPC.target].Center.Y + 20)), ShootSpeed);
				int Proj = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, Velocity.X, Velocity.Y, ShootType, (int)Helper.DistortFloat(ShootDamage, DistortPercent), Helper.DistortFloat(ShootKnockback, DistortPercent));
				Main.projectile[Proj].Center = NPC.Center;
			}
		}

		void DoAI()
		{
			switch (State)
			{
				case 1:
					NPC.velocity.Y -= MinionsStete_YSpeedStep;
					if (NPC.velocity.Y < -MinionsState_YMaxSpeed)
						NPC.velocity.Y = MinionsState_YMaxSpeed;
					if (TimeToState % StateTime_Minions / MinionsCount == 0)
					{
						Vector2 Position = Helper.RandomPointInArea(NPC.Hitbox);
						int index = NPC.NewNPC(NPC.GetSource_FromThis(), (int)Position.X, (int)Position.Y, ModContent.NPCType<PlagueSoul>());
						Main.npc[index].Center = Position;
					}
					break;
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			SpriteEffects Direction = (NPC.target == -1) ? SpriteEffects.None : ((Main.player[NPC.target].position.X < NPC.position.X) ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
			spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, new Rectangle((int)(NPC.position.X - Main.screenPosition.X), (int)(NPC.position.Y - Main.screenPosition.Y), 248, 240), new Rectangle(0, Frame * 240, 248, 240), drawColor, 0, new Vector2(0, 0), Direction, 0);
			return false;
		}
        public override void OnKill()
		{
            TremorSpawnEnemys.downedAlchemaster = true;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AlchemasterMask>(), 7));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlagueFlask>(), 1, 60, 158));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LongFuse>(), 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheGlorch>(), 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadApple>(), 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AlchemasterTrophy>(), 10));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<AlchemasterTreasureBag>(), 1));
        }
    }
}