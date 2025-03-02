using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class Observer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Observer");
			Main.npcFrameCount[NPC.type] = 4;
		}
		
		const int ShootDamage = 20;
		const float ShootKN = 1.0f;
		const float ShootSpeed = 4;
        const int ShootType = 100;

        int TimeToShoot = 0;

		public override void SetDefaults()
		{
			NPC.lifeMax = 2500;
			NPC.damage = 80;
			NPC.defense = 32;
			NPC.knockBackResist = 0f;
			NPC.width = 130;
			NPC.height = 130;
			AnimationType = 82;
			NPC.aiStyle = 22;
			NPC.npcSlots = 0.5f;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit31;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 55, 9);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<ObserverBanner>();
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
            if (Main.rand.NextBool(15))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<Spearaxe>());
            }
			if (Main.rand.NextBool(15))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<ScarredReaper>());
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
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ObserverGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ObserverGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ObserverGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ObserverGore4").Type, 1f);
			}
			else
			{
				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && Main.hardMode && Main.bloodMoon && spawnInfo.SpawnTileY < Main.worldSurface ? 0.006f : 0f;
	}
}