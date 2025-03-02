using Terraria;
using TremorMod.Content.Items.Placeable.Banners;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Materials;
using Terraria.GameContent.ItemDropRules;
using System.IO; 

namespace TremorMod.Content.NPCs
{
	public class Atis : ModNPC
	{
        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Atis");
			Main.npcFrameCount[npc.type] = 4;
		}*/

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Ghost];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
		{
			NPC.lifeMax = 140;
            NPC.damage = 15;
            NPC.defense = 10;
            NPC.knockBackResist = 0.6f;
            NPC.width = 34;
            NPC.height = 48;
			AnimationType = 82;
            NPC.aiStyle = 22;
            NPC.value = 40f;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit31;
            NPC.noGravity = true;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.value = Item.buyPrice(0, 0, 4, 15);
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<AtisBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50; // 50 убийств для баннера
		}

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                // Определяем направление удара по направлению NPC
                int hitDirection = NPC.direction;  // Используем direction NPC, чтобы определить направление

                // Создаём частицы при смерти
                for (int k = 0; k < 20; k++)
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                // Создаём големы (пожираемые объекты) при смерти
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AtisGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AtisGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AtisGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AtisGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AtisGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AtisGore2").Type, 1f);
            }
        }



        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
				new FlavorTextBestiaryInfoElement("An Atis that prowls the underground.")
			});
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<HeartofAtis>(), 10));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BoneMask>(), 50));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AtisBlood>(), 1));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return spawnInfo.Player.ZoneRockLayerHeight ? 0.01f : 0f;
        }
	}
}
