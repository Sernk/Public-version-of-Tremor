using TremorMod.Content.Items.Placeable.Banners;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using System.IO;

namespace TremorMod.Content.NPCs
{
    public class Abomination : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 125;
            NPC.damage = 25;
            NPC.defense = 15;
            NPC.knockBackResist = 0.6f;
            NPC.width = 18;
            NPC.height = 40;
            NPC.value = 60f;
            AnimationType = NPCID.Zombie;
            NPC.aiStyle = 3; // AI стиля Zombie
            NPC.HitSound = SoundID.NPCHit31;
            AIType = NPCID.Zombie;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = Item.buyPrice(0, 0, 4, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<AbominationBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50; // 50 убийств для баннера

        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                for (int i = 0; i < 10; i++) // Создаем 10 частиц
                {
                    var dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Blood);
                    dust.velocity.X += Main.rand.NextFloat(-0.5f, 0.5f);
                    dust.velocity.Y += Main.rand.NextFloat(-0.5f, 0.5f);
                    dust.scale *= 1f + Main.rand.NextFloat(-0.1f, 0.1f);
                }
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
                new FlavorTextBestiaryInfoElement("An abomination that prowls the jungles.")
            });
        }

        public override void OnKill()
        {
            if (Main.rand.NextBool())
            {
                Item.NewItem(NPC.GetSource_Loot(), NPC.position, ItemID.JungleSpores, Main.rand.Next(1, 3));
            }

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.NewNPC(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPCID.Skeleton);
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.JungleSpores, 1, 1, 3));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneJungle && spawnInfo.SpawnTileY > Main.rockLayer ? 0.2f : 0f;
        }
    }
}