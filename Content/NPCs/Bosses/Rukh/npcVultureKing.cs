using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Weapons.Summon;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Projectiles;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs.Bosses.Rukh
{
	[AutoloadBossHead]
	public class npcVultureKing : ModNPC
	{
		#region "Константы"
		const int AnimationRate = 8; // Частота смены кадров (То, сколько кадров не будет сменятся кадр)
		const int FrameCount = 4; // Кол-во кадров

		const int ShootRate = 50; // Частота выстрела. Будет производить 60/ShootRate выстрелов в секунду
		const int ShootDamage = 15; // Урон от выстрела
		int ShootType; // Тип выстрела (задаётся в SetDefaults())
		const float ShootKnockback = 1; // Отбрасование от выстрела
		const float ShootSpeed = 10; // Скорость выстрела

		const int ShootRate2 = 400; // Частота выстрела. Будет производить 60/ShootRate выстрелов в секунду
		const int ShootDamage2 = 15; // Урон от выстрела
		int ShootType2; // Тип выстрела (задаётся в SetDefaults())
		const float ShootKnockback2 = 1; // Отбрасование от выстрела
		const float ShootSpeed2 = 0; // Скорость выстрела		

		const float DistortPercent = 0.15f; // Процент деформации статов (неточности) (1.0 == 100%)

		const int MinionsID = 61; // ID вуртулек
		const int MinionsCount = 4; // Кол-во вуртулек которых заспавнит

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

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rukh");
			Main.npcFrameCount[NPC.type] = 20;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 2500;
			NPC.damage = 22;
			NPC.defense = 8;
			NPC.knockBackResist = 0f;
			NPC.width = 160;
			NPC.height = 210;
			NPC.aiStyle = 2;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 75, 0);
			NPC.boss = true;
			ShootType = ModContent.ProjectileType<projVultureFeather>();
			ShootType2 = 657;
			//bossBag = mod.ItemType("VultureKingBag");
			NPC.noTileCollide = true;
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void AI()
		{
			PlayAnimation(); // Проигрывание анимации
			if (CheckRunConditions())
				return;
			ChangeState(); // Смена стадии
			Shoot(); // Выстрел
			Shoot2(); // Выстрел			
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

		void Shoot2()
		{
			if (!Shoots && NPC.target < 0)
				return;
			if (--TimeToShoot > 0)
				return;
			TimeToShoot = (int)Helper.DistortFloat(ShootRate, DistortPercent);
			for (int i = 0; i < ((Main.expertMode) ? 3 : 1); i++)
			{
				Vector2 Velocity = Helper.VelocityToPoint(NPC.Center, Helper.RandomPointInArea(new Vector2(Main.player[NPC.target].Center.X - 10, Main.player[NPC.target].Center.Y - 10), new Vector2(Main.player[NPC.target].Center.X + 20, Main.player[NPC.target].Center.Y + 20)), ShootSpeed2);
				int Proj = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, Velocity.X, Velocity.Y, ShootType2, (int)Helper.DistortFloat(ShootDamage, DistortPercent), Helper.DistortFloat(ShootKnockback, DistortPercent));
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
						int index = NPC.NewNPC(NPC.GetSource_FromThis(), (int)Position.X, (int)Position.Y, MinionsID);
						Main.npc[index].Center = Position;
					}
					break;
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			SpriteEffects Direction = (NPC.target == -1) ? SpriteEffects.None : ((Main.player[NPC.target].position.X < NPC.position.X) ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
			spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, new Rectangle((int)(NPC.position.X - Main.screenPosition.X), (int)(NPC.position.Y - Main.screenPosition.Y), 240, 160), new Rectangle(0, Frame * 160, 240, 160), drawColor, 0, new Vector2(0, 0), Direction, 0);
			return false;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TRGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TRGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TRGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TRGore2").Type, 1f);
			}
		}

        public override void OnKill()
        {
            TremorSpawnEnemys.downedRukh = true;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VultureKingMask>(), 7));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VultureFeather>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CactusBow>(), 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandKnife>(), 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandstoneBar>(), 1, 10, 18));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VultureKingTrophy>(), 10));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<VultureKingBag>(), 1));
        }

        /*public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (!Main.expertMode && Main.rand.NextBool(7))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VultureKingMask"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VultureKingTrophy"));
				}
				if (!Main.expertMode && Main.rand.NextBool(3))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CactusBow"));
				}
				if (!Main.expertMode && Main.rand.NextBool(3))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SandKnife"));
				}
				if (!Main.expertMode && Main.rand.NextBool(4))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VultureFeather"));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SandstoneBar"), Main.rand.Next(10, 18));
				}

				TremorWorld.Boss.Rukh.Downed();

			}
		}*/
    }
}