using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.CogLord;

namespace TremorMod.Content.NPCs.Bosses.CogLord
{
    public class CogLordArmSecond : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;
        }

        //Int variables
        private int _animationRate = 6;

        private int _currentFrame;
        private int _timeToAnimation = 6;

        //Float variables
        //private float _dist = 150;

        public override void SetDefaults()
        {
            NPC.lifeMax = 1;
            NPC.knockBackResist = 0.5f;
            NPC.width = 112;
            NPC.height = 34;
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
                NPC.frame = GetFrame(_currentFrame);  // Используем npc.frame, так как это поле объекта
            }

            // Проверяем активность и тип NPC
            if ((Main.npc[(int)NPC.ai[0]].type == ModContent.NPCType<CogLordGun>() ||
                 Main.npc[(int)NPC.ai[0]].type == ModContent.NPCType<CogLordHand>()) &&
                 Main.npc[(int)NPC.ai[0]].active)
            {
                Vector2 centerPoint1 = Vector2.Lerp(Main.npc[(int)NPC.ai[3]].Center, Main.npc[(int)NPC.ai[0]].Center, 0.5f);
                Vector2 centerPoint2 = Vector2.Lerp(centerPoint1, Main.npc[(int)NPC.ai[0]].Center, 0.5f);

                NPC.Center = centerPoint2;
                NPC.rotation = (Main.npc[(int)NPC.ai[3]].Center - Main.npc[(int)NPC.ai[0]].Center).ToRotation();

                // Обработка направления спрайта
                if (NPC.ai[1] == 0)
                    NPC.spriteDirection = -1;
                else
                    NPC.spriteDirection = 1;
            }
            else
            {
                NPC.life = -1;  // Удаляем NPC, если условия не выполняются
            }
        }

        private Rectangle GetFrame(int number)
        {
            return new Rectangle(0, NPC.frame.Height * (number - 1), NPC.frame.Width, NPC.frame.Height);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D drawTexture = Terraria.GameContent.TextureAssets.Npc[NPC.type].Value;
            Vector2 origin = new Vector2(drawTexture.Width * 0.5f, drawTexture.Height / Main.npcFrameCount[NPC.type] * 0.5f);
            Vector2 drawPos = NPC.Center - screenPos;

            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, drawColor, NPC.rotation, origin, NPC.scale, effects, 0f);

            return false; // Возвращаем false, чтобы отменить стандартную отрисовку
        }



        public static class Helper
        {
            // Функция для нахождения средней точки между двумя векторами
            public static Vector2 CenterPoint(Vector2 point1, Vector2 point2)
            {
                return (point1 + point2) / 2;
            }

            // Функция для нахождения угла между двумя точками
            public static float RotateBetween2Points(Vector2 point1, Vector2 point2)
            {
                return (point2 - point1).ToRotation();
            }
        }

        


    }
}