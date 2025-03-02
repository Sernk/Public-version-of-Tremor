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
	public class ArmoredJellyfish : ModNPC
	{
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BloodJelly];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Armored Jellyfish");
			Main.npcFrameCount[npc.type] = 7;
		}*/

        public override void SetDefaults()
		{
			NPC.lifeMax = 40;
            NPC.damage = 12;
            NPC.defense = 20;
            NPC.knockBackResist = 0.3f;
            NPC.width = 62;
            NPC.height = 46;
			AnimationType = NPCID.BloodJelly;
            AIType = NPCID.BloodJelly;
            NPC.aiStyle = 18;
            NPC.value = 60f;
            NPC.HitSound = SoundID.NPCHit47;
			NPC.DeathSound = SoundID.NPCDeath23;
			NPC.value = Item.buyPrice(0, 0, 6, 3);
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<ArmoredJellyfishBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void HitEffect(NPC.HitInfo hitInfo)
        {
            if (NPC.life <= 0) // Проверка на смерть
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitInfo.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                // Спавн gore при смерти
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ArmoredGore").Type, 1f);
            }
        }

        public override void OnKill()
        {
            if (Main.rand.NextBool())
            {
                Item.NewItem(NPC.GetSource_Loot(), NPC.position, NPC.Size, ItemID.RottenChunk);
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.RottenChunk, 1));
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground, // Биом "Underground"
            //new BestiaryBackgroundImagePathAndColorProvider("Images/MapBGs/Water", Color.CornflowerBlue), // Фон воды
            new FlavorTextBestiaryInfoElement("An armored jellyfish lurking in the corrupted waters.") // Описание
            });
        }



        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneCorrupt && spawnInfo.Water ? 0.05f : 0f;
        }
    }
}