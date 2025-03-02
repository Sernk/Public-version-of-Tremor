using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content;
using TremorMod.Content.NPCs.Bosses.CogLord;
using Terraria.DataStructures;
using Terraria.GameContent;


namespace TremorMod.Content.NPCs.Bosses.CogLord
{
    public class CogLordHand : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Cog Lord Hand");
            Main.npcFrameCount[NPC.type] = 2; // Укажите количество кадров
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 20000;
            NPC.damage = 80;
            NPC.defense = 20;
            NPC.knockBackResist = 0f;
            NPC.width = 44;
            NPC.height = 84;
            NPC.aiStyle = 12;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = Item.buyPrice(0, 0, 5, 0);
        }

        private const float MaxDist = 250f;
        private bool _firstAi = true;
        private int _timer;

        public override void AI()
        {
            _timer++;
            if (_firstAi)
            {
                _firstAi = false;
                MakeArms();
            }

            if (NPC.AnyNPCs(ModContent.NPCType<CogLordProbe>()))
            {
                NPC.dontTakeDamage = true;
            }
            else
            {
                NPC.dontTakeDamage = false;
            }

            if (_timer < 1000)
            {
                NPC.frame = GetFrame(1);
                NPC.damage = 80;
            }
            else if (_timer >= 1000 && _timer < 1500)
            {
                NPC.frame = GetFrame(2);
                NPC.dontTakeDamage = true;
                NPC.damage = 120;
            }
            else if (_timer > 1500)
            {
                _timer = 0;
            }

            Vector2 cogLordCenter = Main.npc[(int)NPC.ai[1]].Center;
            Vector2 distance = NPC.Center - cogLordCenter;
            if (distance.Length() >= MaxDist)
            {
                distance.Normalize();
                distance *= MaxDist;
                NPC.Center = cogLordCenter + distance;
            }
        }

        private Rectangle GetFrame(int number)
        {
            return new Rectangle(0, NPC.frame.Height * (number - 1), NPC.frame.Width, NPC.frame.Height);
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D drawTexture = TextureAssets.Npc[NPC.type].Value;
            Vector2 origin = new Vector2(drawTexture.Width / 2f, drawTexture.Height / Main.npcFrameCount[NPC.type] / 2f);
            Vector2 drawPos = new Vector2(
                NPC.position.X - screenPos.X + (NPC.width / 2) - (drawTexture.Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
                NPC.position.Y - screenPos.Y + NPC.height - drawTexture.Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY
            );
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, Color.White, NPC.rotation, origin, NPC.scale, effects, 0f);
        }

        private void MakeArms()
        {
            IEntitySource source = NPC.GetSource_FromAI();
            int arm = NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CogLordArm>(), 0, 9999, 1, 1, NPC.ai[1]);
            int arm2 = NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CogLordArmSecond>(), 0, NPC.whoAmI, 0, 1, arm);

            Main.npc[arm].ai[0] = arm2;
        }
    }
}