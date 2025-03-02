using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class HallowSlimer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hallow Slimer");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 200;
			NPC.damage = 25;
			NPC.defense = 20;
			NPC.knockBackResist = 0.5f;
			NPC.width = 40;
			NPC.height = 40;
			AnimationType = 121;
			NPC.aiStyle = 14;
			NPC.noGravity = true;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 5, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<HallowSlimerBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                if (Main.netMode != NetmodeID.MultiplayerClient)
                    NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X, (int)NPC.position.Y - 48, NPCID.IlluminantSlime);
            }
		}

		public override void AI()
		{
			Lighting.AddLight((int)NPC.position.X / 16, (int)NPC.position.Y / 16, 0.3f, 0f, 0.2f);

			for (int i = NPC.oldPos.Length - 1; i > 0; i--)
				NPC.oldPos[i] = NPC.oldPos[i - 1];
			NPC.oldPos[0] = NPC.position;
		}

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Vector2 drawOrigin = new Vector2(TextureAssets.Npc[NPC.type].Value.Width, TextureAssets.Npc[NPC.type].Value.Height * 0.8f);
            for (int k = 0; k < NPC.oldPos.Length; k++)
            {
                SpriteEffects effect = NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                Color color = NPC.GetAlpha(drawColor) * ((NPC.oldPos.Length - k) / (float)NPC.oldPos.Length);
                Rectangle frame = new Rectangle(0, 0, 90, 42);
                frame.Y += 164 * (k / 60);

                spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.oldPos[k] - Main.screenPosition, frame, color, 0, Vector2.Zero, NPC.scale, effect, 1f);
            }
            return true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.Player.ZoneHallow && spawnInfo.SpawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}