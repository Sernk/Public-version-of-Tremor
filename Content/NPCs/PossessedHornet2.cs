using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Dusts;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
    public class PossessedHornet2 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Possessed Hornet");
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 1500;
            NPC.noGravity = true;
            NPC.damage = 132;
            NPC.defense = 68;
            NPC.knockBackResist = 0.05f;
            NPC.width = 32;
            NPC.height = 40;
            AnimationType = 176;
            NPC.aiStyle = 5;
            AIType = 176;
            NPC.npcSlots = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath44;
            NPC.value = Item.buyPrice(0, 0, 10, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<PossessedHornetBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;

        }

        public override void OnKill()
        {
            if (Main.rand.NextBool())
            {
                int amount = Main.rand.Next(1, 2);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<CarbonSteel>(), amount);
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<NightmareFlame>(), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PHGore1"), 1f);
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PHGore2"), 1f);
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PHGore4"), 1f);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
           => Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.Player.ZoneJungle && NPC.downedMoonlord && Main.hardMode && spawnInfo.SpawnTileY > Main.rockLayer ? 0.01f : 0f;
    }
}