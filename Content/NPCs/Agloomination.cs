using TremorMod.Content.Items.Placeable.Banners;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using System.IO;
using Microsoft.Xna.Framework;



namespace TremorMod.Content.NPCs
{
	public class Agloomination : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.ToxicSludge];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
		{
			NPC.lifeMax = 600;
			NPC.damage = 90;
			NPC.defense = 24;
			NPC.knockBackResist = 0.6f;
			NPC.width = 38;
			NPC.height = 44;
			AnimationType = NPCID.ToxicSludge;
            AIType = NPCID.ToxicSludge;
            NPC.aiStyle = 1;
            NPC.value = 60f;
            NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 12, 24);
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<AgloominationBanner>();
			ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // Используем direction для направления пыли
            int hitDirection = NPC.direction;

            if (NPC.life <= 0)
            {
                // Создаем пыль при смерти NPC
                for (int k = 0; k < 60; k++)
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                for (int k = 0; k < 20; k++)
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            else
            {
                // Пыль при получении урона
                for (int k = 0; k < hit.Damage / NPC.lifeMax * 50; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, hitDirection, -1f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, hitDirection, -1f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, hitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
                new FlavorTextBestiaryInfoElement("An Agloomination that prowls the jungles.")
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // Проверяем, что враг может появиться в шахтах после победы над Плантерой
            return NPC.downedPlantBoss && spawnInfo.Player.ZoneRockLayerHeight ? 0.01f : 0f;
        }
    }
	
}