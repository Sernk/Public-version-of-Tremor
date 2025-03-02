using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class HarpyWarrior : ModNPC
	{
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Harpy];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);

            Main.npcFrameCount[Type] = 4; // Указываем количество кадров
        }

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harpy Warrior");
			Main.npcFrameCount[npc.type] = 4;
		}*/

		public override void SetDefaults()
		{
            NPC.lifeMax = 300;
            NPC.damage = 90;
            NPC.defense = 17;
            NPC.knockBackResist = 0.3f;
            NPC.width = 80;
            NPC.height = 60;
			AnimationType = 48;
            NPC.aiStyle = 3;
            NPC.value = 40f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.noGravity = true;
            NPC.DeathSound = SoundID.NPCDeath4;
			NPC.value = Item.buyPrice(0, 0, 8, 9);

			Banner = NPC.type;
            BannerItem = ModContent.ItemType<HarpyWarriorBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50; // 50 убийств для баннера
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                int hitDirection = NPC.direction;  // Используем direction NPC, чтобы определить направление

                for (int k = 0; k < 20; k++)
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HarpyGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HarpyGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HarpyGore2").Type, 1f);
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
                new FlavorTextBestiaryInfoElement("An Harpy Warrior that prowls the Sky.")
            });
        }

        public override void OnKill()
        {
            if (Main.rand.NextFloat() < 0.02f) // 2% шанс
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.GiantHarpyFeather);
            }

            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Feather);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && spawnInfo.Player.ZoneSkyHeight ? 0.01f : 0f;
        }

    }
}