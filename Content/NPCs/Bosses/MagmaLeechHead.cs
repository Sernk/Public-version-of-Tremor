using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace TremorMod.Content.NPCs.Bosses
{
	public class MagmaLeechHead : ModNPC
	{
		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Leech");
		}*/

		bool TailSpawned;

		public static int ShootRate = 20;
		const int ShootDamage = 58;
		const float ShootKN = 1.0f;
		const int ShootType = 100;
		const float ShootSpeed = 10;
		const int ShootCount = 5;
		const int spread = 2;
		const float spreadMult = 0.045f;

		const int ShootSound = 62;
		const int ShootSoundStyle = 1;

		int TimeToShoot = ShootRate;
		public override void SetDefaults()
		{
			NPC.lifeMax = 250;
            NPC.damage = 15;
            NPC.defense = 10;
            NPC.knockBackResist = 0f;
            NPC.width = 74;
            NPC.height = 82;
            NPC.aiStyle = 6;
            NPC.npcSlots = 1f;
            NPC.noTileCollide = true;
            NPC.behindTiles = true;
            NPC.friendly = false;
            NPC.dontTakeDamage = false;
            NPC.noGravity = true;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.buffImmune[24] = true;
            NPC.buffImmune[67] = true;
            NPC.lavaImmune = true;
		}

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 0f, 0f, 200, NPC.color, 1f);
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 0f, 0f, 200, NPC.color, 1f);
            }

            NPC.position += NPC.velocity;

            if (!TailSpawned && Main.netMode != 1)
            {
                int Previous = NPC.whoAmI;
                for (int i = 0; i < 14; i++)
                {
                    int newNPCIndex = 0;
                    var source = NPC.GetSource_FromAI(); // Получение источника создания NPC

                    if (i < 13)
                        newNPCIndex = NPC.NewNPC(source, (int)NPC.position.X + (NPC.width / 2), (int)NPC.position.Y + (NPC.width / 2), ModContent.NPCType<MagmaLeechBody>(), NPC.whoAmI);
                    else
                        newNPCIndex = NPC.NewNPC(source, (int)NPC.position.X + (NPC.width / 2), (int)NPC.position.Y + (NPC.width / 2), ModContent.NPCType<MagmaLeechTail>(), NPC.whoAmI);

                    Main.npc[newNPCIndex].realLife = NPC.whoAmI;
                    Main.npc[newNPCIndex].ai[2] = NPC.whoAmI;
                    Main.npc[newNPCIndex].ai[1] = Previous;
                    Main.npc[Previous].ai[0] = newNPCIndex;


                    NetMessage.SendData(23, -1, -1, null, newNPCIndex, 0f, 0f, 0f, 0, 0, 0);
                    Previous = newNPCIndex;
                }
                TailSpawned = true;
            }

            if ((int)(Main.time % 180) == 0)
            {
                Vector2 vector = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
                float birdRotation = (float)Math.Atan2(vector.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                NPC.velocity.X = (float)(Math.Cos(birdRotation) * 7) * -1;
                NPC.velocity.Y = (float)(Math.Sin(birdRotation) * 7) * -1;
                NPC.netUpdate = true;
            }
        }


        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.NextBool())
            {
                target.AddBuff(BuffID.OnFire, 180);
            }
        }

        /*public override bool PreDraw(ref Color drawColor)
        {
            // Получаем текстуру NPC
            Texture2D drawTexture = ModContent.Request<Texture2D>(NPC.Texture).Value;

            // Определяем точку для отрисовки (центр)
            Vector2 origin = new Vector2((drawTexture.Width / 2), (drawTexture.Height / Main.npcFrameCount[NPC.type]) * 0.5f);

            // Позиция для отрисовки
            Vector2 drawPos = NPC.Center - Main.screenPosition + new Vector2(0f, NPC.gfxOffY);

            // Эффекты для отрисовки в зависимости от направления NPC
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            // Отрисовываем NPC
            Main.spriteBatch.Draw(drawTexture, drawPos, NPC.frame, drawColor, NPC.rotation, origin, NPC.scale, effects, 0f);

            // Отключаем стандартный рендеринг
            return false;
        }*/

    }
}