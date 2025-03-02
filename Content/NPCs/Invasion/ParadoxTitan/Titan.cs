using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Dusts;
using TremorMod.Utilities;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items;
using TremorMod.Content.Items.Placeable;

namespace TremorMod.Content.NPCs.Invasion.ParadoxTitan
{
	[AutoloadBossHead]
	public class Titan : ModNPC
	{
		/*
		Интеллект босса состоит из резких рывков. 
		Рывок определяется таймером npc.ai[1]
		Макс. кол-во "тиков" в 	npc.ai[1] = 4500
		Чем меньше у босса здоровья, тем быстрее и сильнее рывки
		С небольшим шансом может сделать комбинацию из рывков (от 1 до 6 рывков подряд)
		Иногда создает кольцо из быстро меняющихся картинок (как у мозга Ктулху)
		Выбирает случайную позицию и встает на место картинки
		Со временем картинки исчезают
		В зависимости от выбранной картинки меняется урон рывка
		Босс не покидает поле сражения, при этом, сделая рывок 6, может улететь
		Рывки 1, 2 и 3 самые безвредные
		Иногда спаунит кристаллы
		*/
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Paradox Titan");
			Main.npcFrameCount[NPC.type] = 4;
		}

		Vector2 Hands = new Vector2(-1, -1);
		public static readonly int arenaWidth = (int)(1.3f * NPC.sWidth);
		public override void SetDefaults()
		{
			NPC.lifeMax = 90000;
			NPC.damage = 145;
			NPC.defense = 50;
			NPC.knockBackResist = 0f;
			NPC.noTileCollide = true;
			NPC.width = 180;
			NPC.height = 200;
			AnimationType = 82;
			NPC.aiStyle = 14;
			NPC.npcSlots = 50f;
			NPC.HitSound = SoundID.NPCHit31;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 25, 0);
			NPC.boss = true;
			//bossBag/* tModPorter Note: Removed. Spawn the treasure bag alongside other loot via npcLoot.Add(ItemDropRule.BossBag(type)) */ = Mod.Find<ModItem>("ParadoxTitanBag").Type;
		}

		int draw = -25;
		int draw_ = 75;
		public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			//spriteBatch.Draw(mod.GetTexture("NPCs/CogLordBody"), npc.Center - Main.screenPosition, null, Color.White, 0f, new Vector2(74, -18), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(ModContent.Request<Texture2D>("TremorMod/Content/NPCs/Invasion/ParadoxTitan/Hand_").Value, NPC.Center - Main.screenPosition, null, Color.White, 0.0f, new Vector2(draw, -10), 1f, SpriteEffects.None, 1);
            spriteBatch.Draw(ModContent.Request<Texture2D>("TremorMod/Content/NPCs/Invasion/ParadoxTitan/Hand").Value, NPC.Center - Main.screenPosition, null, Color.White, 0.0f, new Vector2(draw_, -10), 1f, SpriteEffects.None, 1);
			//spriteBatch.Draw(mod.GetTexture("Invasion/Titan"), new Vector2(npc.Center.X, npc.Center.Y), null, Color.White, 0.0f, new Vector2(-10, -25), 1f, SpriteEffects.None, 1);				
		}

		int CurrentFrame;
		int TimeToAnimation = 6;
		const int AnimationRate = 6;
		bool FirstState_ = true;
		void Animation()
		{
			if (--TimeToAnimation <= 0)
			{

				if (++CurrentFrame > 4)
					CurrentFrame = 1;
				TimeToAnimation = AnimationRate;
				NPC.frame = GetFrame(CurrentFrame + ((FirstState_) ? 0 : 4));
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, NPC.frame.Height * (Number - 1), NPC.frame.Width, NPC.frame.Height);
		}

		private void SetupCrystals(int radius, bool clockwise)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			Vector2 center = NPC.Center;
			for (int k = 0; k < 15; k++)
			{
				float angle = 2f * (float)Math.PI / 10f * k;
				Vector2 pos = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				int damage = 80;
				if (Main.expertMode)
				{
					damage = (int)(100 / Main.GameModeInfo.EnemyDamageMultiplier);
				}
				int proj = Projectile.NewProjectile(NPC.GetSource_FromThis(), pos.X, pos.Y, 0f, 0f, Mod.Find<ModProjectile>("TitanCrystal_").Type, damage, 0f, Main.myPlayer, NPC.whoAmI, angle);
				Main.projectile[proj].localAI[0] = radius;
				Main.projectile[proj].localAI[1] = clockwise ? 1 : -1;
				//NetMessage.SendData(27, -1, -1, "", proj);
			}
		}

		public override void AI()
		{
			Animation();
			Vector2 PTC = Main.player[NPC.target].position + new Vector2(NPC.width / 2, NPC.height / 2);
			Vector2 NPos = NPC.position + new Vector2(NPC.width / 2, NPC.height / 2);
			if (Main.rand.Next(150) == 0)
			{
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, Mod.Find<ModNPC>("TitanCrystal").Type);
			}

			if (Main.rand.Next(150) == 1)
			{
				Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
				float rotation = (float)Math.Atan2(vector8.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector8.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
				NPC.velocity.X = (float)(Math.Cos(rotation) * 14) * -1;
				NPC.velocity.Y = (float)(Math.Sin(rotation) * 14) * -1;
				NPC.netUpdate = true;
			}

			if (Main.rand.Next(250) == 1)
			{
				Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
				float rotation = (float)Math.Atan2(vector8.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector8.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
				NPC.velocity.X = (float)(Math.Cos(rotation) * 28) * -1;
				NPC.velocity.Y = (float)(Math.Sin(rotation) * 28) * -1;
				NPC.netUpdate = true;
			}

			if (Main.rand.Next(350) == 1) //6 комбо
			{
				Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
				float rotation = (float)Math.Atan2(vector8.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector8.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
				NPC.velocity.X = (float)(Math.Cos(rotation) * 46) * -1;
				NPC.velocity.Y = (float)(Math.Sin(rotation) * 46) * -1;
				NPC.netUpdate = true;
			}

			NPC.netUpdate = false;
			NPC.ai[0]++;
			NPC.ai[1]++; //старт таймера
			if (NPC.ai[1] >= 40) //ускорение рывков
			{
				NPC.velocity.X *= 0.97f;
				NPC.velocity.Y *= 0.97f;
			}

			if (NPC.ai[1] >= 4500) //макс. таймера
			{
				NPC.ai[0]++;
				NPC.ai[1] = 0;
			}

			if ((NPC.ai[1] >= 200 && NPC.life > 90000 && NPC.ai[1] < 3000) || (NPC.ai[1] >= 120 && NPC.life <= 90000 && NPC.ai[1] < 3000) && Main.expertMode) //экспертные рывки
			{
				SoundEngine.PlaySound(SoundID.Item8, NPC.position);
				for (int num36 = 0; num36 < 10; num36++)
				{
					Color color = new Color();
					int dust = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, ModContent.DustType<CyberDust>(), NPC.velocity.X + Main.rand.Next(-10, 10), NPC.velocity.Y + Main.rand.Next(-10, 10), 200, color, 1f);
					Main.dust[dust].noGravity = true;
				}
				NPC.ai[3] = (float)(Main.rand.Next(360) * (Math.PI / 180));
				NPC.ai[2] = 0;
				//npc.ai[1] = 0;

				if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
				{
					NPC.TargetClosest(true);
				}
				if (!Main.player[NPC.target].dead && Main.rand.NextBool(2))
				{
					NPC.position.X = Main.player[NPC.target].position.X + (float)((600 * Math.Cos(NPC.ai[3])) * -1);
					NPC.position.Y = Main.player[NPC.target].position.Y + (float)((600 * Math.Sin(NPC.ai[3])) * -1);
					Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
					float rotation = (float)Math.Atan2(vector8.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector8.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
					NPC.velocity.X = (float)(Math.Cos(rotation) * 14) * -1;
					NPC.velocity.Y = (float)(Math.Sin(rotation) * 14) * -1;
				}
			}

			if ((NPC.ai[1] >= 200 && NPC.life > 45000 && NPC.ai[1] < 500) || (NPC.ai[1] >= 120 && NPC.life <= 45000 && NPC.ai[1] < 500) && !Main.expertMode) //рывки
			{
				SoundEngine.PlaySound(SoundID.Item8, NPC.position);
				for (int num36 = 0; num36 < 10; num36++)
				{
					Color color = new Color();
					int dust = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, ModContent.DustType<CyberDust>(), NPC.velocity.X + Main.rand.Next(-10, 10), NPC.velocity.Y + Main.rand.Next(-10, 10), 200, color, 1f);
					Main.dust[dust].noGravity = true;
				}
				NPC.ai[3] = (float)(Main.rand.Next(360) * (Math.PI / 180));
				NPC.ai[2] = 0;
				//npc.ai[1] = 0;

				if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
				{
					NPC.TargetClosest(true);
				}

				if (!Main.player[NPC.target].dead && Main.rand.NextBool(2))
				{
					NPC.position.X = Main.player[NPC.target].position.X + (float)((600 * Math.Cos(NPC.ai[3])) * -1);
					NPC.position.Y = Main.player[NPC.target].position.Y + (float)((600 * Math.Sin(NPC.ai[3])) * -1);
					Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
					float rotation = (float)Math.Atan2(vector8.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector8.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
					NPC.velocity.X = (float)(Math.Cos(rotation) * 14) * -1;
					NPC.velocity.Y = (float)(Math.Sin(rotation) * 14) * -1;
				}
			}

			if (NPC.ai[1] >= 3000) //комбо 2
			{
				if (NPC.ai[0] == 0)
				{
					NPC.velocity.Y = Main.rand.Next(-10, -2);
					NPC.velocity.X = Main.rand.Next(-10, 10) / 10;
					NPC.ai[0] = 1;
				}
				NPC.TargetClosest();
				if (Main.player[NPC.target].position.X < NPC.position.X)
				{
					if (NPC.velocity.X > -6) { NPC.velocity.X -= 0.3f; NPC.netUpdate = true; }
				}
				if (Main.player[NPC.target].position.X > NPC.position.X)
				{
					if (NPC.velocity.X < 6) { NPC.velocity.X += 0.3f; NPC.netUpdate = true; }
				}

				if (Main.player[NPC.target].position.Y < NPC.position.Y && NPC.velocity.Y > -8)
				{
					if (NPC.velocity.Y > 0f) NPC.velocity.Y -= 0.3f;
					else NPC.velocity.Y -= 0.015f;
				}
				if (Main.player[NPC.target].position.Y > NPC.position.Y && NPC.velocity.Y < 8)
				{
					if (NPC.velocity.Y < 0f) NPC.velocity.Y += 0.3f;
					else NPC.velocity.Y += 0.015f;
				}
			}

			if (NPC.ai[1] >= 3200) //комбо 3
			{
				Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
				float rotation = (float)Math.Atan2(vector8.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector8.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
				NPC.velocity.X = (float)(Math.Cos(rotation) * 28) * -1;
				NPC.velocity.Y = (float)(Math.Sin(rotation) * 28) * -1;
				NPC.netUpdate = true;
				float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
				int SpitShot1 = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), Mod.Find<ModProjectile>("CyberLaserBat").Type, 30, 0f, 0);
				Main.projectile[SpitShot1].friendly = false;
				Main.projectile[SpitShot1].timeLeft = 500;
			}

			if (NPC.ai[1] >= 3500) //комбо 4
			{
				NPC.velocity.X *= 2.00f;
				NPC.velocity.Y *= 2.00f;
				Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
				{
					float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), (vector8.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
					NPC.velocity.X = (float)(Math.Cos(rotation) * 28) * -1;
					NPC.velocity.Y = (float)(Math.Sin(rotation) * 28) * -1;
					float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
					int SpitShot1 = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), Mod.Find<ModProjectile>("CyberLaserBat").Type, 50, 0f, 0);
					Main.projectile[SpitShot1].friendly = false;
					Main.projectile[SpitShot1].timeLeft = 500;
				}
				return;
			}

			if (NPC.ai[1] >= 4000) //комбо 5-6
			{
				NPC.velocity.X *= 5.00f;
				NPC.velocity.Y *= 5.00f;
				Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
				{
					float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
					int SpitShot1 = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), Mod.Find<ModProjectile>("CyberLaserBat").Type, 90, 0f, 0);
					Main.projectile[SpitShot1].friendly = false;
					Main.projectile[SpitShot1].timeLeft = 500;
					float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), (vector8.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
					NPC.velocity.X = (float)(Math.Cos(rotation) * 28) * -1;
					NPC.velocity.Y = (float)(Math.Sin(rotation) * 28) * -1;
				}
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
			if (Main.netMode != 1)
			{
				int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
				int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
				int halfLength = NPC.width / 2 / 16 + 1;
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ParadoxTitanMask>(), 7));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TimeTissue>(), 1, 20, 32));
                npcLoot.Add(ItemDropRule.OneFromOptions(1,ModContent.ItemType<RocketWand>(),ModContent.ItemType<TheEtherealm>(),  ModContent.ItemType<SoulFlames>()));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ParadoxTitanTrophy>(), 10));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VioleumWings>(), 20));
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<ParadoxTitanBag>(), 1));
            }
        }
    }
}