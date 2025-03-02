using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.NPCs.Bosses.CogLord;
using Terraria.DataStructures;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs.Bosses.CogLord
{
    public class CogLordArm : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2; // Устанавливаем количество кадров
        }

        // Int variables
        private int _animationRate = 6;
        private int _timeToAnimation = 6;
        private int _currentFrame;

        // Float variables
        //private float _dist = 150;

        public override void SetDefaults()
        {
            NPC.lifeMax = 1;
            NPC.knockBackResist = 0.5f;
            NPC.width = 104;
            NPC.height = 38;
            NPC.aiStyle = 0;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.dontTakeDamage = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 0, 5, 0);
        }

        public override void AI()
        {
            if (--_timeToAnimation <= 0)
            {
                if (++_currentFrame > 2)
                    _currentFrame = 1;
                _timeToAnimation = _animationRate;
                NPC.frame = GetFrame(_currentFrame);
            }

            if (Main.npc[(int)NPC.ai[0]].type == ModContent.NPCType<CogLordArmSecond>() && Main.npc[(int)NPC.ai[0]].active)
            {
                NPC.Center = Helper.CenterPoint(Main.npc[(int)NPC.ai[3]].Center, Main.npc[(int)NPC.ai[0]].Center);
                NPC.rotation = Helper.RotateBetween2Points(Main.npc[(int)NPC.ai[3]].Center, Main.npc[(int)NPC.ai[0]].Center);
                NPC.spriteDirection = NPC.ai[1] == 0 ? -1 : 1;
            }
            else
            {
                NPC.life = -1;
            }
        }

        private Rectangle GetFrame(int number)
        {
            return new Rectangle(0, NPC.frame.Height * (number - 1), NPC.frame.Width, NPC.frame.Height);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            // Используем TextureAssets.Npc для получения текстуры
            Texture2D drawTexture = Terraria.GameContent.TextureAssets.Npc[NPC.type].Value;

            Vector2 origin = new Vector2(drawTexture.Width * 0.5f, drawTexture.Height / Main.npcFrameCount[NPC.type] * 0.5f);
            Vector2 drawPos = NPC.Center - screenPos;

            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, drawColor, NPC.rotation, origin, NPC.scale, effects, 0f);

            return false; // Отменяем стандартную отрисовку
        }
    }
}
