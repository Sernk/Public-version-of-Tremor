using System;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
    public class Banshee : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.DesertLamiaLight];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);

            Main.npcFrameCount[Type] = 9; // ”казываем количество кадров
        }

        public override void SetDefaults()
        {
            NPC.width = 50;
            NPC.height = 62;
            NPC.damage = 21;
            NPC.defense = 10;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.value = Item.buyPrice(0, 0, 5, 7);
            NPC.knockBackResist = 0.3f;
            NPC.aiStyle = 3;
            AnimationType = 529;
            NPC.buffImmune[20] = true;
            NPC.buffImmune[31] = false;
            NPC.buffImmune[24] = true;
            
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<BansheeBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50; // 50 убийств дл€ баннера
        }

       public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 16) // —корость анимации
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
                {
                    NPC.frame.Y = 0; // —брасываем анимацию на первый кадр
                }
            }
        }


        public override void AI()
        {
            if (Main.rand.Next(500) == 0)
                SoundEngine.PlaySound(SoundID.Item1, NPC.position); 
            if (Main.rand.Next(500) == 0)
                SoundEngine.PlaySound(SoundID.Item2, NPC.position);  
            if (Main.rand.Next(500) == 0)
                SoundEngine.PlaySound(SoundID.Item3, NPC.position); 

            for (int i = NPC.oldPos.Length - 1; i > 0; i--)
            {
                NPC.oldPos[i] = NPC.oldPos[i - 1];
            }
            NPC.oldPos[0] = NPC.position;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            for (int k = 0; k < NPC.oldPos.Length; k++)
            {
                SpriteEffects effect = NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                Color color = NPC.GetAlpha(drawColor) * ((NPC.oldPos.Length - k) / (float)NPC.oldPos.Length);
                Rectangle frame = new Rectangle(0, NPC.frame.Y, 50, 62);

                Vector2 shadowOffset = new Vector2(-4, 4); 
                spriteBatch.Draw(
                    TextureAssets.Npc[NPC.type].Value,
                    NPC.oldPos[k] - screenPos + shadowOffset, 
                    frame,
                    Color.Black * 0.3f, 
                    0,
                    Vector2.Zero,
                    NPC.scale * 0.9f, 
                    effect,
                    0
                );

                spriteBatch.Draw(
                    TextureAssets.Npc[NPC.type].Value,
                    NPC.oldPos[k] - screenPos, 
                    frame,
                    color,
                    0,
                    Vector2.Zero,
                    NPC.scale,
                    effect,
                    0
                );
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Sapphire, 7));
            npcLoot.Add(ItemDropRule.Common(ItemID.Ruby, 7));
            npcLoot.Add(ItemDropRule.Common(ItemID.Topaz, 7));
            npcLoot.Add(ItemDropRule.Common(ItemID.Amethyst, 7));
            npcLoot.Add(ItemDropRule.Common(ItemID.Diamond, 7));
            npcLoot.Add(ItemDropRule.Common(ItemID.Emerald, 7));
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                int hitDirection = hit.HitDirection;

                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
        }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneSnow && spawnInfo.Player.ZoneRockLayerHeight)
            {
                return 0.01f; 
            }
            return 0f; 
        }

    }
}
