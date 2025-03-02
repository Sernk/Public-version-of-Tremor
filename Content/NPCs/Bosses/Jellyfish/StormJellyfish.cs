using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Summon;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Bag;

namespace TremorMod.Content.NPCs.Bosses.Jellyfish
{
	[AutoloadBossHead]
	public class StormJellyfish : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Storm Jellyfish");
			Main.npcFrameCount[NPC.type] = 6;
		}

		const int ShootRate = 100; // Частота выстрела
		const int ShootDamage = 18; // Урон от лазера.
		const float ShootKN = 1.0f; // Отбрасывание
		const int ShootType = 435; // Тип проджектайла которым будет произведён выстрел.
		const float ShootSpeed = 8; // Это, я так понимаю, влияет на дальность выстрела
		const int ProjID = 437;
		const int UpSpeed = 6;

		const int ShootRate2 = 660; // Частота выстрела
		const int ShootDamage2 = 15; // Урон от лазера.
		const float ShootKN2 = 1.0f; // Отбрасывание
		const int ShootType2 = 465; // Тип проджектайла которым будет произведён выстрел.
		const float ShootSpeed2 = 5; // Это, я так понимаю, влияет на дальность выстрела
		const int ProjID2 = 437;
		const int UpSpeed2 = 6;

		int TimeToShoot = ShootRate; // Время до выстрела.

		int TimeToShoot2 = ShootRate2; // Время до выстрела.

		public override void SetDefaults()
		{
			NPC.width = 140;
			NPC.height = 140;
			NPC.damage = 18;
			NPC.defense = 16;
			NPC.lifeMax = 2800;
			NPC.HitSound = SoundID.NPCHit25;
			NPC.DeathSound = SoundID.NPCDeath28;
			NPC.boss = true;
			NPC.knockBackResist = 0.1f;
			AIType = 472;
			NPC.noGravity = true;
			NPC.noGravity = true;
			Music = 39;
			NPC.aiStyle = 86;
			AnimationType = 472;
			//bossBag/* tModPorter Note: Removed. Spawn the treasure bag alongside other loot via npcLoot.Add(ItemDropRule.BossBag(type)) */ = Mod.Find<ModItem>("StormJellyfishBag").Type;
		}

		public override void AI()
		{
			NPC.position += NPC.velocity * 0.5f;

			if (--TimeToShoot <= 0 && NPC.target != -1) Shoot(); // В этой строке из переменной TimeToShot отнимается 1, и если TimeToShot < или = 0, то вызывается метод Shoot()
			if (--TimeToShoot2 <= 0 && NPC.target != -1) Shoot2(); // В этой строке из переменной TimeToShot отнимается 1, и если TimeToShot < или = 0, то вызывается метод Shoot()

			if (Main.rand.Next(400) == 0)
			{
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<FlyingJelly>());
			}
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			int hitDirection = hit.HitDirection;

			if (NPC.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 226, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 226, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 226, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StormGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StormGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StormGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StormGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StormGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StormGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StormGore4").Type, 1f);
			}
			else
			{

				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 226, hitDirection, -2f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 27, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

		void Shoot()
		{
			TimeToShoot = ShootRate;
			Vector2 velocity = VelocityFPTP(NPC.Center, Main.player[NPC.target].Center, ShootSpeed);
			Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, velocity.X, velocity.Y, ShootType, ShootDamage, ShootKN);
		}

		void Shoot2()
		{
			TimeToShoot2 = ShootRate2;
			Vector2 velocity = VelocityFPTP(NPC.Center, Main.player[NPC.target].Center, ShootSpeed2);
			Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, velocity.X, velocity.Y, ShootType2, ShootDamage2, ShootKN2);
		}

		Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
		{
			Vector2 move = pos2 - pos1;
			return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StormJellyfishMask>(), 7));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StormBlade>(), 4));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Poseidon>(), 3));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<JellyfishStaff>(), 3));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BoltTome>(), 3));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StickyFlail>(), 3));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StormJellyfishTrophy>(), 10));
			npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<StormJellyfishBag>(), 1));
		}	
	}
}