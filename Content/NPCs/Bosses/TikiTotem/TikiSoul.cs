using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs.Bosses.TikiTotem
{
	public class TikiSoul : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tiki Soul");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 600;
			NPC.damage = 12;
			NPC.defense = 0;
			NPC.knockBackResist = 0f;
			NPC.width = 28;
			NPC.height = 34;
			NPC.aiStyle = -1;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit31;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 15, 0);
			NPCID.Sets.TrailCacheLength[NPC.type] = 5;
		}

		int ShootRate = 4;
		int TimeToShoot = 4;
		public override bool PreAI()
		{
			bool expertMode = Main.expertMode;
			NPC.TargetClosest(true);
			Vector2 direction = Main.player[NPC.target].Center - NPC.Center;
			direction.Normalize();
			direction *= 9f;
			Player player = Main.player[NPC.target];
			NPC parent = Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("TikiTotem").Type)];
			double deg = (double)NPC.ai[1] / 2;
			double rad = deg * (Math.PI / 150);
			double dist = 240;
			NPC.position.X = parent.Center.X - (int)(Math.Cos(rad) * dist) - NPC.width / 2;
			NPC.position.Y = parent.Center.Y - (int)(Math.Sin(rad) * dist) - NPC.height / 2;
			NPC.ai[1] += 2f;
			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				NPC parent2 = Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("TikiTotem").Type)];
				Vector2 Velocity = Helper.VelocityToPoint(NPC.Center, parent2.Center, 20);
				//int k = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("TikiSoulPro"), 0, 1f);
				//Main.projectile[k].friendly = false;
				//Main.projectile[k].tileCollide = false;
				//Main.projectile[k].hostile = true;
			}
			return false;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			Texture2D drawTexture = TextureAssets.Npc[NPC.type].Value;
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[NPC.type]) * 0.5F);

			Vector2 drawPos = new Vector2(
				NPC.position.X - Main.screenPosition.X + (NPC.width / 2) - (TextureAssets.Npc[NPC.type].Value.Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
				NPC.position.Y - Main.screenPosition.Y + NPC.height - TextureAssets.Npc[NPC.type].Value.Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY);

			SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, NPC.frame, Color.White, NPC.rotation, origin, NPC.scale, effects, 0);

			return false;
		}
	}
}