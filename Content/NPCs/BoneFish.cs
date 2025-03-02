using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class BoneFish : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bone Fish");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 40;
			NPC.damage = 28;
			NPC.defense = 6;
			NPC.knockBackResist = 0.3f;
			NPC.width = 38;
			NPC.height = 26;
			AnimationType = 241;
			NPC.aiStyle = 16;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 0, 3);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("BoneFishBanner");
			NPCID.Sets.TrailCacheLength[NPC.type] = 5;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Bone, 1));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Vector2 drawOrigin = new Vector2(TextureAssets.Npc[NPC.type].Value.Width, TextureAssets.Npc[NPC.type].Value.Height * 0.8f);
            for (int k = 0; k < NPC.oldPos.Length; k++)
            {
                SpriteEffects effect = NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                Color color = NPC.GetAlpha(drawColor) * ((NPC.oldPos.Length - k) / (float)NPC.oldPos.Length);
                Rectangle frame = new Rectangle(0, 164 * (k / 60), 38, 26);

                spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.oldPos[k] - Main.screenPosition, frame, color, 0, Vector2.Zero, NPC.scale, effect, 1f);
            }
            return true;
        }

		public override void AI()
		{
			for (int i = NPC.oldPos.Length - 1; i > 0; i--)
				NPC.oldPos[i] = NPC.oldPos[i - 1];
			NPC.oldPos[0] = NPC.position;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BoneFishGore").Type, 1f);
            }
		}
	}
}