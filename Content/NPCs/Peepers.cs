using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class Peepers : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Peepers");
			Main.npcFrameCount[NPC.type] = 4;
		}

		const int ShootRate = 100;
		const int ShootDamage = 10;
		const float ShootKN = 1.0f;
		const float ShootSpeed = 4;
        const int ShootType = 100;

        int TimeToShoot = 0;

		public override void SetDefaults()
		{
			NPC.lifeMax = 250;
			NPC.damage = 30;
			NPC.defense = 23;
			NPC.knockBackResist = 0f;
			NPC.width = 136;
			NPC.height = 175;
			AnimationType = 82;
			NPC.aiStyle = 22;
			NPC.npcSlots = 0.5f;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 8, 9);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<PeepersBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
            TimeToShoot = 0;
		}

        public override void AI()
        {
            if (Main.netMode != 1 && TimeToShoot++ >= 250 && NPC.target != -1)
            {
                IEntitySource source = NPC.GetSource_FromAI();
                Vector2 position = NPC.Center;
                Vector2 velocity = Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center) * ShootSpeed;
                Projectile.NewProjectile(source, position, velocity, ShootType, ShootDamage, ShootKN);
                TimeToShoot = 0;
            }
        }

        public override void OnKill()
		{
			if (Main.rand.NextBool(1))
			{
				Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<SharpenedTooth>());
			}
		}

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				for (int i = 0; i < 3; ++i)
				{
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PeepersGore1").Type, 1f);
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PeepersGore2").Type, 1f);
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PeepersGore3").Type, 1f);
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PeepersGore3").Type, 1f);
				}
                
            }
			else
			{
				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.Player.ZoneDungeon && spawnInfo.SpawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}