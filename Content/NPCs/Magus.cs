using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class Magus : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Magus");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 290;
			NPC.damage = 65;
			NPC.defense = 18;
			NPC.knockBackResist = 0.3f;
			NPC.width = 42;
			NPC.height = 56;
			AnimationType = 29;
			NPC.aiStyle = -1;
			NPC.npcSlots = 15f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 1, 21);
		}
		
		public override void AI()
		{
			if ((int)Main.time % 180 == 0)
			{
				DoAI();
				Teleport();
			}
		}

		public void Teleport()
		{
			for (int i = 0; i < 10; i++)
				Main.dust[Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 68, NPC.velocity.X + Main.rand.Next(-10, 10), NPC.velocity.Y + Main.rand.Next(-10, 10), 5, NPC.color, 2.6f)].noGravity = true;

			NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
			NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
		}

		public void DoAI()
		{
			if (Main.netMode == 1) return;

			float SpeedX = Main.LocalPlayer.Center.X - NPC.Center.X;
			float SpeedY = Main.LocalPlayer.Center.Y - NPC.Center.Y;
			float Length = (float)Math.Sqrt(SpeedX * SpeedX + SpeedY * SpeedY);
			float Speed = 8;
			Length = Speed / Length;
			SpeedX = SpeedX * Length;
			SpeedY = SpeedY * Length;
			int Proj = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X - 10f, NPC.Center.Y, SpeedX, SpeedY, ModContent.ProjectileType<MagusBall>(), 14, 1f, Main.myPlayer);
			Main.projectile[Proj].timeLeft = 300;
			Main.projectile[Proj].netUpdate = true;
		}

		public override void FindFrame(int frameHeight)
		{
			if (NPC.frameCounter++ >= 50)
			{
				NPC.frame.Y = (NPC.frame.Y + frameHeight) % (Main.npcFrameCount[NPC.type] * frameHeight);
				NPC.frameCounter = 0;
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			if (Main.invasionType == InvasionID.GoblinArmy)
			{
				Main.invasionSize -= 1;
				if (Main.invasionSize < 0)
					Main.invasionSize = 0;
				if (Main.netMode != 1)
					Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, Main.invasionSizeStart, InvasionID.GoblinArmy + 3, 0);
				if (Main.netMode == 2)
					NetMessage.SendData(78, -1, -1, null, Main.invasionProgress, Main.invasionProgressMax, Main.invasionProgressIcon, 0f, 0, 0, 0);
			}
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MagusTome>(), 50));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.invasionType == InvasionID.GoblinArmy && Main.hardMode && spawnInfo.SpawnTileY < Main.worldSurface ? 0.08f : 0f;
	}
}