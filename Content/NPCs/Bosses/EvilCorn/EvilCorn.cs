using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using TremorMod.Utilities;
using TremorMod.Content.Items.EvilCornItems;
using TremorMod.Content.Items.Vanity;

/*
1 состояние - парит на месте - при приближении игрока даёт ему оплеуху. 
Время от времени на пару секунд скрывается в своих "листьях" переводя весь полученный урон - в хил.
2 состояние - начинает лететь за игроком махая своими "листьями" и раздавая оплеухи уже всем подряд.
3 состояние - после полёта на несколько секунд зарывается в землю - после чего резко оттуда выпрыгивает нанося большой урон.
*/

namespace TremorMod.Content.NPCs.Bosses.EvilCorn
{
	[AutoloadBossHead]
	public class EvilCorn : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Evil Corn");
			Main.npcFrameCount[NPC.type] = 22;
		}

		#region "Константы для настойки AI"
		const int simpleAttakStateTime = 120; // Время которое он будет стоять на месте и бить
		const int simpleDefenseStateTime = 120; // Время которое он будет стоять и хилится
		const int normalAttackStateTime = 180; // Время которое он будет летать за игроком и бить его
		const int normalDefenseStateTime = 45;

		const int simpleAttakAnimTime = 30; // Длительность анимации атаки (лучше не менять, а попросить меня...)
		const int simpleCangeLeversTime = 12; // Длительность анимации Листьем (тоже что и с атакой...)

		const float SimpleHitDist = 125f; // Дистанция обычного удара
		#endregion

		#region "Переменные для работы с AI"
		int State;
		// 0 - парит на месте, при приближении бьёт
		// 1 - парит на месте, скрыт в своих листьях
		// 2 - летает за игроком махая листьями
		int stateTime = simpleAttakStateTime;
		// Время до завершения текущего действия
		int nowHitPlayerLeft;
		// Время до завершения текущей анимации удара влево
		int nowHitPlayerRight;
		// Время до завершения текущей анимации удара вправо
		int nowCangeLeavs;
		// Время до завершения текушей анимации смены листьев
		#endregion

		public override void SetDefaults()
		{
			NPC.lifeMax = 3000;
			NPC.damage = 30;
			NPC.defense = 12;
			NPC.knockBackResist = 0f;
			NPC.width = 155;
			NPC.height = 93;
			NPC.aiStyle = -1;
			NPC.noGravity = false;
			NPC.noTileCollide = false;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.boss = true;
			NPC.value = Item.buyPrice(0, 3, 25, 0);
            Music = MusicLoader.GetMusicSlot("TremorMod/Content/Music/EvilCorn");
        }
        #region "ТУТ ЕЩЕ НАСТРОЙКИ"
        // ТУТ ЕЩЕ НАСТРОЙКИ !!!
        const int damage0 = 20; // Урон в первом состоянии
		const int defense0 = 2; // Броня в первом состоянии
		const int damage1 = 10; // Урон во втором состоянии
		const int defense1 = 4; // Броня во втором состоянии
		const int damage2 = 30; // Урон в 3 состоянии
		const int defense2 = 3; // Броня в 3 состоянии
		const int damage3 = 30; // Урон в 4 состоянии
		const int defense3 = 4; // Броня в 4 состоянии
        #endregion

        #region "Вылёт попкорна при ударе"
        public override void OnHitByItem(Player player, Item item, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool(2))
				Item.NewItem(NPC.GetSource_FromThis(), NPC.position, NPC.Size, Mod.Find<ModItem>("Popcorn").Type);
			base.OnHitByItem(player, item, hit, damageDone);
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
			NPC.damage = (int)(NPC.damage * 0.6f);
		}

		public override void OnHitByProjectile(Projectile projectile, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool(2))
				Item.NewItem(NPC.GetSource_FromThis(), NPC.position, NPC.Size, Mod.Find<ModItem>("Popcorn").Type);
			base.OnHitByProjectile(projectile, hit, damageDone);
		}
		#endregion

		#region "Работа с анимацией"
		int _2_Frame = 17;
		int FrameNow;
		bool needState3SetFrame = true;
		void PlayAnimation()
		{
			NPC.rotation = 0;
			if (nowHitPlayerLeft > 0 || nowHitPlayerRight > 0)
			{
				if (nowHitPlayerLeft > 0)
					if (nowHitPlayerLeft % 6 == 0)
					{
						NPC.frame = getFrame(nowHitPlayerLeft / 6 + 1);
						FrameNow = nowHitPlayerLeft / 6 + 1;
					}
				if (nowHitPlayerRight > 0)
					if (nowHitPlayerRight % 6 == 0)
					{
						NPC.frame = getFrame(nowHitPlayerRight / 6 + 6);
						FrameNow = nowHitPlayerLeft / 6 + 6;
					}
				return;
			}
			if (nowCangeLeavs > 0)
			{
				if (State == 0 || State == 2)
				{
					if (nowCangeLeavs % 6 == 0)
					{
						if (nowCangeLeavs > 6)
						{
							NPC.frame = getFrame(12);
							FrameNow = 12;
						}
						else
						{
							NPC.frame = getFrame(13);
							FrameNow = 13;
						}
					}
				}
				else
				{
					if (nowCangeLeavs % 6 == 0)
					{
						if (nowCangeLeavs > 6)
						{
							NPC.frame = getFrame(13);
							FrameNow = 13;
						}
						else
						{
							NPC.frame = getFrame(12);
							FrameNow = 12;
						}
					}
				}
			}
			else
			{
				if (State == 0)
					if (nowHitPlayerLeft <= 0 && nowHitPlayerRight <= 0)
					{
						NPC.frame = getFrame(1);
						FrameNow = 1;
					}
				if (State == 1)
				{
					NPC.frame = getFrame(14);
					FrameNow = 14;
				}
				if (State == 2)
				{
					if (stateTime % 3 == 0)
					{
						NPC.frame = getFrame(_2_Frame);
						FrameNow = _2_Frame;
						_2_Frame++;
						if (_2_Frame > 20)
							_2_Frame = 17;
					}
				}
				if (State == 3)
				{
					if (needState3SetFrame)
						NPC.frame = getFrame(14);
					needState3SetFrame = false;
				}
			}
		}

		Rectangle getFrame(int Index)
		{
			Index--;
			Rectangle rect = new Rectangle(0, 93 * Index, 155, 93);
			if (++Index > 13)
				rect.Y += 2;
			else
				rect.Y += 1;
			return rect;
		}
		#endregion

		bool NeedPrepere = true;
		List<int> Stadyes = new List<int> { 0, 1, 2, 3 };
		int NextStady = -1;
		void RechangeStage()
		{
			if (NextStady == -1)
			{
				if (Stadyes.Contains(State))
					Stadyes.Remove(State);
				if (Stadyes.Count <= 0) { Stadyes = new List<int> { 0, 1, 2, 3 }; Stadyes.Remove(State); }
				int ID = Main.rand.Next(0, Stadyes.Count);
				NextStady = Stadyes[ID];
				Stadyes.RemoveAt(ID);
			}

			switch (State)
			{
				case 0:
					#region "Оброботка перехода с первой стадии"
					switch (NextStady)
					{
						case 1:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								NPC.damage = damage1;
								NPC.defense = defense1;
								State = 1;
								stateTime = simpleDefenseStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
						case 2:
							NPC.damage = damage2;
							NPC.defense = defense2;
							NPC.noGravity = true;
							NPC.noTileCollide = true;
							NPC.aiStyle = 5;
							State = 2;
							stateTime = normalAttackStateTime;
							NextStady = -1;
							break;
						case 3:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								NPC.damage = damage3;
								NPC.defense = defense3;
								State = 3;
								stateTime = normalDefenseStateTime;
								NeedPrepere = true;
								NextStady = -1;
								needState3SetFrame = true;
							}
							break;
					}
					#endregion
					break;
				case 1:
					#region "Оброботка перехода с второй стадии"
					switch (NextStady)
					{
						case 0:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								NPC.damage = damage0;
								NPC.defense = defense0;
								State = 0;
								stateTime = simpleAttakStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
						case 2:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								NPC.damage = damage2;
								NPC.defense = defense2;
								NPC.noGravity = true;
								NPC.noTileCollide = true;
								NPC.aiStyle = 5;
								State = 2;
								stateTime = normalAttackStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
						case 3:
							NPC.damage = damage3;
							NPC.defense = defense3;
							State = 3;
							stateTime = normalDefenseStateTime;
							NextStady = -1;
							needState3SetFrame = true;
							break;
					}
					#endregion
					break;
				case 2:
					#region "Оброботка перехода с третьей стадии"
					switch (NextStady)
					{
						case 0:
							NPC.velocity.X = 0;
							NPC.damage = damage0;
							NPC.defense = defense0;
							NPC.noGravity = false;
							NPC.noTileCollide = false;
							NPC.aiStyle = -1;
							State = 0;
							stateTime = simpleAttakStateTime;
							NextStady = -1;
							break;
						case 1:
							if (NeedPrepere)
							{
								NPC.velocity.X = 0;
								NPC.noGravity = false;
								NPC.noTileCollide = false;
								NPC.aiStyle = -1;
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								NPC.damage = damage1;
								NPC.defense = defense1;
								State = 1;
								stateTime = simpleDefenseStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
						case 3:
							if (NeedPrepere)
							{
								NPC.velocity.X = 0;
								NPC.noGravity = false;
								NPC.noTileCollide = false;
								NPC.aiStyle = -1;
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								NPC.damage = damage3;
								NPC.defense = defense3;
								State = 3;
								stateTime = normalDefenseStateTime;
								NeedPrepere = true;
								NextStady = -1;
								needState3SetFrame = true;
							}
							break;
					}
					#endregion
					break;
				case 3:
					#region "Оброботка перехода с четвёртой стадии"
					switch (NextStady)
					{
						case 0:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								NPC.damage = damage0;
								NPC.defense = defense0;
								State = 0;
								stateTime = simpleAttakStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
						case 1:
							NPC.damage = damage1;
							NPC.defense = defense1;
							State = 1;
							stateTime = simpleDefenseStateTime;
							NextStady = -1;
							break;
						case 2:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								NPC.noGravity = true;
								NPC.noTileCollide = true;
								NPC.aiStyle = 5;
								NPC.damage = damage2;
								NPC.defense = defense2;
								State = 2;
								stateTime = normalAttackStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
					}
					#endregion
					break;
			}
		}

		#region "Урон в здоровье во время 2 стадии"
		public override void ModifyHitByItem(Player player, Item item, ref NPC.HitModifiers modifiers)
		{
			if (State == 1) // Если вторая стадия (в ней идёт конвертирование урона в хп), то
			{
				int hpBeforeHeal = NPC.life; // Сохраняем в переменную текущее хп
				NPC.life += (int)modifiers.FinalDamage.Flat; // Добавляем в хп моба урон который должны нанести
				if (NPC.life > NPC.lifeMax) // Если теперь хп больше макс. хп, уменьшаем до макс. хп
					NPC.life = NPC.lifeMax;
				if (NPC.lifeMax - hpBeforeHeal > 0) // Если отхил произошол
					NPC.HealEffect(NPC.lifeMax - hpBeforeHeal); // Показываем эффект лечения на то хп, которое восстановил моб
				modifiers.FinalDamage.Flat = 0; // Убираем урон
			}
			base.ModifyHitByItem(player, item, ref modifiers);
		}

		public override void ModifyHitByProjectile(Projectile projectile, ref NPC.HitModifiers modifiers)
		{
			if (State == 1) // Если вторая стадия (в ней идёт конвертирование урона в хп), то
			{
				int hpBeforeHeal = NPC.life; // Сохраняем в переменную текущее хп
				NPC.life += (int)modifiers.FinalDamage.Flat; // Добавляем в хп моба урон который должны нанести
				if (NPC.life > NPC.lifeMax) // Если теперь хп больше макс. хп, уменьшаем до макс. хп
					NPC.life = NPC.lifeMax;
				if (NPC.lifeMax - hpBeforeHeal > 0) // Если отхил произошол
					NPC.HealEffect(NPC.lifeMax - hpBeforeHeal); // Показываем эффект лечения на то хп, которое восстановил моб
				modifiers.FinalDamage.Flat = 0; // Убираем урон
			}
			base.ModifyHitByProjectile(projectile, ref modifiers);
		}
		#endregion

		public override void AI()
		{
			if (Helper.GetNearestPlayer(NPC.Center, true) != -1 && !Main.dayTime)
			{
				// В зависимости от состояния, вызываются разные методы AI
				switch (State)
				{
					case 0:
						SimpleAttak(); // парит на месте, при приближении бьёт
						break;
					case 1:
						SimpleDeffense(); // парит на месте, скрыт в своих листьях
						break;
					case 2:
						NormalAttak(); // летает за игроком махая листьями
						break;
					case 3:
						NormalDefense(); // летает за игроком махая листьями
						break;
				}
				PlayAnimation(); // Проигрываем анимацию
			}
			else
			{
				NPC.velocity = new Vector2(0, -25);
				if (NPC.Distance(Main.player[Helper.GetNearestPlayer(NPC.Center)].position) > 2500f)
					NPC.life = -1;
			}
		}

		#region "Методы работы первой стадии"
		void SimpleAttak() // парит на месте, при приближении бьёт
		{
			// Если время действия подошло к концу (тут его и уменьшаем) и не идёт анимации удара, то изменить стадию
			if (--stateTime <= 0 && nowHitPlayerLeft <= 0 && nowHitPlayerRight <= 0)
			{
				RechangeStage();
				return;
			}
			// Если анимаций нет (а значит стадия не меняется, так как переход на следующую стадию проходит с анимацией листьев) то пробуем ударить кого-то
			if (nowHitPlayerRight <= 0 && nowHitPlayerLeft <= 0 && nowCangeLeavs <= 0 && stateTime > 0)
				SimpleAttak_Hit();
			// Уменьшаем время до конца удара
			if (nowHitPlayerLeft > 0)
				nowHitPlayerLeft--;
			if (nowHitPlayerRight > 0)
				nowHitPlayerRight--;
		}

		void SimpleAttak_Hit()
		{
			// Получаем ближайшего живого игрока, и если таких нет, то прерываем метод
			int Target = Helper.GetNearestPlayer(NPC.Center, true);
			if (Target == -1)
				return;
			// Если дистанция до ближайшего живого игрока нормальная для удара - бьём
			if (NPC.Distance(Main.player[Target].Center) <= SimpleHitDist)
			{
				// Тут происходит выбор - в какую сторону бить.
				if (Main.player[Target].position.X < NPC.position.X)
					nowHitPlayerLeft = simpleAttakAnimTime;
				else
					nowHitPlayerRight = simpleAttakAnimTime;
			}
		}
		#endregion // парит на месте, при приближении бьёт // парит на месте, при приближении бьёт// парит на месте, при приближении бьёт

		void SimpleDeffense() // парит на месте, скрыт в своих листьях
		{
			if (--stateTime <= 0)
			{
				RechangeStage();
			}
		}

		void NormalAttak() // летает за игроком махая листьями
		{
			if (--stateTime <= 0)
			{
				RechangeStage();
				return;
			}
			NPC.position += NPC.velocity; // Увеличиваем скорость вдвое
		}

		int FrameYOffset;
		bool FirstAction = true;
		bool needTP = true;
		int TimeToNS = 6;
		const int TimeToNSConst = 6;
		void NormalDefense()
		{
			if (stateTime > 30)
				--stateTime;
			if (stateTime <= 30)
			{
				NPC.dontTakeDamage = true;
				if (stateTime <= 0)
				{
					NPC.dontTakeDamage = false;
					NextStady = 2;
					RechangeStage();
					FrameYOffset = 0;
					FirstAction = true;
					needTP = true;
					return;
				}
				if (FirstAction)
				{
					if (NPC.velocity.Y <= 0)
					{
						if (Main.rand.NextBool(6))
							for (int x = (int)NPC.position.X; x < (NPC.position.X + NPC.width); x++)
								Dust.NewDust(new Vector2(x, NPC.position.Y + NPC.height), 1, 1, DustID.GoldCoin);
						NPC.frame = getFrame(22);
						NPC.frame.Y -= FrameYOffset;
						FrameYOffset += 4;
						if (FrameYOffset >= NPC.height)
						{
							FirstAction = false;
							FrameYOffset = 0;
						}
					}
				}
				else
				{
					if (NPC.velocity.Y > 0)
						return;
					if (needTP)
					{
						needTP = false;
						TeleportOnPlayer();
					}
					while (!WorldGen.SolidTile((int)NPC.Center.X / 16, ((int)NPC.position.Y + NPC.height) / 16 + 1))
						NPC.position.Y += 8;
					if (Main.rand.NextBool(6))
						for (int x = (int)NPC.position.X; x < (NPC.position.X + NPC.width); x++)
							Dust.NewDust(new Vector2(x, NPC.position.Y + NPC.height), 1, 1, DustID.GoldCoin);
					NPC.frame = getFrame(21);
					NPC.frame.Y += FrameYOffset;
					FrameYOffset += 8;
					if (FrameYOffset >= NPC.height)
					{
						NPC.frame = getFrame(14);
						if (--TimeToNS >= 1)
							return;
						TimeToNS = TimeToNSConst;
						stateTime = -1;
					}
				}
			}
		}

		void TeleportOnPlayer()
		{
			NPC.Teleport(new Vector2(Main.player[Helper.GetNearestPlayer(NPC.Center, true)].position.X - NPC.width / 2, Main.player[Helper.GetNearestPlayer(NPC.Center, true)].position.Y - NPC.height), -1);
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 1, 4));
            npcLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 6, 25));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EvilCornTrophy>(), 10));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<EvilCornMask>(), 7));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<GrayKnightHelmet>(), 5));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<GrayKnightBreastplate>(), 5));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<KnightGreaves>(), 5));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CornSword>(), 3));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Corn>(), 1, 25, 48));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CornJavelin>(), 1, 15, 45));

            npcLoot.Add(ItemDropRule.ByCondition(new MissingItemCondition(ModContent.ItemType<FarmerShovel>()), ModContent.ItemType<FarmerShovel>(), 1));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<EvilCornBag>(), 1));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CornGore1").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CornGore2").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CornGore3").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CornGore3").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CornGore4").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CornGore4").Type, 1f);
			}
		}       
    }
}