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
	public class UndeadWyrmTail : ModNPC
	{
		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undead Wyrm");
		}*/

		public override void SetDefaults()
		{
            NPC.lifeMax = 1;
            NPC.damage = 65;
            NPC.defense = 30;
            NPC.width = 30;
            NPC.height = 62;
            NPC.noTileCollide = true;
            NPC.behindTiles = true;
            NPC.friendly = false;
            NPC.noGravity = true;
            NPC.aiStyle = 6;
            NPC.dontTakeDamage = false;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.buffImmune[24] = true;
            NPC.buffImmune[67] = true;
            NPC.lavaImmune = true;
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}

		public override void AI()
		{
			if (!Main.npc[(int)NPC.ai[1]].active)
			{
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
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