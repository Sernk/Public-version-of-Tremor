using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.NPCs.Bosses.WallofShadows // не ясно как корректно реализовать
{
    public class ShadowHand : ModNPC
    {
        public int wallOfShadowIndex = -1;
        //private Player targetPlayer;
        private int respawnTimer = 0;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 30;
            NPC.damage = 60;
            NPC.defense = 25;
            NPC.lifeMax = 780;
            NPC.knockBackResist = 0.8f;
            NPC.noGravity = true;
            NPC.behindTiles = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit9;
            NPC.DeathSound = SoundID.NPCDeath11;
            NPC.aiStyle = 2;
        }

        public override void AI()
        {
            if (wallOfShadowIndex == -1)
            {
                FindWallOfShadow();
            }

            if (wallOfShadowIndex != -1 && Main.npc[wallOfShadowIndex].active)
            {
                
            }
            else
            {
                NPC.active = false;
            }
            if (!NPC.active)
            {
                respawnTimer++;
                if (respawnTimer >= 480)
                {
                    respawnTimer = 0;
                }
            }
        }

        private void FindWallOfShadow()
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].type == ModContent.NPCType<WallOfShadow>() && Main.npc[i].active)
                {
                    wallOfShadowIndex = i;
                    break;
                }
            }
        }

        

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 15)
            {
                NPC.frame.Y = (NPC.frame.Y + frameHeight) % (Main.npcFrameCount[NPC.type] * frameHeight);
                NPC.frameCounter = 0;
            }

            NPC.spriteDirection = -NPC.direction;
        }
    }
}
