using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content;
using TremorMod.Content.Projectiles;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs.Bosses.CogLord
{
	public class CogLordProbe : ModNPC
	{
		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Probe");
		}*/

		public override void SetDefaults()
		{
            NPC.lifeMax = 4500;
            NPC.damage = 250;
            NPC.defense = 10;
            NPC.knockBackResist = 0f;
            NPC.width = 42;
            NPC.height = 42;
            NPC.aiStyle = 14;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath10;
            NPC.value = Item.buyPrice(0, 1, 0, 0);
		}

		private int _shootRate = 4;
		private int _timeToShoot = 4;

        public override void AI()
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<CogLord>()))
            {
                NPC.active = false;
                return;
            }

            NPC.position += NPC.velocity * 1.7f;
            NPC.rotation = Helper.RotateBetween2Points(NPC.Center, Main.npc[(int)NPC.ai[0]].Center);

            while (NPC.Distance(Main.npc[(int)NPC.ai[0]].position) > 1000)
            {
                NPC.Center = Main.npc[(int)NPC.ai[0]].Center;
            }

            if (--_timeToShoot <= 0)
            {
                _timeToShoot = _shootRate;
                NPC parent = Main.npc[NPC.FindFirstNPC(ModContent.NPCType<CogLord>())];
                Vector2 velocity = Helper.VelocityToPoint(NPC.Center, parent.Center, 20);
                int k = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity, ModContent.ProjectileType<CogLordLaser>(), 100, 1f);
                Main.projectile[k].friendly = false;
                Main.projectile[k].tileCollide = false;
                Main.projectile[k].hostile = true;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            // Получаем текстуру NPC
            Texture2D drawTexture = ModContent.Request<Texture2D>(Texture).Value;

            Vector2 origin = new Vector2(
                drawTexture.Width / 2,
                drawTexture.Height / Main.npcFrameCount[NPC.type] / 2
            );

            Vector2 drawPos = new Vector2(
                NPC.position.X - screenPos.X + (NPC.width / 2) - (drawTexture.Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
                NPC.position.Y - screenPos.Y + NPC.height - drawTexture.Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY
            );

            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, drawColor, NPC.rotation, origin, NPC.scale, effects, 0f);
            return false;
        }
    }
}