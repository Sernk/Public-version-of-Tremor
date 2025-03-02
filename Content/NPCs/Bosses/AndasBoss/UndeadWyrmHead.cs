using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Filters = Terraria.Graphics.Effects.Filters;

namespace TremorMod.Content.NPCs.Bosses.AndasBoss
{
	public class UndeadWyrmHead : ModNPC
	{

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undead Wyrm");
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
			NPC.lifeMax = 8000;
            NPC.damage = 75;
            NPC.defense = 50;
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
            NPC.position += NPC.velocity * (2 - 1);

            if (!TailSpawned)
            {
                int previous = NPC.whoAmI;
                for (int num36 = 0; num36 < 10; num36++)
                {
                    int newNpcId = 0;

                    // Получаем источник для создания NPC
                    IEntitySource source = NPC.GetSource_FromAI();

                    if (num36 >= 0 && num36 < 9)
                    {
                        newNpcId = NPC.NewNPC(source, (int)NPC.position.X + (NPC.width / 2), (int)NPC.position.Y + (NPC.width / 2), ModContent.NPCType<UndeadWyrmBody>());
                    }
                    else
                    {
                        newNpcId = NPC.NewNPC(source, (int)NPC.position.X + (NPC.width / 2), (int)NPC.position.Y + (NPC.width / 2), ModContent.NPCType<UndeadWyrmTail>());
                    }

                    // Ссылка на новый NPC
                    NPC newNpc = Main.npc[newNpcId];
                    newNpc.realLife = NPC.whoAmI;
                    newNpc.ai[2] = NPC.whoAmI;
                    newNpc.ai[1] = previous;
                    Main.npc[previous].ai[0] = newNpcId;

                    // Отправка данных для сетевой синхронизации (если необходимо)
                    //NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, newNpcId);

                    previous = newNpcId;
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

		/*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);

			Vector2 drawPos = new Vector2(
				npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
				npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);

			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);

			return false;
		}*/
	}
}