using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
    public class FlyingLeech : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Flying Leech");
            Terraria.Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 80;
            NPC.damage = 20;
            NPC.defense = 10;
            NPC.knockBackResist = 0.5f;
            NPC.width = 74;
            NPC.height = 42;
            AnimationType = 2;
            NPC.aiStyle = 2;
            NPC.noGravity = true;
            NPC.npcSlots = 1f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Terraria.Item.buyPrice(0, 0, 32, 20);
            // banner = npc.type;
            // Todo: bannerItem = mod.ItemType("FlyingLeechBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
            => Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && Terraria.NPC.downedBoss2 && spawnInfo.Player.ZoneCrimson && spawnInfo.SpawnTileY < Terraria.Main.worldSurface ? 0.02f : 0;
    }
}
